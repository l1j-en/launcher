using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Launcher
{
    public partial class UpdateForm : Form
    {
        public UpdateForm(VersionInfo versionInfo)
        {
            InitializeComponent();

            this.lblUpdateVersion.Text = string.Format("Upgrade to version {0}!", versionInfo.Version);
            this.updateDetails.DocumentText = versionInfo.VersionDetails;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLater_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
