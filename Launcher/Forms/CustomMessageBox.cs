using System.Drawing;
using System.Windows.Forms;

namespace Launcher.Forms
{
    public partial class CustomMessageBox : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        private const int Window_Growth_Height = 60;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public CustomMessageBox(string title, string message, Image icon = null)
        {
            InitializeComponent();

            this.icon.Image = icon ?? SystemIcons.Information.ToBitmap();
            this.Text = title;
            this.lblMessage.Text = message;
            if(this.lblMessage.Height > Window_Growth_Height)
            {
                var heightAdjustment = this.lblMessage.Height - Window_Growth_Height;
                this.panel1.Height += heightAdjustment;
                this.Height += heightAdjustment;
                this.btnOk.Top += heightAdjustment;
            }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
