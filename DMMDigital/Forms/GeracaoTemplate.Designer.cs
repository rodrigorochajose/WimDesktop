namespace DMMDigital
{
    partial class GeracaoTemplate
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
            this.gerarTemplate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.orientacao = new System.Windows.Forms.ListBox();
            this.quantidadeLinhas = new System.Windows.Forms.NumericUpDown();
            this.quantidadeColunas = new System.Windows.Forms.NumericUpDown();
            this.nomeDoTemplate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeLinhas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeColunas)).BeginInit();
            this.SuspendLayout();
            // 
            // gerarTemplate
            // 
            this.gerarTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gerarTemplate.Location = new System.Drawing.Point(134, 238);
            this.gerarTemplate.Name = "gerarTemplate";
            this.gerarTemplate.Size = new System.Drawing.Size(100, 30);
            this.gerarTemplate.TabIndex = 0;
            this.gerarTemplate.Text = "Gerar";
            this.gerarTemplate.UseVisualStyleBackColor = true;
            this.gerarTemplate.Click += new System.EventHandler(this.GerarTemplate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(14, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantidade de Linhas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(217, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade de Colunas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(145, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Orientação";
            // 
            // orientacao
            // 
            this.orientacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.orientacao.FormattingEnabled = true;
            this.orientacao.ItemHeight = 16;
            this.orientacao.Items.AddRange(new object[] {
            "Vertical",
            "Horizontal Esquerda",
            "Horizontal Direita"});
            this.orientacao.Location = new System.Drawing.Point(111, 157);
            this.orientacao.Name = "orientacao";
            this.orientacao.Size = new System.Drawing.Size(155, 52);
            this.orientacao.TabIndex = 6;
            // 
            // quantidadeLinhas
            // 
            this.quantidadeLinhas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.quantidadeLinhas.Location = new System.Drawing.Point(53, 100);
            this.quantidadeLinhas.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.quantidadeLinhas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantidadeLinhas.Name = "quantidadeLinhas";
            this.quantidadeLinhas.Size = new System.Drawing.Size(48, 23);
            this.quantidadeLinhas.TabIndex = 7;
            this.quantidadeLinhas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quantidadeColunas
            // 
            this.quantidadeColunas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.quantidadeColunas.Location = new System.Drawing.Point(276, 100);
            this.quantidadeColunas.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.quantidadeColunas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantidadeColunas.Name = "quantidadeColunas";
            this.quantidadeColunas.Size = new System.Drawing.Size(48, 23);
            this.quantidadeColunas.TabIndex = 8;
            this.quantidadeColunas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nomeDoTemplate
            // 
            this.nomeDoTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.nomeDoTemplate.Location = new System.Drawing.Point(148, 24);
            this.nomeDoTemplate.Name = "nomeDoTemplate";
            this.nomeDoTemplate.Size = new System.Drawing.Size(224, 23);
            this.nomeDoTemplate.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(14, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nome do Template";
            // 
            // GeracaoTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 280);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nomeDoTemplate);
            this.Controls.Add(this.quantidadeColunas);
            this.Controls.Add(this.quantidadeLinhas);
            this.Controls.Add(this.orientacao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gerarTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GeracaoTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiálogoGeraçãoTemplate";
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeLinhas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantidadeColunas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gerarTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox orientacao;
        private System.Windows.Forms.NumericUpDown quantidadeLinhas;
        private System.Windows.Forms.NumericUpDown quantidadeColunas;
        private System.Windows.Forms.TextBox nomeDoTemplate;
        private System.Windows.Forms.Label label4;
    }
}