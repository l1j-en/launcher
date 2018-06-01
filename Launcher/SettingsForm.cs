/* This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc.,
 * 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 */
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Launcher.Models;

namespace Launcher
{
    public partial class SettingsForm : Form
    {
        private readonly bool _isWin8OrHigher;
        private readonly string _windowsVersion;
        private bool _initialLoad = true;
        private readonly LauncherConfig _config;
        private int _windowDelay = 500;
        private int _loginDelay = 500;

        public SettingsForm(LauncherConfig config, bool isWin8OrHigher, string windowsVersion)
        {
            InitializeComponent();
            this._config = config;
            this._isWin8OrHigher = isWin8OrHigher;
            this._windowsVersion = windowsVersion;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!Int32.TryParse(this.txtWinInjectionTiming.Text, out this._windowDelay) ||
                !Int32.TryParse(this.txtLoginInjectionTiming.Text, out this._loginDelay) ||
                this._windowDelay < 0 || this._windowDelay > 5000 || this._loginDelay < 0 || this._loginDelay > 5000)
            {
                MessageBox.Show("The Window and Login injection timing must be a number between 0 and 5000!",
                    "Invalid Injection Timing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var settings = new Settings
            {
                Resize = this.chkResize.Checked,
                ClientBin = this.cmbBin.Text,
                DisableDark = this.chkDisableDark.Checked,
                EnableMobColours = this.chkMobColours.Checked,
                MusicType = this.cmbMusic.SelectedItem.ToString(),
                UseProxy = this.chkUseProxy.Checked,
                DisableServerUpdate = !this.chkSyncServers.Checked,
                WindowedDelay = this._windowDelay,
                LoginDelay = this._loginDelay,
                DisableUnderwater = this.chkDisableUnderwater.Checked
            };

            settings.Resolution = this.chkResize.Checked ? (Resolution) this.cmbResolution.SelectedItem : null;
            settings.Windowed = this.chkWindowed.Checked;

            if (settings.ClientBin.Trim() == string.Empty || settings.ClientBin.Trim() == "No Client Directory Selected"
                || settings.ClientBin.Trim() == string.Empty)
            {
                MessageBox.Show(@"You must enter a client directory and select a bin to continue.", @"Invalid Settings",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
                
            Helpers.SaveSettings(this._config.KeyName, settings, this._config.InstallDir, this._isWin8OrHigher);
            this.Close();
        }

        private void chkResize_CheckedChanged(object sender, EventArgs e)
        {
            this.grpResolution.Enabled = this.chkResize.Checked;

            if (this.chkResize.Checked && this.cmbResolution.Text == string.Empty)
                this.cmbResolution.SelectedIndex = 0;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var savedSettings = Helpers.LoadSettings(this._config.KeyName) ?? new Settings(this._windowDelay);
            var resolutions = LineageClient.GetResolutions(this._isWin8OrHigher);

            if (resolutions.Count > 0)
            {
                this.cmbResolution.Items.AddRange(resolutions.ToArray());
                this.cmbResolution.SelectedIndex = savedSettings.Resolution == null
                    ? 0
                    : this.cmbResolution.FindString(savedSettings.Resolution.ToString());
            }
            else
            {
                MessageBox.Show("Unable to load screen resolutions. Screen resize is not available.", "No Resolutions Found", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.chkResize.Enabled = false;
            }

            this.chkResize.Checked = savedSettings.Resize;
            this.chkWindowed.Checked = savedSettings.Windowed;

            this.chkDisableDark.Checked = savedSettings.DisableDark;
            this.chkMobColours.Checked = savedSettings.EnableMobColours;
            this.chkDisableUnderwater.Checked = savedSettings.DisableUnderwater;

            this.chkUseProxy.Checked = savedSettings.UseProxy;

            if (!string.IsNullOrEmpty(savedSettings.ClientBin))
            {
                FindBins();

                this.cmbBin.Text = savedSettings.ClientBin;
            }
            else
                FindBins();
                
                
            if (string.IsNullOrEmpty(savedSettings.MusicType))
                this.cmbMusic.SelectedIndex = 0;
            else
                this.cmbMusic.SelectedIndex = this.cmbMusic.FindString(savedSettings.MusicType);

            this.txtLoginInjectionTiming.Text = savedSettings.LoginDelay.ToString();
            this.txtWinInjectionTiming.Text = savedSettings.WindowedDelay.ToString();
            this.chkSyncServers.Checked = !savedSettings.DisableServerUpdate;

            this._initialLoad = false;
        }

        private void FindBins()
        {
            var binFiles = Directory.GetFiles(this._config.InstallDir, "*.bin");
            this.cmbBin.Items.Clear();
            this.cmbBin.Items.AddRange(binFiles.Select(b => new ComboBoxItem { Text = Path.GetFileName(b), Value = b }).ToArray());

            var initialBinIndex = this.cmbBin.FindString("S3EP1.bin");

            if (initialBinIndex > -1)
                this.cmbBin.SelectedIndex = initialBinIndex;
        }

        private void chkWindowed_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.chkWindowed.Checked)
            {
                this.chkResize.Checked = false;
            }
            else
            {
                if (!this._initialLoad)
                {
                    if (MessageBox.Show(@"Any window moved frop the top left corner will not be able to take screenshots!" 
                            + "\n\nAre you sure you want to continue?", @"Continue?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    {
                        this.chkWindowed.Checked = false;
                    }

                    if (this._isWin8OrHigher)
                    {
                        if (MessageBox.Show(@"When you click save with this enabled, the launcher will write to the registry for the selected bin file forcing" +
                            @" it into 16 bit colours. This is required for Windows 8 or Higher. Do you wish to continue?", @"Continue?",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                            this.chkWindowed.Checked = false;
                    }
                }
            }
            
            if(this.cmbResolution.Items.Count > 0)
                this.chkResize.Enabled = this.chkWindowed.Checked;
        }

        private void picSyncHelp_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Server Sync", "This will stop the launcher from verifying your server information against the website.\n\n" + 
                "That means if we update the server IP or DNS, you will not be able to connect unless you re-enable this option!",
                new System.Drawing.Bitmap(Launcher.Properties.Resources.Help_Big)).ShowDialog();
        }

        private void picWinInjectionHelp_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Windowed Mode Injection Timing", 
                "The amount of time in milliseconds, the client waits after the window opens before injecting the Windowed Mode code.\n\n" +
                "Min Value: 0, Max Value: 5000, Default: 500",
                new System.Drawing.Bitmap(Launcher.Properties.Resources.Help_Big)).ShowDialog();
        }

        private void picLoginInjection_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Login Code Injection Timing",
                "The amount of time in milliseconds, the client waits after the Lineage process has started to inject the launcher code.\n\n" +
                "Min Value: 0, Max Value: 5000, Default: 500",
                new System.Drawing.Bitmap(Launcher.Properties.Resources.Help_Big)).ShowDialog();
        }

