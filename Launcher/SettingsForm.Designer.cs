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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblSettings = new System.Windows.Forms.Label();
            this.btnSave = new Launcher.Controls.GlassButton();
            this.btnCancel = new Launcher.Controls.GlassButton();
            this.grpWindowed = new System.Windows.Forms.GroupBox();
            this.grpResolution = new System.Windows.Forms.GroupBox();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.chkResize = new System.Windows.Forms.CheckBox();
            this.chkCentre = new System.Windows.Forms.CheckBox();
            this.chkWindowed = new System.Windows.Forms.CheckBox();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.grpScreenshot = new System.Windows.Forms.GroupBox();
            this.chkBlurLevel = new System.Windows.Forms.CheckBox();
            this.cmbBlurOptions = new System.Windows.Forms.ComboBox();
            this.chkBlurChat = new System.Windows.Forms.CheckBox();
            this.chkBlurHotKeys = new System.Windows.Forms.CheckBox();
            this.chkBlurHpMp = new System.Windows.Forms.CheckBox();
            this.chkBlurAc = new System.Windows.Forms.CheckBox();
            this.grpMouse = new System.Windows.Forms.GroupBox();
            this.pctMouseHelp = new System.Windows.Forms.PictureBox();
            this.chkCaptureMouse = new System.Windows.Forms.CheckBox();
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
            this.cmbBin = new System.Windows.Forms.ComboBox();
            this.lblBin = new System.Windows.Forms.Label();
            this.btnDirectory = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClose = new Launcher.Controls.GlassButton();
            this.grpWindowed.SuspendLayout();
            this.grpResolution.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpScreenshot.SuspendLayout();
            this.grpMouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMouseHelp)).BeginInit();
            this.tabWindow.SuspendLayout();
            this.tabInGame.SuspendLayout();
            this.grpMobColours.SuspendLayout();
            this.grpMusic.SuspendLayout();
            this.grpDisableDark.SuspendLayout();
            this.tabClient.SuspendLayout();
            this.grpClient.SuspendLayout();
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
            // grpWindowed
            // 
            this.grpWindowed.Controls.Add(this.grpResolution);
            this.grpWindowed.Controls.Add(this.chkResize);
            this.grpWindowed.Controls.Add(this.chkCentre);
            this.grpWindowed.Controls.Add(this.chkWindowed);
            this.grpWindowed.Location = new System.Drawing.Point(6, 6);
            this.grpWindowed.Name = "grpWindowed";
            this.grpWindowed.Size = new System.Drawing.Size(276, 140);
            this.grpWindowed.TabIndex = 5;
            this.grpWindowed.TabStop = false;
            this.grpWindowed.Text = "Window Settings";
            // 
            // grpResolution
            // 
            this.grpResolution.Controls.Add(this.cmbResolution);
            this.grpResolution.Enabled = false;
            this.grpResolution.Location = new System.Drawing.Point(16, 88);
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
            this.chkResize.Location = new System.Drawing.Point(18, 65);
            this.chkResize.Name = "chkResize";
            this.chkResize.Size = new System.Drawing.Size(126, 17);
            this.chkResize.TabIndex = 2;
            this.chkResize.Text = "Auto Resize Desktop";
            this.chkResize.UseVisualStyleBackColor = true;
            this.chkResize.CheckedChanged += new System.EventHandler(this.chkResize_CheckedChanged);
            // 
            // chkCentre
            // 
            this.chkCentre.AutoSize = true;
            this.chkCentre.Enabled = false;
            this.chkCentre.Location = new System.Drawing.Point(18, 42);
            this.chkCentre.Name = "chkCentre";
            this.chkCentre.Size = new System.Drawing.Size(99, 17);
            this.chkCentre.TabIndex = 1;
            this.chkCentre.Text = "Centre Window";
            this.chkCentre.UseVisualStyleBackColor = true;
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
            this.tabSettings.Controls.Add(this.tabGeneral);
            this.tabSettings.Controls.Add(this.tabWindow);
            this.tabSettings.Controls.Add(this.tabInGame);
            this.tabSettings.Controls.Add(this.tabClient);
            this.tabSettings.Location = new System.Drawing.Point(5, 27);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(295, 215);
            this.tabSettings.TabIndex = 7;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.tabGeneral.Controls.Add(this.grpScreenshot);
            this.tabGeneral.Controls.Add(this.grpMouse);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(287, 189);
            this.tabGeneral.TabIndex = 3;
            this.tabGeneral.Text = "General";
            // 
            // grpScreenshot
            // 
            this.grpScreenshot.Controls.Add(this.chkBlurLevel);
            this.grpScreenshot.Controls.Add(this.cmbBlurOptions);
            this.grpScreenshot.Controls.Add(this.chkBlurChat);
            this.grpScreenshot.Controls.Add(this.chkBlurHotKeys);
            this.grpScreenshot.Controls.Add(this.chkBlurHpMp);
            this.grpScreenshot.Controls.Add(this.chkBlurAc);
            this.grpScreenshot.Location = new System.Drawing.Point(6, 52);
            this.grpScreenshot.Name = "grpScreenshot";
            this.grpScreenshot.Size = new System.Drawing.Size(278, 130);
            this.grpScreenshot.TabIndex = 1;
            this.grpScreenshot.TabStop = false;
            this.grpScreenshot.Text = "Screenshots";
            // 
            // chkBlurLevel
            // 
            this.chkBlurLevel.AutoSize = true;
            this.chkBlurLevel.Location = new System.Drawing.Point(19, 16);
            this.chkBlurLevel.Name = "chkBlurLevel";
            this.chkBlurLevel.Size = new System.Drawing.Size(98, 17);
            this.chkBlurLevel.TabIndex = 8;
            this.chkBlurLevel.Text = "Auto-Blur Level";
            this.chkBlurLevel.UseVisualStyleBackColor = true;
            this.chkBlurLevel.CheckedChanged += new System.EventHandler(this.chkBlur_CheckedChanged);
            // 
            // cmbBlurOptions
            // 
            this.cmbBlurOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBlurOptions.Enabled = false;
            this.cmbBlurOptions.FormattingEnabled = true;
            this.cmbBlurOptions.Items.AddRange(new object[] {
            "Only Save Blurred Version",
            "Save Blurred and Unblurred Versions"});
            this.cmbBlurOptions.Location = new System.Drawing.Point(19, 102);
            this.cmbBlurOptions.Name = "cmbBlurOptions";
            this.cmbBlurOptions.Size = new System.Drawing.Size(240, 21);
            this.cmbBlurOptions.TabIndex = 7;
            // 
            // chkBlurChat
            // 
            this.chkBlurChat.AutoSize = true;
            this.chkBlurChat.Location = new System.Drawing.Point(19, 83);
            this.chkBlurChat.Name = "chkBlurChat";
            this.chkBlurChat.Size = new System.Drawing.Size(94, 17);
            this.chkBlurChat.TabIndex = 6;
            this.chkBlurChat.Text = "Auto-Blur Chat";
            this.chkBlurChat.UseVisualStyleBackColor = true;
            this.chkBlurChat.CheckedChanged += new System.EventHandler(this.chkBlur_CheckedChanged);
            // 
            // chkBlurHotKeys
            // 
            this.chkBlurHotKeys.AutoSize = true;
            this.chkBlurHotKeys.Location = new System.Drawing.Point(19, 66);
            this.chkBlurHotKeys.Name = "chkBlurHotKeys";
            this.chkBlurHotKeys.Size = new System.Drawing.Size(112, 17);
            this.chkBlurHotKeys.TabIndex = 5;
            this.chkBlurHotKeys.Text = "Auto-Blur HotKeys";
            this.chkBlurHotKeys.UseVisualStyleBackColor = true;
            this.chkBlurHotKeys.CheckedChanged += new System.EventHandler(this.chkBlur_CheckedChanged);
            // 
            // chkBlurHpMp
            // 
            this.chkBlurHpMp.AutoSize = true;
            this.chkBlurHpMp.Location = new System.Drawing.Point(19, 48);
            this.chkBlurHpMp.Name = "chkBlurHpMp";
            this.chkBlurHpMp.Size = new System.Drawing.Size(106, 17);
            this.chkBlurHpMp.TabIndex = 4;
            this.chkBlurHpMp.Text = "Auto-Blur Hp/Mp";
            this.chkBlurHpMp.UseVisualStyleBackColor = true;
            this.chkBlurHpMp.CheckedChanged += new System.EventHandler(this.chkBlur_CheckedChanged);
            // 
            // chkBlurAc
            // 
            this.chkBlurAc.AutoSize = true;
            this.chkBlurAc.Location = new System.Drawing.Point(19, 32);
            this.chkBlurAc.Name = "chkBlurAc";
            this.chkBlurAc.Size = new System.Drawing.Size(86, 17);
            this.chkBlurAc.TabIndex = 3;
            this.chkBlurAc.Text = "Auto-Blur AC";
            this.chkBlurAc.UseVisualStyleBackColor = true;
            this.chkBlurAc.CheckedChanged += new System.EventHandler(this.chkBlur_CheckedChanged);
            // 
            // grpMouse
            // 
            this.grpMouse.Controls.Add(this.pctMouseHelp);
            this.grpMouse.Controls.Add(this.chkCaptureMouse);
            this.grpMouse.Location = new System.Drawing.Point(6, 6);
            this.grpMouse.Name = "grpMouse";
            this.grpMouse.Size = new System.Drawing.Size(278, 40);
            this.grpMouse.TabIndex = 0;
            this.grpMouse.TabStop = false;
            this.grpMouse.Text = "Mouse";
            // 
            // pctMouseHelp
            // 
            this.pctMouseHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctMouseHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctMouseHelp.Image = ((System.Drawing.Image)(resources.GetObject("pctMouseHelp.Image")));
            this.pctMouseHelp.Location = new System.Drawing.Point(114, 16);
            this.pctMouseHelp.Name = "pctMouseHelp";
            this.pctMouseHelp.Size = new System.Drawing.Size(15, 15);
            this.pctMouseHelp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctMouseHelp.TabIndex = 2;
            this.pctMouseHelp.TabStop = false;
            this.pctMouseHelp.Click += new System.EventHandler(this.pctMouseHelp_Click);
            // 
            // chkCaptureMouse
            // 
            this.chkCaptureMouse.AutoSize = true;
            this.chkCaptureMouse.Location = new System.Drawing.Point(19, 16);
            this.chkCaptureMouse.Name = "chkCaptureMouse";
            this.chkCaptureMouse.Size = new System.Drawing.Size(98, 17);
            this.chkCaptureMouse.TabIndex = 1;
            this.chkCaptureMouse.Text = "Capture Mouse";
            this.chkCaptureMouse.UseVisualStyleBackColor = true;
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
            this.chkMobColours.Location = new System.Drawing.Point(26, 19);
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
            this.chkDisableDark.Location = new System.Drawing.Point(26, 19);
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
            this.grpClient.Controls.Add(this.cmbBin);
            this.grpClient.Controls.Add(this.lblBin);
            this.grpClient.Controls.Add(this.btnDirectory);
            this.grpClient.Controls.Add(this.txtDirectory);
            this.grpClient.Controls.Add(this.lblDirectory);
            this.grpClient.Location = new System.Drawing.Point(5, 6);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(279, 110);
            this.grpClient.TabIndex = 7;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Settings";
            // 
            // cmbBin
            // 
            this.cmbBin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBin.FormattingEnabled = true;
            this.cmbBin.Items.AddRange(new object[] {
            "No Client Directory Selected"});
            this.cmbBin.Location = new System.Drawing.Point(9, 80);
            this.cmbBin.Name = "cmbBin";
            this.cmbBin.Size = new System.Drawing.Size(233, 21);
            this.cmbBin.TabIndex = 4;
            // 
            // lblBin
            // 
            this.lblBin.AutoSize = true;
            this.lblBin.Location = new System.Drawing.Point(6, 64);
            this.lblBin.Name = "lblBin";
            this.lblBin.Size = new System.Drawing.Size(41, 13);
            this.lblBin.TabIndex = 3;
            this.lblBin.Text = "Bin File";
            // 
            // btnDirectory
            // 
            this.btnDirectory.Location = new System.Drawing.Point(248, 30);
            this.btnDirectory.Name = "btnDirectory";
            this.btnDirectory.Size = new System.Drawing.Size(26, 23);
            this.btnDirectory.TabIndex = 2;
            this.btnDirectory.Text = "...";
            this.btnDirectory.UseVisualStyleBackColor = true;
            this.btnDirectory.Click += new System.EventHandler(this.btnDirectory_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Enabled = false;
            this.txtDirectory.Location = new System.Drawing.Point(8, 32);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(234, 20);
            this.txtDirectory.TabIndex = 1;
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(6, 16);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(49, 13);
            this.lblDirectory.TabIndex = 0;
            this.lblDirectory.Text = "Directory";
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
            this.tabGeneral.ResumeLayout(false);
            this.grpScreenshot.ResumeLayout(false);
            this.grpScreenshot.PerformLayout();
            this.grpMouse.ResumeLayout(false);
            this.grpMouse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctMouseHelp)).EndInit();
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
        private System.Windows.Forms.CheckBox chkCentre;
        private System.Windows.Forms.CheckBox chkWindowed;
        private System.Windows.Forms.ComboBox cmbResolution;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabWindow;
        private System.Windows.Forms.TabPage tabClient;
        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.ComboBox cmbBin;
        private System.Windows.Forms.Label lblBin;
        private System.Windows.Forms.Button btnDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabPage tabInGame;
        private System.Windows.Forms.GroupBox grpMusic;
        private System.Windows.Forms.ComboBox cmbMusic;
        private System.Windows.Forms.GroupBox grpDisableDark;
        private System.Windows.Forms.CheckBox chkDisableDark;
        private System.Windows.Forms.GroupBox grpMobColours;
        private System.Windows.Forms.CheckBox chkMobColours;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox grpMouse;
        private System.Windows.Forms.CheckBox chkCaptureMouse;
        private System.Windows.Forms.GroupBox grpScreenshot;
        private System.Windows.Forms.PictureBox pctMouseHelp;
        private System.Windows.Forms.CheckBox chkBlurChat;
        private System.Windows.Forms.CheckBox chkBlurHotKeys;
        private System.Windows.Forms.CheckBox chkBlurHpMp;
        private System.Windows.Forms.CheckBox chkBlurAc;
        private System.Windows.Forms.ComboBox cmbBlurOptions;
        private System.Windows.Forms.CheckBox chkBlurLevel;

    }
}