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
            IPAddress ip;
            int port;

            if(txtName.Text.Trim() != string.Empty && IPAddress.TryParse(txtIpAddress.Text, out ip)
                && int.TryParse(txtPort.Text, out port))
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Invalid values in fields.");
        } //end btnAdd_Click
    } //end class
} //end namespace
