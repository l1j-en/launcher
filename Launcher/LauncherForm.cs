using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using Launcher.WindowsAPI;

namespace Launcher
{
    public partial class LauncherForm : Form
    {
        private const string Version = "1.2";
        private VersionInfo _versionInfo;

        private readonly object _lockObject = new object();
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

        private static readonly List<int> HookedProcIds = new List<int>(); 

        public LauncherForm()
        {
            if (this._servers == null || this._servers.Count == 0)
            {
                MessageBox.Show(@"No servers configured, contact your server admin. Closing launcher.", @"No Servers Found", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Load += (s, e) =>
                {
                    this.Close(); 
                    Application.Exit(); 
                };
            }

            InitializeComponent();
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
            //TODO -- maybe I want to thread this in the future to stop the UI freeze?
            //TODO -- 2 seconds doesn't seem too bad so far
            this._versionInfo = Helpers.GetVersionInfo();

            cmbServer.Items.AddRange(this._servers.Keys.ToArray());
            cmbServer.SelectedIndex = 0;
            
            var settings = Helpers.LoadSettings();
            var serverOnline = this.CheckServerStatus(false);

            if (!settings.AutoPlay || ModifierKeys == Keys.Control
                || (this._versionInfo != null && Version != this._versionInfo.Version))
                return;

            if (!serverOnline)
            {
                MessageBox.Show("Did not auto play because server is offline.");
                return;
            }

            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;

            this.Launch();
        }

        private void LauncherForm_Shown(object sender, EventArgs e)
        {
            if (this._versionInfo != null && Version != this._versionInfo.Version)
                new UpdateForm(this._versionInfo).ShowDialog();

            if (this._versionInfo != null && this._versionInfo.Required)
                Application.Exit();
        } 

        private void playButton_Click(object sender, EventArgs e)
        {
            this.Launch();
        }

        private void Launch()
        {
            var settings = Helpers.LoadSettings();

            if (settings.ClientDirectory == string.Empty || settings.ClientBin == string.Empty)
            {
                MessageBox.Show(@"You must select your lineage directory under settings before continuing.",
                   @"Cannot continue!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            var binFile = Path.GetFileNameWithoutExtension(settings.ClientBin);

            var selectedServer = this._servers[this.cmbServer.SelectedItem.ToString()];
            var ip = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(IPAddress.Parse(selectedServer.Ip).GetAddressBytes(), 0));

            var revertResolution = new User32.DevMode();

            if (settings.Resize)
                revertResolution = WindowStyling.ChangeDisplaySettings(settings.Resolution.Width, settings.Resolution.Height, 16);
            else if(settings.Windowed)
                revertResolution = WindowStyling.ChangeDisplayColour(16);

            Lineage.Run(settings, settings.ClientBin, ip, (ushort)selectedServer.Port);

            var hookedProcId = -1;

            if (settings.Windowed)
                lock (this._lockObject)
                    hookedProcId = WindowStyling.SetWindowed(binFile, HookedProcIds);
                
            if (settings.Centred)
            {
                var windowSize = Screen.PrimaryScreen.WorkingArea;
                hookedProcId = WindowStyling.SetCentred(binFile, windowSize.Width, windowSize.Height, hookedProcId);
            }

            if(hookedProcId != -1)
                lock (this._lockObject)
                    HookedProcIds.Add(hookedProcId);

            if(!this.processChecker.IsBusy)
                this.processChecker.RunWorkerAsync(revertResolution);
        }

        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblServerStatus.Text = @"PINGING...";
            this.lblServerStatus.ForeColor = Color.Khaki;
            
            var statusThread = new Thread(() => this.CheckServerStatus(true)) {  IsBackground = true };
            statusThread.Start();
        }

        private bool CheckServerStatus(bool threaded)
        {
            var returnValue = false;

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
                        host = this._servers[this.cmbServer.Text].Ip;
                        port = this._servers[this.cmbServer.Text].Port;
                    }));
            }
            else
            {
                host = this._servers[this.cmbServer.Text].Ip;
                port = this._servers[this.cmbServer.Text].Port;
            }

            //should never happen, but let's handle it just in case
            if (host == string.Empty || port == -1)
                return false;

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    var result = socket.BeginConnect(host, port, null, null);
                    result.AsyncWaitHandle.WaitOne(2000, true);

                    if (!socket.Connected)
                    {
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "Text", "OFFLINE");
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "ForeColor", Color.Red);
                    }
                    else
                    {
                        returnValue = true;
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "Text", "ONLINE");
                        Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "ForeColor", Color.Green);
                    }
                }
                catch (Exception)
                {
                    Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "Text", "OFFLINE");
                    Helpers.SetControlPropertyThreadSafe(this.lblServerStatus, "ForeColor", Color.Red);
                }
                finally
                {
                    socket.Close();
                } //end try/catch/finally
            } //end using

            return returnValue;
        } //end checkServerStatus

        private void processChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            var revertResolution = (User32.DevMode)e.Argument;
            
            while (true)
            {
                lock (this._lockObject)
                {
                    for (var i = HookedProcIds.Count - 1; i >= 0; i--)
                    {
                        try
                        {
                            var runningProcess = Process.GetProcessById(HookedProcIds[i]);
                        }
                        catch (Exception)
                        {
                            WindowStyling.Listeners.Remove(HookedProcIds[i]);
                            HookedProcIds.RemoveAt(i);
                        }
                    }

                    if (HookedProcIds.Count == 0)
                    {
                        e.Cancel = true;
                        WindowStyling.ChangeDisplaySettings(revertResolution);
                        return;
                    }
                }
            }
        } //end processChecker_DoWork

        private void pctVote_Click(object sender, EventArgs e)
        {
            var voteUrl = new ProcessStartInfo("http://lineage.extreme-gamerz.org/in.php?id=soren");
            Process.Start(voteUrl);
        } //end pctVote_Click

        private void pctLinLogo_Click(object sender, EventArgs e)
        {
            var voteUrl = new ProcessStartInfo("https://zelgo.net");
            Process.Start(voteUrl);
        }//end pctLinLogo_Click

        private void LauncherForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || !e.Shift || e.KeyCode != Keys.A)
                return;

            var addServerForm = new AddServerForm();

            if (addServerForm.ShowDialog() == DialogResult.OK)
            {
                this._servers.Add(addServerForm.txtName.Text, new Server
                {
                    Ip = addServerForm.txtIpAddress.Text,
                    Port = Convert.ToInt32(addServerForm.txtPort.Text)
                });

                this.cmbServer.Items.Add(addServerForm.txtName.Text);
            } //end if
        }  //end LauncherForm_KeyDown
    } //end class
} //end namespace
