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
using System.Windows.Forms;
using Launcher.Models;
using System.Linq;

namespace Launcher.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly LauncherConfig _config;

        public SettingsForm(LauncherConfig config)
        {
            InitializeComponent();
            this._config = config;
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
                DisableDark = this.chkDisableDark.Checked,
                EnableMobColours = this.chkMobColours.Checked,
                DisableUnderwater = this.chkDisableUnderwater.Checked,
                Windowed = this.rdioWindowed.Checked
            };

            foreach(RadioButton resolution in this.grpWindowSize.Controls)
            {
                if (resolution.Checked)
                    settings.WindowSize = resolution.Text.Replace(" ","").ToLower();
            }
                
            Helpers.SaveSettings(this._config.KeyName, settings, this._config.InstallDir, this._config.ConfigType);
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var savedSettings = Helpers.LoadSettings(
                this._config.ConfigType == ConfigType.Registry ? this._config.KeyName : this._config.InstallDir, 
                this._config.ConfigType) ?? new Settings();

            this.chkDisableDark.Checked = savedSettings.DisableDark;
            this.chkMobColours.Checked = savedSettings.EnableMobColours;
            this.chkDisableUnderwater.Checked = savedSettings.DisableUnderwater;
            this.rdioWindowed.Checked = savedSettings.Windowed;
            this.rdioFullscreen.Checked = !savedSettings.Windowed;

            if(!savedSettings.Windowed)
                ToggleResolutions(false);

            if (string.IsNullOrEmpty(savedSettings.WindowSize))
                this.rdio800x600.Checked = true;
            else
            {
                var resolution = this.grpWindowSize.Controls.Find($"rdio{savedSettings.WindowSize}", false);
                if (resolution.Length > 0)
                    ((RadioButton)resolution[0]).Checked = true;
            }
        }

        private void ToggleResolutions(bool enable)
        {
            foreach (RadioButton resolution in this.grpWindowSize.Controls)
                resolution.Enabled = enable;
        }

        private void rdioWindowed_CheckedChanged(object sender, EventArgs e)
        {
            ToggleResolutions(this.rdioWindowed.Checked);
        }
    }
}
