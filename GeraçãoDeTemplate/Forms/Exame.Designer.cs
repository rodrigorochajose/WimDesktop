namespace GeraçãoDeTemplate
{
    partial class Exame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Exame));
            this.panelTemplate = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelTemplate = new System.Windows.Forms.Label();
            this.labelPaciente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelFerramentas = new System.Windows.Forms.Panel();
            this.botaoMover = new System.Windows.Forms.Button();
            this.botaoRestaurar = new System.Windows.Forms.Button();
            this.botaoGirarDireita = new System.Windows.Forms.Button();
            this.botaoGirarEsquerda = new System.Windows.Forms.Button();
            this.botaoRetangulo = new System.Windows.Forms.Button();
            this.botaoCirculo = new System.Windows.Forms.Button();
            this.botaoTexto = new System.Windows.Forms.Button();
            this.botaoDesenho = new System.Windows.Forms.Button();
            this.botaoFiltro = new System.Windows.Forms.Button();
            this.botaoRefazer = new System.Windows.Forms.Button();
            this.botaoDesfazer = new System.Windows.Forms.Button();
            this.botaoRegua = new System.Windows.Forms.Button();
            this.botaoLupa = new System.Windows.Forms.Button();
            this.botaoSelecionar = new System.Windows.Forms.Button();
            this.botaoComparar = new System.Windows.Forms.Button();
            this.botaoExcluir = new System.Windows.Forms.Button();
            this.botaoExportar = new System.Windows.Forms.Button();
            this.botaoImportar = new System.Windows.Forms.Button();
            this.conexaoSensor = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelFerramentas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conexaoSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTemplate
            // 
            this.panelTemplate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelTemplate.Location = new System.Drawing.Point(0, 73);
            this.panelTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.panelTemplate.Name = "panelTemplate";
            this.panelTemplate.Size = new System.Drawing.Size(350, 225);
            this.panelTemplate.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(350, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 648);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.labelTemplate);
            this.panel3.Controls.Add(this.labelPaciente);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panelTemplate);
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 645);
            this.panel3.TabIndex = 0;
            // 
            // labelTemplate
            // 
            this.labelTemplate.AutoSize = true;
            this.labelTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplate.Location = new System.Drawing.Point(70, 41);
            this.labelTemplate.Name = "labelTemplate";
            this.labelTemplate.Size = new System.Drawing.Size(113, 13);
            this.labelTemplate.TabIndex = 3;
            this.labelTemplate.Text = "Nome do Template";
            // 
            // labelPaciente
            // 
            this.labelPaciente.AutoSize = true;
            this.labelPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaciente.Location = new System.Drawing.Point(70, 9);
            this.labelPaciente.Name = "labelPaciente";
            this.labelPaciente.Size = new System.Drawing.Size(111, 13);
            this.labelPaciente.TabIndex = 2;
            this.labelPaciente.Text = "Nome do Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Template:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paciente:";
            // 
            // panelFerramentas
            // 
            this.panelFerramentas.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFerramentas.Controls.Add(this.botaoMover);
            this.panelFerramentas.Controls.Add(this.botaoRestaurar);
            this.panelFerramentas.Controls.Add(this.botaoGirarDireita);
            this.panelFerramentas.Controls.Add(this.botaoGirarEsquerda);
            this.panelFerramentas.Controls.Add(this.botaoRetangulo);
            this.panelFerramentas.Controls.Add(this.botaoCirculo);
            this.panelFerramentas.Controls.Add(this.botaoTexto);
            this.panelFerramentas.Controls.Add(this.botaoDesenho);
            this.panelFerramentas.Controls.Add(this.botaoFiltro);
            this.panelFerramentas.Controls.Add(this.botaoRefazer);
            this.panelFerramentas.Controls.Add(this.botaoDesfazer);
            this.panelFerramentas.Controls.Add(this.botaoRegua);
            this.panelFerramentas.Controls.Add(this.botaoLupa);
            this.panelFerramentas.Controls.Add(this.botaoSelecionar);
            this.panelFerramentas.Controls.Add(this.botaoComparar);
            this.panelFerramentas.Controls.Add(this.botaoExcluir);
            this.panelFerramentas.Controls.Add(this.botaoExportar);
            this.panelFerramentas.Controls.Add(this.botaoImportar);
            this.panelFerramentas.Controls.Add(this.conexaoSensor);
            this.panelFerramentas.Location = new System.Drawing.Point(0, 0);
            this.panelFerramentas.Name = "panelFerramentas";
            this.panelFerramentas.Size = new System.Drawing.Size(1375, 50);
            this.panelFerramentas.TabIndex = 5;
            // 
            // botaoMover
            // 
            this.botaoMover.Enabled = false;
            this.botaoMover.FlatAppearance.BorderSize = 0;
            this.botaoMover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoMover.Image = global::GeraçãoDeTemplate.Properties.Resources.move;
            this.botaoMover.Location = new System.Drawing.Point(420, 3);
            this.botaoMover.Margin = new System.Windows.Forms.Padding(0);
            this.botaoMover.Name = "botaoMover";
            this.botaoMover.Size = new System.Drawing.Size(50, 45);
            this.botaoMover.TabIndex = 22;
            this.botaoMover.UseVisualStyleBackColor = true;
            this.botaoMover.Click += new System.EventHandler(this.botaoMoverClique);
            // 
            // botaoRestaurar
            // 
            this.botaoRestaurar.Enabled = false;
            this.botaoRestaurar.FlatAppearance.BorderSize = 0;
            this.botaoRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoRestaurar.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_reset;
            this.botaoRestaurar.Location = new System.Drawing.Point(1108, 3);
            this.botaoRestaurar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoRestaurar.Name = "botaoRestaurar";
            this.botaoRestaurar.Size = new System.Drawing.Size(50, 45);
            this.botaoRestaurar.TabIndex = 21;
            this.botaoRestaurar.UseVisualStyleBackColor = true;
            this.botaoRestaurar.Click += new System.EventHandler(this.botaoRestaurarClique);
            // 
            // botaoGirarDireita
            // 
            this.botaoGirarDireita.Enabled = false;
            this.botaoGirarDireita.FlatAppearance.BorderSize = 0;
            this.botaoGirarDireita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoGirarDireita.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_rotate_right;
            this.botaoGirarDireita.Location = new System.Drawing.Point(1054, 3);
            this.botaoGirarDireita.Margin = new System.Windows.Forms.Padding(0);
            this.botaoGirarDireita.Name = "botaoGirarDireita";
            this.botaoGirarDireita.Size = new System.Drawing.Size(50, 45);
            this.botaoGirarDireita.TabIndex = 20;
            this.botaoGirarDireita.UseVisualStyleBackColor = true;
            this.botaoGirarDireita.Click += new System.EventHandler(this.botaoGirarDireitaClique);
            // 
            // botaoGirarEsquerda
            // 
            this.botaoGirarEsquerda.Enabled = false;
            this.botaoGirarEsquerda.FlatAppearance.BorderSize = 0;
            this.botaoGirarEsquerda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoGirarEsquerda.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_rotate_left;
            this.botaoGirarEsquerda.Location = new System.Drawing.Point(1000, 3);
            this.botaoGirarEsquerda.Margin = new System.Windows.Forms.Padding(0);
            this.botaoGirarEsquerda.Name = "botaoGirarEsquerda";
            this.botaoGirarEsquerda.Size = new System.Drawing.Size(50, 45);
            this.botaoGirarEsquerda.TabIndex = 19;
            this.botaoGirarEsquerda.UseVisualStyleBackColor = true;
            this.botaoGirarEsquerda.Click += new System.EventHandler(this.botaoGirarEsquerdaClique);
            // 
            // botaoRetangulo
            // 
            this.botaoRetangulo.Enabled = false;
            this.botaoRetangulo.FlatAppearance.BorderSize = 0;
            this.botaoRetangulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoRetangulo.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_rectangle;
            this.botaoRetangulo.Location = new System.Drawing.Point(946, 3);
            this.botaoRetangulo.Margin = new System.Windows.Forms.Padding(0);
            this.botaoRetangulo.Name = "botaoRetangulo";
            this.botaoRetangulo.Size = new System.Drawing.Size(50, 45);
            this.botaoRetangulo.TabIndex = 18;
            this.botaoRetangulo.UseVisualStyleBackColor = true;
            this.botaoRetangulo.Click += new System.EventHandler(this.botaoRetanguloClique);
            // 
            // botaoCirculo
            // 
            this.botaoCirculo.Enabled = false;
            this.botaoCirculo.FlatAppearance.BorderSize = 0;
            this.botaoCirculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoCirculo.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_circle;
            this.botaoCirculo.Location = new System.Drawing.Point(882, 3);
            this.botaoCirculo.Margin = new System.Windows.Forms.Padding(0);
            this.botaoCirculo.Name = "botaoCirculo";
            this.botaoCirculo.Size = new System.Drawing.Size(50, 45);
            this.botaoCirculo.TabIndex = 17;
            this.botaoCirculo.UseVisualStyleBackColor = true;
            this.botaoCirculo.Click += new System.EventHandler(this.botaoCirculoClique);
            // 
            // botaoTexto
            // 
            this.botaoTexto.Enabled = false;
            this.botaoTexto.FlatAppearance.BorderSize = 0;
            this.botaoTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoTexto.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_text;
            this.botaoTexto.Location = new System.Drawing.Point(828, 3);
            this.botaoTexto.Margin = new System.Windows.Forms.Padding(0);
            this.botaoTexto.Name = "botaoTexto";
            this.botaoTexto.Size = new System.Drawing.Size(50, 45);
            this.botaoTexto.TabIndex = 16;
            this.botaoTexto.UseVisualStyleBackColor = true;
            this.botaoTexto.Click += new System.EventHandler(this.botaoTextoClique);
            // 
            // botaoDesenho
            // 
            this.botaoDesenho.Enabled = false;
            this.botaoDesenho.FlatAppearance.BorderSize = 0;
            this.botaoDesenho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoDesenho.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_pencil2;
            this.botaoDesenho.Location = new System.Drawing.Point(774, 3);
            this.botaoDesenho.Margin = new System.Windows.Forms.Padding(0);
            this.botaoDesenho.Name = "botaoDesenho";
            this.botaoDesenho.Size = new System.Drawing.Size(50, 45);
            this.botaoDesenho.TabIndex = 15;
            this.botaoDesenho.UseVisualStyleBackColor = true;
            this.botaoDesenho.Click += new System.EventHandler(this.botaoDesenhoClique);
            // 
            // botaoFiltro
            // 
            this.botaoFiltro.Enabled = false;
            this.botaoFiltro.FlatAppearance.BorderSize = 0;
            this.botaoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoFiltro.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_exposure;
            this.botaoFiltro.Location = new System.Drawing.Point(720, 3);
            this.botaoFiltro.Margin = new System.Windows.Forms.Padding(0);
            this.botaoFiltro.Name = "botaoFiltro";
            this.botaoFiltro.Size = new System.Drawing.Size(50, 45);
            this.botaoFiltro.TabIndex = 14;
            this.botaoFiltro.UseVisualStyleBackColor = true;
            this.botaoFiltro.Click += new System.EventHandler(this.botaoFiltroClique);
            // 
            // botaoRefazer
            // 
            this.botaoRefazer.Enabled = false;
            this.botaoRefazer.FlatAppearance.BorderSize = 0;
            this.botaoRefazer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoRefazer.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_redo;
            this.botaoRefazer.Location = new System.Drawing.Point(656, 3);
            this.botaoRefazer.Margin = new System.Windows.Forms.Padding(0);
            this.botaoRefazer.Name = "botaoRefazer";
            this.botaoRefazer.Size = new System.Drawing.Size(50, 45);
            this.botaoRefazer.TabIndex = 13;
            this.botaoRefazer.UseVisualStyleBackColor = true;
            this.botaoRefazer.Click += new System.EventHandler(this.botaoRefazerClique);
            // 
            // botaoDesfazer
            // 
            this.botaoDesfazer.Enabled = false;
            this.botaoDesfazer.FlatAppearance.BorderSize = 0;
            this.botaoDesfazer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoDesfazer.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_undo;
            this.botaoDesfazer.Location = new System.Drawing.Point(592, 3);
            this.botaoDesfazer.Margin = new System.Windows.Forms.Padding(0);
            this.botaoDesfazer.Name = "botaoDesfazer";
            this.botaoDesfazer.Size = new System.Drawing.Size(50, 45);
            this.botaoDesfazer.TabIndex = 12;
            this.botaoDesfazer.UseVisualStyleBackColor = true;
            this.botaoDesfazer.Click += new System.EventHandler(this.botaoDesfazerClique);
            // 
            // botaoRegua
            // 
            this.botaoRegua.Enabled = false;
            this.botaoRegua.FlatAppearance.BorderSize = 0;
            this.botaoRegua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoRegua.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_measure_tape;
            this.botaoRegua.Location = new System.Drawing.Point(538, 3);
            this.botaoRegua.Margin = new System.Windows.Forms.Padding(0);
            this.botaoRegua.Name = "botaoRegua";
            this.botaoRegua.Size = new System.Drawing.Size(50, 45);
            this.botaoRegua.TabIndex = 11;
            this.botaoRegua.UseVisualStyleBackColor = true;
            this.botaoRegua.Click += new System.EventHandler(this.botaoReguaClique);
            // 
            // botaoLupa
            // 
            this.botaoLupa.Enabled = false;
            this.botaoLupa.FlatAppearance.BorderSize = 0;
            this.botaoLupa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoLupa.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_search;
            this.botaoLupa.Location = new System.Drawing.Point(484, 3);
            this.botaoLupa.Margin = new System.Windows.Forms.Padding(0);
            this.botaoLupa.Name = "botaoLupa";
            this.botaoLupa.Size = new System.Drawing.Size(50, 45);
            this.botaoLupa.TabIndex = 10;
            this.botaoLupa.UseVisualStyleBackColor = true;
            this.botaoLupa.Click += new System.EventHandler(this.botaoLupaClique);
            // 
            // botaoSelecionar
            // 
            this.botaoSelecionar.Enabled = false;
            this.botaoSelecionar.FlatAppearance.BorderSize = 0;
            this.botaoSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoSelecionar.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_cursor;
            this.botaoSelecionar.Location = new System.Drawing.Point(366, 3);
            this.botaoSelecionar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoSelecionar.Name = "botaoSelecionar";
            this.botaoSelecionar.Size = new System.Drawing.Size(50, 45);
            this.botaoSelecionar.TabIndex = 9;
            this.botaoSelecionar.UseVisualStyleBackColor = true;
            this.botaoSelecionar.Click += new System.EventHandler(this.botaoSelecionarClique);
            // 
            // botaoComparar
            // 
            this.botaoComparar.Enabled = false;
            this.botaoComparar.FlatAppearance.BorderSize = 0;
            this.botaoComparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoComparar.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_compare;
            this.botaoComparar.Location = new System.Drawing.Point(302, 3);
            this.botaoComparar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoComparar.Name = "botaoComparar";
            this.botaoComparar.Size = new System.Drawing.Size(50, 45);
            this.botaoComparar.TabIndex = 8;
            this.botaoComparar.UseVisualStyleBackColor = true;
            this.botaoComparar.Click += new System.EventHandler(this.botaoCompararClique);
            // 
            // botaoExcluir
            // 
            this.botaoExcluir.Enabled = false;
            this.botaoExcluir.FlatAppearance.BorderSize = 0;
            this.botaoExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoExcluir.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_delete;
            this.botaoExcluir.Location = new System.Drawing.Point(238, 3);
            this.botaoExcluir.Margin = new System.Windows.Forms.Padding(0);
            this.botaoExcluir.Name = "botaoExcluir";
            this.botaoExcluir.Size = new System.Drawing.Size(50, 45);
            this.botaoExcluir.TabIndex = 7;
            this.botaoExcluir.UseVisualStyleBackColor = true;
            this.botaoExcluir.Click += new System.EventHandler(this.botaoExcluirClique);
            // 
            // botaoExportar
            // 
            this.botaoExportar.Enabled = false;
            this.botaoExportar.FlatAppearance.BorderSize = 0;
            this.botaoExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoExportar.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_export;
            this.botaoExportar.Location = new System.Drawing.Point(174, 3);
            this.botaoExportar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoExportar.Name = "botaoExportar";
            this.botaoExportar.Size = new System.Drawing.Size(50, 45);
            this.botaoExportar.TabIndex = 6;
            this.botaoExportar.UseVisualStyleBackColor = true;
            this.botaoExportar.Click += new System.EventHandler(this.botaoExportarClique);
            // 
            // botaoImportar
            // 
            this.botaoImportar.FlatAppearance.BorderSize = 0;
            this.botaoImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botaoImportar.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_import;
            this.botaoImportar.Location = new System.Drawing.Point(120, 2);
            this.botaoImportar.Margin = new System.Windows.Forms.Padding(0);
            this.botaoImportar.Name = "botaoImportar";
            this.botaoImportar.Size = new System.Drawing.Size(50, 45);
            this.botaoImportar.TabIndex = 5;
            this.botaoImportar.UseVisualStyleBackColor = true;
            this.botaoImportar.Click += new System.EventHandler(this.botaoImportarClique);
            // 
            // conexaoSensor
            // 
            this.conexaoSensor.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_red;
            this.conexaoSensor.InitialImage = ((System.Drawing.Image)(resources.GetObject("conexaoSensor.InitialImage")));
            this.conexaoSensor.Location = new System.Drawing.Point(0, 0);
            this.conexaoSensor.Margin = new System.Windows.Forms.Padding(0);
            this.conexaoSensor.Name = "conexaoSensor";
            this.conexaoSensor.Size = new System.Drawing.Size(64, 50);
            this.conexaoSensor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.conexaoSensor.TabIndex = 4;
            this.conexaoSensor.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1025, 648);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Exame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 696);
            this.Controls.Add(this.panelFerramentas);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Name = "Exame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exame";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ExameCarregar);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelFerramentas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.conexaoSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTemplate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTemplate;
        private System.Windows.Forms.Label labelPaciente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox conexaoSensor;
        private System.Windows.Forms.Panel panelFerramentas;
        private System.Windows.Forms.Button botaoImportar;
        private System.Windows.Forms.Button botaoExportar;
        private System.Windows.Forms.Button botaoRestaurar;
        private System.Windows.Forms.Button botaoGirarDireita;
        private System.Windows.Forms.Button botaoGirarEsquerda;
        private System.Windows.Forms.Button botaoRetangulo;
        private System.Windows.Forms.Button botaoCirculo;
        private System.Windows.Forms.Button botaoTexto;
        private System.Windows.Forms.Button botaoDesenho;
        private System.Windows.Forms.Button botaoFiltro;
        private System.Windows.Forms.Button botaoRefazer;
        private System.Windows.Forms.Button botaoDesfazer;
        private System.Windows.Forms.Button botaoRegua;
        private System.Windows.Forms.Button botaoLupa;
        private System.Windows.Forms.Button botaoSelecionar;
        private System.Windows.Forms.Button botaoComparar;
        private System.Windows.Forms.Button botaoExcluir;
        private System.Windows.Forms.Button botaoMover;
    }
}