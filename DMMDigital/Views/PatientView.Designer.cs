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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientView));
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
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            resources.ApplyResources(this.roundedPanel2, "roundedPanel2");
            this.roundedPanel2.Name = "roundedPanel2";
            // 
            // dataGridViewExam
            // 
            this.dataGridViewExam.AllowUserToAddRows = false;
            this.dataGridViewExam.AllowUserToDeleteRows = false;
            this.dataGridViewExam.AllowUserToResizeColumns = false;
            this.dataGridViewExam.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewExam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridViewExam, "dataGridViewExam");
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
            this.dataGridViewExam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // columnExamId
            // 
            this.columnExamId.DataPropertyName = "id";
            this.columnExamId.Frozen = true;
            resources.ApplyResources(this.columnExamId, "columnExamId");
            this.columnExamId.Name = "columnExamId";
            this.columnExamId.ReadOnly = true;
            // 
            // columnTemplateId
            // 
            this.columnTemplateId.DataPropertyName = "templateId";
            this.columnTemplateId.Frozen = true;
            resources.ApplyResources(this.columnTemplateId, "columnTemplateId");
            this.columnTemplateId.Name = "columnTemplateId";
            this.columnTemplateId.ReadOnly = true;
            // 
            // columnSessionName
            // 
            this.columnSessionName.DataPropertyName = "sessionName";
            this.columnSessionName.Frozen = true;
            resources.ApplyResources(this.columnSessionName, "columnSessionName");
            this.columnSessionName.Name = "columnSessionName";
            this.columnSessionName.ReadOnly = true;
            this.columnSessionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnExamDate
            // 
            this.columnExamDate.DataPropertyName = "createdAt";
            this.columnExamDate.Frozen = true;
            resources.ApplyResources(this.columnExamDate, "columnExamDate");
            this.columnExamDate.Name = "columnExamDate";
            this.columnExamDate.ReadOnly = true;
            this.columnExamDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnTemplate
            // 
            this.columnTemplate.DataPropertyName = "name";
            this.columnTemplate.Frozen = true;
            resources.ApplyResources(this.columnTemplate, "columnTemplate");
            this.columnTemplate.Name = "columnTemplate";
            this.columnTemplate.ReadOnly = true;
            this.columnTemplate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // columnDeleteExam
            // 
            this.columnDeleteExam.Frozen = true;
            resources.ApplyResources(this.columnDeleteExam, "columnDeleteExam");
            this.columnDeleteExam.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.columnDeleteExam.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnDeleteExam.Name = "columnDeleteExam";
            this.columnDeleteExam.ReadOnly = true;
            this.columnDeleteExam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnDeleteExam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonExportExam
            // 
            resources.ApplyResources(this.buttonExportExam, "buttonExportExam");
            this.buttonExportExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderWidth = 5F;
            this.buttonExportExam.CornerRadius = 5;
            this.buttonExportExam.ForeColor = System.Drawing.Color.White;
            this.buttonExportExam.Name = "buttonExportExam";
            this.buttonExportExam.UseVisualStyleBackColor = false;
            // 
            // buttonNewExam
            // 
            resources.ApplyResources(this.buttonNewExam, "buttonNewExam");
            this.buttonNewExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderWidth = 5F;
            this.buttonNewExam.CornerRadius = 5;
            this.buttonNewExam.ForeColor = System.Drawing.Color.White;
            this.buttonNewExam.Name = "buttonNewExam";
            this.buttonNewExam.UseVisualStyleBackColor = false;
            // 
            // buttonOpenExam
            // 
            resources.ApplyResources(this.buttonOpenExam, "buttonOpenExam");
            this.buttonOpenExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExam.BorderWidth = 5F;
            this.buttonOpenExam.CornerRadius = 5;
            this.buttonOpenExam.ForeColor = System.Drawing.Color.White;
            this.buttonOpenExam.Name = "buttonOpenExam";
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
            resources.ApplyResources(this.roundedPanel1, "roundedPanel1");
            this.roundedPanel1.Name = "roundedPanel1";
            // 
            // textBoxSearchPatient
            // 
            resources.ApplyResources(this.textBoxSearchPatient, "textBoxSearchPatient");
            this.textBoxSearchPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxSearchPatient.BorderColor = System.Drawing.Color.White;
            this.textBoxSearchPatient.BorderRadius = 10;
            this.textBoxSearchPatient.BorderSize = 10;
            this.textBoxSearchPatient.Name = "textBoxSearchPatient";
            this.textBoxSearchPatient.PlaceholderText = "Buscar Paciente";
            // 
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToResizeColumns = false;
            this.dataGridViewPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dataGridViewPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.dataGridViewPatient, "dataGridViewPatient");
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
            this.dataGridViewPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // columnPatientId
            // 
            this.columnPatientId.DataPropertyName = "id";
            this.columnPatientId.Frozen = true;
            resources.ApplyResources(this.columnPatientId, "columnPatientId");
            this.columnPatientId.Name = "columnPatientId";
            this.columnPatientId.ReadOnly = true;
            // 
            // columnPatientName
            // 
            this.columnPatientName.DataPropertyName = "name";
            this.columnPatientName.Frozen = true;
            resources.ApplyResources(this.columnPatientName, "columnPatientName");
            this.columnPatientName.Name = "columnPatientName";
            this.columnPatientName.ReadOnly = true;
            // 
            // columnPatientBirthDate
            // 
            this.columnPatientBirthDate.DataPropertyName = "birthDate";
            this.columnPatientBirthDate.Frozen = true;
            resources.ApplyResources(this.columnPatientBirthDate, "columnPatientBirthDate");
            this.columnPatientBirthDate.Name = "columnPatientBirthDate";
            this.columnPatientBirthDate.ReadOnly = true;
            // 
            // columnPatientPhone
            // 
            this.columnPatientPhone.DataPropertyName = "phone";
            this.columnPatientPhone.Frozen = true;
            resources.ApplyResources(this.columnPatientPhone, "columnPatientPhone");
            this.columnPatientPhone.Name = "columnPatientPhone";
            this.columnPatientPhone.ReadOnly = true;
            // 
            // columnEditPatient
            // 
            this.columnEditPatient.Frozen = true;
            resources.ApplyResources(this.columnEditPatient, "columnEditPatient");
            this.columnEditPatient.Image = global::DMMDigital.Properties.Resources.icon_32x32_pencil;
            this.columnEditPatient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnEditPatient.Name = "columnEditPatient";
            this.columnEditPatient.ReadOnly = true;
            this.columnEditPatient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnDeletePatient
            // 
            this.columnDeletePatient.Frozen = true;
            resources.ApplyResources(this.columnDeletePatient, "columnDeletePatient");
            this.columnDeletePatient.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.columnDeletePatient.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnDeletePatient.Name = "columnDeletePatient";
            this.columnDeletePatient.ReadOnly = true;
            this.columnDeletePatient.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // buttonNewPatient
            // 
            resources.ApplyResources(this.buttonNewPatient, "buttonNewPatient");
            this.buttonNewPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewPatient.BorderWidth = 5F;
            this.buttonNewPatient.CornerRadius = 5;
            this.buttonNewPatient.FlatAppearance.BorderSize = 0;
            this.buttonNewPatient.ForeColor = System.Drawing.Color.White;
            this.buttonNewPatient.Name = "buttonNewPatient";
            this.buttonNewPatient.UseVisualStyleBackColor = false;
            // 
            // buttonSearchPatient
            // 
            resources.ApplyResources(this.buttonSearchPatient, "buttonSearchPatient");
            this.buttonSearchPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSearchPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSearchPatient.BorderWidth = 5F;
            this.buttonSearchPatient.CornerRadius = 5;
            this.buttonSearchPatient.Image = global::DMMDigital.Properties.Resources.icon_32x32_search;
            this.buttonSearchPatient.Name = "buttonSearchPatient";
            this.buttonSearchPatient.UseVisualStyleBackColor = false;
            // 
            // PatientView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientView";
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