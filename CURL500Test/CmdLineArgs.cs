using System;
using System.IO;
using NLog;

namespace CURL500Test
{
    public class CmdLineArgs
    {
        public string server { get; set; } = System.Configuration.ConfigurationManager.AppSettings["Server"];
        public string testSetNumber { get; set; }
        public string testSetName { get; set; }
        public string workstation { get; set; }
        public string serialPortNumber { get; set; }
        public string[] args { get; set; }
        public string path { get; set; } = @"C:\CURL500\settings.ini";


        public CmdLineArgs()
        {
            args = null;
        }

        public void getArgs(out string error)
        {
            error = "";

            if (File.Exists(path))
            {
                this.server = IniFileHelper.ReadValue("TestSet", "Server", path);
                this.workstation = IniFileHelper.ReadValue("TestSet", "Workstation", path);
                this.testSetName = IniFileHelper.ReadValue("TestSet", "Name", path);
                this.testSetNumber = IniFileHelper.ReadValue("TestSet", "Number", path);
                this.serialPortNumber = IniFileHelper.ReadValue("TestSet", "Port", path);
            }
            else
            {
                error = "Failed to find settings file. Please setup test set.";
                setupSettingsFile();
                Settings settings = new Settings();
                getArgs(out error);
                return;
            }

            setServer();
        }

        private void setupSettingsFile()
        {
            try
            {
                File.AppendAllText(path, "[TestSet]");
            }
            catch(Exception ex)
            {
                string err = ex.Message;
            }

            IniFileHelper.WriteValue("TestSet", "Workstation", "", path);
            IniFileHelper.WriteValue("TestSet","Name","",path);            
            IniFileHelper.WriteValue("TestSet", "Number", "", path);
            IniFileHelper.WriteValue("TestSet", "Port", "", path);
            IniFileHelper.WriteValue("TestSet", "Server", "", path);
        }

        private void setServer()
        {
            switch (server)
            {
                case "PROD":
                    System.Configuration.ConfigurationManager.AppSettings["Server"] = "PROD";
                    break;
                case "DEV":
                    System.Configuration.ConfigurationManager.AppSettings["Server"] = "DEV";
                    break;
                case "SIM":
                    Properties.Settings.Default.Server = "SIM";
                    break;
                default:
                    System.Configuration.ConfigurationManager.AppSettings["Server"] = "PROD";
                    break;
            }
            LogManager.Configuration.Variables["server"] = server;
            LogManager.Configuration.Variables["setNum"] = testSetNumber;
        }
    }
}
