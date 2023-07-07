namespace GeraçãoDeTemplate.Forms
{
    partial class Pacientes
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
            this.buscarPaciente = new System.Windows.Forms.TextBox();
            this.novoPaciente = new System.Windows.Forms.Button();
            this.tabelaPacientes = new System.Windows.Forms.DataGridView();
            this.botaoCancelar = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataNascimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Deletar = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(302, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pacientes";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(22, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar";
            this.label2.UseWaitCursor = true;
            // 
            // buscarPaciente
            // 
            this.buscarPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buscarPaciente.Location = new System.Drawing.Point(80, 91);
            this.buscarPaciente.Name = "buscarPaciente";
            this.buscarPaciente.Size = new System.Drawing.Size(259, 23);
            this.buscarPaciente.TabIndex = 2;
            this.buscarPaciente.UseWaitCursor = true;
            this.buscarPaciente.TextChanged += new System.EventHandler(this.buscarPacienteTextoAlterado);
            // 
            // novoPaciente
            // 
            this.novoPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.novoPaciente.Location = new System.Drawing.Point(543, 82);
            this.novoPaciente.Name = "novoPaciente";
            this.novoPaciente.Size = new System.Drawing.Size(135, 35);
            this.novoPaciente.TabIndex = 3;
            this.novoPaciente.Text = "Novo Paciente";
            this.novoPaciente.UseVisualStyleBackColor = true;
            this.novoPaciente.UseWaitCursor = true;
            this.novoPaciente.Click += new System.EventHandler(this.criarNovoPaciente);
            // 
            // tabelaPacientes
            // 
            this.tabelaPacientes.AllowUserToAddRows = false;
            this.tabelaPacientes.AllowUserToDeleteRows = false;
            this.tabelaPacientes.AllowUserToResizeColumns = false;
            this.tabelaPacientes.AllowUserToResizeRows = false;
            this.tabelaPacientes.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.tabelaPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaPacientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Nome,
            this.DataNascimento,
            this.Telefone,
            this.Editar,
            this.Deletar});
            this.tabelaPacientes.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabelaPacientes.Location = new System.Drawing.Point(25, 140);
            this.tabelaPacientes.MultiSelect = false;
            this.tabelaPacientes.Name = "tabelaPacientes";
            this.tabelaPacientes.ReadOnly = true;
            this.tabelaPacientes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tabelaPacientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabelaPacientes.Size = new System.Drawing.Size(653, 179);
            this.tabelaPacientes.TabIndex = 4;
            this.tabelaPacientes.UseWaitCursor = true;
            this.tabelaPacientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colunasAcoesClique);
            // 
            // botaoCancelar
            // 
            this.botaoCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.botaoCancelar.Location = new System.Drawing.Point(25, 363);
            this.botaoCancelar.Name = "botaoCancelar";
            this.botaoCancelar.Size = new System.Drawing.Size(80, 33);
            this.botaoCancelar.TabIndex = 5;
            this.botaoCancelar.Text = "Cancelar";
            this.botaoCancelar.UseVisualStyleBackColor = true;
            this.botaoCancelar.UseWaitCursor = true;
            this.botaoCancelar.Click += new System.EventHandler(this.botaoCancelarClique);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.Frozen = true;
            this.dataGridViewImageColumn1.HeaderText = "Editar";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 80;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.Frozen = true;
            this.dataGridViewImageColumn2.HeaderText = "Deletar";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 80;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Nome
            // 
            this.Nome.DataPropertyName = "nome";
            this.Nome.Frozen = true;
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            this.Nome.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Nome.Width = 200;
            // 
            // DataNascimento
            // 
            this.DataNascimento.DataPropertyName = "data_nascimento";
            this.DataNascimento.Frozen = true;
            this.DataNascimento.HeaderText = "Data de Nascimento";
            this.DataNascimento.Name = "DataNascimento";
            this.DataNascimento.ReadOnly = true;
            this.DataNascimento.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataNascimento.Width = 150;
            // 
            // Telefone
            // 
            this.Telefone.DataPropertyName = "telefone";
            this.Telefone.Frozen = true;
            this.Telefone.HeaderText = "Telefone";
            this.Telefone.Name = "Telefone";
            this.Telefone.ReadOnly = true;
            this.Telefone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Editar
            // 
            this.Editar.Frozen = true;
            this.Editar.HeaderText = "Editar";
            this.Editar.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_pencil2;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            this.Editar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Editar.Width = 80;
            // 
            // Deletar
            // 
            this.Deletar.Frozen = true;
            this.Deletar.HeaderText = "Deletar";
            this.Deletar.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_delete;
            this.Deletar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Deletar.Name = "Deletar";
            this.Deletar.ReadOnly = true;
            this.Deletar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Deletar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Deletar.Width = 80;
            // 
            // Pacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 428);
            this.Controls.Add(this.botaoCancelar);
            this.Controls.Add(this.tabelaPacientes);
            this.Controls.Add(this.novoPaciente);
            this.Controls.Add(this.buscarPaciente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Pacientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPacientes";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.FormPacientesCarregar);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaPacientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox buscarPaciente;
        private System.Windows.Forms.Button novoPaciente;
        private System.Windows.Forms.DataGridView tabelaPacientes;
        private System.Windows.Forms.Button botaoCancelar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataNascimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefone;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Deletar;
    }
}