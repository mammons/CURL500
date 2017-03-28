using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class CurlResults
    {
        public bool successful { get; set; }
        public string radius { get; set; }
        public string delta { get; set; }
        public string amplitude { get; set; }
        public string offset { get; set; }
        public string phase { get; set; }

        /// <summary>
        /// curlXXXvalue is the value to send to PTS. For curl it is they 'y' or Offset value. Not the curl radius
        /// </summary>
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

        public CurlResults()
        {

        }
    }
}
