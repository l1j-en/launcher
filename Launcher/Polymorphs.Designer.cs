namespace Launcher
{
    partial class Polymorphs
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
            this.grp_available = new System.Windows.Forms.GroupBox();
            this.lst_available = new System.Windows.Forms.ListBox();
            this.grp_selected = new System.Windows.Forms.GroupBox();
            this.lst_selected = new System.Windows.Forms.ListBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_heading = new Launcher.Controls.GlassButton();
            this.btn_update = new Launcher.Controls.GlassButton();
            this.btnClose = new Launcher.Controls.GlassButton();
            this.grp_available.SuspendLayout();
            this.grp_selected.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_available
            // 
            this.grp_available.Controls.Add(this.lst_available);
            this.grp_available.Location = new System.Drawing.Point(12, 35);
            this.grp_available.Name = "grp_available";
            this.grp_available.Size = new System.Drawing.Size(197, 459);
            this.grp_available.TabIndex = 3;
            this.grp_available.TabStop = false;
            this.grp_available.Text = "Available Polymorphs";
            // 
            // lst_available
            // 
            this.lst_available.FormattingEnabled = true;
            this.lst_available.Location = new System.Drawing.Point(8, 19);
            this.lst_available.Name = "lst_available";
            this.lst_available.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_available.Size = new System.Drawing.Size(181, 433);
            this.lst_available.TabIndex = 5;
            // 
            // grp_selected
            // 
            this.grp_selected.Controls.Add(this.lst_selected);
            this.grp_selected.Location = new System.Drawing.Point(283, 35);
            this.grp_selected.Name = "grp_selected";
            this.grp_selected.Size = new System.Drawing.Size(197, 459);
            this.grp_selected.TabIndex = 4;
            this.grp_selected.TabStop = false;
            this.grp_selected.Text = "Selected Polymorphs";
            // 
            // lst_selected
            // 
            this.lst_selected.FormattingEnabled = true;
            this.lst_selected.Location = new System.Drawing.Point(9, 19);
            this.lst_selected.Name = "lst_selected";
            this.lst_selected.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lst_selected.Size = new System.Drawing.Size(181, 433);
            this.lst_selected.TabIndex = 6;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(227, 179);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(40, 23);
            this.btn_add.TabIndex = 5;
            this.btn_add.Text = ">>";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(227, 226);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(40, 23);
            this.btn_remove.TabIndex = 6;
            this.btn_remove.Text = "<<";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // btn_down
            // 
            this.btn_down.Image = global::Launcher.Properties.Resources.downarrow;
            this.btn_down.Location = new System.Drawing.Point(495, 203);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(26, 23);
            this.btn_down.TabIndex = 8;
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_up
            // 
            this.btn_up.Image = global::Launcher.Properties.Resources.uparrow;
            this.btn_up.Location = new System.Drawing.Point(495, 156);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(26, 23);
            this.btn_up.TabIndex = 7;
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_heading
            // 
            this.btn_heading.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_heading.Location = new System.Drawing.Point(319, 8);
            this.btn_heading.Name = "btn_heading";
            this.btn_heading.Size = new System.Drawing.Size(123, 23);
            this.btn_heading.TabIndex = 10;
            this.btn_heading.Text = "Add Heading";
            this.btn_heading.Click += new System.EventHandler(this.btn_heading_Click);
            // 
            // btn_update
            // 
            this.btn_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_update.Location = new System.Drawing.Point(410, 512);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(119, 29);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Update Poly List!";
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
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
            this.btnClose.Location = new System.Drawing.Point(514, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.OuterBorderColor = System.Drawing.Color.Silver;
            this.btnClose.ShineColor = System.Drawing.Color.Transparent;
            this.btnClose.Size = new System.Drawing.Size(20, 22);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Polymorphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(203)))), ((int)(((byte)(203)))));
            this.ClientSize = new System.Drawing.Size(541, 553);
            this.Controls.Add(this.btn_heading);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.grp_selected);
            this.Controls.Add(this.grp_available);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Polymorphs";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Polymorphs";
            this.Load += new System.EventHandler(this.Polymorphs_Load);
            this.grp_available.ResumeLayout(false);
            this.grp_selected.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GlassButton btnClose;
        private System.Windows.Forms.GroupBox grp_available;
        private System.Windows.Forms.GroupBox grp_selected;
        private System.Windows.Forms.ListBox lst_available;
        private System.Windows.Forms.ListBox lst_selected;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_down;
        private Controls.GlassButton btn_update;
        private Controls.GlassButton btn_heading;
    }
}