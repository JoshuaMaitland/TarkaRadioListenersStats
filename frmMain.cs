using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarkaRadioListenersStats
{
    public partial class frmMain : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public frmMain()
        {
            InitializeComponent();
        }

        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        #region Form Events
        private void frmMain_Load(object sender, EventArgs e)
        {
            Location = Properties.Settings.Default.Position;

            // Get the listeners statistics
            GetListeners();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the current position of the form when it is closed
            Properties.Settings.Default.Position = Location;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Menu Events
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assembly currentAssem = typeof(Program).Assembly;
            var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            // Get the copyright info from versionInfo
            var copyright = versionInfo.LegalCopyright;
            // Show the message box
            MessageBox.Show(currentAssem.GetAssemblyDescription() + "\n\n" + copyright, "About " + Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            Properties.Settings.Default.AlwaysOnTop = TopMost;
        }
        #endregion

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            // Get the listeners statistics
            GetListeners();
        }

        private async void GetListeners()
        {
            // Check if the computer is connected to the internet
            if (IsConnectedToInternet() == true)
            {
                // Create a single HttpClient instance to reuse throughout your application
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Get the listeners statistics from the server's URL
                        HttpResponseMessage response = await client.GetAsync("http://uk3-vn.mixstream.net/:8088/7.html");
                        // Check if the request was successful
                        response.EnsureSuccessStatusCode();
                        // Read response content
                        string responseBody = await response.Content.ReadAsStringAsync();
                        // Parse the response to extract listener statistics and remove both HTML tags and a comma
                        string[] stats = responseBody.Replace("<html><body>", "").Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        // Send them to the both labels
                        lblListenersCount.Text = "Listeners Count: " + stats[0].Trim();
                        lblListenersPeak.Text = "Listeners Peak: " + stats[2].Trim();
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Request error: {e.Message}");
                    }
                }
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
