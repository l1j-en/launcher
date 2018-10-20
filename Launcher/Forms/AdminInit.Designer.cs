namespace Launcher.Forms
{
    partial class AdminInit
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
            this.lblWarning = new System.Windows.Forms.Label();
            this.grpSetup = new System.Windows.Forms.GroupBox();
            this.txtPublicKey = new System.Windows.Forms.RichTextBox();
            this.txtNewsUrl = new System.Windows.Forms.TextBox();
            this.txtWebsiteUrl = new System.Windows.Forms.TextBox();
            this.txtVoteUrl = new System.Windows.Forms.TextBox();
            this.txtVersionInfoUrl = new System.Windows.Forms.TextBox();
            this.txtUpdaterUrl = new System.Windows.Forms.TextBox();
            this.txtUpdaterFilesRoot = new System.Windows.Forms.TextBox();
            this.grpServers = new System.Windows.Forms.GroupBox();
            this.btnRemoveServer = new System.Windows.Forms.Button();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lstServers = new System.Windows.Forms.ListBox();
            this.lblPublicKey = new System.Windows.Forms.Label();
            this.lblNewsUrl = new System.Windows.Forms.Label();
            this.lblWebsiteUrl = new System.Windows.Forms.Label();
            this.lblVoteUrl = new System.Windows.Forms.Label();
            this.lblVersionInfoUrl = new System.Windows.Forms.Label();
            this.lblUpdaterUrl = new System.Windows.Forms.Label();
            this.lblUpdaterFilesRoot = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.hlpUpdaterFilesRoot = new System.Windows.Forms.PictureBox();
            this.hlpUpdaterUrl = new System.Windows.Forms.PictureBox();
            this.hlpVersionInfoUrl = new System.Windows.Forms.PictureBox();
            this.hlpVoteUrl = new System.Windows.Forms.PictureBox();
            this.hlpWebsiteUrl = new System.Windows.Forms.PictureBox();
            this.hlpNewsUrl = new System.Windows.Forms.PictureBox();
            this.hlpPublicKey = new System.Windows.Forms.PictureBox();
            this.grpSetup.SuspendLayout();
            this.grpServers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hlpUpdaterFilesRoot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpUpdaterUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpVersionInfoUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpVoteUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpWebsiteUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpNewsUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpPublicKey)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWarning
            // 
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(12, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(359, 67);
            this.lblWarning.TabIndex = 0;
            this.lblWarning.Text = "This form is for server admins only. If you are a player and see this form, conta" +
    "ct the server admin!";
            // 
            // grpSetup
            // 
            this.grpSetup.Controls.Add(this.hlpPublicKey);
            this.grpSetup.Controls.Add(this.hlpNewsUrl);
            this.grpSetup.Controls.Add(this.hlpWebsiteUrl);
            this.grpSetup.Controls.Add(this.hlpVoteUrl);
            this.grpSetup.Controls.Add(this.hlpVersionInfoUrl);
            this.grpSetup.Controls.Add(this.hlpUpdaterUrl);
            this.grpSetup.Controls.Add(this.hlpUpdaterFilesRoot);
            this.grpSetup.Controls.Add(this.txtPublicKey);
            this.grpSetup.Controls.Add(this.txtNewsUrl);
            this.grpSetup.Controls.Add(this.txtWebsiteUrl);
            this.grpSetup.Controls.Add(this.txtVoteUrl);
            this.grpSetup.Controls.Add(this.txtVersionInfoUrl);
            this.grpSetup.Controls.Add(this.txtUpdaterUrl);
            this.grpSetup.Controls.Add(this.txtUpdaterFilesRoot);
            this.grpSetup.Controls.Add(this.grpServers);
            this.grpSetup.Controls.Add(this.lblPublicKey);
            this.grpSetup.Controls.Add(this.lblNewsUrl);
            this.grpSetup.Controls.Add(this.lblWebsiteUrl);
            this.grpSetup.Controls.Add(this.lblVoteUrl);
            this.grpSetup.Controls.Add(this.lblVersionInfoUrl);
            this.grpSetup.Controls.Add(this.lblUpdaterUrl);
            this.grpSetup.Controls.Add(this.lblUpdaterFilesRoot);
            this.grpSetup.Location = new System.Drawing.Point(16, 72);
            this.grpSetup.Name = "grpSetup";
            this.grpSetup.Size = new System.Drawing.Size(355, 393);
            this.grpSetup.TabIndex = 1;
            this.grpSetup.TabStop = false;
            this.grpSetup.Text = "Launcher Setup";
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(121, 162);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(201, 53);
            this.txtPublicKey.TabIndex = 7;
            this.txtPublicKey.Text = "";
            // 
            // txtNewsUrl
            // 
            this.txtNewsUrl.Location = new System.Drawing.Point(121, 138);
            this.txtNewsUrl.Name = "txtNewsUrl";
            this.txtNewsUrl.Size = new System.Drawing.Size(201, 20);
            this.txtNewsUrl.TabIndex = 6;
            // 
            // txtWebsiteUrl
            // 
            this.txtWebsiteUrl.Location = new System.Drawing.Point(121, 115);
            this.txtWebsiteUrl.Name = "txtWebsiteUrl";
            this.txtWebsiteUrl.Size = new System.Drawing.Size(201, 20);
            this.txtWebsiteUrl.TabIndex = 5;
            // 
            // txtVoteUrl
            // 
            this.txtVoteUrl.Location = new System.Drawing.Point(121, 92);
            this.txtVoteUrl.Name = "txtVoteUrl";
            this.txtVoteUrl.Size = new System.Drawing.Size(201, 20);
            this.txtVoteUrl.TabIndex = 4;
            // 
            // txtVersionInfoUrl
            // 
            this.txtVersionInfoUrl.Location = new System.Drawing.Point(121, 68);
            this.txtVersionInfoUrl.Name = "txtVersionInfoUrl";
            this.txtVersionInfoUrl.Size = new System.Drawing.Size(201, 20);
            this.txtVersionInfoUrl.TabIndex = 3;
            // 
            // txtUpdaterUrl
            // 
            this.txtUpdaterUrl.Location = new System.Drawing.Point(121, 44);
            this.txtUpdaterUrl.Name = "txtUpdaterUrl";
            this.txtUpdaterUrl.Size = new System.Drawing.Size(201, 20);
            this.txtUpdaterUrl.TabIndex = 2;
            // 
            // txtUpdaterFilesRoot
            // 
            this.txtUpdaterFilesRoot.Location = new System.Drawing.Point(121, 20);
            this.txtUpdaterFilesRoot.Name = "txtUpdaterFilesRoot";
            this.txtUpdaterFilesRoot.Size = new System.Drawing.Size(201, 20);
            this.txtUpdaterFilesRoot.TabIndex = 1;
            // 
            // grpServers
            // 
            this.grpServers.Controls.Add(this.btnRemoveServer);
            this.grpServers.Controls.Add(this.btnAddServer);
            this.grpServers.Controls.Add(this.txtPort);
            this.grpServers.Controls.Add(this.txtIp);
            this.grpServers.Controls.Add(this.txtServerName);
            this.grpServers.Controls.Add(this.lblPort);
            this.grpServers.Controls.Add(this.lblIp);
            this.grpServers.Controls.Add(this.lblServerName);
            this.grpServers.Controls.Add(this.lstServers);
            this.grpServers.Location = new System.Drawing.Point(6, 214);
            this.grpServers.Name = "grpServers";
            this.grpServers.Size = new System.Drawing.Size(343, 173);
            this.grpServers.TabIndex = 7;
            this.grpServers.TabStop = false;
            this.grpServers.Text = "Servers";
            // 
            // btnRemoveServer
            // 
            this.btnRemoveServer.Location = new System.Drawing.Point(95, 140);
            this.btnRemoveServer.Name = "btnRemoveServer";
            this.btnRemoveServer.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveServer.TabIndex = 12;
            this.btnRemoveServer.Text = "Remove";
            this.btnRemoveServer.UseVisualStyleBackColor = true;
            this.btnRemoveServer.Click += new System.EventHandler(this.btnRemoveServer_Click);
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(95, 111);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(75, 23);
            this.btnAddServer.TabIndex = 11;
            this.btnAddServer.Text = "Add";
            this.btnAddServer.UseVisualStyleBackColor = true;
            this.btnAddServer.Click += new System.EventHandler(this.btnAddServer_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(14, 131);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(65, 20);
            this.txtPort.TabIndex = 10;
            this.txtPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.serverFields_KeyUp);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(16, 84);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(154, 20);
            this.txtIp.TabIndex = 9;
            this.txtIp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.serverFields_KeyUp);
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(16, 36);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(154, 20);
            this.txtServerName.TabIndex = 8;
            this.txtServerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.serverFields_KeyUp);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(16, 115);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 11;
            this.lblPort.Text = "Port";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(16, 68);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(55, 13);
            this.lblIp.TabIndex = 10;
            this.lblIp.Text = "IP or DNS";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(13, 20);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(35, 13);
            this.lblServerName.TabIndex = 9;
            this.lblServerName.Text = "Name";
            // 
            // lstServers
            // 
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Location = new System.Drawing.Point(194, 15);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(143, 134);
            this.lstServers.TabIndex = 13;
            // 
            // lblPublicKey
            // 
            this.lblPublicKey.AutoSize = true;
            this.lblPublicKey.Location = new System.Drawing.Point(17, 163);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(60, 13);
            this.lblPublicKey.TabIndex = 6;
            this.lblPublicKey.Text = "Public Key:";
            // 
            // lblNewsUrl
            // 
            this.lblNewsUrl.AutoSize = true;
            this.lblNewsUrl.Location = new System.Drawing.Point(17, 138);
            this.lblNewsUrl.Name = "lblNewsUrl";
            this.lblNewsUrl.Size = new System.Drawing.Size(53, 13);
            this.lblNewsUrl.TabIndex = 5;
            this.lblNewsUrl.Text = "News Url:";
            // 
            // lblWebsiteUrl
            // 
            this.lblWebsiteUrl.AutoSize = true;
            this.lblWebsiteUrl.Location = new System.Drawing.Point(17, 115);
            this.lblWebsiteUrl.Name = "lblWebsiteUrl";
            this.lblWebsiteUrl.Size = new System.Drawing.Size(68, 13);
            this.lblWebsiteUrl.TabIndex = 4;
            this.lblWebsiteUrl.Text = "Website Url: ";
            // 
            // lblVoteUrl
            // 
            this.lblVoteUrl.AutoSize = true;
            this.lblVoteUrl.Location = new System.Drawing.Point(19, 92);
            this.lblVoteUrl.Name = "lblVoteUrl";
            this.lblVoteUrl.Size = new System.Drawing.Size(48, 13);
            this.lblVoteUrl.TabIndex = 3;
            this.lblVoteUrl.Text = "Vote Url:";
            // 
            // lblVersionInfoUrl
            // 
            this.lblVersionInfoUrl.AutoSize = true;
            this.lblVersionInfoUrl.Location = new System.Drawing.Point(19, 68);
            this.lblVersionInfoUrl.Name = "lblVersionInfoUrl";
            this.lblVersionInfoUrl.Size = new System.Drawing.Size(82, 13);
            this.lblVersionInfoUrl.TabIndex = 2;
            this.lblVersionInfoUrl.Text = "Version Info Url:";
            // 
            // lblUpdaterUrl
            // 
            this.lblUpdaterUrl.AutoSize = true;
            this.lblUpdaterUrl.Location = new System.Drawing.Point(17, 44);
            this.lblUpdaterUrl.Name = "lblUpdaterUrl";
            this.lblUpdaterUrl.Size = new System.Drawing.Size(64, 13);
            this.lblUpdaterUrl.TabIndex = 1;
            this.lblUpdaterUrl.Text = "Updater Url:";
            // 
            // lblUpdaterFilesRoot
            // 
            this.lblUpdaterFilesRoot.AutoSize = true;
            this.lblUpdaterFilesRoot.Location = new System.Drawing.Point(17, 20);
            this.lblUpdaterFilesRoot.Name = "lblUpdaterFilesRoot";
            this.lblUpdaterFilesRoot.Size = new System.Drawing.Size(98, 13);
            this.lblUpdaterFilesRoot.TabIndex = 0;
            this.lblUpdaterFilesRoot.Text = "Updater Files Root:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(283, 471);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 36);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save Config";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // hlpUpdaterFilesRoot
            // 
            this.hlpUpdaterFilesRoot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpUpdaterFilesRoot.Image = global::Launcher.Properties.Resources.Help;
            this.hlpUpdaterFilesRoot.Location = new System.Drawing.Point(331, 23);
            this.hlpUpdaterFilesRoot.Name = "hlpUpdaterFilesRoot";
            this.hlpUpdaterFilesRoot.Size = new System.Drawing.Size(15, 15);
            this.hlpUpdaterFilesRoot.TabIndex = 24;
            this.hlpUpdaterFilesRoot.TabStop = false;
            this.hlpUpdaterFilesRoot.Click += new System.EventHandler(this.hlpUpdaterFilesRoot_Click);
            // 
            // hlpUpdaterUrl
            // 
            this.hlpUpdaterUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpUpdaterUrl.Image = global::Launcher.Properties.Resources.Help;
            this.hlpUpdaterUrl.Location = new System.Drawing.Point(331, 47);
            this.hlpUpdaterUrl.Name = "hlpUpdaterUrl";
            this.hlpUpdaterUrl.Size = new System.Drawing.Size(15, 15);
            this.hlpUpdaterUrl.TabIndex = 25;
            this.hlpUpdaterUrl.TabStop = false;
            this.hlpUpdaterUrl.Click += new System.EventHandler(this.hlpUpdaterUrl_Click);
            // 
            // hlpVersionInfoUrl
            // 
            this.hlpVersionInfoUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpVersionInfoUrl.Image = global::Launcher.Properties.Resources.Help;
            this.hlpVersionInfoUrl.Location = new System.Drawing.Point(331, 71);
            this.hlpVersionInfoUrl.Name = "hlpVersionInfoUrl";
            this.hlpVersionInfoUrl.Size = new System.Drawing.Size(15, 15);
            this.hlpVersionInfoUrl.TabIndex = 26;
            this.hlpVersionInfoUrl.TabStop = false;
            this.hlpVersionInfoUrl.Click += new System.EventHandler(this.hlpVersionInfoUrl_Click);
            // 
            // hlpVoteUrl
            // 
            this.hlpVoteUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpVoteUrl.Image = global::Launcher.Properties.Resources.Help;
            this.hlpVoteUrl.Location = new System.Drawing.Point(331, 95);
            this.hlpVoteUrl.Name = "hlpVoteUrl";
            this.hlpVoteUrl.Size = new System.Drawing.Size(15, 15);
            this.hlpVoteUrl.TabIndex = 27;
            this.hlpVoteUrl.TabStop = false;
            this.hlpVoteUrl.Click += new System.EventHandler(this.hlpVoteUrl_Click);
            // 
            // hlpWebsiteUrl
            // 
            this.hlpWebsiteUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpWebsiteUrl.Image = global::Launcher.Properties.Resources.Help;
            this.hlpWebsiteUrl.Location = new System.Drawing.Point(331, 118);
            this.hlpWebsiteUrl.Name = "hlpWebsiteUrl";
            this.hlpWebsiteUrl.Size = new System.Drawing.Size(15, 15);
            this.hlpWebsiteUrl.TabIndex = 28;
            this.hlpWebsiteUrl.TabStop = false;
            this.hlpWebsiteUrl.Click += new System.EventHandler(this.hlpWebsiteUrl_Click);
            // 
            // hlpNewsUrl
            // 
            this.hlpNewsUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpNewsUrl.Image = global::Launcher.Properties.Resources.Help;
            this.hlpNewsUrl.Location = new System.Drawing.Point(331, 141);
            this.hlpNewsUrl.Name = "hlpNewsUrl";
            this.hlpNewsUrl.Size = new System.Drawing.Size(15, 15);
            this.hlpNewsUrl.TabIndex = 29;
            this.hlpNewsUrl.TabStop = false;
            this.hlpNewsUrl.Click += new System.EventHandler(this.hlpNewsUrl_Click);
            // 
            // hlpPublicKey
            // 
            this.hlpPublicKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hlpPublicKey.Image = global::Launcher.Properties.Resources.Help;
            this.hlpPublicKey.Location = new System.Drawing.Point(331, 163);
            this.hlpPublicKey.Name = "hlpPublicKey";
            this.hlpPublicKey.Size = new System.Drawing.Size(15, 15);
            this.hlpPublicKey.TabIndex = 30;
            this.hlpPublicKey.TabStop = false;
            this.hlpPublicKey.Click += new System.EventHandler(this.hlpPublicKey_Click);
            // 
            // AdminInit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 519);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpSetup);
            this.Controls.Add(this.lblWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Admin Launcher Configuration";
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            this.grpServers.ResumeLayout(false);
            this.grpServers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hlpUpdaterFilesRoot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpUpdaterUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpVersionInfoUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpVoteUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpWebsiteUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpNewsUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hlpPublicKey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.GroupBox grpSetup;
        private System.Windows.Forms.Label lblPublicKey;
        private System.Windows.Forms.Label lblNewsUrl;
        private System.Windows.Forms.Label lblWebsiteUrl;
        private System.Windows.Forms.Label lblVoteUrl;
        private System.Windows.Forms.Label lblVersionInfoUrl;
        private System.Windows.Forms.Label lblUpdaterUrl;
        private System.Windows.Forms.Label lblUpdaterFilesRoot;
        private System.Windows.Forms.GroupBox grpServers;
        private System.Windows.Forms.ListBox lstServers;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Button btnAddServer;
        private System.Windows.Forms.Button btnRemoveServer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox txtPublicKey;
        private System.Windows.Forms.TextBox txtNewsUrl;
        private System.Windows.Forms.TextBox txtWebsiteUrl;
        private System.Windows.Forms.TextBox txtVoteUrl;
        private System.Windows.Forms.TextBox txtVersionInfoUrl;
        private System.Windows.Forms.TextBox txtUpdaterUrl;
        private System.Windows.Forms.TextBox txtUpdaterFilesRoot;
        private System.Windows.Forms.PictureBox hlpPublicKey;
        private System.Windows.Forms.PictureBox hlpNewsUrl;
        private System.Windows.Forms.PictureBox hlpWebsiteUrl;
        private System.Windows.Forms.PictureBox hlpVoteUrl;
        private System.Windows.Forms.PictureBox hlpVersionInfoUrl;
        private System.Windows.Forms.PictureBox hlpUpdaterUrl;
        private System.Windows.Forms.PictureBox hlpUpdaterFilesRoot;
    }
}