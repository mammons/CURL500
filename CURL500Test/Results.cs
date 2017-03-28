using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class Results
    {
        public string lastTestResult { get; set; } = "I"; //default value is I for incomplete
        public CurlResults curlResults = new CurlResults();

    }
}
