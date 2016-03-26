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
using System.Net;
using System.Windows.Forms;

namespace Launcher
{
    public partial class AddServerForm : Form
    {
        public AddServerForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IPAddress ip = null;
            int port;

            try
            {
                ip = Dns.GetHostAddresses(txtIpAddress.Text)[0];
            } catch (Exception){ }

            if(txtName.Text.Trim() != string.Empty && ip != null
                && int.TryParse(txtPort.Text, out port))
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Invalid values in fields.");
        } //end btnAdd_Click
    } //end class
} //end namespace
