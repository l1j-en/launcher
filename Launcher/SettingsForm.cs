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
        private bool _initialLoad = true;

        public SettingsForm(bool isWin8OrHigher)
        {
            InitializeComponent();
            this._isWin8OrHigher = isWin8OrHigher;
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
            var settings = new Settings
            {
                Resize = this.chkResize.Checked,
                ClientDirectory = this.txtDirectory.Text,
                ClientBin = this.cmbBin.Text,
                DisableDark = this.chkDisableDark.Checked,
                EnableMobColours = this.chkMobColours.Checked,
                MusicType = this.cmbMusic.SelectedItem.ToString()
            };

            settings.Resolution = this.chkResize.Checked ? (Resolution) this.cmbResolution.SelectedItem : null;
            settings.Centred = this.chkCentre.Checked;
            settings.Windowed = this.chkWindowed.Checked;

            if (settings.ClientBin.Trim() == string.Empty || settings.ClientBin.Trim() == "No Client Directory Selected"
                || settings.ClientBin.Trim() == string.Empty)
            {
                MessageBox.Show(@"You must enter a client directory and select a bin to continue.", @"Invalid Settings",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
                
            Helpers.SaveSettings(settings, this._isWin8OrHigher);
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
            var savedSettings = Helpers.LoadSettings() ?? new Settings();

            this.cmbResolution.Items.AddRange(LineageClient.GetResolutions(this._isWin8OrHigher).ToArray());
            this.chkResize.Checked = savedSettings.Resize;
            this.chkWindowed.Checked = savedSettings.Windowed;
            this.chkCentre.Checked = savedSettings.Centred;

            if (savedSettings.Resolution != null)
                this.cmbResolution.SelectedIndex = savedSettings.Resolution == null ? 0 : this.cmbResolution.FindString(savedSettings.Resolution.ToString());
                
            this.chkDisableDark.Checked = savedSettings.DisableDark;
            this.chkMobColours.Checked = savedSettings.EnableMobColours;
            this.txtDirectory.Text = savedSettings.ClientDirectory ?? "";

            if (this.txtDirectory.Text != string.Empty)
            {
                FindBins();

                this.cmbBin.Text = savedSettings.ClientBin;
            }
            else
                this.cmbBin.SelectedIndex = 0;
                
            if (string.IsNullOrEmpty(savedSettings.MusicType))
                this.cmbMusic.SelectedIndex = 0;
            else
                this.cmbMusic.SelectedIndex = this.cmbMusic.FindString(savedSettings.MusicType);

            this._initialLoad = false;
        }

        private void btnDirectory_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            this.txtDirectory.Text = folderBrowserDialog.SelectedPath;
            this.FindBins();
        }

        private void FindBins()
        {
            var binFiles = Directory.GetFiles(this.txtDirectory.Text, "*.bin");
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
                this.chkCentre.Checked = false;
            }
            else if (this._isWin8OrHigher && !this._initialLoad)
            {
                if (MessageBox.Show(@"When you click save with this enabled, the launcher will write to the registry for the selected bin file forcing" + 
                    @" it into 16 bit colours. This is required for Windows 8 or Higher. Do you wish to continue?", @"Continue?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                    this.chkWindowed.Checked = false;
            }
            
            this.chkResize.Enabled = this.chkWindowed.Checked;
            this.chkCentre.Enabled = this.chkWindowed.Checked;
        }
    }
}
