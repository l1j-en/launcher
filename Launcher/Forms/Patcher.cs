using System;
using System.Windows.Forms;
using Launcher.Models;
using System.Collections.Generic;
using Launcher.Utilities;
using System.IO;
using Launcher.Controls;
using System.Drawing;
using System.Net;
using System.Linq;
using System.ComponentModel;
using System.Threading;

namespace Launcher.Forms
{
    public partial class Patcher : Form
    {
        private readonly LauncherConfig _config;
        private readonly bool _force;
        private bool _hadUpdates;

        public static Dictionary<string, string> PatchDirectories {
            get {
                return new Dictionary<string, string>
                {
                    { "text", "text.pak" }
                };
            }
        }

        public Patcher(LauncherConfig config, bool hasUpdates, bool force = false)
        {
            this._config = config;
            this._force = force;
            var patchFiles = false;

            foreach (var path in Patcher.PatchDirectories.Keys)
            {
                if (Directory.GetFiles(Path.Combine(this._config.InstallDir, path)).Length > 0)
                {
                    patchFiles = true;
                    break;
                }
            }

            if (!patchFiles && !hasUpdates)
            {
                this.Close();
                return;
            }

            InitializeComponent();
            Region = Region.FromHrgn(Win32Api.CreateRoundRectRgn(0, 0, Width, Height, 8, 8));
            this.updateChecker.RunWorkerAsync(force);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(this.updateChecker.IsBusy)
            {
                this.updateChecker.CancelAsync();
            }
            
            if(patchWorker.IsBusy)
            {
                this.patchWorker.CancelAsync();
            }
            
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var borderPath = RoundedRectangle.Create(2, 2, this.Width - 5, this.Height - 5);
            using (var borderPen = new Pen(Brushes.White))
            {
                borderPen.Width = 2;
                e.Graphics.DrawPath(borderPen, borderPath);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var versionInfo = Helpers.GetVersionInfo(this._config.VersionInfoUrl, this._config.PublicKey);
                var force = e.Argument != null && (bool)e.Argument;

                if (versionInfo == null)
                    return;

                var settings = Helpers.LoadSettings(this._config.InstallDir);
                var updatesLastRun = settings.LastUpdateCheck;

                var appDataPath = Directory.GetParent(Application.UserAppDataPath).ToString();
                var updaterLocation = Path.Combine(appDataPath, "Updater.exe");

                if (this._config.UpdaterUrl != null && (!File.Exists(updaterLocation) || versionInfo.Files["Updater.exe"].Updated > updatesLastRun))
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += client_DownloadProgressChanged;
                        client.DownloadFileAsyncSync(new Uri(this._config.UpdaterUrl.ToString()),
                            updaterLocation);
                    }

                    this.updateChecker.ReportProgress(1);
                } //end if

                var filesToUpdate = versionInfo.Files.Where(b => (b.Value.Updated > updatesLastRun || force)
                                                    && b.Key != "Updater.exe").ToList();
                
                if (filesToUpdate.Any())
                {
                    Helpers.SetControlPropertyThreadSafe(this.prgTotal, "Maximum", filesToUpdate.Count);

                    for (var i = 0; i < filesToUpdate.Count; i++)
                    {
                        var file = filesToUpdate.ElementAt(i);
                        var filePath = Path.Combine(this._config.InstallDir, file.Key);
                        var localChecksum = Helpers.GetChecksum(filePath);

                        if (localChecksum != file.Value.Checksum)
                        {
                            using (var client = new WebClient())
                            {
                                client.DownloadProgressChanged += client_DownloadProgressChanged;
                                client.DownloadFileAsyncSync(
                                    new Uri(this._config.UpdaterFilesRoot + file.Key.Replace("\\", "/")),
                                    filePath);
                            }
                        }

                        this.updateChecker.ReportProgress(i);
                    } //end for

                    Helpers.SetLastUpdated(this._config.InstallDir);
                } //end if
            }
            finally
            {
                this.updateChecker.ReportProgress(this.prgTotal.Maximum);
            } //end try/finally
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
             Helpers.SetControlPropertyThreadSafe(this.prgCurrent, "Maximum" , (int)e.TotalBytesToReceive / 100);
             Helpers.SetControlPropertyThreadSafe(this.prgCurrent, "Value", (int)e.BytesReceived / 100);
        } //end client_DownloadProgressChanged

        private void updateChecker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // if we did any updates to the progress, then it had files to download, so set the flag
            if (e.ProgressPercentage < this.prgTotal.Maximum)
                this._hadUpdates = true;

             this.prgTotal.Value = e.ProgressPercentage;
        } //end updateChecker_updateChecker_ProgressChanged

        private void updateChecker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblUpdateStatus.Text = "Patching files...";
            this.prgTotal.Value = 0;
            this.patchWorker.RunWorkerAsync();
        }

        private void patchWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (var directory in PatchDirectories.Keys)
            {
                var filesToPack = new List<PakFile>();
                var directoryString = Path.Combine(this._config.InstallDir, directory);

                var filePaths = Directory.GetFiles(directoryString);
                foreach (var filePath in filePaths)
                {
                    filesToPack.Add(new PakFile
                    {
                        FileName = filePath,
                        Content = File.ReadAllText(filePath)
                    });
                }

                Helpers.SetControlPropertyThreadSafe(this.prgCurrent, "Maximum", filesToPack.Count);
                Helpers.SetControlPropertyThreadSafe(this.prgTotal, "Maximum", PatchDirectories.Keys.Count);

                if(filesToPack.Any())
                {
                    PakTools.RebuildPak(Path.Combine(this._config.InstallDir, PatchDirectories[directory]),
                    filesToPack,
                    true,
                    (progress) =>
                    {
                        this.patchWorker.ReportProgress(progress);
                    });
                }

                var directoryInfo = new DirectoryInfo(directoryString);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();
                }
            }

            Helpers.SetControlPropertyThreadSafe(this.prgTotal, "Value", PatchDirectories.Keys.Count);
        }

        private void patchWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.prgCurrent.Value = e.ProgressPercentage;
        }

        private void patchWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblUpdateStatus.Text = "Patching Complete!" + (this._force ? "" : " Launching game...");

            if (!this._hadUpdates)
                this.lblUpdateStatus.Text = "Nothing to update!" + (this._force ? "" : " Launching game...");

            // wait 1 second after the worker has completed so the progress bar updates
            var closeThread = new Thread(() =>
            {
                Thread.Sleep(1000);

                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }) { IsBackground = true };
            closeThread.Start();
        }
    }
}
