namespace DMMDigital
{
    partial class GerenciarTemplate
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.novoFilme = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orientacaoAtual = new System.Windows.Forms.TextBox();
            this.botaoGirarFilmeDireita = new System.Windows.Forms.Button();
            this.botaoGirarFilmeEsquerda = new System.Windows.Forms.Button();
            this.excluirFilme = new System.Windows.Forms.Button();
            this.salvarTemplate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.filmeAtual = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // novoFilme
            // 
            this.novoFilme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.novoFilme.Location = new System.Drawing.Point(37, 286);
            this.novoFilme.Name = "novoFilme";
            this.novoFilme.Size = new System.Drawing.Size(128, 30);
            this.novoFilme.TabIndex = 1;
            this.novoFilme.Text = "Novo Filme";
            this.novoFilme.UseVisualStyleBackColor = true;
            this.novoFilme.Click += new System.EventHandler(this.GerarNovoFilme);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.orientacaoAtual);
            this.panel1.Controls.Add(this.botaoGirarFilmeDireita);
            this.panel1.Controls.Add(this.botaoGirarFilmeEsquerda);
            this.panel1.Controls.Add(this.excluirFilme);
            this.panel1.Controls.Add(this.salvarTemplate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.filmeAtual);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.novoFilme);
            this.panel1.Location = new System.Drawing.Point(700, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 460);
            this.panel1.TabIndex = 2;
            // 
            // orientacaoAtual
            // 
            this.orientacaoAtual.Enabled = false;
            this.orientacaoAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.orientacaoAtual.Location = new System.Drawing.Point(13, 117);
            this.orientacaoAtual.Name = "orientacaoAtual";
            this.orientacaoAtual.Size = new System.Drawing.Size(157, 26);
            this.orientacaoAtual.TabIndex = 14;
            // 
            // botaoGirarFilmeDireita
            // 
            this.botaoGirarFilmeDireita.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.botaoGirarFilmeDireita.Location = new System.Drawing.Point(101, 155);
            this.botaoGirarFilmeDireita.Name = "botaoGirarFilmeDireita";
            this.botaoGirarFilmeDireita.Size = new System.Drawing.Size(43, 38);
            this.botaoGirarFilmeDireita.TabIndex = 12;
            this.botaoGirarFilmeDireita.UseVisualStyleBackColor = true;
            this.botaoGirarFilmeDireita.Click += new System.EventHandler(this.botaoGirarFilmeDireitaClique);
            // 
            // botaoGirarFilmeEsquerda
            // 
            this.botaoGirarFilmeEsquerda.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_left;
            this.botaoGirarFilmeEsquerda.Location = new System.Drawing.Point(33, 155);
            this.botaoGirarFilmeEsquerda.Name = "botaoGirarFilmeEsquerda";
            this.botaoGirarFilmeEsquerda.Size = new System.Drawing.Size(43, 38);
            this.botaoGirarFilmeEsquerda.TabIndex = 11;
            this.botaoGirarFilmeEsquerda.UseVisualStyleBackColor = true;
            this.botaoGirarFilmeEsquerda.Click += new System.EventHandler(this.botaoGirarFilmeEsquerdaClique);
            // 
            // excluirFilme
            // 
            this.excluirFilme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.excluirFilme.Location = new System.Drawing.Point(37, 322);
            this.excluirFilme.Name = "excluirFilme";
            this.excluirFilme.Size = new System.Drawing.Size(128, 30);
            this.excluirFilme.TabIndex = 10;
            this.excluirFilme.Text = "Excluir Filme";
            this.excluirFilme.UseVisualStyleBackColor = true;
            this.excluirFilme.Click += new System.EventHandler(this.ExcluirFilme);
            // 
            // salvarTemplate
            // 
            this.salvarTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.salvarTemplate.Location = new System.Drawing.Point(55, 406);
            this.salvarTemplate.Name = "salvarTemplate";
            this.salvarTemplate.Size = new System.Drawing.Size(84, 30);
            this.salvarTemplate.TabIndex = 9;
            this.salvarTemplate.Text = "Salvar";
            this.salvarTemplate.UseVisualStyleBackColor = true;
            this.salvarTemplate.Click += new System.EventHandler(this.SalvarTemplate);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Orientação";
            // 
            // filmeAtual
            // 
            this.filmeAtual.Enabled = false;
            this.filmeAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.filmeAtual.Location = new System.Drawing.Point(13, 40);
            this.filmeAtual.Name = "filmeAtual";
            this.filmeAtual.Size = new System.Drawing.Size(157, 26);
            this.filmeAtual.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filme";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 460);
            this.panel2.TabIndex = 11;
            // 
            // GerenciarTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GerenciarTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciador Template";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button novoFilme;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filmeAtual;
        private System.Windows.Forms.Button salvarTemplate;
        private System.Windows.Forms.Button excluirFilme;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button botaoGirarFilmeEsquerda;
        private System.Windows.Forms.Button botaoGirarFilmeDireita;
        private System.Windows.Forms.TextBox orientacaoAtual;
    }
}

