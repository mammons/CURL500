using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CURL500Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            Application.Run(new Main());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            try
            {
                System.IO.File.AppendAllText(@"\\nordevengr01\userapps\apps\CURL400\ErrorLog.txt", "Unhandled exception: " + e + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText(@"\\nordevengr01\userapps\apps\CURL400\ErrorLog.txt", "ERROR IN TRY THIS WON'T WORK I DON'T THINK: " + ex.Message);
            }
        }
    }
}
