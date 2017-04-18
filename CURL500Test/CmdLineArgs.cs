using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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
                SetUpSettingsFile();
                Settings settings = new Settings();
                getArgs(out error);
                return;
            }

            setServer();
        }

        private void SetUpSettingsFile()
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

        private NameValueCollection GetQueryStringParameters()
        {
            NameValueCollection nameValueTable = new NameValueCollection();

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                string queryString = ApplicationDeployment.CurrentDeployment.ActivationUri.Query;
                nameValueTable = HttpUtility.ParseQueryString(queryString);
            }

            return (nameValueTable);
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
        }
    }

    //if (!ApplicationDeployment.IsNetworkDeployed)
    //{
    //    var arguments = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
    //    if (arguments != null && arguments.Length > 0)
    //    {
    //        args = arguments[0].Split(new char[] { ',' });
    //    }
    //}
    //else
    //{
    //    args = Environment.GetCommandLineArgs();
    //}

    //if (args == null || args.Length < 2)
    //{
    //    error = ("Not enough arguments.");
    //}
    //else
    //{
    //TODO get this working with clickonce commandline arguments
    //    this.server = "DEV";// args[1].Trim();
    //this.workstation = "1S";// args[2].Trim();
    //this.testSetName = "LTCURL";// args[3].Trim();
    //this.testSetNumber = "01";// args[4].Trim();
    //this.serialPortNumber = '3';// Convert.ToInt16(args[5].Trim());


    //}

    //setServer();

    //NameValueCollection queryArgs = GetQueryStringParameters();
}
