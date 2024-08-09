namespace DMMDigital.Views
{
    partial class ExportExamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportExamView));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxClearSelection = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.checkBoxExportEditedImage = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxExportOriginalImage = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonExportExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBoxSelectPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonSelectPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.comboBoxFormat = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.panelHeader.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.labelTitle);
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Name = "panelHeader";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.textBoxSelectPath);
            this.panel2.Controls.Add(this.buttonSelectPath);
            this.panel2.Controls.Add(this.checkBoxClearSelection);
            this.panel2.Controls.Add(this.checkBoxSelectAll);
            this.panel2.Controls.Add(this.checkBoxExportEditedImage);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.label2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // checkBoxClearSelection
            // 
            resources.ApplyResources(this.checkBoxClearSelection, "checkBoxClearSelection");
            this.checkBoxClearSelection.Name = "checkBoxClearSelection";
            this.checkBoxClearSelection.UseVisualStyleBackColor = true;
            this.checkBoxClearSelection.MouseCaptureChanged += new System.EventHandler(this.checkBoxClearSelectionMouseCaptureChanged);
            // 
            // checkBoxSelectAll
            // 
            resources.ApplyResources(this.checkBoxSelectAll, "checkBoxSelectAll");
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.MouseCaptureChanged += new System.EventHandler(this.checkBoxSelectAllMouseCaptureChanged);
            // 
            // checkBoxExportEditedImage
            // 
            resources.ApplyResources(this.checkBoxExportEditedImage, "checkBoxExportEditedImage");
            this.checkBoxExportEditedImage.Name = "checkBoxExportEditedImage";
            this.checkBoxExportEditedImage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.comboBoxFormat);
            this.groupBox1.Controls.Add(this.checkBoxExportOriginalImage);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // checkBoxExportOriginalImage
            // 
            resources.ApplyResources(this.checkBoxExportOriginalImage, "checkBoxExportOriginalImage");
            this.checkBoxExportOriginalImage.Checked = true;
            this.checkBoxExportOriginalImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExportOriginalImage.Name = "checkBoxExportOriginalImage";
            this.checkBoxExportOriginalImage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonExportExam);
            this.panel3.Controls.Add(this.buttonCancel);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::DMMDigital.Properties.Resources.icon_32x32_export;
            resources.ApplyResources(this.pictureBoxIcon, "pictureBoxIcon");
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.TabStop = false;
            // 
            // labelTitle
            // 
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitle.Name = "labelTitle";
            // 
            // buttonExportExam
            // 
            resources.ApplyResources(this.buttonExportExam, "buttonExportExam");
            this.buttonExportExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderWidth = 5F;
            this.buttonExportExam.CornerRadius = 5;
            this.buttonExportExam.FlatAppearance.BorderSize = 0;
            this.buttonExportExam.ForeColor = System.Drawing.Color.White;
            this.buttonExportExam.Name = "buttonExportExam";
            this.buttonExportExam.UseVisualStyleBackColor = false;
            this.buttonExportExam.Click += new System.EventHandler(this.buttonExportExamClick);
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
            // textBoxSelectPath
            // 
            this.textBoxSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxSelectPath.BorderColor = System.Drawing.Color.White;
            this.textBoxSelectPath.BorderRadius = 10;
            this.textBoxSelectPath.BorderSize = 10;
            resources.ApplyResources(this.textBoxSelectPath, "textBoxSelectPath");
            this.textBoxSelectPath.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSelectPath.Name = "textBoxSelectPath";
            this.textBoxSelectPath.PlaceholderText = null;
            // 
            // buttonSelectPath
            // 
            this.buttonSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSelectPath.BorderColor = System.Drawing.Color.White;
            this.buttonSelectPath.BorderWidth = 5F;
            this.buttonSelectPath.CornerRadius = 10;
            this.buttonSelectPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            resources.ApplyResources(this.buttonSelectPath, "buttonSelectPath");
            this.buttonSelectPath.Name = "buttonSelectPath";
            this.buttonSelectPath.UseVisualStyleBackColor = false;
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxFormat.BorderColor = System.Drawing.Color.White;
            this.comboBoxFormat.BorderRadius = 10;
            this.comboBoxFormat.BorderSize = 10;
            resources.ApplyResources(this.comboBoxFormat, "comboBoxFormat");
            this.comboBoxFormat.ForeColor = System.Drawing.Color.Black;
            this.comboBoxFormat.Name = "comboBoxFormat";
            // 
            // ExportExamView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportExamView";
            this.Load += new System.EventHandler(this.exportExamViewLoad);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxClearSelection;
        private System.Windows.Forms.CheckBox checkBoxSelectAll;
        private System.Windows.Forms.CheckBox checkBoxExportEditedImage;
        private System.Windows.Forms.CheckBox checkBoxExportOriginalImage;
        private Components.Rounded.RoundedButton buttonSelectPath;
        private Components.Rounded.RoundedTextBox textBoxSelectPath;
        private Components.Rounded.RoundedComboBox comboBoxFormat;
        private Components.Rounded.RoundedButton buttonExportExam;
        private Components.Rounded.RoundedButton buttonCancel;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelTitle;
    }
}