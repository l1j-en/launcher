using Launcher.Controls;

namespace Launcher.Forms
{
    partial class SettingsForm
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
            this.lblSettings = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new Launcher.Controls.GlassButton();
            this.btnCancel = new Launcher.Controls.GlassButton();
            this.btnClose = new Launcher.Controls.GlassButton();
            this.grpUnderwater = new System.Windows.Forms.GroupBox();
            this.chkDisableUnderwater = new System.Windows.Forms.CheckBox();
            this.grpMobColours = new System.Windows.Forms.GroupBox();
            this.chkMobColours = new System.Windows.Forms.CheckBox();
            this.grpDisableDark = new System.Windows.Forms.GroupBox();
            this.chkDisableDark = new System.Windows.Forms.CheckBox();
            this.grpUnderwater.SuspendLayout();
            this.grpMobColours.SuspendLayout();
            this.grpDisableDark.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSettings
            // 
            this.lblSettings.AutoSize = true;
            this.lblSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.lblSettings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSettings.Location = new System.Drawing.Point(12, 9);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(59, 15);
            this.lblSettings.TabIndex = 2;
            this.lblSettings.Text = "Settings";
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.GlowColor = System.Drawing.Color.Blue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(153, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save Settings";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.GlowColor = System.Drawing.Color.Red;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(229, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.btnClose.Location = new System.Drawing.Point(284, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.OuterBorderColor = System.Drawing.Color.Silver;
            this.btnClose.ShineColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(20, 22);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grpUnderwater
            // 
            this.grpUnderwater.Controls.Add(this.chkDisableUnderwater);
            this.grpUnderwater.Location = new System.Drawing.Point(18, 148);
            this.grpUnderwater.Name = "grpUnderwater";
            this.grpUnderwater.Size = new System.Drawing.Size(278, 48);
            this.grpUnderwater.TabIndex = 7;
            this.grpUnderwater.TabStop = false;
            this.grpUnderwater.Text = "Underwater Effects";
            // 
            // chkDisableUnderwater
            // 
            this.chkDisableUnderwater.AutoSize = true;
            this.chkDisableUnderwater.Location = new System.Drawing.Point(14, 19);
            this.chkDisableUnderwater.Name = "chkDisableUnderwater";
            this.chkDisableUnderwater.Size = new System.Drawing.Size(150, 17);
            this.chkDisableUnderwater.TabIndex = 0;
            this.chkDisableUnderwater.Text = "Disable Underwater Effect";
            this.chkDisableUnderwater.UseVisualStyleBackColor = true;
            // 
            // grpMobColours
            // 
            this.grpMobColours.Controls.Add(this.chkMobColours);
            this.grpMobColours.Location = new System.Drawing.Point(18, 92);
            this.grpMobColours.Name = "grpMobColours";
            this.grpMobColours.Size = new System.Drawing.Size(278, 48);
            this.grpMobColours.TabIndex = 6;
            this.grpMobColours.TabStop = false;
            this.grpMobColours.Text = "Mob Colours";
            // 
            // chkMobColours
            // 
            this.chkMobColours.AutoSize = true;
            this.chkMobColours.Location = new System.Drawing.Point(14, 19);
            this.chkMobColours.Name = "chkMobColours";
            this.chkMobColours.Size = new System.Drawing.Size(121, 17);
            this.chkMobColours.TabIndex = 0;
            this.chkMobColours.Text = "Enable Mob Colours";
            this.chkMobColours.UseVisualStyleBackColor = true;
            // 
            // grpDisableDark
            // 
            this.grpDisableDark.Controls.Add(this.chkDisableDark);
            this.grpDisableDark.Location = new System.Drawing.Point(18, 38);
            this.grpDisableDark.Name = "grpDisableDark";
            this.grpDisableDark.Size = new System.Drawing.Size(278, 48);
            this.grpDisableDark.TabIndex = 5;
            this.grpDisableDark.TabStop = false;
            this.grpDisableDark.Text = "Disable Darkness";
            // 
            // chkDisableDark
            // 
            this.chkDisableDark.AutoSize = true;
            this.chkDisableDark.Location = new System.Drawing.Point(18, 19);
            this.chkDisableDark.Name = "chkDisableDark";
            this.chkDisableDark.Size = new System.Drawing.Size(109, 17);
            this.chkDisableDark.TabIndex = 0;
            this.chkDisableDark.Text = "Disable Darkness";
            this.chkDisableDark.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 251);
            this.Controls.Add(this.grpUnderwater);
            this.Controls.Add(this.grpMobColours);
            this.Controls.Add(this.grpDisableDark);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.grpUnderwater.ResumeLayout(false);
            this.grpUnderwater.PerformLayout();
            this.grpMobColours.ResumeLayout(false);
            this.grpMobColours.PerformLayout();
            this.grpDisableDark.ResumeLayout(false);
            this.grpDisableDark.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GlassButton btnClose;
        private System.Windows.Forms.Label lblSettings;
        private GlassButton btnSave;
        private GlassButton btnCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.GroupBox grpUnderwater;
        private System.Windows.Forms.CheckBox chkDisableUnderwater;
        private System.Windows.Forms.GroupBox grpMobColours;
        private System.Windows.Forms.CheckBox chkMobColours;
        private System.Windows.Forms.GroupBox grpDisableDark;
        private System.Windows.Forms.CheckBox chkDisableDark;
    }
}