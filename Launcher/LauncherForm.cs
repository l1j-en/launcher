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
using Launcher.Models;
using Launcher.Utilities;
using Launcher.WindowsAPI;
using Microsoft.Win32;

namespace Launcher
{
    public partial class LauncherForm : Form
    {
        private const string Version = "1.5";
        private readonly bool _isWin8OrHigher;
        private User32.DevMode _revertResolution;

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

        private static readonly List<LineageClient> Clients = new List<LineageClient>(); 

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

            this._isWin8OrHigher = this._isWin8OrHigher = Helpers.IsWin8Orhigher();
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(this._isWin8OrHigher);
            settingsForm.ShowDialog();
            settingsForm.Dispose();
        }

        private void LauncherForm_Shown(object sender, EventArgs e)
        {
            var settings = Helpers.LoadSettings();

            if (settings == null)
            {
                MessageBox.Show(@"There was an error loading your settings. If this was after an update, it may be intentional, however, " +
                @"if it happens often please file a bug report.", @"Error Loading Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                settings = new Settings();
            }
                
            if (string.IsNullOrEmpty(settings.ClientDirectory))
            {
                var settingsDialog = new SettingsForm(this._isWin8OrHigher);
                var dialogResult = settingsDialog.ShowDialog();

                if (dialogResult != DialogResult.OK)
                {
                    settings = Helpers.LoadSettings();

                    if (settings == null || string.IsNullOrEmpty(settings.ClientDirectory))
                    {
                        MessageBox.Show("You must configure your settings before continuing. Closing launcher.");
                        Application.Exit();
                    } //end if
                } //end if
            } //end if

            this.updateChecker.RunWorkerAsync();

            cmbServer.Items.AddRange(this._servers.Keys.ToArray());
            cmbServer.SelectedIndex = 0;
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
                revertResolution = LineageClient.ChangeDisplaySettings(settings.Resolution.Width, settings.Resolution.Height, settings.Resolution.Colour);
            else if (settings.Windowed)
                revertResolution = LineageClient.ChangeDisplayColour(this._isWin8OrHigher ? 32 : 16);

            Lineage.Run(settings, settings.ClientBin, ip, (ushort)selectedServer.Port);

            var client = new LineageClient(binFile, settings.ClientDirectory, Clients);
            client.Initialize();
                
            if (settings.Centred)
            {
                var windowSize = Screen.PrimaryScreen.WorkingArea;
                client.SetCentred(windowSize.Width, windowSize.Height);
            }

            lock (this._lockObject)
                Clients.Add(client);

            if (!tmrCheckProcess.Enabled)
            {
                this._revertResolution = revertResolution;
                this.tmrCheckProcess.Enabled = true;
            }
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
                Thread.Sleep(500);
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
                this.cmbServer.SelectedIndex = cmbServer.Items.Count - 1;
            } //end if
        } //end LauncherForm_KeyDown

        private void updateChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var force = e.Argument != null && (bool) e.Argument;
                var versionInfo = Helpers.GetVersionInfo();
                var launcherKey = Registry.CurrentUser.OpenSubKey(@"Software\LineageLauncher", true);
                var lastUpdatedCheck = launcherKey.GetValue("LastUpdated");
                var updatesLastRun = (int?) lastUpdatedCheck ?? 0;

                if (versionInfo == null)
                    return;

                var settings = Helpers.LoadSettings();
                var applicationPath = Application.ExecutablePath;
                var appDataPath = Directory.GetParent(Application.UserAppDataPath).ToString();
                var updaterLocation = Path.Combine(appDataPath, "Updater.exe");
                var updaterChecksum = Helpers.GetChecksum(updaterLocation);

