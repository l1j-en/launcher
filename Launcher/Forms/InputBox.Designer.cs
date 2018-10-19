namespace Launcher.Forms
{
    partial class InputBox
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
            this.btnClose = new Launcher.Controls.GlassButton();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.btn_ok = new Launcher.Controls.GlassButton();
            this.btn_cancel = new Launcher.Controls.GlassButton();
            this.lbl_prompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(368, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.OuterBorderColor = System.Drawing.Color.Silver;
            this.btnClose.ShineColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(20, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txt_input
            // 
            this.txt_input.Location = new System.Drawing.Point(36, 49);
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(341, 20);
            this.txt_input.TabIndex = 4;
            // 
            // btn_ok
            // 
            this.btn_ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ok.GlowColor = System.Drawing.Color.Blue;
            this.btn_ok.Location = new System.Drawing.Point(302, 85);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.GlowColor = System.Drawing.Color.Red;
            this.btn_cancel.Location = new System.Drawing.Point(221, 85);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_prompt
            // 
            this.lbl_prompt.AutoSize = true;
            this.lbl_prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_prompt.Location = new System.Drawing.Point(33, 15);
            this.lbl_prompt.Name = "lbl_prompt";
            this.lbl_prompt.Size = new System.Drawing.Size(47, 15);
            this.lbl_prompt.TabIndex = 7;
            this.lbl_prompt.Text = "label1";
            // 
            // InputBox
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(390, 120);
            this.Controls.Add(this.lbl_prompt);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_input);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.GlassButton btnClose;
        private System.Windows.Forms.TextBox txt_input;
        private Controls.GlassButton btn_ok;
        private Controls.GlassButton btn_cancel;
        private System.Windows.Forms.Label lbl_prompt;
    }
}