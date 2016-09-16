using System;
using System.Windows.Forms;

namespace AutoPrintr
{
    public partial class mainWin
    {
        void updateInit()
        {
            Autoupdate.onAvailable += Autoupdate_onAvailable;
            Autoupdate.onDownloaded += Autoupdate_onDownloaded;
            Autoupdate.onProgress += Autoupdate_onProgress;
            updateStatus.Click += updateStatus_Click;
            Autoupdate.check();
        }
        
        void Autoupdate_onProgress(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;

            progressBarValue.Text =
                e.ProgressPercentage + "% | " +
                tools.BytesToString(e.TotalBytesToReceive) +
                " / " + tools.BytesToString(e.TotalBytesToReceive)
            ;
        }

        void Autoupdate_onDownloaded(object sender, EventArgs e)
        {
            progressBar.Visible = false;
            progressBarValue.Visible = false;
            statusSeparatorUpdate.Visible = false; ;
            updateStatus.Visible = false;
            Autoupdate.install();
        }

        void Autoupdate_onAvailable(object sender, Autoupdate.UpdateEventArgs e)
        {
            statusSeparatorUpdate.Visible = true;
            updateStatus.Visible = true;
            updateStatus.Text = "Update available " + e.release.tag_name + " - click here to install";
        }

        void updateStatus_Click(object sender, EventArgs e)
        {
            string caption = "AutoPrintr update";
            string msg =
                "AutoPrintr new version available:\n" + 
                "Release name: " + Autoupdate.release.name +
                "\nVersion: " + Autoupdate.release.tag_name +
                "\n\n " + Autoupdate.release.body +
                "\n\nDownload (" + tools.BytesToString(Autoupdate.releaseFile.size) +
                ") and install new version?"
            ;
            if (MessageBox.Show(msg, caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                updateStatus.Text = "Update downloading";
                progressBar.Visible = true;
                progressBarValue.Visible = true;
                Autoupdate.download();
            }
        }
    }
}
