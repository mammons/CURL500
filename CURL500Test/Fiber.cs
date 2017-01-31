using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class Fiber
    {
        public string fiberId { get; set; }
        public string serialId { get; set; }
        public string rwrId { get; set; }
        public string status { get; set; }
        public TestList testList { get; set; }
        public Results results { get; set; }

        public Fiber()
        {
            testList = new TestList();
            results = new Results();
        }

        public void formatIdForPTS()
        {
            while (this.fiberId.Length < 16)
            {
                this.fiberId += " ";
            }
        }

        public bool CheckIfTestRequired(TestSet set)
        {
            var test = testList.TestEntries.FirstOrDefault(o => o.Name == set.testName);
            if (test != null)
            {
                return test.boolRequired;
            }
            return false;
        }

        public bool CheckFiberNeedsRemeasure(TestSet set)
        {
            var test = testList.TestEntries.FirstOrDefault(o => o.Name == set.testName);
            if (test != null)
            {
                return test.Required == "R";
            }
            return false;
        }
    }
}
