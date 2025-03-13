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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.roundedTextBoxSearchPatient = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.checkBoxTo = new System.Windows.Forms.CheckBox();
            this.checkBoxFrom = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new DMMDigital.Components.Rounded.RoundedDateTimePicker();
            this.dateTimePickerFrom = new DMMDigital.Components.Rounded.RoundedDateTimePicker();
            this.buttonSearchPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedPanel1 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.buttonNewExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonOpenExams = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonPatientExams = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonNewPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.dataGridViewPatient = new DMMDigital.Components.Rounded.RoundedDataGridView();
            this.columnPatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLastChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundedPanel2.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).BeginInit();
            this.SuspendLayout();
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
            this.roundedPanel2.Controls.Add(this.roundedTextBoxSearchPatient);
            this.roundedPanel2.Controls.Add(this.checkBoxTo);
            this.roundedPanel2.Controls.Add(this.checkBoxFrom);
            this.roundedPanel2.Controls.Add(this.label4);
            this.roundedPanel2.Controls.Add(this.label3);
            this.roundedPanel2.Controls.Add(this.label2);
            this.roundedPanel2.Controls.Add(this.dateTimePickerTo);
            this.roundedPanel2.Controls.Add(this.dateTimePickerFrom);
            this.roundedPanel2.Controls.Add(this.buttonSearchPatient);
            this.roundedPanel2.CornerRadius = 20;
            resources.ApplyResources(this.roundedPanel2, "roundedPanel2");
            this.roundedPanel2.Name = "roundedPanel2";
            // 
            // roundedTextBoxSearchPatient
            // 
            this.roundedTextBoxSearchPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxSearchPatient.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxSearchPatient.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxSearchPatient.BorderRadius = 10;
            this.roundedTextBoxSearchPatient.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBoxSearchPatient, "roundedTextBoxSearchPatient");
            this.roundedTextBoxSearchPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxSearchPatient.Multiline = false;
            this.roundedTextBoxSearchPatient.Name = "roundedTextBoxSearchPatient";
            this.roundedTextBoxSearchPatient.PasswordChar = false;
            this.roundedTextBoxSearchPatient.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxSearchPatient.PlaceholderText = "";
            this.roundedTextBoxSearchPatient.Texts = "";
            this.roundedTextBoxSearchPatient.UnderlinedStyle = false;
            // 
            // checkBoxTo
            // 
            resources.ApplyResources(this.checkBoxTo, "checkBoxTo");
            this.checkBoxTo.Name = "checkBoxTo";
            this.checkBoxTo.UseVisualStyleBackColor = true;
            this.checkBoxTo.CheckedChanged += new System.EventHandler(this.checkBoxToCheckedChanged);
            // 
            // checkBoxFrom
            // 
            resources.ApplyResources(this.checkBoxFrom, "checkBoxFrom");
            this.checkBoxFrom.Name = "checkBoxFrom";
            this.checkBoxFrom.UseVisualStyleBackColor = true;
            this.checkBoxFrom.CheckedChanged += new System.EventHandler(this.checkBoxFromCheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.BorderColor = System.Drawing.Color.White;
            this.dateTimePickerTo.BorderRadius = 5;
            this.dateTimePickerTo.BorderSize = 0;
            resources.ApplyResources(this.dateTimePickerTo, "dateTimePickerTo");
            this.dateTimePickerTo.Checked = false;
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.dateTimePickerTo.TextColor = System.Drawing.Color.Gray;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.BorderColor = System.Drawing.Color.White;
            this.dateTimePickerFrom.BorderRadius = 5;
            this.dateTimePickerFrom.BorderSize = 0;
            resources.ApplyResources(this.dateTimePickerFrom, "dateTimePickerFrom");
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.ShowCheckBox = true;
            this.dateTimePickerFrom.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.dateTimePickerFrom.TextColor = System.Drawing.Color.Gray;
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
            this.buttonSearchPatient.Click += new System.EventHandler(this.buttonSearchPatientClick);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedPanel1.BorderWidth = 5F;
            this.roundedPanel1.Controls.Add(this.buttonNewExam);
            this.roundedPanel1.Controls.Add(this.buttonOpenExams);
            this.roundedPanel1.Controls.Add(this.buttonPatientExams);
            this.roundedPanel1.Controls.Add(this.buttonNewPatient);
            this.roundedPanel1.Controls.Add(this.dataGridViewPatient);
            this.roundedPanel1.CornerRadius = 20;
            resources.ApplyResources(this.roundedPanel1, "roundedPanel1");
            this.roundedPanel1.Name = "roundedPanel1";
            // 
            // buttonNewExam
            // 
            resources.ApplyResources(this.buttonNewExam, "buttonNewExam");
            this.buttonNewExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderWidth = 5F;
            this.buttonNewExam.CornerRadius = 5;
            this.buttonNewExam.FlatAppearance.BorderSize = 0;
            this.buttonNewExam.ForeColor = System.Drawing.Color.White;
            this.buttonNewExam.Name = "buttonNewExam";
            this.buttonNewExam.UseVisualStyleBackColor = false;
            this.buttonNewExam.Click += new System.EventHandler(this.buttonNewExamClick);
            // 
            // buttonOpenExams
            // 
            resources.ApplyResources(this.buttonOpenExams, "buttonOpenExams");
            this.buttonOpenExams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExams.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExams.BorderWidth = 5F;
            this.buttonOpenExams.CornerRadius = 5;
            this.buttonOpenExams.FlatAppearance.BorderSize = 0;
            this.buttonOpenExams.ForeColor = System.Drawing.Color.White;
            this.buttonOpenExams.Name = "buttonOpenExams";
            this.buttonOpenExams.UseVisualStyleBackColor = false;
            this.buttonOpenExams.Click += new System.EventHandler(this.buttonOpenExamsClick);
            // 
            // buttonPatientExams
            // 
            resources.ApplyResources(this.buttonPatientExams, "buttonPatientExams");
            this.buttonPatientExams.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonPatientExams.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonPatientExams.BorderWidth = 5F;
            this.buttonPatientExams.CornerRadius = 5;
            this.buttonPatientExams.FlatAppearance.BorderSize = 0;
            this.buttonPatientExams.ForeColor = System.Drawing.Color.White;
            this.buttonPatientExams.Name = "buttonPatientExams";
            this.buttonPatientExams.UseVisualStyleBackColor = false;
            this.buttonPatientExams.Click += new System.EventHandler(this.buttonPatientExamsClick);
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
            this.buttonNewPatient.Click += new System.EventHandler(this.buttonNewPatientClick);
            // 
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToOrderColumns = true;
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
            this.columnLastChange});
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
            this.dataGridViewPatient.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPatientColumnHeaderMouseClick);
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
            this.columnPatientName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // columnLastChange
            // 
            this.columnLastChange.DataPropertyName = "lastChange";
            this.columnLastChange.Frozen = true;
            resources.ApplyResources(this.columnLastChange, "columnLastChange");
            this.columnLastChange.Name = "columnLastChange";
            this.columnLastChange.ReadOnly = true;
            this.columnLastChange.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PatientView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientView";
            this.Load += new System.EventHandler(this.patientViewLoad);
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.Rounded.RoundedButton buttonNewPatient;
        private Components.Rounded.RoundedDataGridView dataGridViewPatient;
        private Components.Rounded.RoundedButton buttonSearchPatient;
        private Components.Rounded.RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedButton buttonOpenExams;
        private Components.Rounded.RoundedButton buttonPatientExams;
        private Components.Rounded.RoundedPanel roundedPanel2;
        private Components.Rounded.RoundedDateTimePicker dateTimePickerFrom;
        private Components.Rounded.RoundedDateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLastChange;
        private System.Windows.Forms.CheckBox checkBoxTo;
        private System.Windows.Forms.CheckBox checkBoxFrom;
        private Components.Rounded.RoundedButton buttonNewExam;
        private Components.Rounded.RoundedTextBox roundedTextBoxSearchPatient;
    }
}