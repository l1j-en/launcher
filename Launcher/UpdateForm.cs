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

namespace Launcher
{
    public partial class UpdateForm : Form
    {
        public UpdateForm(VersionInfo versionInfo)
        {
            InitializeComponent();

            this.lblUpdateVersion.Text = string.Format("Upgrade to version {0}!", versionInfo.Version);
            this.updateDetails.DocumentText = versionInfo.VersionDetails;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLater_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
