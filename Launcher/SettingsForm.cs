using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Launcher
{
    public partial class SettingsForm : Form
    {
        private readonly bool _isWin8OrHigher;

        public SettingsForm()
        {
            InitializeComponent();

            this._isWin8OrHigher = Helpers.IsWin8Orhigher();
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
                AutoPlay = this.chkAutoPlay.Checked,
                ClientDirectory = this.txtDirectory.Text,
                ClientBin = this.cmbBin.Text,
                DisableDark = this.chkDisableDark.Checked,
                MusicType = this.cmbMusic.SelectedItem.ToString()
            };

            if (!this._isWin8OrHigher)
            {
                settings.Resolution = this.chkResize.Checked ? (Resolution) this.cmbResolution.SelectedItem : null;
                settings.Centred = this.chkCentre.Checked;
                settings.Windowed = this.chkWindowed.Checked;
            }

            if (settings.ClientBin.Trim() == string.Empty || settings.ClientBin.Trim() == "No Client Directory Selected"
                || settings.ClientBin.Trim() == string.Empty)
            {
                MessageBox.Show(@"You must enter a client directory and select a bin to continue.", @"Invalid Settings",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
                
            Helpers.SaveSettings(settings);
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
            var savedSettings = Helpers.LoadSettings();

            if (!this._isWin8OrHigher)
            {
                this.cmbResolution.Items.AddRange(WindowStyling.GetResolutions().ToArray());
                this.chkResize.Checked = savedSettings.Resize;
                this.chkWindowed.Checked = savedSettings.Windowed;
                this.chkCentre.Checked = savedSettings.Centred;

                if (savedSettings.Resolution != null)
                    this.cmbResolution.SelectedIndex = savedSettings.Resolution == null ? 0 : this.cmbResolution.FindString(savedSettings.Resolution.ToString());
            }
            else
            {
                foreach (Control control in this.grpWindowed.Controls)
                    control.Visible = false;

                var win8Label = new Label();
                win8Label.Top = 30;
                win8Label.Left = 10;
                win8Label.TextAlign  = ContentAlignment.MiddleCenter;
                win8Label.Dock = DockStyle.Fill;
                win8Label.Font = new Font(win8Label.Font, FontStyle.Bold);
                win8Label.ForeColor = Color.Red;
                win8Label.Text = "Windowed mode is not supported\n in Windows 8 or above.";

                this.grpWindowed.Controls.Add(win8Label);
            }
                
            this.chkAutoPlay.Checked = savedSettings.AutoPlay;
            this.chkDisableDark.Checked = savedSettings.DisableDark;
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
            
            this.chkResize.Enabled = this.chkWindowed.Checked;
            this.chkCentre.Enabled = this.chkWindowed.Checked;
        }
    }
}
