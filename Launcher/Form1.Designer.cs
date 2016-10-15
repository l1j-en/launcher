using Launcher.Controls;

namespace Launcher
{
    partial class LauncherForm
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

        #region Clients Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.BannerBrowser = new System.Windows.Forms.WebBrowser();
            this.pctLinLogo = new System.Windows.Forms.PictureBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.pctVote = new System.Windows.Forms.PictureBox();
            this.prgUpdates = new System.Windows.Forms.ProgressBar();
            this.updateChecker = new System.ComponentModel.BackgroundWorker();
            this.prgUpdateCurrent = new System.Windows.Forms.ProgressBar();
            this.tmrCheckProcess = new System.Windows.Forms.Timer(this.components);
            this.systemIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.systemTrayContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Restore = new System.Windows.Forms.ToolStripMenuItem();
            this.Close = new System.Windows.Forms.ToolStripMenuItem();
            this.lblVersion = new Launcher.Controls.OutlineLabel();
            this.lblVersionText = new Launcher.Controls.OutlineLabel();
            this.btnCheck = new Launcher.Controls.GlassButton();
            this.lvlUpdateCurrent = new Launcher.Controls.OutlineLabel();
            this.lblUpdates = new Launcher.Controls.OutlineLabel();
            this.btnPlay = new Launcher.Controls.GlassButton();
            this.btnSettings = new Launcher.Controls.GlassButton();
            this.btnClose = new Launcher.Controls.GlassButton();
            this.lblServerStatus = new Launcher.Controls.OutlineLabel();
            this.lblServerStatusText = new Launcher.Controls.OutlineLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pctLinLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctVote)).BeginInit();
            this.systemTrayContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BannerBrowser
            // 
            this.BannerBrowser.CausesValidation = false;
            this.BannerBrowser.IsWebBrowserContextMenuEnabled = false;
            this.BannerBrowser.Location = new System.Drawing.Point(32, 64);
            this.BannerBrowser.Name = "BannerBrowser";
            this.BannerBrowser.ScrollBarsEnabled = false;
            this.BannerBrowser.Size = new System.Drawing.Size(608, 243);
            this.BannerBrowser.TabIndex = 19;
            this.BannerBrowser.TabStop = false;
            this.BannerBrowser.Url = new System.Uri("", System.UriKind.Relative);
            this.BannerBrowser.Visible = false;
            this.BannerBrowser.WebBrowserShortcutsEnabled = false;
            // 
            // pctLinLogo
            // 
            this.pctLinLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctLinLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctLinLogo.Image = global::Launcher.Properties.Resources.lineage_logo;
            this.pctLinLogo.Location = new System.Drawing.Point(8, 5);
            this.pctLinLogo.Name = "pctLinLogo";
            this.pctLinLogo.Size = new System.Drawing.Size(151, 53);
            this.pctLinLogo.TabIndex = 20;
            this.pctLinLogo.TabStop = false;
            this.pctLinLogo.Click += new System.EventHandler(this.pctLinLogo_Click);
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(310, 353);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(158, 21);
            this.cmbServer.TabIndex = 21;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            // 
            // pctVote
            // 
            this.pctVote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pctVote.Image = global::Launcher.Properties.Resources.vote;
            this.pctVote.Location = new System.Drawing.Point(474, 334);
            this.pctVote.Name = "pctVote";
            this.pctVote.Size = new System.Drawing.Size(88, 53);
            this.pctVote.TabIndex = 25;
            this.pctVote.TabStop = false;
            this.pctVote.Click += new System.EventHandler(this.pctVote_Click);
            // 
            // prgUpdates
            // 
            this.prgUpdates.Location = new System.Drawing.Point(74, 362);
            this.prgUpdates.Name = "prgUpdates";
            this.prgUpdates.Size = new System.Drawing.Size(157, 23);
            this.prgUpdates.TabIndex = 27;
            // 
            // updateChecker
            // 
            this.updateChecker.WorkerReportsProgress = true;
            this.updateChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateChecker_DoWork);
            this.updateChecker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateChecker_ProgressChanged);
            this.updateChecker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateChecker_RunWorkerCompleted);
            // 
            // prgUpdateCurrent
            // 
            this.prgUpdateCurrent.Location = new System.Drawing.Point(100, 337);
            this.prgUpdateCurrent.Name = "prgUpdateCurrent";
            this.prgUpdateCurrent.Size = new System.Drawing.Size(131, 23);
            this.prgUpdateCurrent.TabIndex = 29;
            // 
            // tmrCheckProcess
            // 
            this.tmrCheckProcess.Interval = 500;
            this.tmrCheckProcess.Tick += new System.EventHandler(this.tmrCheckProcess_Tick);
            // 
            // systemIcon
            // 
            this.systemIcon.BalloonTipText = "Launcher is still running! If you close it while the game is running, you will be" +
    " disconnected!";
            this.systemIcon.BalloonTipTitle = "Still Running!";
            this.systemIcon.ContextMenuStrip = this.systemTrayContextMenu;
            this.systemIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systemIcon.Icon")));
            this.systemIcon.Text = "Lineage Launcher";
            this.systemIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systemIcon_MouseDoubleClick);
            // 
            // systemTrayContextMenu
            // 
            this.systemTrayContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Restore,
            this.Close});
            this.systemTrayContextMenu.Name = "systemTrayContextMenu";
            this.systemTrayContextMenu.Size = new System.Drawing.Size(114, 48);
            // 
            // Restore
            // 
            this.Restore.Name = "Restore";
            this.Restore.Size = new System.Drawing.Size(113, 22);
            this.Restore.Text = "Restore";
            this.Restore.Click += new System.EventHandler(this.Restore_Click);
            // 
            // Close
            // 
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(113, 22);
            this.Close.Text = "Close";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Red;
            this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersion.Location = new System.Drawing.Point(642, 29);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.OutlineForeColor = System.Drawing.Color.Black;
            this.lblVersion.OutlineWidth = 2F;
            this.lblVersion.Size = new System.Drawing.Size(0, 13);
            this.lblVersion.TabIndex = 32;
            // 
            // lblVersionText
            // 
            this.lblVersionText.AutoSize = true;
            this.lblVersionText.BackColor = System.Drawing.Color.Transparent;
            this.lblVersionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionText.ForeColor = System.Drawing.Color.Red;
            this.lblVersionText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblVersionText.Location = new System.Drawing.Point(584, 29);
            this.lblVersionText.Name = "lblVersionText";
            this.lblVersionText.OutlineForeColor = System.Drawing.Color.Black;
            this.lblVersionText.OutlineWidth = 2F;
            this.lblVersionText.Size = new System.Drawing.Size(70, 13);
            this.lblVersionText.TabIndex = 31;
            this.lblVersionText.Text = "VERSION: ";
            // 
            // btnCheck
            // 
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.Enabled = false;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCheck.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnCheck.Location = new System.Drawing.Point(242, 346);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnCheck.ShineColor = System.Drawing.Color.Transparent;
            this.btnCheck.Size = new System.Drawing.Size(62, 41);
            this.btnCheck.SpecialSymbolColor = System.Drawing.Color.Transparent;
            this.btnCheck.TabIndex = 30;
            this.btnCheck.Text = "CHECK";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // lvlUpdateCurrent
            // 
            this.lvlUpdateCurrent.AutoSize = true;
            this.lvlUpdateCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lvlUpdateCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvlUpdateCurrent.ForeColor = System.Drawing.Color.White;
            this.lvlUpdateCurrent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lvlUpdateCurrent.Location = new System.Drawing.Point(8, 339);
            this.lvlUpdateCurrent.Name = "lvlUpdateCurrent";
            this.lvlUpdateCurrent.OutlineForeColor = System.Drawing.Color.Black;
            this.lvlUpdateCurrent.OutlineWidth = 2F;
            this.lvlUpdateCurrent.Size = new System.Drawing.Size(99, 20);
            this.lvlUpdateCurrent.TabIndex = 28;
            this.lvlUpdateCurrent.Text = "CURRENT:";
            // 
            // lblUpdates
            // 
            this.lblUpdates.AutoSize = true;
            this.lblUpdates.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdates.ForeColor = System.Drawing.Color.White;
            this.lblUpdates.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUpdates.Location = new System.Drawing.Point(8, 365);
            this.lblUpdates.Name = "lblUpdates";
            this.lblUpdates.OutlineForeColor = System.Drawing.Color.Black;
            this.lblUpdates.OutlineWidth = 2F;
            this.lblUpdates.Size = new System.Drawing.Size(69, 20);
            this.lblUpdates.TabIndex = 26;
            this.lblUpdates.Text = "TOTAL:";
            // 
            // btnPlay
            // 
            this.btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlay.Enabled = false;
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPlay.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnPlay.Location = new System.Drawing.Point(568, 334);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnPlay.ShineColor = System.Drawing.Color.Transparent;
            this.btnPlay.Size = new System.Drawing.Size(93, 51);
            this.btnPlay.SpecialSymbolColor = System.Drawing.Color.Transparent;
            this.btnPlay.TabIndex = 24;
            this.btnPlay.Text = "PLAY!";
            this.btnPlay.Click += new System.EventHandler(this.playButton_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Silver;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnSettings.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnSettings.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnSettings.Location = new System.Drawing.Point(565, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnSettings.ShineColor = System.Drawing.Color.Transparent;
            this.btnSettings.Size = new System.Drawing.Size(75, 21);
            this.btnSettings.SpecialSymbolColor = System.Drawing.Color.Transparent;
            this.btnSettings.TabIndex = 23;
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.btnClose.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.btnClose.Image = global::Launcher.Properties.Resources.close;
            this.btnClose.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(645, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.OuterBorderColor = System.Drawing.Color.Silver;
            this.btnClose.ShineColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(20, 22);
            this.btnClose.TabIndex = 22;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.Khaki;
            this.lblServerStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblServerStatus.Location = new System.Drawing.Point(388, 316);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.OutlineForeColor = System.Drawing.Color.Black;
            this.lblServerStatus.OutlineWidth = 2F;
            this.lblServerStatus.Size = new System.Drawing.Size(99, 20);
            this.lblServerStatus.TabIndex = 15;
            this.lblServerStatus.Text = "PINGING...";
            // 
            // lblServerStatusText
            // 
            this.lblServerStatusText.AutoSize = true;
            this.lblServerStatusText.BackColor = System.Drawing.Color.Transparent;
            this.lblServerStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatusText.ForeColor = System.Drawing.Color.White;
            this.lblServerStatusText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblServerStatusText.Location = new System.Drawing.Point(242, 316);
            this.lblServerStatusText.Name = "lblServerStatusText";
            this.lblServerStatusText.OutlineForeColor = System.Drawing.Color.Black;
            this.lblServerStatusText.OutlineWidth = 2F;
            this.lblServerStatusText.Size = new System.Drawing.Size(162, 20);
            this.lblServerStatusText.TabIndex = 14;
            this.lblServerStatusText.Text = "SERVER STATUS:";
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Launcher.Properties.Resources.launcherBg;
            this.ClientSize = new System.Drawing.Size(670, 389);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblVersionText);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.prgUpdateCurrent);
            this.Controls.Add(this.lvlUpdateCurrent);
            this.Controls.Add(this.prgUpdates);
            this.Controls.Add(this.lblUpdates);
            this.Controls.Add(this.pctVote);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblServerStatusText);
            this.Controls.Add(this.pctLinLogo);
            this.Controls.Add(this.BannerBrowser);
            this.Controls.Add(this.cmbServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lineage Resurrection";
            this.Shown += new System.EventHandler(this.LauncherForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LauncherForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pctLinLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctVote)).EndInit();
            this.systemTrayContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser BannerBrowser;
        private System.Windows.Forms.PictureBox pctLinLogo;
        private System.Windows.Forms.ComboBox cmbServer;
        private GlassButton btnClose;
        private GlassButton btnSettings;
        private GlassButton btnPlay;
        private System.Windows.Forms.PictureBox pctVote;
        private OutlineLabel lblServerStatusText;
        private OutlineLabel lblServerStatus;
        private OutlineLabel lblUpdates;
        private System.Windows.Forms.ProgressBar prgUpdates;
        private System.ComponentModel.BackgroundWorker updateChecker;
        private System.Windows.Forms.ProgressBar prgUpdateCurrent;
        private OutlineLabel lvlUpdateCurrent;
        private GlassButton btnCheck;
        private System.Windows.Forms.Timer tmrCheckProcess;
        private OutlineLabel lblVersionText;
        private OutlineLabel lblVersion;
        private System.Windows.Forms.NotifyIcon systemIcon;
        private System.Windows.Forms.ContextMenuStrip systemTrayContextMenu;
        private System.Windows.Forms.ToolStripMenuItem Restore;
        private System.Windows.Forms.ToolStripMenuItem Close;
    }
}

