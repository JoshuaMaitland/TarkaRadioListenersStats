using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarkaRadioListenersStats
{
    internal static class Program
    {
        public static string TitleCommit
        {
            get
            {
                string title = Application.ProductName + " (Git Commit: " + ThisAssembly.Git.Commit + ")";
#if DEBUG
                title += " [Debug]";
#endif
                return title;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
