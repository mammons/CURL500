using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CURL500Test
{
    class Log
    {
        public static string localPath  = "C:\\CURL500\\Logs\\" + DateTime.Now.ToString("yyyyMMdd") + "--Log.txt";
        public static string networkPath = @"\\nordevengr01\userapps\apps\CURL500\Logs\" + DateTime.Now.ToString("yyyyMMdd") + "--Log.txt";

        public static void permaLog(string sessionInfo, string text)
        {
            System.IO.File.AppendAllText(localPath,sessionInfo + " " + text + Environment.NewLine);

            try
            {
                System.IO.File.AppendAllText(networkPath, sessionInfo + " " + text + Environment.NewLine);
            }
            catch(Exception)
            {
                System.IO.File.AppendAllText(localPath, "Couldn't reach network log" + Environment.NewLine);
            }
        }
    }
}
