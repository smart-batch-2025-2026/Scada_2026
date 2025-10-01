using System;
using System.Windows.Forms;

namespace SmartBatchHMI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login()); // Start with Login Form
        }
    }
}
