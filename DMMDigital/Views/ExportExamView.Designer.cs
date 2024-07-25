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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxSelectPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonSelectPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.checkBoxClearSelection = new System.Windows.Forms.CheckBox();
            this.checkBoxSelectAll = new System.Windows.Forms.CheckBox();
            this.checkBoxExportEditedImage = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxFormat = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.checkBoxExportOriginalImage = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonExportExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 58);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Image = global::DMMDigital.Properties.Resources.icon_32x32_export;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(143, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "      Exportar Exame";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(516, 588);
            this.panel2.TabIndex = 2;
            // 
            // textBoxSelectPath
            // 
            this.textBoxSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxSelectPath.BorderColor = System.Drawing.Color.White;
            this.textBoxSelectPath.BorderRadius = 10;
            this.textBoxSelectPath.BorderSize = 10;
            this.textBoxSelectPath.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxSelectPath.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSelectPath.Location = new System.Drawing.Point(63, 7);
            this.textBoxSelectPath.Name = "textBoxSelectPath";
            this.textBoxSelectPath.PlaceholderText = null;
            this.textBoxSelectPath.Size = new System.Drawing.Size(353, 44);
            this.textBoxSelectPath.TabIndex = 31;
            // 
            // buttonSelectPath
            // 
            this.buttonSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSelectPath.BorderColor = System.Drawing.Color.White;
            this.buttonSelectPath.BorderWidth = 5F;
            this.buttonSelectPath.CornerRadius = 10;
            this.buttonSelectPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            this.buttonSelectPath.Location = new System.Drawing.Point(422, 8);
            this.buttonSelectPath.Name = "buttonSelectPath";
            this.buttonSelectPath.Size = new System.Drawing.Size(42, 42);
            this.buttonSelectPath.TabIndex = 30;
            this.buttonSelectPath.UseVisualStyleBackColor = false;
            // 
            // checkBoxClearSelection
            // 
            this.checkBoxClearSelection.AutoSize = true;
            this.checkBoxClearSelection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxClearSelection.Location = new System.Drawing.Point(391, 72);
            this.checkBoxClearSelection.Name = "checkBoxClearSelection";
            this.checkBoxClearSelection.Size = new System.Drawing.Size(106, 19);
            this.checkBoxClearSelection.TabIndex = 27;
            this.checkBoxClearSelection.Text = "Limpar Seleção";
            this.checkBoxClearSelection.UseVisualStyleBackColor = true;
            this.checkBoxClearSelection.MouseCaptureChanged += new System.EventHandler(this.checkBoxClearSelectionMouseCaptureChanged);
            // 
            // checkBoxSelectAll
            // 
            this.checkBoxSelectAll.AutoSize = true;
            this.checkBoxSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxSelectAll.Location = new System.Drawing.Point(266, 72);
            this.checkBoxSelectAll.Name = "checkBoxSelectAll";
            this.checkBoxSelectAll.Size = new System.Drawing.Size(110, 19);
            this.checkBoxSelectAll.TabIndex = 26;
            this.checkBoxSelectAll.Text = "Selecionar Tudo";
            this.checkBoxSelectAll.UseVisualStyleBackColor = true;
            this.checkBoxSelectAll.MouseCaptureChanged += new System.EventHandler(this.checkBoxSelectAllMouseCaptureChanged);
            // 
            // checkBoxExportEditedImage
            // 
            this.checkBoxExportEditedImage.AutoSize = true;
            this.checkBoxExportEditedImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExportEditedImage.Location = new System.Drawing.Point(297, 429);
            this.checkBoxExportEditedImage.Name = "checkBoxExportEditedImage";
            this.checkBoxExportEditedImage.Size = new System.Drawing.Size(112, 19);
            this.checkBoxExportEditedImage.TabIndex = 25;
            this.checkBoxExportEditedImage.Text = "Imagem Editada";
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
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 400);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 111);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxFormat.BorderColor = System.Drawing.Color.White;
            this.comboBoxFormat.BorderRadius = 10;
            this.comboBoxFormat.BorderSize = 10;
            this.comboBoxFormat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxFormat.ForeColor = System.Drawing.Color.Black;
            this.comboBoxFormat.Location = new System.Drawing.Point(121, 60);
            this.comboBoxFormat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(150, 45);
            this.comboBoxFormat.TabIndex = 62;
            // 
            // checkBoxExportOriginalImage
            // 
            this.checkBoxExportOriginalImage.AutoSize = true;
            this.checkBoxExportOriginalImage.Checked = true;
            this.checkBoxExportOriginalImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExportOriginalImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxExportOriginalImage.Location = new System.Drawing.Point(130, 29);
            this.checkBoxExportOriginalImage.Name = "checkBoxExportOriginalImage";
            this.checkBoxExportOriginalImage.Size = new System.Drawing.Size(115, 19);
            this.checkBoxExportOriginalImage.TabIndex = 24;
            this.checkBoxExportOriginalImage.Text = "Imagem Original";
            this.checkBoxExportOriginalImage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(44, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Exportar :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(46, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Formato :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Imagens";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 95);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(481, 299);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Local :";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\USER";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonExportExam);
            this.panel3.Controls.Add(this.buttonCancel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 588);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(516, 58);
            this.panel3.TabIndex = 4;
            // 
            // buttonExportExam
            // 
            this.buttonExportExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonExportExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderWidth = 5F;
            this.buttonExportExam.CornerRadius = 5;
            this.buttonExportExam.FlatAppearance.BorderSize = 0;
            this.buttonExportExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonExportExam.ForeColor = System.Drawing.Color.White;
            this.buttonExportExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExportExam.Location = new System.Drawing.Point(420, 13);
            this.buttonExportExam.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExportExam.Name = "buttonExportExam";
            this.buttonExportExam.Padding = new System.Windows.Forms.Padding(2);
            this.buttonExportExam.Size = new System.Drawing.Size(87, 33);
            this.buttonExportExam.TabIndex = 60;
            this.buttonExportExam.Text = "Exportar";
            this.buttonExportExam.UseVisualStyleBackColor = false;
            this.buttonExportExam.Click += new System.EventHandler(this.buttonExportExamClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderWidth = 5F;
            this.buttonCancel.CornerRadius = 5;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(16, 13);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Padding = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Size = new System.Drawing.Size(87, 33);
            this.buttonCancel.TabIndex = 59;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // ExportExamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 646);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportExamView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exportar";
            this.Load += new System.EventHandler(this.exportExamViewLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
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
    }
}