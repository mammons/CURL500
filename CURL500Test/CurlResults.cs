using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class CurlResults : Results
    {
            public bool successful { get; set; }
            public string radius { get; set; }
            public string delta { get; set; }
            public string amplitude { get; set; }
            public string offset { get; set; }
            public string phase { get; set; }
    }
}
