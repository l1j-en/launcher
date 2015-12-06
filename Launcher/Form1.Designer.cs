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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblServerStatusText = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.BannerBrowser = new System.Windows.Forms.WebBrowser();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.processChecker = new System.ComponentModel.BackgroundWorker();
            this.btnSettings = new Launcher.GlassButton();
            this.btnClose = new Launcher.GlassButton();
            this.btnPlay = new Launcher.GlassButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServerStatusText
            // 
            this.lblServerStatusText.AutoSize = true;
            this.lblServerStatusText.BackColor = System.Drawing.Color.Transparent;
            this.lblServerStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblServerStatusText.ForeColor = System.Drawing.Color.Black;
            this.lblServerStatusText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblServerStatusText.Location = new System.Drawing.Point(11, 353);
            this.lblServerStatusText.Name = "lblServerStatusText";
            this.lblServerStatusText.Size = new System.Drawing.Size(105, 16);
            this.lblServerStatusText.TabIndex = 14;
            this.lblServerStatusText.Text = "Server Status:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblServerStatus.ForeColor = System.Drawing.Color.Khaki;
            this.lblServerStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblServerStatus.Location = new System.Drawing.Point(122, 353);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(72, 16);
            this.lblServerStatus.TabIndex = 15;
            this.lblServerStatus.Text = "Pinging...";
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
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Launcher.Properties.Resources.lineage_logo;
            this.pictureBox2.Location = new System.Drawing.Point(8, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(151, 53);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(386, 333);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(158, 21);
            this.cmbServer.TabIndex = 21;
            this.cmbServer.SelectedIndexChanged += new System.EventHandler(this.cmbServer_SelectedIndexChanged);
            // 
            // processChecker
            // 
            this.processChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.processChecker_DoWork);
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
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnPlay.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnPlay.Location = new System.Drawing.Point(568, 319);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnPlay.ShineColor = System.Drawing.Color.Transparent;
            this.btnPlay.Size = new System.Drawing.Size(93, 51);
            this.btnPlay.SpecialSymbolColor = System.Drawing.Color.Transparent;
            this.btnPlay.TabIndex = 24;
            this.btnPlay.Text = "PLAY!";
            this.btnPlay.Click += new System.EventHandler(this.playButton_Click);
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Launcher.Properties.Resources.launcherBg;
            this.ClientSize = new System.Drawing.Size(670, 377);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblServerStatusText);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BannerBrowser);
            this.Controls.Add(this.cmbServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lineage Resurrection";
            this.Load += new System.EventHandler(this.LauncherForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerStatusText;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.WebBrowser BannerBrowser;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.ComponentModel.BackgroundWorker processChecker;
        private GlassButton btnClose;
        private GlassButton btnSettings;
        private GlassButton btnPlay;


    }
}

