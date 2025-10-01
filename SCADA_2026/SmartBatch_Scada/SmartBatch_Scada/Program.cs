using System;
using System.Windows.Forms;
using UserFlowAppWinForms;

namespace SmartBatch_Scada
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1()); // Changed from Form() to Form1()
        }
    }
}
