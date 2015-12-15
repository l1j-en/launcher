using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Launcher
{
    public partial class UpdateForm : Form
    {public UpdateForm(VersionInfo versionInfo)
        {
            InitializeComponent();

            this.lblUpdateVersion.Text = string.Format("Upgrade to version {0}!", versionInfo.Version);
            this.updateDetails.DocumentText = versionInfo.VersionDetails;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var voteUrl = new ProcessStartInfo(this.lblLink.Text);
            Process.Start(voteUrl);
        }
    }
}
