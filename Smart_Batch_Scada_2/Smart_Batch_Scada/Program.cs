using System;
using System.Windows.Forms;

namespace Smart_Batch_Scada
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Userappflow());
        }
    }
}
