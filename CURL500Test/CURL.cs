﻿using NLog;
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
            SetupTest();
        }

        public async Task SetupTest()
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
                WriteToLog(string.Format("-> Load {0} fiber sample", fiber.fiberId.Trim()));
                WriteToStatus("Waiting for curl test to complete");
                Subscribe();
            }
            else
            {
                WriteToLog("Test set not communicating. Check that the test set is connected and that you are using the correct COM port.");
                closeBtn.Visible = true;
                closeBtn.Focus();
            }
                       
        }

        /// <summary>
        /// Not used for CURL500
        /// </summary>
        private void watch()
        {
            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = string.Format("{0}*.txt", fiber.fiberId.Trim());
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        private void DisplayResults()
        {
            if (fiber.results.curlResults.successful)
            {
                WriteToStatus("Success!");
            }
            else
            {
                WriteToStatus("Uh oh!");
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

        private void ExtractResultFromTxtFile(string filePath)
        {
            WriteToStatus("Attempting to extract results...");

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    if (line.Contains("Status"))
                    {
                        fiber.results.curlResults.successful = line.Split(':')[1].Trim() == "Successful" ? true : false;
                    }
                    if (line.Contains("Radius"))
                    {
                        fiber.results.curlResults.ISEradius = line.Split(':')[1].Trim();
                    }
                    if (line.Contains("Delta"))
                    {
                        fiber.results.curlResults.delta = line.Split(':')[1].Trim();
                    }
                    if (line.Contains("Amplitude"))
                    {
                        fiber.results.curlResults.amplitude = line.Split(':')[1];
                    }
                    if (line.Contains("Offset"))
                    {
                        fiber.results.curlResults.offset = line.Split(':')[1];
                    }
                    if (line.Contains("Phase"))
                    {
                        fiber.results.curlResults.phase = line.Split(':')[1];
                    }
                }
            }
            catch (Exception)
            {
                WriteToStatus("Error getting results from text file");
                throw;
            }
            WriteToStatus("Results extracted");
        }

        private void CreateBeforeFile(string fiberId)
        {
            //Create ini file in the following format shown in the manual
            ///[FiberData]
            ///Identifier=Sample Identifier
            ///Remark=Sample Remark

            //Write to the file
            for (int i = 1; i < numberOfRetries; ++i)
            {
                try
                {
                    bool result = IniFileHelper.WriteValue("FiberData", "Identifier", fiber.fiberId, prodbeforeFile);
                    result = IniFileHelper.WriteValue("FiberData", "Remark", fiber.serialId, prodbeforeFile);
                }
                catch (IOException e)
                {
                    if (i == numberOfRetries)
                        throw;

                    Console.WriteLine(e);

                    Thread.Sleep(delayOnRetry);
                }
            }
        }

        public void WriteToLog(string str)
        {
            curlLog.AppendText(str + Environment.NewLine);
            logger.Info(str);
        }

        public void WriteToLog(List<string> strs)
        {
            foreach (var str in strs)
            {
                WriteToLog(str);
            }
        }

        public void WriteToLog(string str, bool clear)
        {
            if (clear) curlLog.Clear();
            WriteToLog(str);
        }

        public void WriteToStatus(string str)
        {
            curlStatusLabel.Text = str;
        }

        private async Task RunTest()
        {
            if(await SendFiberData(fiber.fiberId))
            {
                WriteToLog("Fiber ID sent to test set");
            }
            var gotResults = await GetResultData();
            if (!gotResults)
            {
                SetupTest();
                return;
            }
            
            if (EvaluateResultData())
            {
                await SendCurlResultToPTS();
                if (fiber.CheckIfTestRequired(testSet))
                {
                    if (fiber.CheckFiberNeedsRemeasure(testSet))
                    {
                        WriteToLog(string.Format("-> Remeasure fiber: {0}", fiber.fiberId), true);
                        if (fiber.isReferenceFiber())
                        {
                            fiber.referenceTries++;
                            if (fiber.referenceTries > 3) WriteToLog("The reference fiber is failing, contact engineering");
                        }
                        SetupTest();
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
                SetupTest();
                return;
            }
        }

        private async Task SendCurlResultToPTS()
        {
            PTStransaction pts = new PTStransaction();
            pts.PTSMessageSending += OnPTSMessageSending;
            pts.PTSMessageReceived += OnPTSMessageReceived;

            try
            {
                WriteToLog("Sending results to PTS");
                var newPTSReturn = await pts.sendCurlResultAsync(fiber, testSet);
                WriteToStatus("Results Sent!");
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
                        WriteToLog("-> There was a problem with the result value. Please try the test again");
                        return false;
                    }
        }

        public async Task<bool> GetResultData()
        {
            WriteToLog("Testing curl...");
            logger.Debug("Testing curl on {0}", testSet.portNumber);

            var measStatus = await testSet.port.Measure();
            if (measStatus.Contains("OK"))
            {
                setResponse = await testSet.port.ReadPort();
                logger.Debug("setResponse: {0}", setResponse);
                int setStatus = -1;

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
                WriteToLog("Curl test failed. Try remeasuring.");
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
                    WriteToLog("System ready but no results in memory. Test failed.", true);
                    break;
                case (12):
                    WriteToLog("Measurement aborted, or error. No valid data", true);
                    break;
                default:
                    WriteToLog("Problem with set not returning value. Try restarting", true);
                    break;
            }
        }

        private async Task<bool> ProcessResultData()
        {
            WriteToLog("Test finished. Retrieving result.");
            var value = await testSet.port.ReadResult();
            var errors = ProcessPEReturn(await testSet.port.CheckForTestErrors());
            string processedValue = ProcessPEReturn(value);
            int errorNumber = -1;
            int.TryParse(errors, out errorNumber);

            fiber.results.curlResults.ISEradius = processedValue;
            fiber.results.curlResults.successful = errorNumber < testErrorLimit;
            WriteToLog(string.Format("Test complete with radius: {0}m", processedValue));
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

        private bool openPort(PECommunication port)
        {
            if (port.open())
            {
                WriteToLog("Port Open");
                return true;
            }
            else
            {
                WriteToLog("Port failed to open");
                return false;
            }
        }

        private void ProcessPTSReturn(List<string> ptsReturn)
        {
            //TODO This would be a good place to try and use an Event I think. An event could be triggered when ptsreturn is updated to convert it to test entries, and update the test display on Main
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


        private void CheckSetStatus()
        {
            throw new NotImplementedException();
        }


        private void statusResultLabel_TextChanged(object sender, EventArgs e)
        {
            statusResultLabel.BackColor = fiber.results.curlResults.successful ? Color.LawnGreen : Color.IndianRed;
            if (fiber.results.curlResults.successful != true)
            {
                DialogResult remeas = MessageBox.Show("The PE set reported that the test was unsuccessful. Try cleaning the fiber and measuring again.", "Unsuccessful Test", MessageBoxButtons.OKCancel);
                if (remeas == DialogResult.OK)
                {
                    //SetupTest();
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
            //yesButton.Enabled = false;
            await RunTest();
        }

        /// <summary>
        /// Part of the watch() task and won't be used for the CURL500
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!FileIsReady(e.FullPath)) return;
            watcher.EnableRaisingEvents = false;
            WriteToStatus("Text file found");
            ExtractResultFromTxtFile(e.FullPath);
            DisplayResults();
        }

        /// <summary>
        /// This method checks to see if the file that raised the changed event is ready to be accessed. If we get an io exception when trying to access the file, the method
        /// returns false
        /// </summary>
        /// <param name="path"></param>
        /// <returns>bool</returns>
        private bool FileIsReady(string path)
        {
            try
            {
                using (var file = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return true;
                }
            }
            catch (IOException)
            {
                return false;
            }
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
            WriteToStatus("Enter radius from PE results");
            WriteToLog("Enter radius result manually from PE application", true);
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
