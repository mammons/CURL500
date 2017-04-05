using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using DevLib.IO;
using DevLib.IO.Ports;
using System.Threading.Tasks;

namespace CURL500Test
{
    public class PECommunication
    {
        static string portName = "COM1";
        static int baudRate = 9600;
        static Parity parity = Parity.None;
        static int dataBits = 8;
        static StopBits stopBits = StopBits.One;

        static bool waitTimeout = true;
        static int timeout = 10000;
        static bool throwOnError = true;
        static byte[] response;

        SyncSerialPort port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);

        public delegate void SerialMessageSendingEventHandler(object source, EventArgs args);
        public event SerialMessageSendingEventHandler SerialMessageSending;

        public delegate void SerialMessageReceivedEventHandler(object source, PECommunicationEventArgs args);
        public event SerialMessageReceivedEventHandler SerialMessageReceived;

        //public delegate void SerialMessageErrorEventHandler(object source, EventArgs args);
        //public event SerialMessageErrorEventHandler ErrorReceived;

        public PECommunication()
        {
            
        }

        public PECommunication(string port)
        {
            portName = port;
        }

        public bool open()
        {
            return port.Open();
        }

        /// <summary>
        /// Sends a PE command and also returns the response from the test set
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> sendCommand(string command)
        {
            byte[] cmd = Encoding.ASCII.GetBytes(command + System.Environment.NewLine);
            if (port.IsOpen)
            {
                //port.DataReceived += OnDataReceived;
                //port.ErrorReceived += OnErrorReceived;
                try
                {
                    OnSerialMessageSending();
                    response = await TaskEx.Run(() =>
                        port.SendSync(cmd, waitTimeout, timeout, throwOnError));
                }
                catch (Exception ex)
                {
                    return ex.Message + ex.StackTrace;
                }
                OnSerialMessageReceived();
                return Encoding.ASCII.GetString(response);
            }
            return "Port not open";
        }

        public async Task<bool> MeasureCurl()
        {
            string response = await sendCommand("MEASURE");
            if (response.Contains("OK"))
            {
                OnSerialMessageSending();
                response = Encoding.ASCII.GetString(port.ReadSync(false, timeout, throwOnError));
                OnSerialMessageReceived();
                return response.Contains("FINISHED");
            }
            return false;
        }

        public async Task<string> ReadResult()
        {
            return await sendCommand("READ RESULTS");
        }

        protected virtual void OnSerialMessageSending()
        {
            if (SerialMessageSending != null)
                SerialMessageSending(this, EventArgs.Empty);
        }

        protected virtual void OnSerialMessageReceived()
        {
            string strResponse = Encoding.ASCII.GetString(response);
            if (SerialMessageReceived != null)
                SerialMessageReceived(this, new PECommunicationEventArgs(strResponse));
        }

        public void OnErrorReceived(object source, EventArgs args)
        {
            OnSerialMessageReceived();
        }

        public void OnDataReceived(object source, EventArgs args)
        {
            OnSerialMessageReceived();
        }

    }
}
