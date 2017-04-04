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
            static string portName = "COM3";
            static int baudRate = 9600;
            static Parity parity = Parity.None;
            static int dataBits = 8;
            static StopBits stopBits = StopBits.One;

            //static bool waitTimeout = false;
            static int timeout = 3000;
            static bool throwOnError = true;
            byte[] response;

        SyncSerialPort port;
            




            //SerialPort port = new SerialPort(portName, baudRate,parity, dataBits, stopBits);


            //PortCommunication commPort = new PortCommunication();
            public CommTest()
            {
                //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                InitializeComponent();
                port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);
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

                //try
                //{
                //    port.Write(command.Text);
                //    tb.AppendText(port.BytesToWrite.ToString());
                //}catch(Exception ex)
                //{
                //    tb.AppendText(ex.Message + System.Environment.NewLine);
                //}
                byte[] cmd = Encoding.ASCII.GetBytes(command.Text + System.Environment.NewLine);

                tb.AppendText(string.Format("sending command: ----- {0}\r\n", command.Text));
                response = port.SendSync(cmd, true, timeout, throwOnError);
                
                tb.AppendText(Encoding.ASCII.GetString(response));
                while (!Encoding.ASCII.GetString(response).Contains("FINISHED"))
            {
                response = port.ReadSync(false, timeout, throwOnError);
            }
            tb.AppendText(Encoding.ASCII.GetString(response));
            tb.AppendText(string.Format("-------------complete------------------" + Environment.NewLine));
            }
    }

    class PortCommunication
        {


            public PortCommunication()
            {

            }


        }
    }
