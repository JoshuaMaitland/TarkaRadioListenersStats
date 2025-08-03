using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace TarkaRadioListenersStats
{
    public partial class frmUpdateAvailable : Form
    {
        public frmUpdateAvailable()
        {
            InitializeComponent();
        }

        private void frmUpdateAvailable_Load(object sender, EventArgs e)
        {
            lblCurrentVersion.Text += Application.ProductVersion;
            lblNewVersion.Text += VersionChecker.GetNewVersionNumberFromGithubAPI();
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            lblCurrentVersion.Visible = false;
            lblNewVersion.Visible = false;
            btnDownload.Visible = false;
            btnSkip.Visible = false;
            progressBar1.Visible = true;
            lblProgress.Visible = true;
            lblDownloaded.Visible = true;
            label1.Text = "Downloading new version...";
            try
            {
                string newVersionNumber = VersionChecker.GetNewVersionNumberFromGithubAPI();
                var downloadFileUrl = "https://github.com/JoshuaMaitland/TarkaRadioListenersStats/releases/download/v" + newVersionNumber + "/TarkaRadioListenersStats-v" + newVersionNumber + ".zip";
                var destinationFilePath = Path.Combine(Path.GetTempPath(), "TarkaRadioListenersStats-v" + newVersionNumber + ".zip");

                using (var client = new HttpClientDownloadWithProgress(downloadFileUrl, destinationFilePath))
                {
                    client.ProgressChanged += (totalFileSize, totalBytesDownloaded, progressPercentage) => {
                        Console.WriteLine($"{progressPercentage}% ({totalBytesDownloaded}/{totalFileSize})");
                        progressBar1.Value = (int)(progressPercentage ?? 0);
                        lblProgress.Text = $"{progressPercentage}%";
                        lblDownloaded.Text = $"Downloaded: {totalBytesDownloaded / 1024} KB / {totalFileSize / 1024} KB";
                        if (progressPercentage >= 100)
                        {
                            MessageBox.Show("Download complete!");

                            Process.Start(destinationFilePath);
                            // Close the current application
                            Process.GetCurrentProcess().Kill();
                        }
                    };

                    await client.StartDownload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                lblCurrentVersion.Visible = true;
                lblNewVersion.Visible = true;
                btnDownload.Visible = true;
                btnSkip.Visible = true;
                progressBar1.Visible = false;
                lblProgress.Visible = false;
                lblDownloaded.Visible = false;
                label1.Text = "A new update is available";
            }
        }
    }
}
