using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevLib.IO;
using DevLib.IO.Ports;
using System.IO.Ports;
using NLog;

namespace CURL500Test
{

    public partial class CommTest : Form
    {
        static string portName = "COM1";
        static int baudRate = 9600;
        static Parity parity = Parity.None;
        static int dataBits = 8;
        static StopBits stopBits = StopBits.One;

        string response;

        TestSet tSet;

        //static bool waitTimeout = false;
        //static int timeout = 10000;
        //static bool throwOnError = true;

        static Timer r = new System.Windows.Forms.Timer();

        Logger logger = LogManager.GetCurrentClassLogger();

        SyncSerialPort port;
        

        public CommTest()
        {
            InitializeComponent();
            port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);
            if (port.Open())
            {
                WriteToLog(string.Format("Port: {0} open\n", portName));
            }
            else
            {
                WriteToLog(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine));
                return;
            }

        }

        public CommTest(string newPort)
        {
            InitializeComponent();
            portName = newPort;
            port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);
            try
            {
                if (port.Open())
                {
                    WriteToLog(string.Format("Port: {0} open\n", portName));
                }
                else
                {

                    WriteToLog(string.Format("Failed to open port {0} ", portName));
                }
            }
            catch (Exception ex)
            {
                WriteToLog(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine, ex.Message));
            }
        }

        public CommTest(TestSet tSet, string newPort)
        {
            InitializeComponent();
            this.tSet = tSet;
            tSet.portNumber = newPort;
            tSet.ManagePorts();
            
            try
            {
                if (tSet.port.isOpen())
                {
                    WriteToLog(string.Format("Port: {0} open\n", tSet.portNumber));
                }
                else
                {
                    WriteToLog(string.Format("Failed to open port {0} ", tSet.portNumber));
                }
            }
            catch (Exception ex)
            {
                WriteToLog(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine, ex.Message));
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //WriteToLog(port.ReadExisting());
            }
            catch (Exception ex)
            {
                WriteToLog(ex.Message + System.Environment.NewLine);
            }
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            WriteToLog("Sending command " + command.Text);
            response = await tSet.port.sendCommand(command.Text);
            WriteToLog("Response: " + response);
        }

        private async void readBtn_Click(object sender, EventArgs e)
        {
            WriteToLog("Reading data on port...");
            response = await tSet.port.ReadPort();
            WriteToLog("Response: " + response);
        }

        private async void measureBtn_Click(object sender, EventArgs e)
        {
            WriteToLog("Sending command MEASURE");
            response = await tSet.port.Measure();
            WriteToLog("Response" + response);
        }

        private async void statusBtn_Click(object sender, EventArgs e)
        {
            WriteToLog("Sending command STATUS");
            response = await tSet.port.CheckStatus();
            WriteToLog("Response" + response);
        }

        private async void readResultBtn_Click(object sender, EventArgs e)
        {
            WriteToLog("Sending command READ RESULTS");
            response = await tSet.port.ReadResult();
            WriteToLog("Response: " + response);
        }

        private void openPortBtn_Click(object sender, EventArgs e)
        {
            WriteToLog("Trying to open port");
            response = tSet.port.open() ? "Port Open" : "Port failed to open";
            WriteToLog("Response: " + response);
        }

        public void WriteToLog(string str)
        {
            tb.AppendText(str + Environment.NewLine);
        }

        private async void readErrorBtn_Click(object sender, EventArgs e)
        {
            WriteToLog("Sending command READ CURL_ERRORS");
            response = await tSet.port.CheckForTestErrors();
            WriteToLog("Response: " + response);
        }
    }



    class PortCommunication
    {


        public PortCommunication()
        {

        }


    }
}
