using Launcher.Controls;

namespace Launcher
{
    partial class Patcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patcher));
            this.lblAutoUpdate = new Launcher.Controls.OutlineLabel();
            this.lblUpdateStatus = new Launcher.Controls.OutlineLabel();
            this.lblCurrentProgress = new Launcher.Controls.OutlineLabel();
            this.lblTotalProgress = new Launcher.Controls.OutlineLabel();
            this.btnCancel = new Launcher.Controls.GlassButton();
            this.prgCurrent = new System.Windows.Forms.ProgressBar();
            this.prgTotal = new System.Windows.Forms.ProgressBar();
            this.updateChecker = new System.ComponentModel.BackgroundWorker();
            this.patchWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lblAutoUpdate
            // 
            this.lblAutoUpdate.AutoSize = true;
            this.lblAutoUpdate.BackColor = System.Drawing.Color.Transparent;
            this.lblAutoUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblAutoUpdate.ForeColor = System.Drawing.Color.White;
            this.lblAutoUpdate.Location = new System.Drawing.Point(59, 13);
            this.lblAutoUpdate.Name = "lblAutoUpdate";
            this.lblAutoUpdate.OutlineForeColor = System.Drawing.Color.Black;
            this.lblAutoUpdate.OutlineWidth = 2F;
            this.lblAutoUpdate.Size = new System.Drawing.Size(91, 17);
            this.lblAutoUpdate.TabIndex = 0;
            this.lblAutoUpdate.Text = "Auto Update:";
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.lblUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.lblUpdateStatus.Location = new System.Drawing.Point(156, 13);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.OutlineForeColor = System.Drawing.Color.Black;
            this.lblUpdateStatus.OutlineWidth = 2F;
            this.lblUpdateStatus.Size = new System.Drawing.Size(130, 17);
            this.lblUpdateStatus.TabIndex = 1;
            this.lblUpdateStatus.Text = "Downloading files...";
            // 
            // lblCurrentProgress
            // 
            this.lblCurrentProgress.AutoSize = true;
            this.lblCurrentProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentProgress.ForeColor = System.Drawing.Color.White;
            this.lblCurrentProgress.Location = new System.Drawing.Point(49, 58);
            this.lblCurrentProgress.Name = "lblCurrentProgress";
            this.lblCurrentProgress.OutlineForeColor = System.Drawing.Color.Black;
            this.lblCurrentProgress.OutlineWidth = 2F;
            this.lblCurrentProgress.Size = new System.Drawing.Size(91, 13);
            this.lblCurrentProgress.TabIndex = 2;
            this.lblCurrentProgress.Text = "Current Progress: ";
            // 
            // lblTotalProgress
            // 
            this.lblTotalProgress.AutoSize = true;
            this.lblTotalProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalProgress.ForeColor = System.Drawing.Color.White;
            this.lblTotalProgress.Location = new System.Drawing.Point(62, 80);
            this.lblTotalProgress.Name = "lblTotalProgress";
            this.lblTotalProgress.OutlineForeColor = System.Drawing.Color.Black;
            this.lblTotalProgress.OutlineWidth = 2F;
            this.lblTotalProgress.Size = new System.Drawing.Size(78, 13);
            this.lblTotalProgress.TabIndex = 3;
            this.lblTotalProgress.Text = "Total Progress:";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.GlowColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.Location = new System.Drawing.Point(433, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.OuterBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.ShineColor = System.Drawing.Color.Transparent;
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.SpecialSymbolColor = System.Drawing.Color.Transparent;
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // prgCurrent
            // 
            this.prgCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.prgCurrent.ForeColor = System.Drawing.Color.Blue;
            this.prgCurrent.Location = new System.Drawing.Point(146, 58);
            this.prgCurrent.Name = "prgCurrent";
            this.prgCurrent.Size = new System.Drawing.Size(274, 13);
            this.prgCurrent.TabIndex = 5;
            // 
            // prgTotal
            // 
            this.prgTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.prgTotal.ForeColor = System.Drawing.Color.Red;
            this.prgTotal.Location = new System.Drawing.Point(146, 80);
            this.prgTotal.Name = "prgTotal";
            this.prgTotal.Size = new System.Drawing.Size(274, 13);
            this.prgTotal.TabIndex = 6;
            // 
            // updateChecker
            // 
            this.updateChecker.WorkerReportsProgress = true;
            this.updateChecker.WorkerSupportsCancellation = true;
            this.updateChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.updateChecker_DoWork);
            this.updateChecker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.updateChecker_ProgressChanged);
            this.updateChecker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.updateChecker_RunWorkerCompleted);
            // 
            // patchWorker
            // 
            this.patchWorker.WorkerReportsProgress = true;
            this.patchWorker.WorkerSupportsCancellation = true;
            this.patchWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.patchWorker_DoWork);
            this.patchWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.patchWorker_ProgressChanged);
            this.patchWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.patchWorker_RunWorkerCompleted);
            // 
            // Patcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(517, 127);
            this.Controls.Add(this.prgTotal);
            this.Controls.Add(this.prgCurrent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTotalProgress);
            this.Controls.Add(this.lblCurrentProgress);
            this.Controls.Add(this.lblUpdateStatus);
            this.Controls.Add(this.lblAutoUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Patcher";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OutlineLabel lblAutoUpdate;
        private OutlineLabel lblUpdateStatus;
        private OutlineLabel lblCurrentProgress;
        private OutlineLabel lblTotalProgress;
        private GlassButton btnCancel;
        private System.Windows.Forms.ProgressBar prgCurrent;
        private System.Windows.Forms.ProgressBar prgTotal;
        private System.ComponentModel.BackgroundWorker updateChecker;
        private System.ComponentModel.BackgroundWorker patchWorker;
    }
}