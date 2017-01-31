using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    public class TestList
    {
        public List<string> ptsReturn { get; set; }
        public BindingList<TestEntry> TestEntries { get; set; } = new BindingList<TestEntry>();
        public string testName { get; set; }
        public string markNumber
        {
            get
            {
                int index = ptsReturn.IndexOf("MARK");
                return ptsReturn[index + 1];
            }
        }

        public DataTable dt { get; set; }
        public TestEntry Entry { get; set; }
        public List<string> Tests = new List<string>()
        {
            "131R",
            "INSP",
            "SLSS",
            "CUTI",
            "CUTO",
            "CRLI",
            "FTIR",
            "MODI",
            "MODO",
            "DISP",
            "FGIS",
            "FGOS",
            "CGIS",
            "CGOS",
            "PMD1",
            "PMDL"
        };

        public DataTable CreateDataTable()
        {
            //create new datatable to bind the datagridview to
            dt = new DataTable();

            //this adds headers to the datatable that will display in the datagridview
            dt.Columns.Add("Test");
            dt.Columns.Add("Required");
            dt.Columns.Add("Status");

            foreach (var entry in TestEntries)
            {
                dt.Rows.Add(entry.Name, entry.Required, entry.Result);
            }
            return dt;
        }

        /// <summary>
        /// Fills the TestEntries list with TestEntry objects that are created from the PTS return string
        /// </summary>
        /// <returns>List of TestEntry objects: TestEntries</returns>
        public BindingList<TestEntry> convertReturnToTestEntries()
        {
            TestEntries.Clear();
            if (ptsReturn != null)
            {
                //iterate through the list of test names created in this class
                foreach (var test in Tests)
                    //add a new TestEntry object for each test in the Tests list. Each of these is returned from PTS in a RE:FI
                    TestEntries.Add(new TestEntry(
                        //Name
                        test,
                        //Required
                        ptsReturn[ptsReturn.IndexOf(test) + 2],
                        //Result
                        ptsReturn[ptsReturn.IndexOf(test) + 3]
                    ));
                return TestEntries;
            }
            return null;
        }
    }
}
