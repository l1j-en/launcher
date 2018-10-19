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
            this.lblUpdaterFilesRoot = new System.Windows.Forms.Label();
            this.lblUpdaterUrl = new System.Windows.Forms.Label();
            this.lblVersionInfoUrl = new System.Windows.Forms.Label();
            this.lblVoteUrl = new System.Windows.Forms.Label();
            this.lblWebsiteUrl = new System.Windows.Forms.Label();
            this.lblNewsUrl = new System.Windows.Forms.Label();
            this.lblPublicKey = new System.Windows.Forms.Label();
            this.grpServers = new System.Windows.Forms.GroupBox();
            this.lstServers = new System.Windows.Forms.ListBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnAddServer = new System.Windows.Forms.Button();
            this.btnRemoveServer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUpdaterFilesRoot = new System.Windows.Forms.TextBox();
            this.txtUpdaterUrl = new System.Windows.Forms.TextBox();
            this.txtVersionInfoUrl = new System.Windows.Forms.TextBox();
            this.txtVoteUrl = new System.Windows.Forms.TextBox();
            this.txtWebsiteUrl = new System.Windows.Forms.TextBox();
            this.txtNewsUrl = new System.Windows.Forms.TextBox();
            this.txtPublicKey = new System.Windows.Forms.RichTextBox();
            this.grpSetup.SuspendLayout();
            this.grpServers.SuspendLayout();
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
            // lblUpdaterFilesRoot
            // 
            this.lblUpdaterFilesRoot.AutoSize = true;
            this.lblUpdaterFilesRoot.Location = new System.Drawing.Point(17, 20);
            this.lblUpdaterFilesRoot.Name = "lblUpdaterFilesRoot";
            this.lblUpdaterFilesRoot.Size = new System.Drawing.Size(98, 13);
            this.lblUpdaterFilesRoot.TabIndex = 0;
            this.lblUpdaterFilesRoot.Text = "Updater Files Root:";
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
            // lblVersionInfoUrl
            // 
            this.lblVersionInfoUrl.AutoSize = true;
            this.lblVersionInfoUrl.Location = new System.Drawing.Point(19, 68);
            this.lblVersionInfoUrl.Name = "lblVersionInfoUrl";
            this.lblVersionInfoUrl.Size = new System.Drawing.Size(82, 13);
            this.lblVersionInfoUrl.TabIndex = 2;
            this.lblVersionInfoUrl.Text = "Version Info Url:";
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
            // lblWebsiteUrl
            // 
            this.lblWebsiteUrl.AutoSize = true;
            this.lblWebsiteUrl.Location = new System.Drawing.Point(17, 115);
            this.lblWebsiteUrl.Name = "lblWebsiteUrl";
            this.lblWebsiteUrl.Size = new System.Drawing.Size(68, 13);
            this.lblWebsiteUrl.TabIndex = 4;
            this.lblWebsiteUrl.Text = "Website Url: ";
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
            // lblPublicKey
            // 
            this.lblPublicKey.AutoSize = true;
            this.lblPublicKey.Location = new System.Drawing.Point(17, 163);
            this.lblPublicKey.Name = "lblPublicKey";
            this.lblPublicKey.Size = new System.Drawing.Size(60, 13);
            this.lblPublicKey.TabIndex = 6;
            this.lblPublicKey.Text = "Public Key:";
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
            // lstServers
            // 
            this.lstServers.FormattingEnabled = true;
            this.lstServers.Items.AddRange(new object[] {
            "Lineage Resurrection"});
            this.lstServers.Location = new System.Drawing.Point(194, 15);
            this.lstServers.Name = "lstServers";
            this.lstServers.Size = new System.Drawing.Size(143, 134);
            this.lstServers.TabIndex = 8;
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
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(16, 68);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(55, 13);
            this.lblIp.TabIndex = 10;
            this.lblIp.Text = "IP or DNS";
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
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(16, 36);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(154, 20);
            this.txtServerName.TabIndex = 12;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(16, 84);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(154, 20);
            this.txtIp.TabIndex = 13;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(14, 131);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(65, 20);
            this.txtPort.TabIndex = 14;
            // 
            // btnAddServer
            // 
            this.btnAddServer.Location = new System.Drawing.Point(95, 111);
            this.btnAddServer.Name = "btnAddServer";
            this.btnAddServer.Size = new System.Drawing.Size(75, 23);
            this.btnAddServer.TabIndex = 15;
            this.btnAddServer.Text = "Add";
            this.btnAddServer.UseVisualStyleBackColor = true;
            // 
            // btnRemoveServer
            // 
            this.btnRemoveServer.Location = new System.Drawing.Point(95, 140);
            this.btnRemoveServer.Name = "btnRemoveServer";
            this.btnRemoveServer.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveServer.TabIndex = 16;
            this.btnRemoveServer.Text = "Remove";
            this.btnRemoveServer.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(283, 471);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Config";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtUpdaterFilesRoot
            // 
            this.txtUpdaterFilesRoot.Location = new System.Drawing.Point(121, 20);
            this.txtUpdaterFilesRoot.Name = "txtUpdaterFilesRoot";
            this.txtUpdaterFilesRoot.Size = new System.Drawing.Size(201, 20);
            this.txtUpdaterFilesRoot.TabIndex = 17;
            // 
            // txtUpdaterUrl
            // 
            this.txtUpdaterUrl.Location = new System.Drawing.Point(121, 44);
            this.txtUpdaterUrl.Name = "txtUpdaterUrl";
            this.txtUpdaterUrl.Size = new System.Drawing.Size(201, 20);
            this.txtUpdaterUrl.TabIndex = 18;
            // 
            // txtVersionInfoUrl
            // 
            this.txtVersionInfoUrl.Location = new System.Drawing.Point(121, 68);
            this.txtVersionInfoUrl.Name = "txtVersionInfoUrl";
            this.txtVersionInfoUrl.Size = new System.Drawing.Size(201, 20);
            this.txtVersionInfoUrl.TabIndex = 19;
            // 
            // txtVoteUrl
            // 
            this.txtVoteUrl.Location = new System.Drawing.Point(121, 92);
            this.txtVoteUrl.Name = "txtVoteUrl";
            this.txtVoteUrl.Size = new System.Drawing.Size(201, 20);
            this.txtVoteUrl.TabIndex = 20;
            // 
            // txtWebsiteUrl
            // 
            this.txtWebsiteUrl.Location = new System.Drawing.Point(121, 115);
            this.txtWebsiteUrl.Name = "txtWebsiteUrl";
            this.txtWebsiteUrl.Size = new System.Drawing.Size(201, 20);
            this.txtWebsiteUrl.TabIndex = 21;
            // 
            // txtNewsUrl
            // 
            this.txtNewsUrl.Location = new System.Drawing.Point(121, 138);
            this.txtNewsUrl.Name = "txtNewsUrl";
            this.txtNewsUrl.Size = new System.Drawing.Size(201, 20);
            this.txtNewsUrl.TabIndex = 22;
            // 
            // txtPublicKey
            // 
            this.txtPublicKey.Location = new System.Drawing.Point(121, 162);
            this.txtPublicKey.Name = "txtPublicKey";
            this.txtPublicKey.Size = new System.Drawing.Size(201, 53);
            this.txtPublicKey.TabIndex = 23;
            this.txtPublicKey.Text = "";
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
            this.Text = "AdminInit";
            this.grpSetup.ResumeLayout(false);
            this.grpSetup.PerformLayout();
            this.grpServers.ResumeLayout(false);
            this.grpServers.PerformLayout();
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
    }
}