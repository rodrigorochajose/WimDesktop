namespace DMMDigital.Forms
{
    partial class ConfigView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigView));
            this.labelCaminho = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // labelCaminho
            // 
            this.labelCaminho.AutoSize = true;
            this.labelCaminho.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCaminho.Location = new System.Drawing.Point(55, 27);
            this.labelCaminho.Name = "labelCaminho";
            this.labelCaminho.Size = new System.Drawing.Size(239, 20);
            this.labelCaminho.TabIndex = 0;
            this.labelCaminho.Text = "Caminho para salvar Radiografia";
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonSave.Location = new System.Drawing.Point(124, 141);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(95, 32);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Salvar";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxPath.Location = new System.Drawing.Point(16, 64);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(332, 23);
            this.textBoxPath.TabIndex = 2;
            // 
            // ConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 201);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelCaminho);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCaminho;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}