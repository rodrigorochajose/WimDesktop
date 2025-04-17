namespace DMMDigital.Views
{
    partial class AdvancedSettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedSettingsView));
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCaminho = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonOk = new DMMDigital.Components.Rounded.RoundedButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonExamPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonSensorPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedButtonMigrateCDR = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedButtonMigrateWimDesktop = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedTextBoxSensorPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.roundedTextBoxExamPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedButtonUpdatePatientData = new DMMDigital.Components.Rounded.RoundedButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkBoxWaterMark = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::DMMDigital.Properties.Resources.icon_32x32_settings;
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // labelCaminho
            // 
            resources.ApplyResources(this.labelCaminho, "labelCaminho");
            this.labelCaminho.Name = "labelCaminho";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOk);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderWidth = 1;
            this.buttonCancel.CornerRadius = 10;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOk.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOk.BorderWidth = 1;
            this.buttonOk.CornerRadius = 10;
            this.buttonOk.FlatAppearance.BorderSize = 0;
            this.buttonOk.ForeColor = System.Drawing.Color.White;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.UseVisualStyleBackColor = false;
            // 
            // buttonExamPath
            // 
            this.buttonExamPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonExamPath.BorderColor = System.Drawing.Color.White;
            this.buttonExamPath.BorderWidth = 5;
            this.buttonExamPath.CornerRadius = 10;
            this.buttonExamPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            resources.ApplyResources(this.buttonExamPath, "buttonExamPath");
            this.buttonExamPath.Name = "buttonExamPath";
            this.buttonExamPath.UseVisualStyleBackColor = false;
            // 
            // buttonSensorPath
            // 
            this.buttonSensorPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSensorPath.BorderColor = System.Drawing.Color.White;
            this.buttonSensorPath.BorderWidth = 5;
            this.buttonSensorPath.CornerRadius = 10;
            this.buttonSensorPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            resources.ApplyResources(this.buttonSensorPath, "buttonSensorPath");
            this.buttonSensorPath.Name = "buttonSensorPath";
            this.buttonSensorPath.UseVisualStyleBackColor = false;
            // 
            // roundedButtonMigrateCDR
            // 
            resources.ApplyResources(this.roundedButtonMigrateCDR, "roundedButtonMigrateCDR");
            this.roundedButtonMigrateCDR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedButtonMigrateCDR.BorderColor = System.Drawing.Color.White;
            this.roundedButtonMigrateCDR.BorderWidth = 1;
            this.roundedButtonMigrateCDR.CornerRadius = 10;
            this.roundedButtonMigrateCDR.FlatAppearance.BorderSize = 0;
            this.roundedButtonMigrateCDR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonMigrateCDR.Name = "roundedButtonMigrateCDR";
            this.roundedButtonMigrateCDR.UseVisualStyleBackColor = false;
            // 
            // roundedButtonMigrateWimDesktop
            // 
            resources.ApplyResources(this.roundedButtonMigrateWimDesktop, "roundedButtonMigrateWimDesktop");
            this.roundedButtonMigrateWimDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedButtonMigrateWimDesktop.BorderColor = System.Drawing.Color.White;
            this.roundedButtonMigrateWimDesktop.BorderWidth = 1;
            this.roundedButtonMigrateWimDesktop.CornerRadius = 10;
            this.roundedButtonMigrateWimDesktop.FlatAppearance.BorderSize = 0;
            this.roundedButtonMigrateWimDesktop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonMigrateWimDesktop.Name = "roundedButtonMigrateWimDesktop";
            this.roundedButtonMigrateWimDesktop.UseVisualStyleBackColor = false;
            // 
            // roundedTextBoxSensorPath
            // 
            this.roundedTextBoxSensorPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxSensorPath.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxSensorPath.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxSensorPath.BorderRadius = 10;
            this.roundedTextBoxSensorPath.BorderSize = 2;
            resources.ApplyResources(this.roundedTextBoxSensorPath, "roundedTextBoxSensorPath");
            this.roundedTextBoxSensorPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxSensorPath.Multiline = false;
            this.roundedTextBoxSensorPath.Name = "roundedTextBoxSensorPath";
            this.roundedTextBoxSensorPath.PasswordChar = false;
            this.roundedTextBoxSensorPath.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.roundedTextBoxSensorPath.PlaceholderText = "";
            this.roundedTextBoxSensorPath.Texts = "";
            this.roundedTextBoxSensorPath.UnderlinedStyle = false;
            // 
            // roundedTextBoxExamPath
            // 
            this.roundedTextBoxExamPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxExamPath.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxExamPath.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxExamPath.BorderRadius = 10;
            this.roundedTextBoxExamPath.BorderSize = 2;
            resources.ApplyResources(this.roundedTextBoxExamPath, "roundedTextBoxExamPath");
            this.roundedTextBoxExamPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxExamPath.Multiline = false;
            this.roundedTextBoxExamPath.Name = "roundedTextBoxExamPath";
            this.roundedTextBoxExamPath.PasswordChar = false;
            this.roundedTextBoxExamPath.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.roundedTextBoxExamPath.PlaceholderText = "";
            this.roundedTextBoxExamPath.Texts = "";
            this.roundedTextBoxExamPath.UnderlinedStyle = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // roundedButtonUpdatePatientData
            // 
            resources.ApplyResources(this.roundedButtonUpdatePatientData, "roundedButtonUpdatePatientData");
            this.roundedButtonUpdatePatientData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedButtonUpdatePatientData.BorderColor = System.Drawing.Color.White;
            this.roundedButtonUpdatePatientData.BorderWidth = 1;
            this.roundedButtonUpdatePatientData.CornerRadius = 10;
            this.roundedButtonUpdatePatientData.FlatAppearance.BorderSize = 0;
            this.roundedButtonUpdatePatientData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonUpdatePatientData.Name = "roundedButtonUpdatePatientData";
            this.roundedButtonUpdatePatientData.UseVisualStyleBackColor = false;
            this.roundedButtonUpdatePatientData.Click += new System.EventHandler(this.roundedButtonUpdatePatientDataClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.labelCaminho);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.roundedTextBoxExamPath);
            this.tabPage1.Controls.Add(this.buttonSensorPath);
            this.tabPage1.Controls.Add(this.roundedTextBoxSensorPath);
            this.tabPage1.Controls.Add(this.buttonExamPath);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.roundedButtonMigrateWimDesktop);
            this.tabPage2.Controls.Add(this.roundedButtonMigrateCDR);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.checkBoxWaterMark);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Controls.Add(this.roundedButtonUpdatePatientData);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkBoxWaterMark
            // 
            resources.ApplyResources(this.checkBoxWaterMark, "checkBoxWaterMark");
            this.checkBoxWaterMark.Name = "checkBoxWaterMark";
            this.checkBoxWaterMark.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // AdvancedSettingsView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxIcon);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedSettingsView";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.advancedSettingsViewKeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label label6;
        private Components.Rounded.RoundedButton buttonExamPath;
        private Components.Rounded.RoundedButton buttonSensorPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelCaminho;
        private System.Windows.Forms.Label label3;
        private Components.Rounded.RoundedButton roundedButtonMigrateCDR;
        private Components.Rounded.RoundedButton roundedButtonMigrateWimDesktop;
        private System.Windows.Forms.Panel panel1;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedButton buttonOk;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private Components.Rounded.RoundedTextBox roundedTextBoxSensorPath;
        private Components.Rounded.RoundedTextBox roundedTextBoxExamPath;
        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedButton roundedButtonUpdatePatientData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBoxWaterMark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}