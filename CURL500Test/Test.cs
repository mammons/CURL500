using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CURL500Test
{
    public class Test
    {
        public bool isRequired { get; set; }
        public string Name { get; set; }
        public Fiber fiber { get; set; }
        public TestSet testSet { get; set; }

        public Test(Fiber fiber, TestSet testSet)
        {
            this.fiber = fiber;
            this.testSet = testSet;
        }

        public void Run()
        {
            switch (testSet.testName)
            {
                case "CRLI":
                    CURL testForm = new CURL(fiber, testSet);
                    testForm.ShowDialog();

                    break;
                default:
                    break;
            }
            //After the test run update this field so we can pull the last test result
            fiber.lastTest = testSet.testName;
        }
    }
}
