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
                writeToLog(string.Format("Port: {0} open\n", portName));
            }
            else
            {
                writeToLog(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine));
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
                    writeToLog(string.Format("Port: {0} open\n", portName));
                }
                else
                {

                    writeToLog(string.Format("Failed to open port {0} ", portName));
                }
            }
            catch (Exception ex)
            {
                writeToLog(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine, ex.Message));
            }
        }

        public CommTest(TestSet tSet, string newPort)
        {
            InitializeComponent();
            this.tSet = tSet;
            tSet.portNumber = newPort;
            tSet.managePorts();
            
            try
            {
                if (tSet.port.isOpen())
                {
                    writeToLog(string.Format("Port: {0} open\n", tSet.portNumber));
                }
                else
                {
                    writeToLog(string.Format("Failed to open port {0} ", tSet.portNumber));
                }
            }
            catch (Exception ex)
            {
                writeToLog(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine, ex.Message));
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //writeToLog(port.ReadExisting());
            }
            catch (Exception ex)
            {
                writeToLog(ex.Message + System.Environment.NewLine);
            }
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            writeToLog("Sending command " + command.Text);
            response = await tSet.port.sendCommand(command.Text);
            writeToLog("Response: " + response);
        }

        private async void readBtn_Click(object sender, EventArgs e)
        {
            writeToLog("Reading data on port...");
            response = await tSet.port.ReadPort();
            writeToLog("Response: " + response);
        }

        private async void measureBtn_Click(object sender, EventArgs e)
        {
            writeToLog("Sending command MEASURE");
            response = await tSet.port.Measure();
            writeToLog("Response" + response);
        }

        private async void statusBtn_Click(object sender, EventArgs e)
        {
            writeToLog("Sending command STATUS");
            response = await tSet.port.CheckStatus();
            writeToLog("Response" + response);
        }

        private async void readResultBtn_Click(object sender, EventArgs e)
        {
            writeToLog("Sending command READ RESULTS");
            response = await tSet.port.ReadResult();
            writeToLog("Response: " + response);
        }

        private void openPortBtn_Click(object sender, EventArgs e)
        {
            writeToLog("Trying to open port");
            response = tSet.port.open() ? "Port Open" : "Port failed to open";
            writeToLog("Response: " + response);
        }

        public void writeToLog(string str)
        {
            tb.AppendText(str + Environment.NewLine);
        }

        private async void readErrorBtn_Click(object sender, EventArgs e)
        {
            writeToLog("Sending command READ CURL_ERRORS");
            response = await tSet.port.CheckForTestErrors();
            writeToLog("Response: " + response);
        }
    }



    class PortCommunication
    {


        public PortCommunication()
        {

        }


    }
}
