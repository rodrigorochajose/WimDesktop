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
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedDateTimePicker2 = new DMMDigital.Components.Rounded.RoundedDateTimePicker();
            this.roundedDateTimePicker1 = new DMMDigital.Components.Rounded.RoundedDateTimePicker();
            this.textBoxSearchPatient = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonSearchPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedPanel1 = new DMMDigital.Components.Rounded.RoundedPanel();
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
            this.roundedPanel2.Controls.Add(this.label4);
            this.roundedPanel2.Controls.Add(this.label3);
            this.roundedPanel2.Controls.Add(this.label2);
            this.roundedPanel2.Controls.Add(this.roundedDateTimePicker2);
            this.roundedPanel2.Controls.Add(this.roundedDateTimePicker1);
            this.roundedPanel2.Controls.Add(this.textBoxSearchPatient);
            this.roundedPanel2.Controls.Add(this.buttonSearchPatient);
            this.roundedPanel2.CornerRadius = 20;
            resources.ApplyResources(this.roundedPanel2, "roundedPanel2");
            this.roundedPanel2.Name = "roundedPanel2";
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
            // roundedDateTimePicker2
            // 
            this.roundedDateTimePicker2.BorderColor = System.Drawing.Color.White;
            this.roundedDateTimePicker2.BorderRadius = 5;
            this.roundedDateTimePicker2.BorderSize = 0;
            resources.ApplyResources(this.roundedDateTimePicker2, "roundedDateTimePicker2");
            this.roundedDateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.roundedDateTimePicker2.Name = "roundedDateTimePicker2";
            this.roundedDateTimePicker2.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedDateTimePicker2.TextColor = System.Drawing.Color.Gray;
            // 
            // roundedDateTimePicker1
            // 
            this.roundedDateTimePicker1.BorderColor = System.Drawing.Color.White;
            this.roundedDateTimePicker1.BorderRadius = 5;
            this.roundedDateTimePicker1.BorderSize = 0;
            resources.ApplyResources(this.roundedDateTimePicker1, "roundedDateTimePicker1");
            this.roundedDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.roundedDateTimePicker1.Name = "roundedDateTimePicker1";
            this.roundedDateTimePicker1.SkinColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedDateTimePicker1.TextColor = System.Drawing.Color.Gray;
            // 
            // textBoxSearchPatient
            // 
            resources.ApplyResources(this.textBoxSearchPatient, "textBoxSearchPatient");
            this.textBoxSearchPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxSearchPatient.BorderColor = System.Drawing.Color.White;
            this.textBoxSearchPatient.BorderRadius = 10;
            this.textBoxSearchPatient.BorderSize = 10;
            this.textBoxSearchPatient.Name = "textBoxSearchPatient";
            this.textBoxSearchPatient.PlaceholderText = "";
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
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedPanel1.BorderWidth = 5F;
            this.roundedPanel1.Controls.Add(this.buttonOpenExams);
            this.roundedPanel1.Controls.Add(this.buttonPatientExams);
            this.roundedPanel1.Controls.Add(this.buttonNewPatient);
            this.roundedPanel1.Controls.Add(this.dataGridViewPatient);
            this.roundedPanel1.CornerRadius = 20;
            resources.ApplyResources(this.roundedPanel1, "roundedPanel1");
            this.roundedPanel1.Name = "roundedPanel1";
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
            // 
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToResizeColumns = false;
            this.dataGridViewPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridViewPatient, "dataGridViewPatient");
            this.dataGridViewPatient.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewPatient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewPatient.BorderWidth = 5F;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPatientId,
            this.columnPatientName,
            this.columnLastChange});
            this.dataGridViewPatient.CornerRadius = 2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPatient.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPatient.EnableHeadersVisualStyles = false;
            this.dataGridViewPatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewPatient.MultiSelect = false;
            this.dataGridViewPatient.Name = "dataGridViewPatient";
            this.dataGridViewPatient.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPatient.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewPatient.RowHeadersVisible = false;
            this.dataGridViewPatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(144)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewPatient.RowsDefaultCellStyle = dataGridViewCellStyle5;
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
            // columnLastChange
            // 
            this.columnLastChange.DataPropertyName = "lastChange";
            this.columnLastChange.Frozen = true;
            resources.ApplyResources(this.columnLastChange, "columnLastChange");
            this.columnLastChange.Name = "columnLastChange";
            this.columnLastChange.ReadOnly = true;
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
        private Components.Rounded.RoundedTextBox textBoxSearchPatient;
        private Components.Rounded.RoundedButton buttonOpenExams;
        private Components.Rounded.RoundedButton buttonPatientExams;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLastChange;
        private Components.Rounded.RoundedPanel roundedPanel2;
        private Components.Rounded.RoundedDateTimePicker roundedDateTimePicker1;
        private Components.Rounded.RoundedDateTimePicker roundedDateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}