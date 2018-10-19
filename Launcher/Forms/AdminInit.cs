using Launcher.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Launcher.Forms
{
    public partial class AdminInit : Form
    {
        private Dictionary<string, Server> _servers;
        public AdminInit()
        {
            this._servers = new Dictionary<string, Server>();
            InitializeComponent();
        }

        private void btnAddServer_Click(object sender, EventArgs e)
        {
            var error = false;
            if(string.IsNullOrEmpty(this.txtServerName.Text.Trim())) {
                this.txtServerName.BackColor = Color.Red;
                error = true;
            }

            if (string.IsNullOrEmpty(this.txtIp.Text.Trim()))
            {
                this.txtIp.BackColor = Color.Red;
                error = true;
            }

            int port = -1;
            if (string.IsNullOrEmpty(this.txtPort.Text.Trim()) || !int.TryParse(this.txtPort.Text, out port))
            {
                this.txtPort.BackColor = Color.Red;
                error = true;
            }

            if (error)
                return;

            this._servers.Add(this.txtServerName.Text.Trim(), new Server
            {
                IpOrDns = this.txtIp.Text.Trim(),
                Port = port
            });

            this.lstServers.Items.Add(this.txtServerName.Text.Trim());
            this.txtServerName.Text = "";
            this.txtPort.Text = "";
            this.txtIp.Text = "";
        }

        private void btnRemoveServer_Click(object sender, EventArgs e)
        {
            var selectedItem = (string)this.lstServers.SelectedItem;

            if (selectedItem == null)
                return;

            this.lstServers.Items.Remove(selectedItem);
            this._servers.Remove(selectedItem);
        }

        private void serverFields_KeyUp(object sender, KeyEventArgs e)
        {
            var caller = sender as TextBox;

            if (caller == null)
                return;

            caller.BackColor = Color.White;
        }

        private void hlpUpdaterFilesRoot_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Updater Files Root",
               "Some Info",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpUpdaterUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Updater Url",
               "Some Info",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpVersionInfoUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Version Info Url",
               "Some Info",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpVoteUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Vote Url",
               "Some Info",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpWebsiteUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Website Url",
               "Some Info",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpNewsUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("News Url",
               "Some Info",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpPublicKey_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Public Key",
               "Some Info",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }
    }
}
