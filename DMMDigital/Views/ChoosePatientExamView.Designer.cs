namespace DMMDigital.Views
{
    partial class ChoosePatientExamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoosePatientExamView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonNewPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonSearchPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.dataGridViewPatient = new DMMDigital.Components.Rounded.RoundedDataGridView();
            this.columnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSelectPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBoxSearchPatient = new DMMDigital.Components.Rounded.RoundedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DMMDigital.Properties.Resources.icon_32x32_patients;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
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
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToResizeColumns = false;
            this.dataGridViewPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            resources.ApplyResources(this.dataGridViewPatient, "dataGridViewPatient");
            this.dataGridViewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnId,
            this.columnName,
            this.columnBirthDate,
            this.columnPhone});
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
            // columnId
            // 
            this.columnId.DataPropertyName = "id";
            this.columnId.Frozen = true;
            resources.ApplyResources(this.columnId, "columnId");
            this.columnId.Name = "columnId";
            this.columnId.ReadOnly = true;
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "name";
            this.columnName.Frozen = true;
            resources.ApplyResources(this.columnName, "columnName");
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            // 
            // columnBirthDate
            // 
            this.columnBirthDate.DataPropertyName = "birthDate";
            this.columnBirthDate.Frozen = true;
            resources.ApplyResources(this.columnBirthDate, "columnBirthDate");
            this.columnBirthDate.Name = "columnBirthDate";
            this.columnBirthDate.ReadOnly = true;
            // 
            // columnPhone
            // 
            this.columnPhone.DataPropertyName = "phone";
            this.columnPhone.Frozen = true;
            resources.ApplyResources(this.columnPhone, "columnPhone");
            this.columnPhone.Name = "columnPhone";
            this.columnPhone.ReadOnly = true;
            // 
            // buttonSelectPatient
            // 
            resources.ApplyResources(this.buttonSelectPatient, "buttonSelectPatient");
            this.buttonSelectPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSelectPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSelectPatient.BorderWidth = 5F;
            this.buttonSelectPatient.CornerRadius = 5;
            this.buttonSelectPatient.FlatAppearance.BorderSize = 0;
            this.buttonSelectPatient.ForeColor = System.Drawing.Color.White;
            this.buttonSelectPatient.Name = "buttonSelectPatient";
            this.buttonSelectPatient.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderWidth = 5F;
            this.buttonCancel.CornerRadius = 5;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
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
            // ChoosePatientExamView
            // 
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.textBoxSearchPatient);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSelectPatient);
            this.Controls.Add(this.buttonNewPatient);
            this.Controls.Add(this.buttonSearchPatient);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoosePatientExamView";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private Components.Rounded.RoundedButton buttonNewPatient;
        private Components.Rounded.RoundedButton buttonSearchPatient;
        private Components.Rounded.RoundedDataGridView dataGridViewPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPhone;
        private Components.Rounded.RoundedButton buttonSelectPatient;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedTextBox textBoxSearchPatient;
    }
}