namespace DMMDigital.Views
{
    partial class MigrationDatabaseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MigrationDatabaseView));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(86, 87);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(360, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label.Location = new System.Drawing.Point(92, 37);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(52, 21);
            this.label.TabIndex = 1;
            this.label.Text = "label1";
            // 
            // MigrationDatabaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(514, 148);
            this.Controls.Add(this.label);
            this.Controls.Add(this.progressBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MigrationDatabaseView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Migração de Dados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label;
    }
}