        private void pctExperimental_Click(object sender, EventArgs e)
        {
            new CustomMessageBox("Experimental Feature",
                "This feature is not fully supported and is used at your own risk.\n\n" +
                "It has been shown to fix swing lag for several users, but some have experienced issues.\n\n" +
                "Report bugs on zelgo.net.",
                new System.Drawing.Bitmap(Properties.Resources.Help_Big)).ShowDialog();
        }

        private void btn_manage_polies_Click(object sender, EventArgs e)
        {
            var polyDialog = new Polymorphs(this._config).ShowDialog();
        }

        private void btn_revert_poly_Click(object sender, EventArgs e)
        {
            var textFile = Path.Combine(this._config.InstallDir, "text.pak");
            var idxFile = textFile.Replace(".pak", ".idx");

            var originalTextPak = textFile.Replace("text.pak", "text.pak.original");
            var originalIdxPak = idxFile.Replace("text.idx", "text.idx.original");

            if (!File.Exists(originalTextPak) || !File.Exists(originalIdxPak))
            {
                MessageBox.Show(@"Unable to revert poly list. No backup found!", @"No Backup Found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(@"This will overwrite your custom poly list with the default. Continue?", @"Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                return;

            File.Copy(originalTextPak, textFile, true);
            File.Copy(originalIdxPak, idxFile, true);

            MessageBox.Show("Polymorph list reverted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
