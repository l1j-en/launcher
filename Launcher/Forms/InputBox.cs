using System;
using System.Windows.Forms;

namespace Launcher.Forms
{
    public partial class InputBox : Form
    {
        public string Input { get; private set; }

        public InputBox(string prompt)
        {
            InitializeComponent();

            this.lbl_prompt.Text = prompt + ":";
            btn_ok.DialogResult = DialogResult.OK;
            btn_cancel.DialogResult = DialogResult.Cancel;
            btnClose.DialogResult = DialogResult.Cancel;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Input = this.txt_input.Text;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
