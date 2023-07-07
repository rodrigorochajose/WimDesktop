namespace GeraçãoDeTemplate.Forms
{
    partial class TemplateExame
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
            this.botaoIniciarRadiografia = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.novoTemplate = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxObservacao = new System.Windows.Forms.TextBox();
            this.textBoxIndicacao = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDataNascimento = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.titulo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // botaoIniciarRadiografia
            // 
            this.botaoIniciarRadiografia.AutoSize = true;
            this.botaoIniciarRadiografia.BackColor = System.Drawing.Color.White;
            this.botaoIniciarRadiografia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.botaoIniciarRadiografia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.botaoIniciarRadiografia.FlatAppearance.BorderSize = 0;
            this.botaoIniciarRadiografia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.botaoIniciarRadiografia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.botaoIniciarRadiografia.Location = new System.Drawing.Point(881, 538);
            this.botaoIniciarRadiografia.Margin = new System.Windows.Forms.Padding(0);
            this.botaoIniciarRadiografia.Name = "botaoIniciarRadiografia";
            this.botaoIniciarRadiografia.Size = new System.Drawing.Size(75, 27);
            this.botaoIniciarRadiografia.TabIndex = 14;
            this.botaoIniciarRadiografia.Text = "Iniciar";
            this.botaoIniciarRadiografia.UseVisualStyleBackColor = false;
            this.botaoIniciarRadiografia.Click += new System.EventHandler(this.botaoIniciarRadiografiaClique);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(48, 542);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.novoTemplate);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(488, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(468, 406);
            this.panel2.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(53, 151);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 225);
            this.panel3.TabIndex = 17;
            // 
            // novoTemplate
            // 
            this.novoTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.novoTemplate.Location = new System.Drawing.Point(312, 97);
            this.novoTemplate.Name = "novoTemplate";
            this.novoTemplate.Size = new System.Drawing.Size(125, 33);
            this.novoTemplate.TabIndex = 8;
            this.novoTemplate.Text = "Novo Template";
            this.novoTemplate.UseVisualStyleBackColor = true;
            this.novoTemplate.Click += new System.EventHandler(this.novoTemplateClique);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(23, 102);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(260, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.selecionaTemplate);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(21, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(19, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Template";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label10.Location = new System.Drawing.Point(19, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(200, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Nome da Sessão Radiográfica";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBoxObservacao);
            this.panel1.Controls.Add(this.textBoxIndicacao);
            this.panel1.Controls.Add(this.textBoxNome);
            this.panel1.Controls.Add(this.textBoxTelefone);
            this.panel1.Controls.Add(this.textBoxDataNascimento);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(35, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 377);
            this.panel1.TabIndex = 11;
            // 
            // textBoxObservacao
            // 
            this.textBoxObservacao.Enabled = false;
            this.textBoxObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxObservacao.Location = new System.Drawing.Point(22, 236);
            this.textBoxObservacao.Multiline = true;
            this.textBoxObservacao.Name = "textBoxObservacao";
            this.textBoxObservacao.ReadOnly = true;
            this.textBoxObservacao.Size = new System.Drawing.Size(297, 86);
            this.textBoxObservacao.TabIndex = 12;
            // 
            // textBoxIndicacao
            // 
            this.textBoxIndicacao.Enabled = false;
            this.textBoxIndicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxIndicacao.Location = new System.Drawing.Point(22, 188);
            this.textBoxIndicacao.Name = "textBoxIndicacao";
            this.textBoxIndicacao.ReadOnly = true;
            this.textBoxIndicacao.Size = new System.Drawing.Size(248, 23);
            this.textBoxIndicacao.TabIndex = 11;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Enabled = false;
            this.textBoxNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxNome.Location = new System.Drawing.Point(22, 44);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.ReadOnly = true;
            this.textBoxNome.Size = new System.Drawing.Size(248, 23);
            this.textBoxNome.TabIndex = 10;
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Enabled = false;
            this.textBoxTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxTelefone.Location = new System.Drawing.Point(22, 141);
            this.textBoxTelefone.Mask = "(99) 99999-9999";
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.ReadOnly = true;
            this.textBoxTelefone.Size = new System.Drawing.Size(137, 23);
            this.textBoxTelefone.TabIndex = 9;
            // 
            // textBoxDataNascimento
            // 
            this.textBoxDataNascimento.Enabled = false;
            this.textBoxDataNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxDataNascimento.Location = new System.Drawing.Point(22, 93);
            this.textBoxDataNascimento.Mask = "00/00/0000";
            this.textBoxDataNascimento.Name = "textBoxDataNascimento";
            this.textBoxDataNascimento.ReadOnly = true;
            this.textBoxDataNascimento.Size = new System.Drawing.Size(137, 23);
            this.textBoxDataNascimento.TabIndex = 8;
            this.textBoxDataNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(19, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Observações";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(19, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Indicação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(19, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(19, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data de Nascimento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nome do Paciente";
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.titulo.Location = new System.Drawing.Point(388, 19);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(168, 31);
            this.titulo.TabIndex = 10;
            this.titulo.Text = "Novo Exame";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(37, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Paciente";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(484, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Radiografia";
            // 
            // TemplateExame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 593);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.botaoIniciarRadiografia);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titulo);
            this.Name = "TemplateExame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TemplateExame";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botaoIniciarRadiografia;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button novoTemplate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.TextBox textBoxObservacao;
        private System.Windows.Forms.TextBox textBoxIndicacao;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.MaskedTextBox textBoxTelefone;
        private System.Windows.Forms.MaskedTextBox textBoxDataNascimento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
    }
}