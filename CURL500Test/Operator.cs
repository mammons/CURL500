using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class Operator
    {
        public string name { get; set; }
        public string Id { get; set; }
        public string password { get; set; }
        public bool loggedIn { get; set; }

        TestSet tset { get; set; }


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

        private IEnumerable<string> login()
        {
            PTStransaction pts = new PTStransaction();
            if (this.name != null && this.password != null)
            {
                return pts.loginOperator(this, tset).ToList(); //true if success else false
            }
            return null; //either name or password was null
        }
    }
}
