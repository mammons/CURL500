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
        static int timeout = 1000;
        static bool throwOnError = true;
        static byte[] response;

        SyncSerialPort port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);

        public delegate void SerialMessageSendingEventHandler(object source, EventArgs args);
        public event SerialMessageSendingEventHandler SerialMessageSending;

        public delegate void SerialMessageReceivedEventHandler(object source, EventArgs args);
        public event SerialMessageReceivedEventHandler SerialMessageReceived;

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
        public string sendCommand(string command)
        {
            byte[] cmd = Encoding.ASCII.GetBytes(command + System.Environment.NewLine);
            if (port.IsOpen)
            {
                try
                {
                    response = port.SendSync(cmd, waitTimeout, timeout, throwOnError);
                }
                catch (Exception ex)
                {
                    return ex.Message + ex.StackTrace;
                }
                return Encoding.ASCII.GetString(response);
            }
            return "Port not open";
        }

        public async Task<string> runCurl()
        {
            var testSetReturn = await TaskEx.Run(() => sendCommand("MEASURE"));

            if (testSetReturn.Contains("OK"))
            {
                testSetReturn = sendCommand("READ RESULTS");
                return testSetReturn;
            }
            else
            {
                return "FAILED";
            }
        }

        protected virtual void OnSerialMessageSending()
        {
            if (SerialMessageSending != null)
                SerialMessageSending(this, EventArgs.Empty);
        }

        protected virtual void OnSerialMessageReceived()
        {
            if (SerialMessageReceived != null)
                SerialMessageReceived(this, EventArgs.Empty);
        }

    }
}
