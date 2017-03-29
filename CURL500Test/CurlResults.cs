using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class CurlResults
    {
        public bool successful { get; set; }
        public string delta { get; set; }
        public string amplitude { get; set; }
        public string offset { get; set; }
        public string phase { get; set; }

        /// <summary>
        /// XXXvalue is the value to send to PTS. For curl it is they 'y' or Offset value. Not the curl radius
        /// </summary>
        public double OSEvalue
        {
            get
            {
                return -0999.00;
            }
        }
        public double ISEvalue { get; set; }
        public string OSEresult
        {
            get
            {
                return "N";
            }
        }
        public string ISEresult { get; set; }
        public string OSEtestcode
        {
            get
            {
                return "NN";
            }
        }
        public string ISEtestcode { get; set; }
        public string ISEradius { get; set; }

        public CurlResults()
        {

        }
    }
}
