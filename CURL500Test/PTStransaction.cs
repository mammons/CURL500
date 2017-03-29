using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CURL500Test
{
    class PTStransaction
    {
        public string sendMessage { get; set; }
        public string responseMessage { get; set; }
        public List<string> responseList { get; set; }
        public string serverUri { get; set; }
        public string developmentUri = "http://devpts.ganor.ofsoptics.com";
        public string productionUri = "http://pts.ganor.ofsoptics.com";

        public delegate void PTSMessageSendingEventHandler(object source, EventArgs args);
        public event PTSMessageSendingEventHandler PTSMessageSending;

        public delegate void PTSMessageReceivedEventHandler(object source, EventArgs args);
        public event PTSMessageReceivedEventHandler PTSMessageReceived;


        public PTStransaction()
        {
            serverUri = Properties.Settings.Default.Server == "DEV" ? developmentUri : productionUri;
        }


        public bool SendReceive(string sendMessage, out string responseMessage)
        {
            this.sendMessage = sendMessage;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUri);
                HttpResponseMessage responsePost = new HttpResponseMessage();
                string url = "/norcross/pts/Measurement/TestSetTransactions/api/TestSetTransactions/";
                try
                {
                    OnPTSMessageSending();
                    responsePost = client.PostAsync(url, new StringContent(sendMessage)).Result;
                    OnPTSMessageReceived();
                }
                catch (Exception eR)
                {
                    responseMessage = "[ERROR] Exception in HTTP request to PTS: " + eR;
                    return false;
                }

                if (responsePost.IsSuccessStatusCode)
                {
                    responseMessage = responsePost.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    responseMessage = "[ERROR] No response in HTTP request";
                    return false;
                }
            }
            return true;
        }

        public IEnumerable<string> sendCurlResult(Fiber fiber, TestSet tset)
        {
            string response;

            sendMessage = string.Format("{0}:{1}:{2}:{3}:UP:CR:{4}:CURL:OSE:{5}:{6}:{7}:0:ISE:{8}:{9}:{10}:1:MARK:{11}",
                tset.workstation,//0
                tset.name,//1
                tset.number,//2
                tset.oper.Id,//3
                fiber.fiberId,//4
                fiber.results.curlResults.OSEvalue.ToString("0000.00"),//5
                fiber.results.curlResults.OSEresult,//6
                fiber.results.curlResults.OSEtestcode,//7
                fiber.results.curlResults.ISEvalue.ToString("0000.00"),//8
                fiber.results.curlResults.ISEresult,//9
                fiber.results.curlResults.ISEtestcode,//10
                fiber.testList.markNumber);//11

            SendReceive(sendMessage, out response);
            return ParsePTSResponse(response);
        }

        public IEnumerable<string> loginOperator(Operator oper, TestSet tset)
        {
            string response;

            sendMessage = string.Format("{0}:{1}:{2}:{3}:RE:OP:{4}:", tset.workstation, tset.name, tset.number, oper.Id, oper.password);
            SendReceive(sendMessage, out response);

            return ParsePTSResponse(response);

        }

        /// <summary>
        /// PTS response comes back in a colon (':') delimited string so split that out into a List<string> that's easier to work with
        /// </summary>
        /// <param name="response"></param>
        /// <returns>List<string> filled with each item in PTS response</string></returns>
        private IEnumerable<string> ParsePTSResponse(string response)
        {
            List<string> ptsResponseList = new List<string>(response.Split(':'));
            return ptsResponseList;
        }

        /// <summary>
        /// Get the test list for the fiber so the operator and the application know what tests need to be run
        /// </summary>
        /// <param name="fiber"></param>
        /// <param name="tset"></param>
        /// <returns>Returns the parsed version of the PTS response</returns>
        public IEnumerable<string> getTestList(Fiber fiber, TestSet tset)
        {
            string response;

            fiber.formatIdForPTS();
            sendMessage = string.Format("{0}:{1}:{2}:{3}:RE:FI:{4}:{5}", tset.workstation, tset.name, tset.number, tset.oper.Id, fiber.fiberId, fiber.serialId);
            SendReceive(sendMessage, out response);
            //-------------SIMULATION----------------//
            //response = "2S:LTCURL:2S:MRA:RE:FI:1:RWR014930586    :Reference spool measurements required:";
            //-------------/SIMULATION--------------//
            return ParsePTSResponse(response);
        }

        /// <summary>
        /// Get the test limits for the testset and fiber so the application knows whether the fiber passes or fails.
        /// 
        /// </summary>
        /// <param name="fiber"></param>
        /// <param name="tset"></param>
        /// <returns></returns>
        public IEnumerable<string> getTestLimits(Fiber fiber, TestSet tset)
        {
            string response;

            fiber.formatIdForPTS();
            sendMessage = string.Format("{0}:{1}:{2}:{3}:RE:LM:{4}", tset.workstation, tset.name, tset.number, tset.oper.Id, fiber.fiberId);
            SendReceive(sendMessage, out response);

            return ParsePTSResponse(response);

        }

        protected virtual void OnPTSMessageSending()
        {
            if (PTSMessageSending != null)
                PTSMessageSending(this, EventArgs.Empty);
        }

        protected virtual void OnPTSMessageReceived()
        {
            if (PTSMessageReceived != null)
                PTSMessageReceived(this, EventArgs.Empty);
        }
    }

    enum PTSField
    {
        WORKSTATION,
        TEST_SET_NAME,
        TEST_SET_NUMBER,
        OPER_ID,
        REQUEST,
        OBJECT,
        RESPONSE_STATUS,
        ERROR_MESSAGE_FIBER_ID,
        ERROR_MESSAGE
    }
}
