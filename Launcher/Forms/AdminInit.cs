﻿using Launcher.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            var config = new LauncherConfig
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
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        }
    }
}
