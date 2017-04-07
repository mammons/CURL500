using System;
using System.Text;
using System.IO.Ports;
using DevLib.IO.Ports;
using System.Threading.Tasks;
using NLog;

namespace CURL500Test
{
    public class PECommunication
    {
        static string portName = "COM1";
        static int baudRate = 9600;
        static Parity parity = Parity.None;
        static int dataBits = 8;
        static StopBits stopBits = StopBits.One;

        static bool waitTimeout = false;
        static int timeout = 10000;
        static bool throwOnError = true;
        static byte[] response;

        private SyncSerialPort port;

        public delegate void SerialMessageSendingEventHandler(object sender, EventArgs e);
        public event SerialMessageSendingEventHandler SerialMessageSending;

        public delegate void SerialMessageReceivedEventHandler(object sender, PECommunicationEventArgs e);
        public event SerialMessageReceivedEventHandler SerialMessageReceived;

        //public delegate void SerialMessageErrorEventHandler(object source, EventArgs args);
        //public event SerialMessageErrorEventHandler ErrorReceived;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public PECommunication()
        {
            port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);
        }

        public PECommunication(string newPortName)
        {
            portName = newPortName;
            port = new SyncSerialPort(portName, baudRate, parity, dataBits, stopBits);
        }

        public bool open()
        {
            return port.Open();
        }

        public bool close()
        {
            return port.Close();
        }

        public bool isOpen()
        {
            return port.IsOpen;
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
                    logger.Debug("Sending command {0}", command);
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

        public async Task<string> Measure()
        {
            return await sendCommand("MEASURE");
            
        }

        public async Task<string> ReadResult()
        {
            return await sendCommand("READ RESULTS");
        }

        public async Task<string> CheckStatus()
        {
            return await sendCommand("STATUS");
        }

        public async Task<string> CheckForTestErrors()
        {
            return await sendCommand("READ CURL_ERRORS");
        }

        public async Task<string> SendID(string Id)
        {
            return await sendCommand(string.Format("SET ID {0}", Id));
        }

        public async Task<bool> CheckConnected()
        {
            string connected = await sendCommand("READ CONNECTED");
            return connected.Contains("1");
        }

        public async Task<string> ReadPort()
        {
            response = await TaskEx.Run(() =>
                   port.ReadSync(waitTimeout, timeout, throwOnError));
            return Encoding.ASCII.GetString(response);
        }

        public string CurrentPort()
        {
            return port.CurrentPort;
        }

        protected virtual void OnSerialMessageSending()
        {
            logger.Debug("OnSerialMessageSending ");
            SerialMessageSending?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSerialMessageReceived()
        {
            string strResponse = Encoding.ASCII.GetString(response);
            SerialMessageReceived?.Invoke(this, new PECommunicationEventArgs(strResponse));
        }

        private void OnErrorReceived(object source, EventArgs args)
        {
            logger.Debug("OnErrorReceived sent me");
            OnSerialMessageReceived();
        }

        private void OnDataReceived(object source, EventArgs args)
        {
            logger.Debug("OnDataReceived sent me");
            OnSerialMessageReceived();
        }

    }
}
