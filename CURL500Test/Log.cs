﻿using System;
using System.IO;

namespace CURL500Test
{
    class Log
    {
        public static string localFolderName = @"C:\CURL500\Logs";
        public static string localPath  = Path.Combine(localFolderName, DateTime.Now.ToString("yyyyMMdd") + "--Log.txt");
        public static string networkPath = @"\\nordevengr01\userapps\apps\CURL500\Logs\" + DateTime.Now.ToString("yyyyMMdd") + "--Log.txt";

        public static void permaLog(string sessionInfo, string text)
        {
            Directory.CreateDirectory(localFolderName);
            string sessionInfoWithTime = sessionInfo + " " + DateTime.Now.ToString("G");

            File.AppendAllText(localPath,sessionInfoWithTime + " " + text + Environment.NewLine);
            

            try
            {
                File.AppendAllText(networkPath, sessionInfoWithTime + " " + text + Environment.NewLine);
            }
            catch(Exception)
            {
                File.AppendAllText(localPath, "Couldn't reach network log" + Environment.NewLine);
            }
        }
    }
}