                if (!File.Exists(updaterLocation) || updaterChecksum != versionInfo.FileChecksums["Updater.exe"])
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += client_DownloadProgressChanged;
                        client.DownloadFileAsyncSync(new Uri("http://launcher.travis-smith.ca/Updater.exe"),
                            updaterLocation);
                    }

                    this.updateChecker.ReportProgress(1);
                } //end if

                if (versionInfo.Version != Version)
                {
                    var result = DialogResult.Cancel;

                    // push to the UI thread to actually display the dialog... ugly hack
                    var dialog = this.BeginInvoke(new MethodInvoker(delegate
                    {
                        result = new UpdateForm(versionInfo).ShowDialog();
                    }));

                    this.EndInvoke(dialog);

                    if (result == DialogResult.OK)
                    {
                        var info = new ProcessStartInfo(updaterLocation);
                        info.Arguments = "\"" + applicationPath + "\"";

                        if (Environment.OSVersion.Version.Major >= 6)
                            info.Verb = "runas";

                        Process.Start(info);
                    } //end if
                } //end if

                if (versionInfo.LastUpdated < updatesLastRun && !force)
                    return;

                // checks for > 1 because the Updater.exe is always present.
                if (versionInfo.FileChecksums != null && versionInfo.FileChecksums.Count > 1)
                {
                    Helpers.SetControlPropertyThreadSafe(this.prgUpdates, "Maximum", versionInfo.FileChecksums.Count);

                    for (var i = 1; i < versionInfo.FileChecksums.Count; i++)
                    {
                        var file = versionInfo.FileChecksums.ElementAt(i).Key;
                        var checksum = versionInfo.FileChecksums.ElementAt(i).Value;
                        var filePath = Path.Combine(settings.ClientDirectory, file);

                        if (!File.Exists(filePath) || Helpers.GetChecksum(filePath) != checksum)
                        {
                            var extension = Path.GetExtension(file);
                            using (var client = new WebClient())
                            {
                                client.DownloadProgressChanged += client_DownloadProgressChanged;

                                if (File.Exists(filePath) && extension != null
                                    && extension.Equals(".pak", StringComparison.CurrentCultureIgnoreCase) &&
                                    !file.Contains("zelgo"))
                                {
                                    var idxFile = filePath.Replace(".pak", ".idx");
                                    var pakIndex = PakTools.RebuildPak(filePath, versionInfo.PakFiles[file], true);

                                    PakTools.RebuildIndex(idxFile, pakIndex, true);
                                }
                                else
                                {
                                    client.DownloadFileAsyncSync(
                                        new Uri("http://launcher.travis-smith.ca/Files/" + file.Replace("\\", "/")),
                                        filePath);
                                }
                            }
                        }

                        this.updateChecker.ReportProgress(i);
                    } //end for

                    var currentTime = DateTime.UtcNow - new DateTime(1970, 1, 1);
                    launcherKey.SetValue("LastUpdated", (int) currentTime.TotalSeconds, RegistryValueKind.DWord);
                } //end if
            }
            finally
            {
                this.updateChecker.ReportProgress(this.prgUpdates.Maximum);
            } //end try/finally
        } //end updateChecker

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Helpers.SetControlPropertyThreadSafe(this.prgUpdateCurrent, "Maximum" , (int)e.TotalBytesToReceive / 100);
            Helpers.SetControlPropertyThreadSafe(this.prgUpdateCurrent, "Value", (int)e.BytesReceived / 100);
        } //end client_DownloadProgressChanged

        private void updateChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.btnPlay.Enabled = true;
            this.btnCheck.Enabled = true;
        } //end updateChecker_RunWorkerCompleted

        private void updateChecker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.prgUpdates.Value = e.ProgressPercentage;
        } //end updateChecker_updateChecker_ProgressChanged

        private void btnCheck_Click(object sender, EventArgs e)
        {
            this.btnCheck.Enabled = false;
            this.updateChecker.RunWorkerAsync(true);
        } //end btnCheck_Click

        private void tmrCheckProcess_Tick(object sender, EventArgs e)
        {
            var revertResolution = this._revertResolution;
            lock (this._lockObject)
            {
                for (var i = Clients.Count - 1; i >= 0; i--)
                {
                    try
                    {
                        var runningProcess = Process.GetProcessById(Clients[i].Process.Id);
                    }
                    catch (Exception)
                    {
                        Clients.RemoveAt(i);
                    }
                }

                if (Clients.Count == 0)
                {
                    this.tmrCheckProcess.Enabled = false;
                    LineageClient.ChangeDisplaySettings(revertResolution);
                    return;
                }
            }
        } 
    } //end class
} //end namespace
