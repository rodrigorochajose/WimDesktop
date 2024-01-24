namespace DMMDigital.Views
{
    partial class PatientView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientView));
            this.buttonNewPatient = new System.Windows.Forms.Button();
            this.dataGridViewPatient = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonExportExam = new System.Windows.Forms.Button();
            this.buttonDeleteExam = new System.Windows.Forms.Button();
            this.buttonOpenExam = new System.Windows.Forms.Button();
            this.buttonNewExam = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewExam = new System.Windows.Forms.DataGridView();
            this.session = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.template = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearchPatient = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSearchPatient = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewPatient
            // 
            this.buttonNewPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNewPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewPatient.Location = new System.Drawing.Point(573, 66);
            this.buttonNewPatient.Name = "buttonNewPatient";
            this.buttonNewPatient.Size = new System.Drawing.Size(82, 26);
            this.buttonNewPatient.TabIndex = 45;
            this.buttonNewPatient.Text = "Novo";
            this.buttonNewPatient.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToResizeColumns = false;
            this.dataGridViewPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.birthDate,
            this.phone,
            this.edit,
            this.delete});
            this.dataGridViewPatient.EnableHeadersVisualStyles = false;
            this.dataGridViewPatient.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewPatient.Location = new System.Drawing.Point(27, 116);
            this.dataGridViewPatient.MultiSelect = false;
            this.dataGridViewPatient.Name = "dataGridViewPatient";
            this.dataGridViewPatient.ReadOnly = true;
            this.dataGridViewPatient.RowHeadersVisible = false;
            this.dataGridViewPatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewPatient.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPatient.Size = new System.Drawing.Size(628, 370);
            this.dataGridViewPatient.TabIndex = 44;
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
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.Frozen = true;
            this.name.HeaderText = "Nome";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 250;
            // 
            // birthDate
            // 
            this.birthDate.DataPropertyName = "birthDate";
            this.birthDate.Frozen = true;
            this.birthDate.HeaderText = "Data de Nascimento";
            this.birthDate.Name = "birthDate";
            this.birthDate.ReadOnly = true;
            this.birthDate.Width = 150;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.Frozen = true;
            this.phone.HeaderText = "Telefone";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.Width = 125;
            // 
            // edit
            // 
            this.edit.Frozen = true;
            this.edit.HeaderText = "Editar";
            this.edit.Image = global::DMMDigital.Properties.Resources.icon_32x32_pencil2;
            this.edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit.Width = 50;
            // 
            // delete
            // 
            this.delete.Frozen = true;
            this.delete.HeaderText = "Excluir";
            this.delete.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Width = 50;
            // 
            // buttonExportExam
            // 
            this.buttonExportExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonExportExam.Location = new System.Drawing.Point(1241, 244);
            this.buttonExportExam.Name = "buttonExportExam";
            this.buttonExportExam.Size = new System.Drawing.Size(81, 26);
            this.buttonExportExam.TabIndex = 43;
            this.buttonExportExam.Text = "Exportar";
            this.buttonExportExam.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteExam
            // 
            this.buttonDeleteExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonDeleteExam.Location = new System.Drawing.Point(1241, 212);
            this.buttonDeleteExam.Name = "buttonDeleteExam";
            this.buttonDeleteExam.Size = new System.Drawing.Size(80, 26);
            this.buttonDeleteExam.TabIndex = 42;
            this.buttonDeleteExam.Text = "Excluir";
            this.buttonDeleteExam.UseVisualStyleBackColor = true;
            // 
            // buttonOpenExam
            // 
            this.buttonOpenExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonOpenExam.Location = new System.Drawing.Point(1241, 180);
            this.buttonOpenExam.Name = "buttonOpenExam";
            this.buttonOpenExam.Size = new System.Drawing.Size(81, 26);
            this.buttonOpenExam.TabIndex = 41;
            this.buttonOpenExam.Text = "Abrir";
            this.buttonOpenExam.UseVisualStyleBackColor = true;
            // 
            // buttonNewExam
            // 
            this.buttonNewExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNewExam.Location = new System.Drawing.Point(1240, 148);
            this.buttonNewExam.Name = "buttonNewExam";
            this.buttonNewExam.Size = new System.Drawing.Size(81, 26);
            this.buttonNewExam.TabIndex = 40;
            this.buttonNewExam.Text = "Novo";
            this.buttonNewExam.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(697, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 21);
            this.label11.TabIndex = 39;
            this.label11.Text = "Exames do Paciente:";
            // 
            // dataGridViewExam
            // 
            this.dataGridViewExam.AllowUserToAddRows = false;
            this.dataGridViewExam.AllowUserToDeleteRows = false;
            this.dataGridViewExam.AllowUserToResizeColumns = false;
            this.dataGridViewExam.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataGridViewExam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewExam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewExam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.session,
            this.date,
            this.template});
            this.dataGridViewExam.EnableHeadersVisualStyles = false;
            this.dataGridViewExam.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewExam.Location = new System.Drawing.Point(701, 116);
            this.dataGridViewExam.MultiSelect = false;
            this.dataGridViewExam.Name = "dataGridViewExam";
            this.dataGridViewExam.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExam.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewExam.RowHeadersVisible = false;
            this.dataGridViewExam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewExam.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewExam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExam.Size = new System.Drawing.Size(524, 370);
            this.dataGridViewExam.TabIndex = 38;
            // 
            // session
            // 
            this.session.DataPropertyName = "sessionName";
            this.session.Frozen = true;
            this.session.HeaderText = "Nome da Sessão";
            this.session.Name = "session";
            this.session.ReadOnly = true;
            this.session.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.session.Width = 197;
            // 
            // date
            // 
            this.date.DataPropertyName = "createdAt";
            this.date.Frozen = true;
            this.date.HeaderText = "Data do Exame";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.date.Width = 130;
            // 
            // template
            // 
            this.template.DataPropertyName = "name";
            this.template.Frozen = true;
            this.template.HeaderText = "Template";
            this.template.Name = "template";
            this.template.ReadOnly = true;
            this.template.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.template.Width = 197;
            // 
            // buttonSearchPatient
            // 
            this.buttonSearchPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearchPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchPatient.Location = new System.Drawing.Point(342, 65);
            this.buttonSearchPatient.Name = "buttonSearchPatient";
            this.buttonSearchPatient.Size = new System.Drawing.Size(58, 26);
            this.buttonSearchPatient.TabIndex = 35;
            this.buttonSearchPatient.Text = "Buscar";
            this.buttonSearchPatient.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 21);
            this.label9.TabIndex = 37;
            this.label9.Text = "Buscar Paciente:";
            // 
            // textBoxSearchPatient
            // 
            this.textBoxSearchPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSearchPatient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchPatient.Location = new System.Drawing.Point(27, 63);
            this.textBoxSearchPatient.Name = "textBoxSearchPatient";
            this.textBoxSearchPatient.Size = new System.Drawing.Size(309, 29);
            this.textBoxSearchPatient.TabIndex = 36;
            // 
            // PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 537);
            this.Controls.Add(this.buttonNewPatient);
            this.Controls.Add(this.dataGridViewPatient);
            this.Controls.Add(this.buttonExportExam);
            this.Controls.Add(this.buttonDeleteExam);
            this.Controls.Add(this.buttonOpenExam);
            this.Controls.Add(this.buttonNewExam);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridViewExam);
            this.Controls.Add(this.buttonSearchPatient);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxSearchPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatientView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes";
            this.Load += new System.EventHandler(this.patientViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNewPatient;
        private System.Windows.Forms.DataGridView dataGridViewPatient;
        private System.Windows.Forms.Button buttonExportExam;
        private System.Windows.Forms.Button buttonDeleteExam;
        private System.Windows.Forms.Button buttonOpenExam;
        private System.Windows.Forms.Button buttonNewExam;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridViewExam;
        private System.Windows.Forms.Button buttonSearchPatient;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSearchPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewImageColumn edit;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn session;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn template;
    }
}