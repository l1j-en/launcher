using Launcher.Controls;

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
            this.lblUpdateVersion = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.updateDetails = new System.Windows.Forms.WebBrowser();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnLater = new Launcher.Controls.GlassButton();
            this.btnUpdate = new Launcher.Controls.GlassButton();
            this.btnClose = new Launcher.Controls.GlassButton();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
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
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(40, 200);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(416, 32);
            this.lblNote.TabIndex = 27;
            this.lblNote.Text = "Note*: Updates to the launcher itself will close the launcher.\r\nIt will re-open w" +
    "hen the update is complete!";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLater
            // 
            this.btnLater.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLater.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLater.GlowColor = System.Drawing.Color.Red;
            this.btnLater.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnLater.Location = new System.Drawing.Point(392, 243);
            this.btnLater.Name = "btnLater";
            this.btnLater.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnLater.ShineColor = System.Drawing.Color.Transparent;
            this.btnLater.Size = new System.Drawing.Size(93, 32);
            this.btnLater.SpecialSymbolColor = System.Drawing.Color.Transparent;
            this.btnLater.TabIndex = 26;
            this.btnLater.Text = "LATER";
            this.btnLater.Click += new System.EventHandler(this.btnLater_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.GlowColor = System.Drawing.Color.Lime;
            this.btnUpdate.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Location = new System.Drawing.Point(296, 243);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnUpdate.ShineColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Size = new System.Drawing.Size(93, 32);
            this.btnUpdate.SpecialSymbolColor = System.Drawing.Color.Transparent;
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.ClientSize = new System.Drawing.Size(497, 287);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnLater);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.lblUpdateVersion);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Update Available!";
            this.grpDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GlassButton btnClose;
        private System.Windows.Forms.Label lblUpdateVersion;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.WebBrowser updateDetails;
        private GlassButton btnUpdate;
        private GlassButton btnLater;
        private System.Windows.Forms.Label lblNote;
    }
}