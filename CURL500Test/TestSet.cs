using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace CURL500Test
{
    public class TestSet
    {
        public Operator oper { get; set; }
        public TestSetLimits limits { get; set; }
        public PECommunication port { get; set; }
        public string name { get; set; }
        public string workstation { get; set; }
        public string number { get; set; }
        public string type { get; set; }
        public bool isAvailable { get; set; }
        public bool subscribedToSerialEvents { get; set; }
        public string testName { get; set; }
        public string sessionInfo { get; set; } = "No session Info.";
        public string settingsPath { get; set; } = @"C:\CURL500\settings.ini";
        public string portNumber { get; set; } = IniFileHelper.ReadValue("TestSet", "Port", @"C:\CURL500\settings.ini", "COM1");
        Logger logger = LogManager.GetCurrentClassLogger();


        public TestSet()
        {
            name = null;
            workstation = null;
            number = null;
        }

        public TestSet(string name, string workstation, string number)
        {
            this.name = name;
            this.workstation = workstation;
            this.number = number;
            SetTestName();
        }

        public TestSet(string[] args)
        {
            this.workstation = args[2].Trim();
            this.name = args[3].Trim();
            this.number = args[4].Trim();
            SetTestName();
        }

        public void SetTestName()
        {
            switch (name)
            {
                case "LTCURL":
                    testName = "CRLI";
                    break;
                default:
                    break;
            }
        }

        public bool ManagePorts()
        {
            logger.Debug("managing ports");
            if(port == null)
            {
                port = new PECommunication(portNumber);
            }
            if (port != null && portNumber != port.CurrentPort())
            {
                port.close();
                port = new PECommunication(portNumber);
            }
            isAvailable = port.open();
            logger.Debug("Isavailable in testsetclass: {0}", this.isAvailable.ToString());
            return this.isAvailable;
        }

    }
}
