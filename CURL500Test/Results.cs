using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class Results
    {
        public string lastTestResult { get; set; } = "I"; //default value is I for incomplete
        //Curl
        //Curl OSE not measured so values are static
        public double curlOSEvalue
        {
            get
            {
                return -0999.00;
            }
        }
        public double curlISEvalue { get; set; }
        public string curlOSEresult
        {
            get
            {
                return "N";
            }
        }
        public string curlISEresult { get; set; }
        public string curlOSEtestcode
        {
            get
            {
                return "NN";
            }
        }
        public string curlISEtestcode { get; set; }
        public string curlISEradius { get; set; }
    }
}
