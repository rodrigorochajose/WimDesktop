namespace DMMDigital.Views
{
    partial class ExamPatientSelectionView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamPatientSelectionView));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonSelectPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonNewPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonSearchPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.dataGridViewPatient = new DMMDigital.Components.Rounded.RoundedDataGridView();
            this.columnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roundedTextBoxSearchPatient = new DMMDigital.Components.Rounded.RoundedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.Name = "labelTitle";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::DMMDigital.Properties.Resources.icon_32x32_patients;
            resources.ApplyResources(this.pictureBoxIcon, "pictureBoxIcon");
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.labelTitle);
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Name = "panelHeader";
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
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancelClick);
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
            this.buttonSelectPatient.Click += new System.EventHandler(this.buttonSelectPatientClick);
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
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToResizeColumns = false;
            this.dataGridViewPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dataGridViewPatient.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
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
            resources.ApplyResources(this.dataGridViewPatient, "dataGridViewPatient");
            this.dataGridViewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnId,
            this.columnName,
            this.columnBirthDate,
            this.columnPhone});
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
            this.dataGridViewPatient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPatientCellDoubleClick);
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
            // ExamPatientSelectionView
            // 
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.roundedTextBoxSearchPatient);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSelectPatient);
            this.Controls.Add(this.buttonNewPatient);
            this.Controls.Add(this.buttonSearchPatient);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.dataGridViewPatient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExamPatientSelectionView";
            this.Load += new System.EventHandler(this.examPatientSelectionViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Panel panelHeader;
        private Components.Rounded.RoundedButton buttonNewPatient;
        private Components.Rounded.RoundedButton buttonSearchPatient;
        private Components.Rounded.RoundedDataGridView dataGridViewPatient;
        private Components.Rounded.RoundedButton buttonSelectPatient;
        private Components.Rounded.RoundedButton buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPhone;
        private Components.Rounded.RoundedTextBox roundedTextBoxSearchPatient;
    }
}