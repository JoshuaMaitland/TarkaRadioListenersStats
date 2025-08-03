using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarkaRadioListenersStats
{
    public partial class Form1 : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public Form1()
        {
            InitializeComponent();
        }

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Check if the computer is connected to the internet
            if (IsConnectedToInternet() == true)
            {

            }
            else
            {
                // Show a message box if not connected to the internet
                MessageBox.Show("This program requires an internet connection. Please connect to the internet and try again.", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
    }
}
