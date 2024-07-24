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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientView));
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.dataGridViewExam = new DMMDigital.Components.Rounded.RoundedDataGridView();
            this.columnExamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSessionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnExamDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDeleteExam = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonExportExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonNewExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonOpenExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedPanel1 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.textBoxSearchPatient = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.dataGridViewPatient = new DMMDigital.Components.Rounded.RoundedDataGridView();
            this.columnPatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPatientBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPatientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnEditPatient = new System.Windows.Forms.DataGridViewImageColumn();
            this.columnDeletePatient = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonNewPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonSearchPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(727, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(206, 30);
            this.label11.TabIndex = 39;
            this.label11.Text = "Exames do Paciente";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "Pacientes";
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedPanel2.BorderWidth = 5F;
            this.roundedPanel2.Controls.Add(this.dataGridViewExam);
            this.roundedPanel2.Controls.Add(this.buttonExportExam);
            this.roundedPanel2.Controls.Add(this.buttonNewExam);
            this.roundedPanel2.Controls.Add(this.buttonOpenExam);
            this.roundedPanel2.CornerRadius = 20;
            this.roundedPanel2.Location = new System.Drawing.Point(715, 61);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(620, 520);
            this.roundedPanel2.TabIndex = 46;
            // 
            // dataGridViewExam
            // 
            this.dataGridViewExam.AllowUserToAddRows = false;
            this.dataGridViewExam.AllowUserToDeleteRows = false;
            this.dataGridViewExam.AllowUserToResizeColumns = false;
            this.dataGridViewExam.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewExam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridViewExam.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewExam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExam.BorderWidth = 5F;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewExam.ColumnHeadersHeight = 30;
            this.dataGridViewExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewExam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnExamId,
            this.columnTemplateId,
            this.columnSessionName,
            this.columnExamDate,
            this.columnTemplate,
            this.columnDeleteExam});
            this.dataGridViewExam.CornerRadius = 2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewExam.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewExam.EnableHeadersVisualStyles = false;
            this.dataGridViewExam.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewExam.Location = new System.Drawing.Point(17, 100);
            this.dataGridViewExam.MultiSelect = false;
            this.dataGridViewExam.Name = "dataGridViewExam";
            this.dataGridViewExam.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExam.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewExam.RowHeadersVisible = false;
            this.dataGridViewExam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(144)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewExam.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewExam.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewExam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExam.Size = new System.Drawing.Size(587, 397);
            this.dataGridViewExam.TabIndex = 38;
            // 
            // columnExamId
            // 
            this.columnExamId.DataPropertyName = "id";
            this.columnExamId.Frozen = true;
            this.columnExamId.HeaderText = "examId";
            this.columnExamId.Name = "columnExamId";
            this.columnExamId.ReadOnly = true;
            this.columnExamId.Visible = false;
            // 
            // columnTemplateId
            // 
            this.columnTemplateId.DataPropertyName = "templateId";
            this.columnTemplateId.Frozen = true;
            this.columnTemplateId.HeaderText = "templateId";
            this.columnTemplateId.Name = "columnTemplateId";
            this.columnTemplateId.ReadOnly = true;
            this.columnTemplateId.Visible = false;
            // 
            // columnSessionName
            // 
            this.columnSessionName.DataPropertyName = "sessionName";
            this.columnSessionName.Frozen = true;
            this.columnSessionName.HeaderText = "Nome da Sessão";
            this.columnSessionName.Name = "columnSessionName";
            this.columnSessionName.ReadOnly = true;
            this.columnSessionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnSessionName.Width = 197;
            // 
            // columnExamDate
            // 
            this.columnExamDate.DataPropertyName = "createdAt";
            this.columnExamDate.Frozen = true;
            this.columnExamDate.HeaderText = "Data do Exame";
            this.columnExamDate.Name = "columnExamDate";
            this.columnExamDate.ReadOnly = true;
            this.columnExamDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnExamDate.Width = 130;
            // 
            // columnTemplate
            // 
            this.columnTemplate.DataPropertyName = "name";
            this.columnTemplate.Frozen = true;
            this.columnTemplate.HeaderText = "Template";
            this.columnTemplate.Name = "columnTemplate";
            this.columnTemplate.ReadOnly = true;
            this.columnTemplate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnTemplate.Width = 197;
            // 
            // columnDeleteExam
            // 
            this.columnDeleteExam.Frozen = true;
            this.columnDeleteExam.HeaderText = "Excluir";
            this.columnDeleteExam.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.columnDeleteExam.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnDeleteExam.Name = "columnDeleteExam";
            this.columnDeleteExam.ReadOnly = true;
            this.columnDeleteExam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnDeleteExam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnDeleteExam.Width = 60;
            // 
            // buttonExportExam
            // 
            this.buttonExportExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonExportExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderWidth = 5F;
            this.buttonExportExam.CornerRadius = 5;
            this.buttonExportExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonExportExam.ForeColor = System.Drawing.Color.White;
            this.buttonExportExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExportExam.Location = new System.Drawing.Point(467, 33);
            this.buttonExportExam.Name = "buttonExportExam";
            this.buttonExportExam.Size = new System.Drawing.Size(132, 42);
            this.buttonExportExam.TabIndex = 43;
            this.buttonExportExam.Text = "Exportar Exame";
            this.buttonExportExam.UseVisualStyleBackColor = false;
            // 
            // buttonNewExam
            // 
            this.buttonNewExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNewExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderWidth = 5F;
            this.buttonNewExam.CornerRadius = 5;
            this.buttonNewExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNewExam.ForeColor = System.Drawing.Color.White;
            this.buttonNewExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewExam.Location = new System.Drawing.Point(17, 32);
            this.buttonNewExam.Name = "buttonNewExam";
            this.buttonNewExam.Size = new System.Drawing.Size(130, 42);
            this.buttonNewExam.TabIndex = 40;
            this.buttonNewExam.Text = "Novo Exame";
            this.buttonNewExam.UseVisualStyleBackColor = false;
            // 
            // buttonOpenExam
            // 
            this.buttonOpenExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonOpenExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExam.BorderWidth = 5F;
            this.buttonOpenExam.CornerRadius = 5;
            this.buttonOpenExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonOpenExam.ForeColor = System.Drawing.Color.White;
            this.buttonOpenExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenExam.Location = new System.Drawing.Point(245, 33);
            this.buttonOpenExam.Name = "buttonOpenExam";
            this.buttonOpenExam.Size = new System.Drawing.Size(129, 42);
            this.buttonOpenExam.TabIndex = 41;
            this.buttonOpenExam.Text = "Abrir Exame";
            this.buttonOpenExam.UseVisualStyleBackColor = false;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedPanel1.BorderWidth = 5F;
            this.roundedPanel1.Controls.Add(this.textBoxSearchPatient);
            this.roundedPanel1.Controls.Add(this.dataGridViewPatient);
            this.roundedPanel1.Controls.Add(this.buttonNewPatient);
            this.roundedPanel1.Controls.Add(this.buttonSearchPatient);
            this.roundedPanel1.CornerRadius = 20;
            this.roundedPanel1.Location = new System.Drawing.Point(12, 61);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(686, 519);
            this.roundedPanel1.TabIndex = 46;
            // 
            // textBoxSearchPatient
            // 
            this.textBoxSearchPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxSearchPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxSearchPatient.BorderColor = System.Drawing.Color.White;
            this.textBoxSearchPatient.BorderRadius = 10;
            this.textBoxSearchPatient.BorderSize = 10;
            this.textBoxSearchPatient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxSearchPatient.Location = new System.Drawing.Point(299, 26);
            this.textBoxSearchPatient.Name = "textBoxSearchPatient";
            this.textBoxSearchPatient.Padding = new System.Windows.Forms.Padding(2);
            this.textBoxSearchPatient.PlaceholderText = "Buscar Paciente";
            this.textBoxSearchPatient.Size = new System.Drawing.Size(309, 53);
            this.textBoxSearchPatient.TabIndex = 56;
            // 
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToResizeColumns = false;
            this.dataGridViewPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dataGridViewPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewPatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewPatient.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewPatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPatient.BorderWidth = 5F;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewPatient.ColumnHeadersHeight = 30;
            this.dataGridViewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPatientId,
            this.columnPatientName,
            this.columnPatientBirthDate,
            this.columnPatientPhone,
            this.columnEditPatient,
            this.columnDeletePatient});
            this.dataGridViewPatient.CornerRadius = 2;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPatient.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewPatient.EnableHeadersVisualStyles = false;
            this.dataGridViewPatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewPatient.Location = new System.Drawing.Point(14, 99);
            this.dataGridViewPatient.MultiSelect = false;
            this.dataGridViewPatient.Name = "dataGridViewPatient";
            this.dataGridViewPatient.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewPatient.RowHeadersVisible = false;
            this.dataGridViewPatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(144)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewPatient.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewPatient.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPatient.Size = new System.Drawing.Size(651, 396);
            this.dataGridViewPatient.TabIndex = 44;
            // 
            // columnPatientId
            // 
            this.columnPatientId.DataPropertyName = "id";
            this.columnPatientId.Frozen = true;
            this.columnPatientId.HeaderText = "id";
            this.columnPatientId.Name = "columnPatientId";
            this.columnPatientId.ReadOnly = true;
            this.columnPatientId.Visible = false;
            // 
            // columnPatientName
            // 
            this.columnPatientName.DataPropertyName = "name";
            this.columnPatientName.Frozen = true;
            this.columnPatientName.HeaderText = "Nome";
            this.columnPatientName.Name = "columnPatientName";
            this.columnPatientName.ReadOnly = true;
            this.columnPatientName.Width = 235;
            // 
            // columnPatientBirthDate
            // 
            this.columnPatientBirthDate.DataPropertyName = "birthDate";
            this.columnPatientBirthDate.Frozen = true;
            this.columnPatientBirthDate.HeaderText = "Data de Nascimento";
            this.columnPatientBirthDate.Name = "columnPatientBirthDate";
            this.columnPatientBirthDate.ReadOnly = true;
            this.columnPatientBirthDate.Width = 175;
            // 
            // columnPatientPhone
            // 
            this.columnPatientPhone.DataPropertyName = "phone";
            this.columnPatientPhone.Frozen = true;
            this.columnPatientPhone.HeaderText = "Telefone";
            this.columnPatientPhone.Name = "columnPatientPhone";
            this.columnPatientPhone.ReadOnly = true;
            this.columnPatientPhone.Width = 125;
            // 
            // columnEditPatient
            // 
            this.columnEditPatient.Frozen = true;
            this.columnEditPatient.HeaderText = "Editar";
            this.columnEditPatient.Image = global::DMMDigital.Properties.Resources.icon_32x32_pencil;
            this.columnEditPatient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnEditPatient.Name = "columnEditPatient";
            this.columnEditPatient.ReadOnly = true;
            this.columnEditPatient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnEditPatient.Width = 55;
            // 
            // columnDeletePatient
            // 
            this.columnDeletePatient.Frozen = true;
            this.columnDeletePatient.HeaderText = "Excluir";
            this.columnDeletePatient.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.columnDeletePatient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnDeletePatient.Name = "columnDeletePatient";
            this.columnDeletePatient.ReadOnly = true;
            this.columnDeletePatient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnDeletePatient.Width = 58;
            // 
            // buttonNewPatient
            // 
            this.buttonNewPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNewPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewPatient.BorderWidth = 5F;
            this.buttonNewPatient.CornerRadius = 5;
            this.buttonNewPatient.FlatAppearance.BorderSize = 0;
            this.buttonNewPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNewPatient.ForeColor = System.Drawing.Color.White;
            this.buttonNewPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewPatient.Location = new System.Drawing.Point(18, 32);
            this.buttonNewPatient.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNewPatient.Name = "buttonNewPatient";
            this.buttonNewPatient.Padding = new System.Windows.Forms.Padding(2);
            this.buttonNewPatient.Size = new System.Drawing.Size(130, 42);
            this.buttonNewPatient.TabIndex = 45;
            this.buttonNewPatient.Text = "Novo Paciente";
            this.buttonNewPatient.UseVisualStyleBackColor = false;
            // 
            // buttonSearchPatient
            // 
            this.buttonSearchPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearchPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSearchPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSearchPatient.BorderWidth = 5F;
            this.buttonSearchPatient.CornerRadius = 5;
            this.buttonSearchPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearchPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchPatient.Image = global::DMMDigital.Properties.Resources.icon_32x32_search;
            this.buttonSearchPatient.Location = new System.Drawing.Point(615, 32);
            this.buttonSearchPatient.Name = "buttonSearchPatient";
            this.buttonSearchPatient.Size = new System.Drawing.Size(45, 42);
            this.buttonSearchPatient.TabIndex = 35;
            this.buttonSearchPatient.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSearchPatient.UseVisualStyleBackColor = false;
            // 
            // PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 599);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes";
            this.roundedPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.Rounded.RoundedButton buttonNewPatient;
        private Components.Rounded.RoundedDataGridView dataGridViewPatient;
        private Components.Rounded.RoundedButton buttonExportExam;
        private Components.Rounded.RoundedButton buttonOpenExam;
        private Components.Rounded.RoundedButton buttonNewExam;
        private System.Windows.Forms.Label label11;
        private Components.Rounded.RoundedDataGridView dataGridViewExam;
        private Components.Rounded.RoundedButton buttonSearchPatient;
        private Components.Rounded.RoundedPanel roundedPanel1;
        private Components.Rounded.RoundedPanel roundedPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnExamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTemplateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSessionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnExamDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTemplate;
        private System.Windows.Forms.DataGridViewImageColumn columnDeleteExam;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientPhone;
        private System.Windows.Forms.DataGridViewImageColumn columnEditPatient;
        private System.Windows.Forms.DataGridViewImageColumn columnDeletePatient;
        private Components.Rounded.RoundedTextBox textBoxSearchPatient;
    }
}