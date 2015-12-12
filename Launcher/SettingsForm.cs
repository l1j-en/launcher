using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Launcher
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
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
                Resolution = this.chkResize.Checked ? (Resolution) this.cmbResolution.SelectedItem : null,
                Centred = this.chkCentre.Checked,
                Windowed = this.chkWindowed.Checked,
                Resize = this.chkResize.Checked,
                AutoPlay = this.chkAutoPlay.Checked,
                ClientDirectory = this.txtDirectory.Text,
                ClientBin = this.cmbBin.Text,
                DisableDark = this.chkDisableDark.Checked,
                MusicType = this.cmbMusic.SelectedItem.ToString()
            };

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
            this.cmbResolution.Items.Add(new Resolution
            {
                Width = 800,
                Height = 600,
                Colour = 16
            });

            var savedSettings = Helpers.LoadSettings();

            this.chkResize.Checked = savedSettings.Resize;
            this.chkWindowed.Checked = savedSettings.Windowed;
            this.chkCentre.Checked = savedSettings.Centred;
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
