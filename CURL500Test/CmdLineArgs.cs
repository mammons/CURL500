using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURL500Test
{
    class CmdLineArgs
    {
        public string server { get; set; }
        public string testSetNumber { get; set; }
        public string testSetName { get; set; }
        public string workstation { get; set; }
        public int serialPortNumber { get; set; }
        public string[] args { get; set; }


        public CmdLineArgs()
        {
            args = null;
        }

        public void getArgs(out string error)
        {
            error = "";
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
            this.server = "DEV";// args[1].Trim();
            this.workstation = "1S";// args[2].Trim();
            this.testSetName = "LTCURL";// args[3].Trim();
            this.testSetNumber = "01";// args[4].Trim();
            this.serialPortNumber = '3';// Convert.ToInt16(args[5].Trim());
            //}

            setServer();
        }

        private void setServer()
        {
            switch (server)
            {
                case "PROD":
                    Properties.Settings.Default.Server = "PROD";
                    break;
                case "DEV":
                    Properties.Settings.Default.Server = "DEV";
                    break;
                case "SIM":
                    Properties.Settings.Default.Server = "SIM";
                    break;
                default:
                    Properties.Settings.Default.Server = "PROD";
                    break;
            }
        }
    }
}
