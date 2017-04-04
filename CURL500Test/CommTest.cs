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

namespace CURL500Test
{

        public partial class CommTest : Form
        {
            static string portName = "COM1";
            static int baudRate = 9600;
            static Parity parity = Parity.None;
            static int dataBits = 8;
            static StopBits stopBits = StopBits.One;

            //static bool waitTimeout = false;
            static int timeout = 20000;
            static bool throwOnError = true;
            byte[] response;

            static Timer r = new System.Windows.Forms.Timer();
        




        SyncSerialPort port;
        PECommunication myPort;       




            //SerialPort port = new SerialPort(portName, baudRate,parity, dataBits, stopBits);


            //PortCommunication commPort = new PortCommunication();
            public CommTest()
            {
                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                InitializeComponent();
                port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);
            myPort = new PECommunication(portName);
            if (port.Open())
                {
                    tb.AppendText(string.Format("Port: {0} open\n", portName));
                }
                else
                {
                    tb.AppendText(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine));
                    return;
                }

            }

        public CommTest(string newPort)
        {
            //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            InitializeComponent();
            portName = newPort;
            port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);
            myPort = new PECommunication(portName);
            try
            {
                if (port.Open())
                {
                    tb.AppendText(string.Format("Port: {0} open\n", portName));
                }
                else
                {

                    tb.AppendText(string.Format("Failed to open port {0} ", portName));
                }
            }
            catch(Exception ex)
            {
                tb.AppendText(string.Format("Port failed to open with ex: {0}" + System.Environment.NewLine, ex.Message));
            }


        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                try
                {
                    //tb.AppendText(port.ReadExisting());
                }
                catch (Exception ex)
                {
                    tb.AppendText(ex.Message + System.Environment.NewLine);
                }
            }

            private void sendBtn_Click(object sender, EventArgs e)
            {
            sendCom(command.Text);
            }

        private void readBtn_Click(object sender, EventArgs e)
        {
            response = port.ReadSync(false, timeout, throwOnError);
            tb.AppendText("ReadSync " + Encoding.ASCII.GetString(response));
        }

        private void measureBtn_Click(object sender, EventArgs e)
        {
            sendCom("MEASURE");
        }

        private void statusBtn_Click(object sender, EventArgs e)
        {
           sendCom("STATUS");
        }

        public void sendCom(string command)
        {
            byte[] cmd = Encoding.ASCII.GetBytes(command + System.Environment.NewLine);

            tb.AppendText(string.Format("sending command: ----- {0}\r\n", command));
            response = port.SendSync(cmd, false, timeout, throwOnError);

            tb.AppendText("SendSync " + Encoding.ASCII.GetString(response) + Environment.NewLine);

            if (command == "MEASURE")
            {
                response = port.ReadSync(false, timeout, throwOnError);
                tb.AppendText("ReadSync " + Encoding.ASCII.GetString(response) + Environment.NewLine);
            }

            tb.AppendText(string.Format("-------------complete------------------" + Environment.NewLine));

        }

        private void readResultBtn_Click(object sender, EventArgs e)
        {
            sendCom("READ RESULTS");
        }
    }



    class PortCommunication
        {


            public PortCommunication()
            {

            }


        }
    }
