namespace Launcher
{
    partial class UpdateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.lblUpdateVersion = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.updateDetails = new System.Windows.Forms.WebBrowser();
            this.btnClose = new Launcher.GlassButton();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(43, 206);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(166, 13);
            this.lblUpdate.TabIndex = 0;
            this.lblUpdate.Text = "You can get the latest version at: ";
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(204, 206);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(230, 13);
            this.lblLink.TabIndex = 1;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "https://github.com/smith-j-travis/Launcher/wiki";
            this.lblLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLink_LinkClicked);
            // 
            // lblUpdateVersion
            // 
            this.lblUpdateVersion.AutoSize = true;
            this.lblUpdateVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblUpdateVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblUpdateVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUpdateVersion.Location = new System.Drawing.Point(12, 6);
            this.lblUpdateVersion.Name = "lblUpdateVersion";
            this.lblUpdateVersion.Size = new System.Drawing.Size(119, 15);
            this.lblUpdateVersion.TabIndex = 3;
            this.lblUpdateVersion.Text = "Update Available!";
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.updateDetails);
            this.grpDetails.Location = new System.Drawing.Point(15, 30);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(458, 165);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Details";
            // 
            // updateDetails
            // 
            this.updateDetails.IsWebBrowserContextMenuEnabled = false;
            this.updateDetails.Location = new System.Drawing.Point(7, 15);
            this.updateDetails.MinimumSize = new System.Drawing.Size(20, 20);
            this.updateDetails.Name = "updateDetails";
            this.updateDetails.ScrollBarsEnabled = false;
            this.updateDetails.Size = new System.Drawing.Size(443, 143);
            this.updateDetails.TabIndex = 0;
            this.updateDetails.WebBrowserShortcutsEnabled = false;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnClose.Image = global::Launcher.Properties.Resources.close;
            this.btnClose.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(470, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.OuterBorderColor = System.Drawing.Color.Silver;
            this.btnClose.ShineColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(20, 22);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(497, 228);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.lblUpdateVersion);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lblUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Available!";
            this.grpDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.LinkLabel lblLink;
        private GlassButton btnClose;
        private System.Windows.Forms.Label lblUpdateVersion;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.WebBrowser updateDetails;
    }
}