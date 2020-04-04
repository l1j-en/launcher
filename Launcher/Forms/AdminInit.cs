using Launcher.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;

namespace Launcher.Forms
{
    public partial class AdminInit : Form
    {
        private Dictionary<string, Server> _servers;
        private readonly string _appDirectory;

        public AdminInit(string appDirectory)
        {
            this._servers = new Dictionary<string, Server>();
            this._appDirectory = appDirectory;
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
               "This is the root path for the updater. It is combined with the files listed in VersionInfo to download the file from your webserver.\n\n" +
               "Example: Your Updater Files Root value is http://updates.launcher.com, and you have a file Text.pak, it would download a file from http://updates.launcher.com/Text.pak",
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
               "This is the URL that returns the version information. It gives the data the launcher reads to know what updates it needs to apply to the user's system. \n\n" + 
               "Leave this blank if you do not wish to push updates.",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpVoteUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Vote Url",
               "This is the vote URL the icon at the bottom left will go to. Typically linked to lineage.extreme-gamerz.org.\n\n" + 
               "Leave this blank and the vote icon will not appear.",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpWebsiteUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Website Url",
               "The server website. Clicking on the 'Lineage' logo at the top left will bring you there.\n\n" + 
               "Leave this blank if you do not want the logo to link anywhere.",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpNewsUrl_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("News Url",
               "The website to load up in the news section.\n\n" + 
               "Leave this blank and the news section will not appear.",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void hlpPublicKey_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Public Key",
               "This is the key used to verify the data came from the expected server. It means if someone hacks the user's machine, the launcher won't pull down dangerous files.\n\n" + 
               "Leave this blank if you don't want the data to be verified",
               new Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            LauncherConfig config;
            try
            {
                config = new LauncherConfig
                {
                    Servers = this._servers,
                    NewsUrl = this.txtNewsUrl.Text.Trim() == string.Empty ? null : new Uri(this.txtNewsUrl.Text.Trim()),
                    UpdaterUrl = this.txtUpdaterUrl.Text.Trim() == string.Empty ? null : new Uri(this.txtUpdaterUrl.Text.Trim()),
                    VersionInfoUrl = this.txtVersionInfoUrl.Text.Trim() == string.Empty ? null : new Uri(this.txtVersionInfoUrl.Text.Trim()),
                    VoteUrl = this.txtVoteUrl.Text.Trim() == string.Empty ? null : new Uri(this.txtVoteUrl.Text.Trim()),
                    WebsiteUrl = this.txtWebsiteUrl.Text.Trim() == string.Empty ? null : new Uri(this.txtWebsiteUrl.Text.Trim()),
                    UpdaterFilesRoot = this.txtUpdaterFilesRoot.Text.Trim() == string.Empty ? null : new Uri(this.txtUpdaterFilesRoot.Text.Trim()),
                    PublicKey = this.txtPublicKey.Text.Trim() == string.Empty ? null : this.txtPublicKey.Text.Trim()
                };
            }
            catch(UriFormatException)
            {
                MessageBox.Show("Unable to save. Invalid URL entered.", "Invalid URL",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!config.Servers.Any())
            {
                MessageBox.Show("Unable to save. No servers entered!", "No Servers",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var fs = new FileStream(
                Path.Combine(this._appDirectory, "l1jLauncher.cfg"),
                FileMode.OpenOrCreate,
                FileAccess.Write))
            {
                using (var ms = new MemoryStream())
                {
                    var serializer = new DataContractJsonSerializer(config.GetType(),
                        new List<Type> { typeof(Server) });

                    serializer.WriteObject(ms, config);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    var bytes = new byte[ms.Length];
                    ms.Read(bytes, 0, (int)ms.Length);

                    // To anyone using this, this is not any form of encryption or security!
                    // This is only being done so the average user won't try to edit it and
                    // possibly crap out their settings!
                    var base64Bytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(bytes));
                    fs.Write(base64Bytes, 0, base64Bytes.Length);
                }
            }

            MessageBox.Show("l1jLauncher.cfg created successfully. Open the launcher again to play!", "Config Saved!",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
