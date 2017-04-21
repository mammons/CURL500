using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ObjectDumper;
using System.Threading.Tasks;
using NLog;

namespace CURL500Test
{
    public partial class Main : Form
    {
        Login login;
        CmdLineArgs testArgs;
        Operator oper;
        TestSet testSet;
        Fiber fiber = new Fiber();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        string version = "1.0.5";

        ErrorProvider fiberIdErrorProvider = new ErrorProvider();        

        public Main()
        {
            testArgs = new CmdLineArgs();
            oper = new Operator();
            InitializeComponent();
            Show();
            showLogin();
            UpdateCOMMenuItems(testSet.portNumber);
        }



        private void logoffButton_Click(object sender, EventArgs e)
        {
            oper.loggedIn = false;
            updateTextBar();
            WriteToOperator(string.Format("Operator {0} has logged off", oper.name), messageType.NORMAL);
            WriteToStatus(string.Format("{0} logged off", oper.name));
            showLogin();
        }

        /// <summary>
        /// Handles the event when the submit button is clicked. The fiber ID and serial ID should have been validated and this will go out to PTS to retrieve the test list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void submitButton_Click(object sender, EventArgs e)
        {

            AssignIdsToFiber();
            //Get the test list
            try
            {
                var err = await GetTestListAsync();
                if (string.IsNullOrWhiteSpace(err))
                {
                    //Get the limits for the test
                    await GetTestLimitsAsync();
                    //Populate the display with the test list
                    PopulateGridView();
                    //If the test for the current set is required, begin the test
                    if (fiber.CheckIfTestRequired(testSet))
                    {
                        WriteToOperator(string.Format("Running {0} test for {1}", testSet.testName, fiber.fiberId), messageType.NORMAL);
                        PerformTest();
                    }
                    else
                    {
                        WriteToOperator(string.Format("{0} test not required for {1}", testSet.testName, fiber.fiberId), messageType.NORMAL);
                    }
                }
                else
                {
                    WriteToOperator(err, messageType.URGENT);
                }
            }
            catch (Exception ex)
            {
                WriteToLog("Exception in Main.submit : " + ex.Message);
            }
        }

        private void PerformTest()
        {
            Test currentTest = new Test(fiber, testSet);
            currentTest.Run();
            updateOperatorDisplayAfterTest();
            updateTestMapDisplay();
        }

        private void updateOperatorDisplayAfterTest()
        {
            string result = fiber.results.lastTestResult;
            string displayText = "did not complete testing";
            messageType msgtype = messageType.INCOMPLETE;

            if (result == "P")
            {
                displayText = "Passed";
                msgtype = messageType.PASSED;
            }
            else if (result == "F")
            {
                displayText = "Failed";
                msgtype = messageType.FAILED;
            }
            string logMsg = string.Format("Test Result for {3}: Offset(PTS Value):{0}um Radius:{1}m Pass/Fail: {2}", fiber.results.curlResults.ISEvalue.ToString("000.0"), fiber.results.curlResults.ISEradius, fiber.results.curlResults.ISEresult, fiber.fiberId);
            string operMsg = string.Format("Fiber {0}{1}", fiber.fiberId, displayText);
            WriteToOperator(operMsg, msgtype);
            if (fiber.results.lastTestResult != "I")
            {
                WriteToLog(logMsg);
                WriteToResultsBox(logMsg);
            }
            else
            {
                WriteToLog(operMsg);
                WriteToResultsBox(operMsg);
            }
        }

        private void PopulateGridView()
        {
            testListDataGrid.DataSource = fiber.testList.TestEntries;
            updateTestMapDisplay();
        }

        private void fiberIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            string error;
            if (!validFiberId(fiberIdTextBox.Text, out error))
            {
                //cancel the event and select the name so it can be corrected
                e.Cancel = true;
                fiberIdTextBox.Select(0, fiberIdTextBox.Text.Length);

                //set the errorprovider with the error text
                fiberIdErrorProvider.SetError(fiberIdTextBox, error);
            }
        }

