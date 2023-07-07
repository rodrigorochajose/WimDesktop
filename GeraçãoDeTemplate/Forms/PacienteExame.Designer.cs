namespace GeraçãoDeTemplate.Forms
{
    partial class PacienteExame
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.botaoNovoPaciente = new System.Windows.Forms.Button();
            this.tabelaPacienteExame = new System.Windows.Forms.DataGridView();
            this.id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nome1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataNascimento1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.botaoSelecionarPacienteExame = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaPacienteExame)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(133, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione um paciente para o Exame";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(31, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.Location = new System.Drawing.Point(89, 91);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 23);
            this.textBox1.TabIndex = 2;
            // 
            // botaoNovoPaciente
            // 
            this.botaoNovoPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.botaoNovoPaciente.Location = new System.Drawing.Point(499, 91);
            this.botaoNovoPaciente.Name = "botaoNovoPaciente";
            this.botaoNovoPaciente.Size = new System.Drawing.Size(146, 25);
            this.botaoNovoPaciente.TabIndex = 3;
            this.botaoNovoPaciente.Text = "Novo Paciente";
            this.botaoNovoPaciente.UseVisualStyleBackColor = true;
            this.botaoNovoPaciente.Click += new System.EventHandler(this.botaoNovoPacienteClique);
            // 
            // tabelaPacienteExame
            // 
            this.tabelaPacienteExame.AllowUserToAddRows = false;
            this.tabelaPacienteExame.AllowUserToDeleteRows = false;
            this.tabelaPacienteExame.AllowUserToResizeColumns = false;
            this.tabelaPacienteExame.AllowUserToResizeRows = false;
            this.tabelaPacienteExame.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaPacienteExame.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id1,
            this.nome1,
            this.dataNascimento1,
            this.telefone1});
            this.tabelaPacienteExame.Location = new System.Drawing.Point(89, 154);
            this.tabelaPacienteExame.MultiSelect = false;
            this.tabelaPacienteExame.Name = "tabelaPacienteExame";
            this.tabelaPacienteExame.ReadOnly = true;
            this.tabelaPacienteExame.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tabelaPacienteExame.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaPacienteExame.Size = new System.Drawing.Size(493, 260);
            this.tabelaPacienteExame.TabIndex = 4;
            // 
            // id1
            // 
            this.id1.DataPropertyName = "id";
            this.id1.Frozen = true;
            this.id1.HeaderText = "id";
            this.id1.Name = "id1";
            this.id1.ReadOnly = true;
            this.id1.Visible = false;
            // 
            // nome1
            // 
            this.nome1.DataPropertyName = "nome";
            this.nome1.Frozen = true;
            this.nome1.HeaderText = "Nome";
            this.nome1.Name = "nome1";
            this.nome1.ReadOnly = true;
            this.nome1.Width = 200;
            // 
            // dataNascimento1
            // 
            this.dataNascimento1.DataPropertyName = "data_nascimento";
            this.dataNascimento1.Frozen = true;
            this.dataNascimento1.HeaderText = "Data de Nascimento";
            this.dataNascimento1.Name = "dataNascimento1";
            this.dataNascimento1.ReadOnly = true;
            this.dataNascimento1.Width = 150;
            // 
            // telefone1
            // 
            this.telefone1.DataPropertyName = "telefone";
            this.telefone1.Frozen = true;
            this.telefone1.HeaderText = "Telefone";
            this.telefone1.Name = "telefone1";
            this.telefone1.ReadOnly = true;
            // 
            // botaoSelecionarPacienteExame
            // 
            this.botaoSelecionarPacienteExame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.botaoSelecionarPacienteExame.Location = new System.Drawing.Point(559, 461);
            this.botaoSelecionarPacienteExame.Name = "botaoSelecionarPacienteExame";
            this.botaoSelecionarPacienteExame.Size = new System.Drawing.Size(89, 34);
            this.botaoSelecionarPacienteExame.TabIndex = 6;
            this.botaoSelecionarPacienteExame.Text = "Selecionar";
            this.botaoSelecionarPacienteExame.UseVisualStyleBackColor = true;
            this.botaoSelecionarPacienteExame.Click += new System.EventHandler(this.botaoSelecionarPacienteExameClique);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button2.Location = new System.Drawing.Point(15, 461);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 34);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PacienteExame
            // 
            this.ClientSize = new System.Drawing.Size(665, 520);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.botaoSelecionarPacienteExame);
            this.Controls.Add(this.tabelaPacienteExame);
            this.Controls.Add(this.botaoNovoPaciente);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PacienteExame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PacienteExameCarregar);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaPacienteExame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button botaoNovoPaciente;
        private System.Windows.Forms.DataGridView tabelaPacienteExame;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataNascimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.Button botaoSelecionarPacienteExame;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nome1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataNascimento1;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefone1;
    }
}