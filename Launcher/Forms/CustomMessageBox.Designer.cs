namespace Launcher.Forms
{
    partial class CustomMessageBox
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(90, 23);
            this.lblMessage.MaximumSize = new System.Drawing.Size(465, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 15);
            this.lblMessage.TabIndex = 1;
            // 
            // icon
            // 
            this.icon.Location = new System.Drawing.Point(15, 19);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(64, 64);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(466, 101);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.icon);
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Location = new System.Drawing.Point(0, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 100);
            this.panel1.TabIndex = 3;
            // 
            // CustomMessageBox
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 141);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomMessageBox";
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
    }
}