        /// <summary>
        /// Validates entered fiber ID by checking the length. The AA condition is just for quick entering
        /// fiber ID for testing
        /// </summary>
        /// <param name="fiberId"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public bool validFiberId(string fiberId, out string errorMessage)
        {
            if (fiberIdTextBox.Text.Length < 12 && fiberIdTextBox.Text.ToUpper() != "AA")
            {
                errorMessage = "Fiber ID must be at least 12 characters";
                WriteToStatus(errorMessage);
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }

        private void fiberIdTextBox_Validated(object sender, EventArgs e)
        {
            fiberIdErrorProvider.SetError(fiberIdTextBox, "");
        }

        /// <summary>
        /// Updates the text on the bar at the top of the form when users log in or out
        /// </summary>
        private void updateTextBar()
        {
            if (oper.loggedIn)
            {
                this.Text = testSet.sessionInfo = string.Format("Operator: {0} | Version: {5} | Workstation: {1} | TestSet: {2} | TestSet Number: {3} | Server: {4}", oper.name, testSet.workstation, testSet.name, testSet.number, System.Configuration.ConfigurationManager.AppSettings["Server"], version);
            }
            else
            {
                this.Text = string.Format("Operator: {0} logged off | Workstation: {1} | TestSet: {2} | TestSet Number: {3}", oper.name, testSet.workstation, testSet.name, testSet.number);
            }

        }

        /// <summary>
        /// Creates and shows a new login form
        /// </summary>
        private void showLogin()
        {
            login = new Login(oper, testSet);
            if (oper.loggedIn)
            {
                updateTextBar();
                WriteToOperator(string.Format("Welcome, {0}", oper.name), messageType.NORMAL);
                WriteToStatus(string.Format("Operator {0} logged in", oper.name));
            }
            else
            {
                WriteToOperator(oper.name, messageType.URGENT); //oper.name will contain the error message from PTS
                return;
            }
        }

        private void InitializeTestSet()
        {
            string err;

            //get command line arguments
            testArgs.getArgs(out err);

            //if there was an error, display it
            if (!string.IsNullOrWhiteSpace(err))
            {
                WriteToLog(err);
            }
            //if no error create a new TestSet and assign the values from the command line arguments to the TestSet object
            else
            {
                testSet = new TestSet(testArgs.testSetName, testArgs.workstation, testArgs.testSetNumber);
                updateTextBar();
                testSet.ManagePorts();
            }
        }

        public void WriteToLog(string str)
        {
            this.mainLogTextBox.AppendText(str + "\r\n");
            logger.Info(str);
        }

        public void WriteToLog(List<string> strs)
        {
            foreach (var str in strs)
            {
                WriteToLog(str);
            }
        }

        private void WriteToOperator(string v, messageType type)
        {
            switch (type)
            {
                case (messageType.NORMAL):
                    operatorMessageBox.BackColor = Color.LightSkyBlue;
                    break;
                case (messageType.URGENT):
                    operatorMessageBox.BackColor = Color.Tomato;
                    break;
                case (messageType.PASSED):
                    operatorMessageBox.BackColor = Color.LightGreen;
                    break;
                case (messageType.FAILED):
                    operatorMessageBox.BackColor = Color.IndianRed;
                    break;
                case (messageType.INCOMPLETE):
                    operatorMessageBox.BackColor = Color.YellowGreen;
                    break;
                default:
                    operatorMessageBox.BackColor = Color.LightSkyBlue;
                    break;
            }
            operatorMessageBox.Text = v;
            logger.Info(v);
        }
        private void WriteToResultsBox(string str)
        {
            resultsTextBox.AppendText(str + Environment.NewLine);
            logger.Info(testSet.sessionInfo + Environment.NewLine + (ObjectDumperExtensions.DumpToString(fiber.results, "Detail Results for " + fiber.fiberId)));
        }

        private void WriteToStatus(string str)
        {
            statusLabel.Text = str;
            WriteToLog(str);
        }

        private void AssignIdsToFiber()
        {
            fiber = new Fiber();
            if (string.IsNullOrWhiteSpace(fiber.fiberId) && !string.IsNullOrWhiteSpace(fiberIdTextBox.Text))
            {
                fiber.fiberId = fiberIdTextBox.Text.ToUpper();
            }
            if (string.IsNullOrWhiteSpace(fiber.serialId) && !string.IsNullOrWhiteSpace(serialIdTextBox.Text))
            {
                fiber.serialId = serialIdTextBox.Text.ToUpper();
            }
        }

        private async Task GetTestLimitsAsync()
        {
            //List<string> limits = new List<string>();

            //Update log
            WriteToLog(string.Format("Getting test limits for test set {0}", testSet.name));

            //Create a PTS transaction to retrieve the test set limits
            PTStransaction pts = new PTStransaction();
            pts.PTSMessageSending += OnPTSMessageSending;
            pts.PTSMessageReceived += OnPTSMessageReceived;

            try
            {
                var response = await pts.getTestLimitsAsync(fiber, testSet);
                var limits = response.ToList();
                //Create a new TestSetLimit object to put the limits in. Adding the testset to the constructor will link the testset with the limits
                testSet.limits = new TestSetLimits(testSet, limits);
                //Display test limits maybe somewhere hidden for technician
                WriteToLog(new List<string> {
                "<------- Test Limits ------->",
                "Pass Limit: " + testSet.limits.Pass.ToString(),
                "Fail Limit: " + testSet.limits.Fail.ToString(),
                "RM Min: " + testSet.limits.RemeasureMin.ToString(),
                "RM Max: " + testSet.limits.RemeasureMax.ToString(),
                "<---------------->"
                    });
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message);
            }
        }

