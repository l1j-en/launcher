using Launcher.Controls;

namespace Launcher
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
            this.grpWindowed = new System.Windows.Forms.GroupBox();
            this.grpResolution = new System.Windows.Forms.GroupBox();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.chkResize = new System.Windows.Forms.CheckBox();
            this.chkWindowed = new System.Windows.Forms.CheckBox();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabWindow = new System.Windows.Forms.TabPage();
            this.tabInGame = new System.Windows.Forms.TabPage();
            this.grpMobColours = new System.Windows.Forms.GroupBox();
            this.chkMobColours = new System.Windows.Forms.CheckBox();
            this.grpMusic = new System.Windows.Forms.GroupBox();
            this.cmbMusic = new System.Windows.Forms.ComboBox();
            this.grpDisableDark = new System.Windows.Forms.GroupBox();
            this.chkDisableDark = new System.Windows.Forms.CheckBox();
            this.tabClient = new System.Windows.Forms.TabPage();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.chkDisableNagle = new System.Windows.Forms.CheckBox();
            this.cmbBin = new System.Windows.Forms.ComboBox();
            this.lblBin = new System.Windows.Forms.Label();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.grpAdvanced = new System.Windows.Forms.GroupBox();
            this.picLoginInjection = new System.Windows.Forms.PictureBox();
            this.txtLoginInjectionTiming = new System.Windows.Forms.TextBox();
            this.lblLoginInjectionTiming = new System.Windows.Forms.Label();
            this.picWinInjectionHelp = new System.Windows.Forms.PictureBox();
            this.txtWinInjectionTiming = new System.Windows.Forms.TextBox();
            this.lblWinInjectionTiming = new System.Windows.Forms.Label();
            this.picSyncHelp = new System.Windows.Forms.PictureBox();
            this.chkSyncServers = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSave = new Launcher.Controls.GlassButton();
            this.btnCancel = new Launcher.Controls.GlassButton();
            this.btnClose = new Launcher.Controls.GlassButton();
            this.grpWindowed.SuspendLayout();
            this.grpResolution.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabWindow.SuspendLayout();
            this.tabInGame.SuspendLayout();
            this.grpMobColours.SuspendLayout();
            this.grpMusic.SuspendLayout();
            this.grpDisableDark.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.grpClient.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.grpAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginInjection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWinInjectionHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSyncHelp)).BeginInit();
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
            // grpWindowed
            // 
            this.grpWindowed.Controls.Add(this.grpResolution);
            this.grpWindowed.Controls.Add(this.chkResize);
            this.grpWindowed.Controls.Add(this.chkWindowed);
            this.grpWindowed.Location = new System.Drawing.Point(6, 6);
            this.grpWindowed.Name = "grpWindowed";
            this.grpWindowed.Size = new System.Drawing.Size(276, 124);
            this.grpWindowed.TabIndex = 5;
            this.grpWindowed.TabStop = false;
            this.grpWindowed.Text = "Window Settings";
            // 
            // grpResolution
            // 
            this.grpResolution.Controls.Add(this.cmbResolution);
            this.grpResolution.Enabled = false;
            this.grpResolution.Location = new System.Drawing.Point(16, 68);
            this.grpResolution.Name = "grpResolution";
            this.grpResolution.Size = new System.Drawing.Size(248, 43);
            this.grpResolution.TabIndex = 3;
            this.grpResolution.TabStop = false;
            this.grpResolution.Text = "Resolution Settings";
            // 
            // cmbResolution
            // 
            this.cmbResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(21, 16);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(202, 21);
            this.cmbResolution.TabIndex = 4;
            // 
            // chkResize
            // 
            this.chkResize.AutoSize = true;
            this.chkResize.Enabled = false;
            this.chkResize.Location = new System.Drawing.Point(18, 42);
            this.chkResize.Name = "chkResize";
            this.chkResize.Size = new System.Drawing.Size(126, 17);
            this.chkResize.TabIndex = 2;
            this.chkResize.Text = "Auto Resize Desktop";
            this.chkResize.UseVisualStyleBackColor = true;
            this.chkResize.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // chkWindowed
            // 
            this.chkWindowed.AutoSize = true;
            this.chkWindowed.Location = new System.Drawing.Point(18, 19);
            this.chkWindowed.Name = "chkWindowed";
            this.chkWindowed.Size = new System.Drawing.Size(107, 17);
            this.chkWindowed.TabIndex = 0;
            this.chkWindowed.Text = "Windowed Mode";
            this.chkWindowed.UseVisualStyleBackColor = true;
            this.chkWindowed.CheckedChanged += new System.EventHandler(this.chkWindowed_CheckedChanged);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabWindow);
            this.tabSettings.Controls.Add(this.tabInGame);
            this.tabSettings.Controls.Add(this.tabClient);
            this.tabSettings.Controls.Add(this.tabAdvanced);
            this.tabSettings.Location = new System.Drawing.Point(5, 27);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(295, 215);
            this.tabSettings.TabIndex = 7;
            // 
            // tabWindow
            // 
            this.tabWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.tabWindow.Controls.Add(this.grpWindowed);
            this.tabWindow.Location = new System.Drawing.Point(4, 22);
            this.tabWindow.Name = "tabWindow";
            this.tabWindow.Padding = new System.Windows.Forms.Padding(3);
            this.tabWindow.Size = new System.Drawing.Size(287, 189);
            this.tabWindow.TabIndex = 0;
            this.tabWindow.Text = "Window";
            // 
            // tabInGame
            // 
            this.tabInGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.tabInGame.Controls.Add(this.grpMobColours);
            this.tabInGame.Controls.Add(this.grpMusic);
            this.tabInGame.Controls.Add(this.grpDisableDark);
            this.tabInGame.Location = new System.Drawing.Point(4, 22);
            this.tabInGame.Name = "tabInGame";
            this.tabInGame.Size = new System.Drawing.Size(287, 189);
            this.tabInGame.TabIndex = 2;
            this.tabInGame.Text = "In-Game";
            // 
            // grpMobColours
            // 
            this.grpMobColours.Controls.Add(this.chkMobColours);
            this.grpMobColours.Location = new System.Drawing.Point(6, 60);
            this.grpMobColours.Name = "grpMobColours";
            this.grpMobColours.Size = new System.Drawing.Size(278, 48);
            this.grpMobColours.TabIndex = 1;
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
            // grpMusic
            // 
            this.grpMusic.Controls.Add(this.cmbMusic);
            this.grpMusic.Location = new System.Drawing.Point(6, 114);
            this.grpMusic.Name = "grpMusic";
            this.grpMusic.Size = new System.Drawing.Size(278, 52);
            this.grpMusic.TabIndex = 1;
            this.grpMusic.TabStop = false;
            this.grpMusic.Text = "In-Game Music";
            // 
            // cmbMusic
            // 
            this.cmbMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusic.FormattingEnabled = true;
            this.cmbMusic.Items.AddRange(new object[] {
            "Newer Music",
            "Original Midi Music"});
            this.cmbMusic.Location = new System.Drawing.Point(14, 19);
            this.cmbMusic.Name = "cmbMusic";
            this.cmbMusic.Size = new System.Drawing.Size(247, 21);
            this.cmbMusic.TabIndex = 0;
            // 
            // grpDisableDark
            // 
            this.grpDisableDark.Controls.Add(this.chkDisableDark);
            this.grpDisableDark.Location = new System.Drawing.Point(6, 6);
            this.grpDisableDark.Name = "grpDisableDark";
            this.grpDisableDark.Size = new System.Drawing.Size(278, 48);
            this.grpDisableDark.TabIndex = 0;
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
            // tabClient
            // 
            this.tabClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.tabClient.Controls.Add(this.grpClient);
            this.tabClient.Location = new System.Drawing.Point(4, 22);
            this.tabClient.Name = "tabClient";
            this.tabClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabClient.Size = new System.Drawing.Size(287, 189);
            this.tabClient.TabIndex = 1;
            this.tabClient.Text = "Client Settings";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.chkDisableNagle);
            this.grpClient.Controls.Add(this.cmbBin);
            this.grpClient.Controls.Add(this.lblBin);
            this.grpClient.Location = new System.Drawing.Point(5, 6);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(279, 101);
            this.grpClient.TabIndex = 7;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Settings";
            // 
            // chkDisableNagle
            // 
            this.chkDisableNagle.AutoSize = true;
            this.chkDisableNagle.Location = new System.Drawing.Point(9, 69);
            this.chkDisableNagle.Name = "chkDisableNagle";
            this.chkDisableNagle.Size = new System.Drawing.Size(166, 17);
            this.chkDisableNagle.TabIndex = 5;
            this.chkDisableNagle.Text = "Local Proxy (Helps Swing lag)";
            this.chkDisableNagle.UseVisualStyleBackColor = false;
            // 
            // cmbBin
            // 
            this.cmbBin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBin.FormattingEnabled = true;
            this.cmbBin.Items.AddRange(new object[] {
            "No Client Directory Selected"});
            this.cmbBin.Location = new System.Drawing.Point(9, 32);
            this.cmbBin.Name = "cmbBin";
            this.cmbBin.Size = new System.Drawing.Size(233, 21);
            this.cmbBin.TabIndex = 4;
            // 
            // lblBin
            // 
            this.lblBin.AutoSize = true;
            this.lblBin.Location = new System.Drawing.Point(6, 16);
            this.lblBin.Name = "lblBin";
            this.lblBin.Size = new System.Drawing.Size(41, 13);
            this.lblBin.TabIndex = 3;
            this.lblBin.Text = "Bin File";
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.tabAdvanced.Controls.Add(this.grpAdvanced);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Size = new System.Drawing.Size(287, 189);
            this.tabAdvanced.TabIndex = 3;
            this.tabAdvanced.Text = "Advanced";
            // 
            // grpAdvanced
            // 
            this.grpAdvanced.Controls.Add(this.picLoginInjection);
            this.grpAdvanced.Controls.Add(this.txtLoginInjectionTiming);
            this.grpAdvanced.Controls.Add(this.lblLoginInjectionTiming);
            this.grpAdvanced.Controls.Add(this.picWinInjectionHelp);
            this.grpAdvanced.Controls.Add(this.txtWinInjectionTiming);
            this.grpAdvanced.Controls.Add(this.lblWinInjectionTiming);
            this.grpAdvanced.Controls.Add(this.picSyncHelp);
            this.grpAdvanced.Controls.Add(this.chkSyncServers);
            this.grpAdvanced.Location = new System.Drawing.Point(6, 3);
            this.grpAdvanced.Name = "grpAdvanced";
            this.grpAdvanced.Size = new System.Drawing.Size(278, 103);
            this.grpAdvanced.TabIndex = 0;
            this.grpAdvanced.TabStop = false;
            this.grpAdvanced.Text = "Advanced Settings";
            // 
            // picLoginInjection
            // 
            this.picLoginInjection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLoginInjection.Image = global::Launcher.Properties.Resources.Help;
            this.picLoginInjection.Location = new System.Drawing.Point(238, 46);
            this.picLoginInjection.Name = "picLoginInjection";
            this.picLoginInjection.Size = new System.Drawing.Size(15, 15);
            this.picLoginInjection.TabIndex = 8;
            this.picLoginInjection.TabStop = false;
            this.picLoginInjection.Click += new System.EventHandler(this.picLoginInjection_Click);
            // 
            // txtLoginInjectionTiming
            // 
            this.txtLoginInjectionTiming.Location = new System.Drawing.Point(17, 43);
            this.txtLoginInjectionTiming.MaxLength = 4;
            this.txtLoginInjectionTiming.Name = "txtLoginInjectionTiming";
            this.txtLoginInjectionTiming.Size = new System.Drawing.Size(50, 20);
            this.txtLoginInjectionTiming.TabIndex = 7;
            // 
            // lblLoginInjectionTiming
            // 
            this.lblLoginInjectionTiming.AutoSize = true;
            this.lblLoginInjectionTiming.Location = new System.Drawing.Point(73, 46);
            this.lblLoginInjectionTiming.Name = "lblLoginInjectionTiming";
            this.lblLoginInjectionTiming.Size = new System.Drawing.Size(129, 13);
            this.lblLoginInjectionTiming.TabIndex = 6;
            this.lblLoginInjectionTiming.Text = "Launcher Injection Timing";
            // 
            // picWinInjectionHelp
            // 
            this.picWinInjectionHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picWinInjectionHelp.Image = global::Launcher.Properties.Resources.Help;
            this.picWinInjectionHelp.Location = new System.Drawing.Point(238, 74);
            this.picWinInjectionHelp.Name = "picWinInjectionHelp";
            this.picWinInjectionHelp.Size = new System.Drawing.Size(15, 15);
            this.picWinInjectionHelp.TabIndex = 5;
            this.picWinInjectionHelp.TabStop = false;
            this.picWinInjectionHelp.Click += new System.EventHandler(this.picWinInjectionHelp_Click);
            // 
            // txtWinInjectionTiming
            // 
            this.txtWinInjectionTiming.Location = new System.Drawing.Point(17, 71);
            this.txtWinInjectionTiming.MaxLength = 4;
            this.txtWinInjectionTiming.Name = "txtWinInjectionTiming";
            this.txtWinInjectionTiming.Size = new System.Drawing.Size(50, 20);
            this.txtWinInjectionTiming.TabIndex = 4;
            // 
            // lblWinInjectionTiming
            // 
            this.lblWinInjectionTiming.AutoSize = true;
            this.lblWinInjectionTiming.Location = new System.Drawing.Point(73, 74);
            this.lblWinInjectionTiming.Name = "lblWinInjectionTiming";
            this.lblWinInjectionTiming.Size = new System.Drawing.Size(165, 13);
            this.lblWinInjectionTiming.TabIndex = 3;
            this.lblWinInjectionTiming.Text = "Windowed Mode Injection Timing";
            // 
            // picSyncHelp
            // 
            this.picSyncHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSyncHelp.Image = global::Launcher.Properties.Resources.Help;
            this.picSyncHelp.Location = new System.Drawing.Point(238, 19);
            this.picSyncHelp.Name = "picSyncHelp";
            this.picSyncHelp.Size = new System.Drawing.Size(15, 15);
            this.picSyncHelp.TabIndex = 2;
            this.picSyncHelp.TabStop = false;
            this.picSyncHelp.Click += new System.EventHandler(this.picSyncHelp_Click);
            // 
            // chkSyncServers
            // 
            this.chkSyncServers.AutoSize = true;
            this.chkSyncServers.Location = new System.Drawing.Point(17, 19);
            this.chkSyncServers.Name = "chkSyncServers";
            this.chkSyncServers.Size = new System.Drawing.Size(150, 17);
            this.chkSyncServers.TabIndex = 1;
            this.chkSyncServers.Text = "Update Server Information";
            this.chkSyncServers.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.GlowColor = System.Drawing.Color.Blue;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(153, 248);
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
            this.btnCancel.Location = new System.Drawing.Point(229, 248);
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
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 279);
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
            this.grpWindowed.ResumeLayout(false);
            this.grpWindowed.PerformLayout();
            this.grpResolution.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabWindow.ResumeLayout(false);
            this.tabInGame.ResumeLayout(false);
            this.grpMobColours.ResumeLayout(false);
            this.grpMobColours.PerformLayout();
            this.grpMusic.ResumeLayout(false);
            this.grpDisableDark.ResumeLayout(false);
            this.grpDisableDark.PerformLayout();
            this.tabClient.ResumeLayout(false);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.tabAdvanced.ResumeLayout(false);
            this.grpAdvanced.ResumeLayout(false);
            this.grpAdvanced.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoginInjection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWinInjectionHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSyncHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GlassButton btnClose;
        private System.Windows.Forms.Label lblSettings;
        private GlassButton btnSave;
        private GlassButton btnCancel;
        private System.Windows.Forms.GroupBox grpWindowed;
        private System.Windows.Forms.GroupBox grpResolution;
        private System.Windows.Forms.CheckBox chkResize;
        private System.Windows.Forms.CheckBox chkWindowed;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabWindow;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.ComboBox cmbBin;
        private System.Windows.Forms.Label lblBin;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabPage tabInGame;
        private System.Windows.Forms.GroupBox grpMusic;
        private System.Windows.Forms.ComboBox cmbMusic;
        private System.Windows.Forms.GroupBox grpDisableDark;
        private System.Windows.Forms.CheckBox chkDisableDark;
        private System.Windows.Forms.GroupBox grpMobColours;
        private System.Windows.Forms.CheckBox chkMobColours;
        private System.Windows.Forms.CheckBox chkDisableNagle;
        private System.Windows.Forms.TabPage tabAdvanced;
        private System.Windows.Forms.GroupBox grpAdvanced;
        private System.Windows.Forms.CheckBox chkSyncServers;
        private System.Windows.Forms.PictureBox picSyncHelp;
        private System.Windows.Forms.PictureBox picWinInjectionHelp;
        private System.Windows.Forms.TextBox txtWinInjectionTiming;
        private System.Windows.Forms.Label lblWinInjectionTiming;
        private System.Windows.Forms.PictureBox picLoginInjection;
        private System.Windows.Forms.TextBox txtLoginInjectionTiming;
        private System.Windows.Forms.Label lblLoginInjectionTiming;
    }
}