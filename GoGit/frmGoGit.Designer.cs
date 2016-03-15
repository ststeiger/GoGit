namespace GoGit
{
    partial class frmGoGit
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCommitAndPush = new System.Windows.Forms.Button();
            this.txtRepo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCommitAndPush
            // 
            this.btnCommitAndPush.Location = new System.Drawing.Point(12, 55);
            this.btnCommitAndPush.Name = "btnCommitAndPush";
            this.btnCommitAndPush.Size = new System.Drawing.Size(600, 23);
            this.btnCommitAndPush.TabIndex = 0;
            this.btnCommitAndPush.Text = "Commit all && Push";
            this.btnCommitAndPush.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommitAndPush.UseVisualStyleBackColor = true;
            this.btnCommitAndPush.Click += new System.EventHandler(this.btnCommitAndPush_Click);
            // 
            // txtRepo
            // 
            this.txtRepo.Location = new System.Drawing.Point(12, 12);
            this.txtRepo.Name = "txtRepo";
            this.txtRepo.Size = new System.Drawing.Size(600, 20);
            this.txtRepo.TabIndex = 1;
            this.txtRepo.Text = "https://github.com/ststeiger/GolangTestRepo.git";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 96);
            this.Controls.Add(this.txtRepo);
            this.Controls.Add(this.btnCommitAndPush);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GoGit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommitAndPush;
        private System.Windows.Forms.TextBox txtRepo;
    }
}