        private async Task<string> GetTestListAsync()
        {
            string err = "";
            //Update log
            WriteToLog(string.Format("Getting test list for {0}", fiber.fiberId));

            //Create a PTS transaction to retrieve the test list
            PTStransaction pts = new PTStransaction();
            pts.PTSMessageSending += OnPTSMessageSending;
            pts.PTSMessageReceived += OnPTSMessageReceived;


            try
            {
                submitButton.Enabled = false;

                var testListString = await pts.getTestListAsync(fiber, testSet);
                fiber.testList.ptsReturn = testListString.ToList();

                //If PTS returns an error then set err to the error text
                if (fiber.testList.ptsReturn[(int)PTSField.RESPONSE_STATUS] != "0")
                {
                    err = fiber.testList.ptsReturn[(int)PTSField.ERROR_MESSAGE];
                    WriteToStatus(string.Format("Error retrieving test list: {0}", err));
                    submitButton.Enabled = true;
                    return err;
                }

                //If no error then convert the returned string to TestEntry objects
                else
                {
                    WriteToStatus("Test list received");
                    fiber.testList.convertReturnToTestEntries();
                }
                submitButton.Enabled = true;
                return err;
            }
            catch (Exception ex)
            {
                WriteToLog("Exception getting testlist: " + ex.Message);
            }
            return err;
        }

        public void updateTestMapDisplay()
        {

            testListLabel.Text = string.Format("Test List for: {0}", fiber.fiberId);

            int numRows = testListDataGrid.Rows.Count;

            foreach (DataGridViewRow row in testListDataGrid.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.Black;
                row.DefaultCellStyle.ForeColor = Color.White;
                if ((string)row.Cells[2].Value == "??" && (string)row.Cells[1].Value == "R")
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

                if ((string)row.Cells[2].Value == "PP")
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void clearTextBoxes()
        {
            fiberIdTextBox.Text = string.Empty;
            serialIdTextBox.Text = string.Empty;
            fiberIdTextBox.Select();
        }


        enum messageType
        {
            NORMAL,
            URGENT,
            PASSED,
            FAILED,
            INCOMPLETE
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitializeTestSet();
            LogManager.ReconfigExistingLoggers();
        }

        public void OnPTSMessageSending(object source, EventArgs args)
        {
            loadingCircle.LoadingCircleControl.Active = true;
            statusLabel.Text = "Communicating with PTS...";
        }

        public void OnPTSMessageReceived(object source, EventArgs args)
        {
            loadingCircle.LoadingCircleControl.Active = false;
            statusLabel.Text = "Data received from PTS";
            clearTextBoxes();
        }

        private void fiberIdTextBox_Leave(object sender, EventArgs e)
        {
            switch (fiberIdTextBox.Text.ToUpper())
            {
                case "AA":
                    fiberIdTextBox.Text = "024VM9822B2CLG";
                    serialIdTextBox.Text = "4108542806";
                    break;
                case "BB":
                    fiberIdTextBox.Text = "024VV1435B2CLG";
                    serialIdTextBox.Text = "5204093865";
                    break;
                case "CC":
                    fiberIdTextBox.Text = "008VV0452B2CLG";
                    serialIdTextBox.Text = "5203881944";
                    break;
                case "DD":
                    fiberIdTextBox.Text = "014VT2512A1CLJ";
                    serialIdTextBox.Text = "5202939530";
                    break;
                case "EE":
                    fiberIdTextBox.Text = "005VV2609C2CLG";
                    serialIdTextBox.Text = "5200289408";
                    break;
                default:
                    fiberIdTextBox.Text = fiberIdTextBox.Text.ToUpper();
                    break;
            }
        }
        private void testCOM_Click(object sender, EventArgs e)
        {
            new CommTest(testSet, testSet.portNumber).ShowDialog();
        }

        private void COMToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            testSet.portNumber = e.ClickedItem.Text;
            testSet.ManagePorts();
            UpdateCOMMenuItems(e.ClickedItem);
        }

        private void UpdateCOMMenuItems(ToolStripItem clickedItem)
        {
            // Set the current clicked item to item
            ToolStripMenuItem item = clickedItem as ToolStripMenuItem;
            ToolStripMenuItem ownerItem = (ToolStripMenuItem)item.OwnerItem;
            // Loop through all items in the subMenu and uncheck them but do check the clicked item
            foreach (ToolStripMenuItem tempItemp in ownerItem.DropDownItems)
            {
                if (tempItemp == item)
                    tempItemp.Checked = true;
                else
                    tempItemp.Checked = false;
            }
        }

        private void UpdateCOMMenuItems(string clickedItem)
        {
            // Set the current clicked item to item
            ToolStripMenuItem ownerItem = (ToolStripMenuItem)COMToolStripMenuItem;
            // Loop through all items in the subMenu and uncheck them but do check the clicked item
            foreach (ToolStripMenuItem tempItemp in ownerItem.DropDownItems)
            {
                if (tempItemp.Text == clickedItem)
                    tempItemp.Checked = true;
                else
                    tempItemp.Checked = false;
            }
        }

        private void DEVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationManager.AppSettings["Server"] = "DEV";
        }

        private void PRODToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Configuration.ConfigurationManager.AppSettings["Server"] = "PROD";
        }

        private void testSetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = false;
            base.OnFormClosing(e);
        }
    }
}
