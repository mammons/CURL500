using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CURL500Test
{
    public partial class CURL : Form
    {
        public Fiber fiber { get; set; }
        public TestSet testSet { get; set; }
        
        FileSystemWatcher watcher;


        private const int numberOfRetries = 5;
        private const int delayOnRetry = 1000;

        private const double gaugeLengthInMeters = 0.01893;

        private Logger logger = LogManager.GetCurrentClassLogger();

        public bool manualEntry = false;

        private string prodbeforeFile = AppDomain.CurrentDomain.BaseDirectory + "FiberData.ini";
        private string prodafterFile = AppDomain.CurrentDomain.BaseDirectory + "ResultData.ini";
        private string path = @"C:\CURL500\results";
        private const int testErrorLimit = 100;

        private string setResponse;


        public CURL(Fiber fiber, TestSet testSet)
        {
            this.fiber = fiber;
            this.testSet = testSet;
            InitializeComponent();
            setupTest();
        }

        public async Task setupTest()
        {
            logger.Debug("Test set available? {0}", testSet.isAvailable.ToString());
            if (testSet.isAvailable)
            {
                yesButton.Visible = false;
                noButton.Visible = false;
                okButton.Visible = true;
                radiusEntryTextbox.Visible = false;
                radiusResultLabel.Visible = true;
                radiusResultLabel.Text = "Waiting...";
                statusResultLabel.TextChanged -= statusResultLabel_TextChanged;
                staticStatusLabel.Visible = true;
                statusResultLabel.Text = "Waiting...";
                statusResultLabel.BackColor = Form.DefaultBackColor;
                statusResultLabel.TextChanged += statusResultLabel_TextChanged;
                writeToLog(string.Format("-> Load {0} fiber sample", fiber.fiberId.Trim()));
                writeToStatus("Waiting for curl test to complete");
                Subscribe();
            }
            else
            {
                writeToLog("Test set not communicating. Check that the test set is connected and that you are using the correct COM port.");
                closeBtn.Visible = true;
                closeBtn.Focus();
            }
                       
        }

        private void displayResults()
        {
            if (fiber.results.curlResults.successful)
            {
                writeToStatus("Success!");
            }
            else
            {
                writeToStatus("Uh oh!");
            }

            if (this.InvokeRequired)
            {
                radiusResultLabel.Invoke((MethodInvoker)(() => radiusResultLabel.Text = fiber.results.curlResults.ISEradius));
            }
            else
            {
                radiusResultLabel.Text = fiber.results.curlResults.ISEradius;
            }
            if (this.InvokeRequired)
            {
                statusResultLabel.Invoke((MethodInvoker)(() => statusResultLabel.Text = fiber.results.curlResults.successful ? "Successful" : "Unsuccessful"));
            }
            else
            {
                statusResultLabel.Text = fiber.results.curlResults.successful ? "Successful" : "Unsuccessful";
            }
            //triggers the statuslabel updated event
        }

        public void writeToLog(string str)
        {
            curlLog.AppendText(str + Environment.NewLine);
            logger.Info(str);
        }

        public void writeToLog(List<string> strs)
        {
            foreach (var str in strs)
            {
                writeToLog(str);
            }
        }

        public void writeToLog(string str, bool clear)
        {
            if (clear) curlLog.Clear();
            writeToLog(str);
        }

        public void writeToStatus(string str)
        {
            curlStatusLabel.Text = str;
        }

        private async Task RunTest()
        {
            if(await SendFiberData(fiber.fiberId))
            {
                writeToLog("Fiber ID sent to test set");
            }
            var gotResults = await GetResultData();
            if (!gotResults)
            {
                setupTest();
                return;
            }
            
            if (EvaluateResultData())
            {
                await sendCurlResultToPTS();
                if (fiber.checkIfTestRequired(testSet))
                {
                    if (fiber.checkFiberNeedsRemeasure(testSet))
                    {
                        writeToLog(string.Format("-> Remeasure fiber: {0}", fiber.fiberId), true);
                        if (fiber.isReferenceFiber())
                        {
                            fiber.referenceTries++;
                            if (fiber.referenceTries > 3) writeToLog("The reference fiber is failing, contact engineering");
                        }
                        setupTest();
                        return;
                    }
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                setupTest();
                return;
            }
        }

        private async Task sendCurlResultToPTS()
        {
            PTStransaction pts = new PTStransaction();
            pts.PTSMessageSending += OnPTSMessageSending;
            pts.PTSMessageReceived += OnPTSMessageReceived;

            try
            {
                writeToLog("Sending results to PTS");
                var newPTSReturn = await pts.sendCurlResultAsync(fiber, testSet);
                writeToStatus("Results Sent!");
                ProcessPTSReturn(newPTSReturn.ToList());
            }
            catch(Exception ex)
            {
                logger.Error(testSet.sessionInfo, "Exception sending curl results to PTS: " + ex);
            }
            return;   
        }


        private bool EvaluateResultData()
        {
            double resultValue = fiber.results.curlResults.ISEvalue;
            //check curl result against limits
                    if (resultValue > -1)
                    {
                        if (resultValue < testSet.limits.Fail ||
                            resultValue > testSet.limits.Pass
                            )
                        {
                            fiber.results.curlResults.ISEresult = "F";
                            fiber.results.curlResults.ISEtestcode = fiber.results.curlResults.ISEtestcode == "RM" ? "FF" : "RM";
                        }
                        else
                        {
                            fiber.results.curlResults.ISEresult = "P";
                            fiber.results.curlResults.ISEtestcode = "PP";
                        }
                        fiber.results.lastTestResult = fiber.results.curlResults.ISEresult;
                        return true;
                    }
                    else
                    {
                        writeToLog("-> There was a problem with the result value. Please try the test again");
                        return false;
                    }
        }

        public async Task<bool> GetResultData()
        {
            writeToLog("Testing curl...");
            logger.Debug("Testing curl on {0}", testSet.portNumber);

            //When sending the MEASURE command, test set returns OK when the command is received, then later returns FINISHED
            var measStatus = await testSet.port.Measure();
            if (measStatus.Contains("OK"))
            {
                //ReadPort will wait for data to be available on the port and put it in the setResponse var
                setResponse = await testSet.port.ReadPort();
                logger.Debug("setResponse: {0}", setResponse);
                int setStatus = -1;

                //Once we get the FINISHED message from the test set we can check the status
                //Statuses:0, 1, 2, 12 are valid. 0 is a failed test, 1 is currently measuring which we shouldn't get, 2 is complete with data in memory, 12 is operator canceled test
                if(setResponse.Contains("FINISHED")) int.TryParse(ProcessPEReturn(await testSet.port.CheckStatus()), out setStatus);
                logger.Debug("Final setStatus: {0}", setStatus);
                if (setStatus == 2) //From PE set means Measurement finished. Results in memory.
                {
                   return await ProcessResultData();
                }
                else
                {
                    DisplayErrorMessage(setStatus);
                    return false;
                }                
            }
            else
            {
                writeToLog("Curl test failed. Try remeasuring.");
                okButton.Visible = true;
                return false;
            }
        }

        public async Task<bool> SendFiberData(string fiberId)
        {
            string response = await testSet.port.SendID(fiberId);
            return response.Contains("OK");
        }

        private void DisplayErrorMessage(int setStatus)
        {
            switch (setStatus)
            {
                case (0):
                    writeToLog("System ready but no results in memory. Test failed.", true);
                    break;
                case (12):
                    writeToLog("Measurement aborted, or error. No valid data", true);
                    break;
                default:
                    writeToLog("Problem with set not returning value. Try restarting", true);
                    break;
            }
        }

        private async Task<bool> ProcessResultData()
        {
            writeToLog("Test finished. Retrieving result.");
            var value = await testSet.port.ReadResult();
            var errors = ProcessPEReturn(await testSet.port.CheckForTestErrors());
            string processedValue = ProcessPEReturn(value);
            int errorNumber = -1;
            int.TryParse(errors, out errorNumber);

            fiber.results.curlResults.ISEradius = processedValue;
            fiber.results.curlResults.successful = errorNumber < testErrorLimit;
            writeToLog(string.Format("Test complete with radius: {0}m", processedValue));
            logger.Info("Number of errors: {0}. If > {1} => Bad Test", errorNumber, testErrorLimit);
            radiusResultLabel.Text = processedValue;
            statusResultLabel.Text = fiber.results.curlResults.successful ? "Successful" : "Failed";
            calculateOffsetForPTS(fiber.results.curlResults.ISEradius);
            return fiber.results.curlResults.successful;
        }

        private string ProcessPEReturn(string inVal)
        {
            string outVal = inVal.Substring(0, inVal.Length-1);

            if (outVal.Contains("FAIL"))
            {
                outVal = "The test did not complete properly";
            }
            outVal = outVal.TrimEnd('\r', '\n', ' ');
            return outVal;
        }


        private void ProcessPTSReturn(List<string> ptsReturn)
        {
            fiber.testList.ptsReturn = ptsReturn;
            fiber.testList.convertReturnToTestEntries();
        }

        //Offset (y) is the value actually stored in PTS. The equation for Radius from y(the max offset at the point of meas) and x(the gauge length) is R=(x^2 + y^2)/2y
        //So here I'm converting the radius value that is measured to our measured offset value for PTS using y = R - sqrt(R^2 - x^2) and converting to microns
        private void calculateOffsetForPTS(string radius)
        {
            float convertedRadiusValue = 0.0f;
            double tempVal = -1;
            if (Single.TryParse(radius, out convertedRadiusValue))
            {
                if (gaugeLengthInMeters < convertedRadiusValue)
                {
                    tempVal = convertedRadiusValue - Math.Sqrt(Math.Pow(convertedRadiusValue, 2) - Math.Pow(gaugeLengthInMeters, 2));
                }
                fiber.results.curlResults.ISEvalue = tempVal * Math.Pow(10, 6);
            }
            else
            {
                fiber.results.curlResults.ISEvalue = -1f;
            }
        }


        private void statusResultLabel_TextChanged(object sender, EventArgs e)
        {
            statusResultLabel.BackColor = fiber.results.curlResults.successful ? Color.LawnGreen : Color.IndianRed;
            if (fiber.results.curlResults.successful != true)
            {
                DialogResult remeas = MessageBox.Show("The PE set reported that the test was unsuccessful. Try cleaning the fiber and measuring again.", "Unsuccessful Test", MessageBoxButtons.OKCancel);
                if (remeas == DialogResult.OK)
                {
                    logger.Info("PE set reported too many errors on test, operator selected to remeasure the fiber");
                    return;
                }
                else
                {
                    Close();
                }
            }
        }

        private async void yesButton_Click(object sender, EventArgs e)
        {
            await RunTest();
        }

        private void Subscribe()
        {
            if (!testSet.subscribedToSerialEvents)
            {
                testSet.port.SerialMessageSending += OnSerialMessageSending;
                testSet.port.SerialMessageReceived += OnSerialMessageReceived;
                testSet.subscribedToSerialEvents = true;
                logger.Debug("Subscribed to serial events");
            }
        }

        public void OnPTSMessageSending(object source, EventArgs args)
        {
            loadingCircle.LoadingCircleControl.Active = true;
            curlStatusLabel.Text = "Communicating with PTS...";
        }

        private void OnPTSMessageReceived(object source, EventArgs args)
        {
            if(!loadingCircle.IsDisposed)
            loadingCircle.LoadingCircleControl.Active = false;
        }

        private void OnSerialMessageReceived(object source, PECommunicationEventArgs args)
        {

                logger.Debug("Serial message received: " + args.response);
                loadingCircle.LoadingCircleControl.Active = false;
        }

        private void OnSerialMessageSending(object source, EventArgs args)
        {
            loadingCircle.LoadingCircleControl.Active = true;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            manualEntry = true;
            yesButton.Visible = false;
            noButton.Visible = false;
            radiusResultLabel.Visible = false;
            statusResultLabel.Visible = false;
            staticStatusLabel.Visible = false;
            okButton.Visible = true;
            radiusEntryTextbox.Visible = true;
            writeToStatus("Enter radius from PE results");
            writeToLog("Enter radius result manually from PE application", true);
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            okButton.Visible = false;
            await RunTest();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
