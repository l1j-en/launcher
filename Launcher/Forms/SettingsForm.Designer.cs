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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabInGame = new System.Windows.Forms.TabPage();
            this.tabWindowed = new System.Windows.Forms.TabPage();
            this.grpWindowType = new System.Windows.Forms.GroupBox();
            this.rdioWindowed = new System.Windows.Forms.RadioButton();
            this.rdioFullscreen = new System.Windows.Forms.RadioButton();
            this.grpWindowSize = new System.Windows.Forms.GroupBox();
            this.rdio400x300 = new System.Windows.Forms.RadioButton();
            this.rdio800x600 = new System.Windows.Forms.RadioButton();
            this.rdio1200x900 = new System.Windows.Forms.RadioButton();
            this.rdio1600x1200 = new System.Windows.Forms.RadioButton();
            this.grpUnderwater.SuspendLayout();
            this.grpMobColours.SuspendLayout();
            this.grpDisableDark.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabInGame.SuspendLayout();
            this.tabWindowed.SuspendLayout();
            this.grpWindowType.SuspendLayout();
            this.grpWindowSize.SuspendLayout();
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
            this.btnSave.Location = new System.Drawing.Point(107, 274);
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
            this.btnCancel.Location = new System.Drawing.Point(183, 274);
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
            this.btnClose.Location = new System.Drawing.Point(242, 6);
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
            this.grpUnderwater.Location = new System.Drawing.Point(7, 120);
            this.grpUnderwater.Name = "grpUnderwater";
            this.grpUnderwater.Size = new System.Drawing.Size(234, 48);
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
            this.grpMobColours.Location = new System.Drawing.Point(7, 64);
            this.grpMobColours.Name = "grpMobColours";
            this.grpMobColours.Size = new System.Drawing.Size(234, 48);
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
            this.grpDisableDark.Location = new System.Drawing.Point(7, 10);
            this.grpDisableDark.Name = "grpDisableDark";
            this.grpDisableDark.Size = new System.Drawing.Size(234, 48);
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
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabInGame);
            this.tabSettings.Controls.Add(this.tabWindowed);
            this.tabSettings.Location = new System.Drawing.Point(7, 34);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(255, 226);
            this.tabSettings.TabIndex = 8;
            // 
            // tabInGame
            // 
            this.tabInGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.tabInGame.Controls.Add(this.grpDisableDark);
            this.tabInGame.Controls.Add(this.grpUnderwater);
            this.tabInGame.Controls.Add(this.grpMobColours);
            this.tabInGame.Location = new System.Drawing.Point(4, 22);
            this.tabInGame.Name = "tabInGame";
            this.tabInGame.Padding = new System.Windows.Forms.Padding(3);
            this.tabInGame.Size = new System.Drawing.Size(247, 200);
            this.tabInGame.TabIndex = 0;
            this.tabInGame.Text = "In Game";
            // 
            // tabWindowed
            // 
            this.tabWindowed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.tabWindowed.Controls.Add(this.grpWindowSize);
            this.tabWindowed.Controls.Add(this.grpWindowType);
            this.tabWindowed.Location = new System.Drawing.Point(4, 22);
            this.tabWindowed.Name = "tabWindowed";
            this.tabWindowed.Padding = new System.Windows.Forms.Padding(3);
            this.tabWindowed.Size = new System.Drawing.Size(247, 200);
            this.tabWindowed.TabIndex = 1;
            this.tabWindowed.Text = "Window";
            // 
            // grpWindowType
            // 
            this.grpWindowType.Controls.Add(this.rdioWindowed);
            this.grpWindowType.Controls.Add(this.rdioFullscreen);
            this.grpWindowType.Location = new System.Drawing.Point(7, 10);
            this.grpWindowType.Name = "grpWindowType";
            this.grpWindowType.Size = new System.Drawing.Size(234, 52);
            this.grpWindowType.TabIndex = 0;
            this.grpWindowType.TabStop = false;
            this.grpWindowType.Text = "Window Type";
            // 
            // rdioWindowed
            // 
            this.rdioWindowed.AutoSize = true;
            this.rdioWindowed.Location = new System.Drawing.Point(121, 22);
            this.rdioWindowed.Name = "rdioWindowed";
            this.rdioWindowed.Size = new System.Drawing.Size(76, 17);
            this.rdioWindowed.TabIndex = 1;
            this.rdioWindowed.TabStop = true;
            this.rdioWindowed.Text = "Windowed";
            this.rdioWindowed.UseVisualStyleBackColor = true;
            this.rdioWindowed.CheckedChanged += new System.EventHandler(this.rdioWindowed_CheckedChanged);
            this.rdioFullscreen.CheckedChanged += new System.EventHandler(this.rdioWindowed_CheckedChanged);
            // 
            // rdioFullscreen
            // 
            this.rdioFullscreen.AutoSize = true;
            this.rdioFullscreen.Location = new System.Drawing.Point(28, 22);
            this.rdioFullscreen.Name = "rdioFullscreen";
            this.rdioFullscreen.Size = new System.Drawing.Size(73, 17);
            this.rdioFullscreen.TabIndex = 0;
            this.rdioFullscreen.TabStop = true;
            this.rdioFullscreen.Text = "Fullscreen";
            this.rdioFullscreen.UseVisualStyleBackColor = true;
            // 
            // grpWindowSize
            // 
            this.grpWindowSize.Controls.Add(this.rdio1600x1200);
            this.grpWindowSize.Controls.Add(this.rdio1200x900);
            this.grpWindowSize.Controls.Add(this.rdio800x600);
            this.grpWindowSize.Controls.Add(this.rdio400x300);
            this.grpWindowSize.Location = new System.Drawing.Point(7, 68);
            this.grpWindowSize.Name = "grpWindowSize";
            this.grpWindowSize.Size = new System.Drawing.Size(234, 126);
            this.grpWindowSize.TabIndex = 1;
            this.grpWindowSize.TabStop = false;
            this.grpWindowSize.Text = "Window Size";
            // 
            // rdio400x300
            // 
            this.rdio400x300.AutoSize = true;
            this.rdio400x300.Location = new System.Drawing.Point(28, 44);
            this.rdio400x300.Name = "rdio400x300";
            this.rdio400x300.Size = new System.Drawing.Size(74, 17);
            this.rdio400x300.TabIndex = 1;
            this.rdio400x300.TabStop = true;
            this.rdio400x300.Text = "400 X 300";
            this.rdio400x300.UseVisualStyleBackColor = true;
            // 
            // rdio800x600
            // 
            this.rdio800x600.AutoSize = true;
            this.rdio800x600.Location = new System.Drawing.Point(122, 44);
            this.rdio800x600.Name = "rdio800x600";
            this.rdio800x600.Size = new System.Drawing.Size(74, 17);
            this.rdio800x600.TabIndex = 2;
            this.rdio800x600.TabStop = true;
            this.rdio800x600.Text = "800 X 600";
            this.rdio800x600.UseVisualStyleBackColor = true;
            // 
            // rdio1200x900
            // 
            this.rdio1200x900.AutoSize = true;
            this.rdio1200x900.Location = new System.Drawing.Point(29, 67);
            this.rdio1200x900.Name = "rdio1200x900";
            this.rdio1200x900.Size = new System.Drawing.Size(80, 17);
            this.rdio1200x900.TabIndex = 3;
            this.rdio1200x900.TabStop = true;
            this.rdio1200x900.Text = "1200 X 900";
            this.rdio1200x900.UseVisualStyleBackColor = true;
            // 
            // rdio1600x1200
            // 
            this.rdio1600x1200.AutoSize = true;
            this.rdio1600x1200.Location = new System.Drawing.Point(122, 67);
            this.rdio1600x1200.Name = "rdio1600x1200";
            this.rdio1600x1200.Size = new System.Drawing.Size(86, 17);
            this.rdio1600x1200.TabIndex = 4;
            this.rdio1600x1200.TabStop = true;
            this.rdio1600x1200.Text = "1600 X 1200";
            this.rdio1600x1200.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(270, 309);
            this.Controls.Add(this.tabSettings);
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
            this.tabSettings.ResumeLayout(false);
            this.tabInGame.ResumeLayout(false);
            this.tabWindowed.ResumeLayout(false);
            this.grpWindowType.ResumeLayout(false);
            this.grpWindowType.PerformLayout();
            this.grpWindowSize.ResumeLayout(false);
            this.grpWindowSize.PerformLayout();
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
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabInGame;
        private System.Windows.Forms.TabPage tabWindowed;
        private System.Windows.Forms.GroupBox grpWindowType;
        private System.Windows.Forms.RadioButton rdioWindowed;
        private System.Windows.Forms.RadioButton rdioFullscreen;
        private System.Windows.Forms.GroupBox grpWindowSize;
        private System.Windows.Forms.RadioButton rdio1600x1200;
        private System.Windows.Forms.RadioButton rdio1200x900;
        private System.Windows.Forms.RadioButton rdio800x600;
        private System.Windows.Forms.RadioButton rdio400x300;
    }
}