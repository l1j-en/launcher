﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
    public partial class LauncherForm : Form
    {
        private readonly Dictionary<string, Server> _servers = new Dictionary<string, Server>
        {
            {
                "Resurrection", 
                new Server
                {
                    Ip = "198.58.107.60",
                    Port = 46838
                }
            },
            {
                "Resurrection Test", 
                new Server
                {
                    Ip = "24.99.243.145",
                    Port = 46838
                }
            }
        };

        public LauncherForm()
        {
            InitializeComponent();

            cmbServer.Items.AddRange(_servers.Keys.ToArray());
            cmbServer.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            this.CheckServerStatus(false);
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            var settings = Helpers.LoadSettings();

            if (settings.ClientDirectory == string.Empty || settings.ClientBin == string.Empty)
            {
                MessageBox.Show("You must select your lineage directory under settings before continuing.",
                   "Cannot continue!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
               

            var binFile = Path.GetFileNameWithoutExtension(settings.ClientBin);

            var selectedServer = this._servers[this.cmbServer.SelectedItem.ToString()];
            var ip = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(IPAddress.Parse(selectedServer.Ip).GetAddressBytes(), 0));

            Lineage.Run(settings.ClientDirectory, settings.ClientBin, ip, (ushort)selectedServer.Port);

            var revertResolution = new DevMode();

            if (settings.Resize)
                revertResolution = WindowStyling.ChangeDisplaySettings(settings.Resolution.Width, settings.Resolution.Height, 16);

            if(settings.Windowed)
                WindowStyling.SetWindowed(binFile);

            if (settings.Centred)
            {
                var windowSize = Screen.PrimaryScreen.WorkingArea;
                WindowStyling.SetCentred(binFile, windowSize.Width, windowSize.Height);
            }
                
            if(!settings.Resize)
                Application.Exit();

            //hide the form and start a thread that checks for lineage to close. When it does, set the window back to normal
            this.Hide();
            processChecker.RunWorkerAsync(revertResolution);
        }

        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblServerStatus.Text = "Pinging...";
            this.lblServerStatus.ForeColor = Color.Khaki;
            
            var statusThread = new Thread(() => this.CheckServerStatus(true)) {  IsBackground = true };
            statusThread.Start();
        }

        private void CheckServerStatus(bool threaded)
        {
            var host = string.Empty;
            var port = -1;

            //add a delay so the "pinging..." actually shows up. Otherwise it kind of looks
            //like it isn't trying to check
            if (threaded)
            {
                Thread.Sleep(1000);
                cmbServer.Invoke(new Action(
                    () =>
                    {
                        host = _servers[this.cmbServer.Text].Ip;
                        port = _servers[this.cmbServer.Text].Port;
                    }));
            }
            else
            {
                host = _servers[this.cmbServer.Text].Ip;
                port = _servers[this.cmbServer.Text].Port;
            }

            //should never happen, but let's handle it just in case
            if (host == string.Empty || port == -1)
                return;

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    var result = socket.BeginConnect(host, port, null, null);
                    result.AsyncWaitHandle.WaitOne(3000, true);

                    if (!socket.Connected)
                    {
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "Text", "Offline");
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "ForeColor", Color.Red);
                    }
                    else
                    {
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "Text", "Online");
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "ForeColor", Color.Green);
                    }
                }
                catch (Exception)
                {
                    Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "Text", "Offline");
                    Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "ForeColor", Color.Red);
                }
                finally
                {
                    socket.Close();
                } //end try/catch/finally
            } //end using
        } //end checkServerStatus

        private void processChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            var revertResolution = (DevMode)e.Argument;
            var settings = Helpers.LoadSettings();
            var bin = Path.GetFileNameWithoutExtension(settings.ClientBin);

            while (true)
            {
                if (!Helpers.CheckProcessRunning(bin))
                {
                    e.Cancel = true;
                    WindowStyling.ChangeDisplaySettings(ref revertResolution, 0);
                    Application.Exit();
                }
            }
        } //end processChecker_DoWork
    } //end class
} //end namespace
