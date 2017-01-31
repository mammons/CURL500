using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class TestEntry
    {
        public string Name { get; set; }
        public string Required { get; set; }
        public string Result { get; set; }

        [System.ComponentModel.Browsable(false)]
        public bool boolRequired { get; set; }


        public TestEntry() { }

        public TestEntry(string name, string required, string result)
        {
            this.Name = name;
            this.Required = required;
            this.Result = result;
            boolRequired = getRequired();
        }

        public bool getRequired()
        {
            return (Required == "R" && Result == "??" || Required == "R" && Result == "RM");
        }
    }
}
