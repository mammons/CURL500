using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURL500Test
{
    public class Operator
    {
        public string name { get; set; }
        public string Id { get; set; }
        public string password { get; set; }
        public bool loggedIn { get; set; }

        TestSet tset { get; set; }

        private static Logger logger = LogManager.GetCurrentClassLogger();


        public Operator(string name, string Id, TestSet tset)
        {
            this.name = name;
            this.Id = Id;
            this.tset = tset;
        }

        public Operator()
        {
            this.name = null;
            this.Id = null;
            this.tset = null;
        }

        private async Task<IEnumerable<string>> login()
        {
            PTStransaction pts = new PTStransaction();
            if (this.name != null && this.password != null)
            {
                try
                {
                    var response = await pts.loginOperatorAsync(this, tset);
                    return response.ToList();
                }
                catch(Exception ex)
                {
                    logger.Error(tset.sessionInfo, "Exception in Operator.login: " + ex.Message);
                }

            }
            return null; //either name or password was null
        }
    }
}
