using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class PTSEventArgs : EventArgs
    {
        public Operator Operator { get; set; }
        public TestList TestList { get; set; }

    }
}
