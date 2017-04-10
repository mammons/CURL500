using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NLog;

namespace CURL500Test
{
    public partial class Settings : Form
    {
        public TestSet set { get; set; }
        public string settingsPath { get; set; } = @"C:\CURL500\settings.ini";
        Logger logger = LogManager.GetCurrentClassLogger();
        public Settings()
        {
            InitializeComponent();
            GetCurrentSettings();
            ShowDialog();
        }



        public Settings(TestSet set)
        {
            this.set = set;
            workstationSelection.Text = set.workstation ?? "";
            nameSelection.Text = set.name ?? "";
            numberSelection.Text = set.number ?? "";
            comSelection.Text = set.portNumber ?? "";
            serverSelection.Text = System.Configuration.ConfigurationManager.AppSettings["Server"];
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            //SetInstanceValues();
            SetIniValues();
            MessageBox.Show("If any changes were made, restart the application for them to take effect");
            Close();
        }

        private void GetCurrentSettings()
        {
            try
            {
                msgLabel.Text = "Set up test set";
                workstationSelection.Text = IniFileHelper.ReadValue("TestSet", "Workstation", settingsPath) ?? "";
                nameSelection.Text = IniFileHelper.ReadValue("TestSet", "Name", settingsPath) ?? "";
                numberSelection.Text = IniFileHelper.ReadValue("TestSet", "Number", settingsPath) ?? "";
                comSelection.Text = IniFileHelper.ReadValue("TestSet", "Port", settingsPath) ?? "";
                serverSelection.Text = IniFileHelper.ReadValue("TestSet", "Server", settingsPath, System.Configuration.ConfigurationManager.AppSettings["Server"]) ?? "";
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }

        private void SetIniValues()
        {
            try
            {
                IniFileHelper.WriteValue("TestSet", "Workstation", workstationSelection.Text, settingsPath);
                IniFileHelper.WriteValue("TestSet", "Name", nameSelection.Text, settingsPath);
                IniFileHelper.WriteValue("TestSet", "Number", numberSelection.Text, settingsPath);
                IniFileHelper.WriteValue("TestSet", "Port", comSelection.Text, settingsPath);
                IniFileHelper.WriteValue("TestSet", "Server", serverSelection.Text, settingsPath);
            }
            catch(Exception ex)
            {
                logger.Debug(ex);
            }
            
        }

        private void SetInstanceValues()
        {
            set.workstation = workstationSelection.Text ?? "";
            set.name = nameSelection.Text ?? "";
            set.number = numberSelection.Text ?? "";
            set.portNumber = comSelection.Text ?? "";
            System.Configuration.ConfigurationManager.AppSettings["Server"] = serverSelection.Text ?? "DEV";
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
