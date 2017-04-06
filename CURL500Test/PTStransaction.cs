using NLog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CURL500Test
{
    class PTStransaction
    {
        //public string sendMessage { get; set; }
        //public string responseMessage { get; set; }
        public List<string> responseList { get; set; }
        public string serverUri { get; set; }
        public string developmentUri = System.Configuration.ConfigurationManager.AppSettings["devURI"];
        public string productionUri = System.Configuration.ConfigurationManager.AppSettings["prodURI"];

        public delegate void PTSMessageSendingEventHandler(object source, EventArgs args);
        public event PTSMessageSendingEventHandler PTSMessageSending;

        public delegate void PTSMessageReceivedEventHandler(object source, EventArgs args);
        public event PTSMessageReceivedEventHandler PTSMessageReceived;

        private static Logger logger = LogManager.GetCurrentClassLogger();


        public PTStransaction()
        {
            serverUri = System.Configuration.ConfigurationManager.AppSettings["Server"] == "DEV" ? developmentUri : productionUri;
        }


        public async Task<string> SendReceiveAsync(string sendMessage)
        {
            string responseString;
            using (var client = new HttpClient(new HttpClientHandler { UseProxy = false }))
            {
                client.BaseAddress = new Uri(serverUri);
                StringContent msgToPTS = new StringContent(sendMessage);
                string url = "/norcross/pts/Measurement/TestSetTransactions/api/TestSetTransactions/";

                try
                {
                    OnPTSMessageSending();
                    var response = await client.PostAsync(url, msgToPTS);
                    OnPTSMessageReceived();
                    if (response.IsSuccessStatusCode)
                    {
                        responseString = response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        responseString = "[ERROR] No response in HTTP request";
                    }
                }
                catch (Exception eR)
                {
                    responseString = "[ERROR] Exception in HTTP request to PTS: " + eR;
                }
            }
            return responseString;
        }

        public async Task<IEnumerable<string>> sendCurlResultAsync(Fiber fiber, TestSet tset)
        {
            string sendMessage = string.Format("{0}:{1}:{2}:{3}:UP:CR:{4}:CURL:OSE:{5}:{6}:{7}:0:ISE:{8}:{9}:{10}:1:MARK:{11}",
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

            try
            {
                var response = await SendReceiveAsync(sendMessage);
                return ParsePTSResponse(response);
            }
            catch(Exception ex)
            {
                List<string> errorMessage = new List<string> { "Exception in PTStransaction.sendCurlResultsAsync: " + ex.Message };
                logger.Error(tset.sessionInfo, errorMessage.ToString());
                return errorMessage;
            }
        }

        public async Task<IEnumerable<string>> loginOperatorAsync(Operator oper, TestSet tset)
        {
            string sendMessage = string.Format("{0}:{1}:{2}:{3}:RE:OP:{4}:", tset.workstation, tset.name, tset.number, oper.Id, oper.password);
            var response = await SendReceiveAsync(sendMessage);

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
        public async Task<IEnumerable<string>> getTestListAsync(Fiber fiber, TestSet tset)
        {
            fiber.formatIdForPTS();
            string sendMessage = string.Format("{0}:{1}:{2}:{3}:RE:FI:{4}:{5}", tset.workstation, tset.name, tset.number, tset.oper.Id, fiber.fiberId, fiber.serialId);

            try
            {
                var response = await SendReceiveAsync(sendMessage);
                return ParsePTSResponse(response);
            }
            catch (Exception ex)
            {
                List<string> errMessage = new List<string> { "Exception in PTStransaction.getTestListAsync :" + ex.Message};
                logger.Error(tset.sessionInfo, errMessage.ToString());
                return errMessage;
            }

        }

        /// <summary>
        /// Get the test limits for the testset and fiber so the application knows whether the fiber passes or fails.
        /// 
        /// </summary>
        /// <param name="fiber"></param>
        /// <param name="tset"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> getTestLimitsAsync(Fiber fiber, TestSet tset)
        {
            fiber.formatIdForPTS();
            string sendMessage = string.Format("{0}:{1}:{2}:{3}:RE:LM:{4}", tset.workstation, tset.name, tset.number, tset.oper.Id, fiber.fiberId);
            var response = await SendReceiveAsync(sendMessage);

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
