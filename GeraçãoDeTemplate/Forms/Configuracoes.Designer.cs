namespace GeraçãoDeTemplate.Forms
{
    partial class Configuracoes
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
            this.labelCaminho = new System.Windows.Forms.Label();
            this.botaoSalvar = new System.Windows.Forms.Button();
            this.textBoxCaminho = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // labelCaminho
            // 
            this.labelCaminho.AutoSize = true;
            this.labelCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCaminho.Location = new System.Drawing.Point(55, 27);
            this.labelCaminho.Name = "labelCaminho";
            this.labelCaminho.Size = new System.Drawing.Size(239, 20);
            this.labelCaminho.TabIndex = 0;
            this.labelCaminho.Text = "Caminho para salvar Radiografia";
            // 
            // botaoSalvar
            // 
            this.botaoSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.botaoSalvar.Location = new System.Drawing.Point(124, 141);
            this.botaoSalvar.Name = "botaoSalvar";
            this.botaoSalvar.Size = new System.Drawing.Size(95, 32);
            this.botaoSalvar.TabIndex = 1;
            this.botaoSalvar.Text = "Salvar";
            this.botaoSalvar.UseVisualStyleBackColor = true;
            this.botaoSalvar.Click += new System.EventHandler(this.botaoSalvarClique);
            // 
            // textBoxCaminho
            // 
            this.textBoxCaminho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxCaminho.Location = new System.Drawing.Point(16, 64);
            this.textBoxCaminho.Name = "textBoxCaminho";
            this.textBoxCaminho.Size = new System.Drawing.Size(332, 23);
            this.textBoxCaminho.TabIndex = 2;
            this.textBoxCaminho.Click += new System.EventHandler(this.textBoxCaminhoClique);
            // 
            // Configuracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 201);
            this.Controls.Add(this.textBoxCaminho);
            this.Controls.Add(this.botaoSalvar);
            this.Controls.Add(this.labelCaminho);
            this.Name = "Configuracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracoes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelCaminho;
        private System.Windows.Forms.Button botaoSalvar;
        private System.Windows.Forms.TextBox textBoxCaminho;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}