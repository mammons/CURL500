using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class TestSetLimits
    {
        public List<string> LimitsList { get; set; }

        public float Pass { get; set; }
        public float Fail { get; set; }
        public float RemeasureMax { get; set; }
        public float RemeasureMin { get; set; }


        public TestSetLimits(TestSet set, List<string> list)
        {
            //Assign this new limits object to the set being passed into the constructor
            LimitsList = list;
            set.limits = this;

            //Assign the limits returned from PTS to meaningful properties based on the requested test set
            AssignLimitsForTestSet(set.name);
        }

        private void AssignLimitsForTestSet(string setName)
        {
            if (setName == "LTCURL")
            {
                for (int i = 8; i < LimitsList.Count; i++)
                {
                    switch (i)
                    {
                        case 8:
                            Pass = Assign(i);
                            break;
                        case 9:
                            Fail = Assign(i);
                            break;
                        case 10:
                            RemeasureMax = Assign(i);
                            break;
                        case 11:
                            RemeasureMin = Assign(i);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private float Assign(int i)
        {
            try
            {
                return Convert.ToSingle(LimitsList[i]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -999999;
            }

        }
    }
}
