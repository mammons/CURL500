using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CURL500Test
{
    public partial class CURL : Form
    {
        public Fiber fiber { get; set; }
        public TestSet testSet { get; set; }
        CurlResult curlResult { get; set; }
        FileSystemWatcher watcher;


        private string prodbeforeFile = AppDomain.CurrentDomain.BaseDirectory + "FiberData.ini";
        private string prodafterFile = AppDomain.CurrentDomain.BaseDirectory + "ResultData.ini";
        private string path = @"C:\CURL400\results";

        private const int numberOfRetries = 5;
        private const int delayOnRetry = 1000;

        private const double gaugeLengthInMeters = 0.01893;

        public bool manualEntry = false;

        public CURL(Fiber fiber, TestSet testSet)
        {
            this.fiber = fiber;
            this.testSet = testSet;
            InitializeComponent();
            BeginTest();
        }

        public void BeginTest()
        {
            yesButton.Visible = false;
            noButton.Visible = false;
            radiusEntryTextbox.Visible = false;
            radiusResultLabel.Visible = true;
            radiusResultLabel.Text = "Waiting...";
            statusResultLabel.TextChanged -= statusResultLabel_TextChanged;
            staticStatusLabel.Visible = true;
            statusResultLabel.Text = "Waiting...";
            statusResultLabel.BackColor = Form.DefaultBackColor;
            statusResultLabel.TextChanged += statusResultLabel_TextChanged;
            WriteToLog(string.Format("-> Perform the Curl test in the PE application on {0}", fiber.fiberId.Trim()));
            WriteToStatus("Waiting for curl test to complete");
            watch();
        }

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
            if (curlResult.successful)
            {
                WriteToStatus("Success!");
            }
            else
            {
                WriteToStatus("Uh oh!");
            }

            if (this.InvokeRequired)
            {
                radiusResultLabel.Invoke((MethodInvoker)(() => radiusResultLabel.Text = curlResult.radius));
            }
            else
            {
                radiusResultLabel.Text = curlResult.radius;
            }
            if (this.InvokeRequired)
            {
                statusResultLabel.Invoke((MethodInvoker)(() => statusResultLabel.Text = curlResult.successful ? "Successful" : "Unsuccessful"));
            }
            else
            {
                statusResultLabel.Text = curlResult.successful ? "Successful" : "Unsuccessful";
            }
            //triggers the statuslabel updated event
        }

        private void ExtractResultFromTxtFile(string filePath)
        {
            WriteToStatus("Attempting to extract results...");
            curlResult = new CurlResult();
            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    if (line.Contains("Status"))
                    {
                        curlResult.successful = line.Split(':')[1].Trim() == "Successful" ? true : false;
                    }
                    if (line.Contains("Radius"))
                    {
                        curlResult.radius = line.Split(':')[1].Trim();
                    }
                    if (line.Contains("Delta"))
                    {
                        curlResult.delta = line.Split(':')[1].Trim();
                    }
                    if (line.Contains("Amplitude"))
                    {
                        curlResult.amplitude = line.Split(':')[1];
                    }
                    if (line.Contains("Offset"))
                    {
                        curlResult.offset = line.Split(':')[1];
                    }
                    if (line.Contains("Phase"))
                    {
                        curlResult.phase = line.Split(':')[1];
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
            curlLog.AppendText(str);
        }

        public void WriteToStatus(string str)
        {
            curlStatusLabel.Text = str;
        }

        private void RunTest()
        {
            GetResultData();
            if (EvaluateResultData())
            {
                SendCurlResultToPTS();
                if (fiber.CheckIfTestRequired(testSet))
                {
                    if (fiber.CheckFiberNeedsRemeasure(testSet))
                    {
                        WriteToLog(string.Format("-> Remeasure fiber: {0}", fiber.fiberId), true);
                        BeginTest();
                        return;
                    }
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                BeginTest();
                return;
            }
        }

        private void SendCurlResultToPTS()
        {
            List<string> newPTSReturn = new List<string>();
            PTStransaction pts = new PTStransaction();
            pts.PTSMessageSending += OnPTSMessageSending;
            newPTSReturn = pts.sendCurlResult(fiber, testSet).ToList();
            WriteToStatus("Results Sent!");
            ProcessPTSReturn(newPTSReturn);
        }

        private bool EvaluateResultData()
        {
            double resultValue = fiber.results.curlISEvalue;
            //check curl result against limits
            if (resultValue > -1)
            {
                if (resultValue < testSet.limits.Fail ||
                    resultValue > testSet.limits.Pass
                    )
                {
                    fiber.results.curlISEresult = "F";
                    fiber.results.curlISEtestcode = fiber.results.curlISEtestcode == "RM" ? "FF" : "RM";
                }
                else
                {
                    fiber.results.curlISEresult = "P";
                    fiber.results.curlISEtestcode = "PP";
                }
                fiber.results.lastTestResult = fiber.results.curlISEresult;
                return true;
            }
            else
            {
                WriteToLog("-> There was a problem with your entry. Please try the test again");
                return false;
            }
        }

        public void GetResultData()
        {
            string value = manualEntry ? radiusEntryTextbox.Text : curlResult.radius.Split(' ')[0];
            calculateOffsetForPTS(value);
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
                fiber.results.curlISEvalue = tempVal * Math.Pow(10, 6);
            }
            else
            {
                fiber.results.curlISEvalue = -1f;
            }
        }

        private void statusResultLabel_TextChanged(object sender, EventArgs e)
        {
            statusResultLabel.BackColor = curlResult.successful ? Color.LawnGreen : Color.IndianRed;
            if (curlResult.successful != true)
            {
                DialogResult remeas = MessageBox.Show("The PE set reported that the test was unsuccessful. Try cleaning the fiber and measuring again.", "Unsuccessful Test", MessageBoxButtons.OKCancel);
                if (remeas == DialogResult.OK)
                {
                    BeginTest();
                    return;
                }
                else
                {
                    Close();
                }
            }
            WriteToLog("Do these results match the PE application results?", true);
            yesButton.Visible = true;
            noButton.Visible = true;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            //yesButton.Enabled = false;
            RunTest();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!FileIsReady(e.FullPath)) return;
            watcher.EnableRaisingEvents = false;
            WriteToStatus("Text file found");
            ExtractResultFromTxtFile(e.FullPath);
            DisplayResults();
        }

        /// <summary>
        /// This method checks to see if the file that raised the changede event is ready to be accessed. If we get an io exception when trying to access the file, the method
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

        public void OnPTSMessageSending(object source, EventArgs args)
        {
            curlStatusLabel.Text = "Communicating with PTS...";
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

        private void okButton_Click(object sender, EventArgs e)
        {
            RunTest();
        }
    }

    public class CurlResult
    {
        public bool successful { get; set; }
        public string radius { get; set; }
        public string delta { get; set; }
        public string amplitude { get; set; }
        public string offset { get; set; }
        public string phase { get; set; }
    }
}
