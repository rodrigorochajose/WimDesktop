namespace DMMDigital.Views
{
    partial class ConfigView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigView));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonSave = new DMMDigital.Components.Rounded.RoundedButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxAcquireMode = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.comboBoxSensorModel = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.textBoxTwainSource = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonSelectTwainSource = new DMMDigital.Components.Rounded.RoundedButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.buttonConfigureFilters = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonRulerColorPicker = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonTextColorPicker = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonDrawingColorPicker = new DMMDigital.Components.Rounded.RoundedButton();
            this.numericUpDownTextSize = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownDrawingSize = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.labelRulerColor = new System.Windows.Forms.Label();
            this.labelTextSize = new System.Windows.Forms.Label();
            this.labelShapeSize = new System.Windows.Forms.Label();
            this.labelTextColor = new System.Windows.Forms.Label();
            this.labelShapeColor = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.roundedButtonMigrateCDR = new DMMDigital.Components.Rounded.RoundedButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.roundedButtonMigrateWimDesktop = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonExamPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBoxExamPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonSensorPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBoxSensorPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.labelCaminho = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelHeader, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonSave);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
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
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSave.BorderWidth = 5F;
            this.buttonSave.CornerRadius = 5;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.comboBoxLanguage);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.comboBoxAcquireMode);
            this.tabPage1.Controls.Add(this.comboBoxSensorModel);
            this.tabPage1.Controls.Add(this.textBoxTwainSource);
            this.tabPage1.Controls.Add(this.buttonSelectTwainSource);
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxLanguage.BorderColor = System.Drawing.Color.White;
            this.comboBoxLanguage.BorderRadius = 10;
            this.comboBoxLanguage.BorderSize = 10;
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.ForeColor = System.Drawing.Color.Black;
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // comboBoxAcquireMode
            // 
            this.comboBoxAcquireMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxAcquireMode.BorderColor = System.Drawing.Color.White;
            this.comboBoxAcquireMode.BorderRadius = 10;
            this.comboBoxAcquireMode.BorderSize = 10;
            resources.ApplyResources(this.comboBoxAcquireMode, "comboBoxAcquireMode");
            this.comboBoxAcquireMode.ForeColor = System.Drawing.Color.Black;
            this.comboBoxAcquireMode.Name = "comboBoxAcquireMode";
            // 
            // comboBoxSensorModel
            // 
            this.comboBoxSensorModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxSensorModel.BorderColor = System.Drawing.Color.White;
            this.comboBoxSensorModel.BorderRadius = 10;
            this.comboBoxSensorModel.BorderSize = 10;
            resources.ApplyResources(this.comboBoxSensorModel, "comboBoxSensorModel");
            this.comboBoxSensorModel.ForeColor = System.Drawing.Color.Black;
            this.comboBoxSensorModel.Name = "comboBoxSensorModel";
            // 
            // textBoxTwainSource
            // 
            this.textBoxTwainSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxTwainSource.BorderColor = System.Drawing.Color.White;
            this.textBoxTwainSource.BorderRadius = 10;
            this.textBoxTwainSource.BorderSize = 10;
            resources.ApplyResources(this.textBoxTwainSource, "textBoxTwainSource");
            this.textBoxTwainSource.Name = "textBoxTwainSource";
            this.textBoxTwainSource.PlaceholderText = null;
            // 
            // buttonSelectTwainSource
            // 
            this.buttonSelectTwainSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSelectTwainSource.BorderColor = System.Drawing.Color.White;
            this.buttonSelectTwainSource.BorderWidth = 5F;
            this.buttonSelectTwainSource.CornerRadius = 10;
            this.buttonSelectTwainSource.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            resources.ApplyResources(this.buttonSelectTwainSource, "buttonSelectTwainSource");
            this.buttonSelectTwainSource.Name = "buttonSelectTwainSource";
            this.buttonSelectTwainSource.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.label15);
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Name = "panel6";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.panel7);
            this.tabPage2.Controls.Add(this.buttonConfigureFilters);
            this.tabPage2.Controls.Add(this.buttonRulerColorPicker);
            this.tabPage2.Controls.Add(this.buttonTextColorPicker);
            this.tabPage2.Controls.Add(this.buttonDrawingColorPicker);
            this.tabPage2.Controls.Add(this.numericUpDownTextSize);
            this.tabPage2.Controls.Add(this.numericUpDownDrawingSize);
            this.tabPage2.Controls.Add(this.panel5);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Controls.Add(this.labelRulerColor);
            this.tabPage2.Controls.Add(this.labelTextSize);
            this.tabPage2.Controls.Add(this.labelShapeSize);
            this.tabPage2.Controls.Add(this.labelTextColor);
            this.tabPage2.Controls.Add(this.labelShapeColor);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Controls.Add(this.label16);
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Name = "panel7";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // buttonConfigureFilters
            // 
            this.buttonConfigureFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonConfigureFilters.BorderColor = System.Drawing.Color.White;
            this.buttonConfigureFilters.BorderWidth = 5F;
            this.buttonConfigureFilters.CornerRadius = 10;
            this.buttonConfigureFilters.Image = global::DMMDigital.Properties.Resources.icon_32x32_exposure;
            resources.ApplyResources(this.buttonConfigureFilters, "buttonConfigureFilters");
            this.buttonConfigureFilters.Name = "buttonConfigureFilters";
            this.buttonConfigureFilters.UseVisualStyleBackColor = false;
            // 
            // buttonRulerColorPicker
            // 
            this.buttonRulerColorPicker.BackColor = System.Drawing.Color.Red;
            this.buttonRulerColorPicker.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRulerColorPicker.BorderWidth = 7F;
            this.buttonRulerColorPicker.CornerRadius = 5;
            this.buttonRulerColorPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.buttonRulerColorPicker, "buttonRulerColorPicker");
            this.buttonRulerColorPicker.Name = "buttonRulerColorPicker";
            this.buttonRulerColorPicker.UseVisualStyleBackColor = false;
            this.buttonRulerColorPicker.Click += new System.EventHandler(this.buttonRulerColorPickerClick);
            // 
            // buttonTextColorPicker
            // 
            this.buttonTextColorPicker.BackColor = System.Drawing.Color.Red;
            this.buttonTextColorPicker.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonTextColorPicker.BorderWidth = 7F;
            this.buttonTextColorPicker.CornerRadius = 5;
            this.buttonTextColorPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.buttonTextColorPicker, "buttonTextColorPicker");
            this.buttonTextColorPicker.Name = "buttonTextColorPicker";
            this.buttonTextColorPicker.UseVisualStyleBackColor = false;
            this.buttonTextColorPicker.Click += new System.EventHandler(this.buttonTextColorPickerClick);
            // 
            // buttonDrawingColorPicker
            // 
            this.buttonDrawingColorPicker.BackColor = System.Drawing.Color.Red;
            this.buttonDrawingColorPicker.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.buttonDrawingColorPicker.BorderWidth = 7F;
            this.buttonDrawingColorPicker.CornerRadius = 5;
            this.buttonDrawingColorPicker.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.buttonDrawingColorPicker, "buttonDrawingColorPicker");
            this.buttonDrawingColorPicker.Name = "buttonDrawingColorPicker";
            this.buttonDrawingColorPicker.UseVisualStyleBackColor = false;
            this.buttonDrawingColorPicker.Click += new System.EventHandler(this.buttonDrawingColorPickerClick);
            // 
            // numericUpDownTextSize
            // 
            this.numericUpDownTextSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownTextSize.BorderColor = System.Drawing.Color.White;
            this.numericUpDownTextSize.BorderRadius = 10;
            this.numericUpDownTextSize.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownTextSize, "numericUpDownTextSize");
            this.numericUpDownTextSize.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTextSize.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownTextSize.Name = "numericUpDownTextSize";
            // 
            // numericUpDownDrawingSize
            // 
            this.numericUpDownDrawingSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownDrawingSize.BorderColor = System.Drawing.Color.White;
            this.numericUpDownDrawingSize.BorderRadius = 10;
            this.numericUpDownDrawingSize.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownDrawingSize, "numericUpDownDrawingSize");
            this.numericUpDownDrawingSize.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownDrawingSize.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownDrawingSize.Name = "numericUpDownDrawingSize";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.label8);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.label5);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.label4);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // labelRulerColor
            // 
            resources.ApplyResources(this.labelRulerColor, "labelRulerColor");
            this.labelRulerColor.Name = "labelRulerColor";
            // 
            // labelTextSize
            // 
            resources.ApplyResources(this.labelTextSize, "labelTextSize");
            this.labelTextSize.Name = "labelTextSize";
            // 
            // labelShapeSize
            // 
            resources.ApplyResources(this.labelShapeSize, "labelShapeSize");
            this.labelShapeSize.Name = "labelShapeSize";
            // 
            // labelTextColor
            // 
            resources.ApplyResources(this.labelTextColor, "labelTextColor");
            this.labelTextColor.Name = "labelTextColor";
            // 
            // labelShapeColor
            // 
            resources.ApplyResources(this.labelShapeColor, "labelShapeColor");
            this.labelShapeColor.Name = "labelShapeColor";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.Controls.Add(this.roundedButtonMigrateCDR);
            this.tabPage4.Controls.Add(this.panel9);
            this.tabPage4.Controls.Add(this.panel8);
            this.tabPage4.Controls.Add(this.roundedButtonMigrateWimDesktop);
            this.tabPage4.Controls.Add(this.buttonExamPath);
            this.tabPage4.Controls.Add(this.textBoxExamPath);
            this.tabPage4.Controls.Add(this.buttonSensorPath);
            this.tabPage4.Controls.Add(this.textBoxSensorPath);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.labelCaminho);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            // 
            // roundedButtonMigrateCDR
            // 
            resources.ApplyResources(this.roundedButtonMigrateCDR, "roundedButtonMigrateCDR");
            this.roundedButtonMigrateCDR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedButtonMigrateCDR.BorderColor = System.Drawing.Color.White;
            this.roundedButtonMigrateCDR.BorderWidth = 5F;
            this.roundedButtonMigrateCDR.CornerRadius = 5;
            this.roundedButtonMigrateCDR.FlatAppearance.BorderSize = 0;
            this.roundedButtonMigrateCDR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonMigrateCDR.Name = "roundedButtonMigrateCDR";
            this.roundedButtonMigrateCDR.UseVisualStyleBackColor = false;
            this.roundedButtonMigrateCDR.Click += new System.EventHandler(this.roundedButtonMigrateCDRClick);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel9.Controls.Add(this.label6);
            resources.ApplyResources(this.panel9, "panel9");
            this.panel9.Name = "panel9";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel8.Controls.Add(this.label3);
            resources.ApplyResources(this.panel8, "panel8");
            this.panel8.Name = "panel8";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // roundedButtonMigrateWimDesktop
            // 
            resources.ApplyResources(this.roundedButtonMigrateWimDesktop, "roundedButtonMigrateWimDesktop");
            this.roundedButtonMigrateWimDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedButtonMigrateWimDesktop.BorderColor = System.Drawing.Color.White;
            this.roundedButtonMigrateWimDesktop.BorderWidth = 5F;
            this.roundedButtonMigrateWimDesktop.CornerRadius = 5;
            this.roundedButtonMigrateWimDesktop.FlatAppearance.BorderSize = 0;
            this.roundedButtonMigrateWimDesktop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonMigrateWimDesktop.Name = "roundedButtonMigrateWimDesktop";
            this.roundedButtonMigrateWimDesktop.UseVisualStyleBackColor = false;
            this.roundedButtonMigrateWimDesktop.Click += new System.EventHandler(this.roundedButtonMigrateWimDesktopClick);
            // 
            // buttonExamPath
            // 
            this.buttonExamPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonExamPath.BorderColor = System.Drawing.Color.White;
            this.buttonExamPath.BorderWidth = 5F;
            this.buttonExamPath.CornerRadius = 10;
            this.buttonExamPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            resources.ApplyResources(this.buttonExamPath, "buttonExamPath");
            this.buttonExamPath.Name = "buttonExamPath";
            this.buttonExamPath.UseVisualStyleBackColor = false;
            // 
            // textBoxExamPath
            // 
            this.textBoxExamPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxExamPath.BorderColor = System.Drawing.Color.White;
            this.textBoxExamPath.BorderRadius = 10;
            this.textBoxExamPath.BorderSize = 10;
            resources.ApplyResources(this.textBoxExamPath, "textBoxExamPath");
            this.textBoxExamPath.Name = "textBoxExamPath";
            this.textBoxExamPath.PlaceholderText = null;
            // 
            // buttonSensorPath
            // 
            this.buttonSensorPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSensorPath.BorderColor = System.Drawing.Color.White;
            this.buttonSensorPath.BorderWidth = 5F;
            this.buttonSensorPath.CornerRadius = 10;
            this.buttonSensorPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            resources.ApplyResources(this.buttonSensorPath, "buttonSensorPath");
            this.buttonSensorPath.Name = "buttonSensorPath";
            this.buttonSensorPath.UseVisualStyleBackColor = false;
            // 
            // textBoxSensorPath
            // 
            this.textBoxSensorPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxSensorPath.BorderColor = System.Drawing.Color.White;
            this.textBoxSensorPath.BorderRadius = 10;
            this.textBoxSensorPath.BorderSize = 10;
            resources.ApplyResources(this.textBoxSensorPath, "textBoxSensorPath");
            this.textBoxSensorPath.Name = "textBoxSensorPath";
            this.textBoxSensorPath.PlaceholderText = null;
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
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.pictureBoxIcon);
            this.panelHeader.Controls.Add(this.labelTitle);
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Name = "panelHeader";
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
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // ConfigView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigView";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRulerColor;
        private System.Windows.Forms.Label labelTextSize;
        private System.Windows.Forms.Label labelShapeSize;
        private System.Windows.Forms.Label labelTextColor;
        private System.Windows.Forms.Label labelShapeColor;
        private System.Windows.Forms.TabPage tabPage4;
        private Components.Rounded.RoundedTextBox textBoxSensorPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelCaminho;
        private Components.Rounded.RoundedButton buttonSensorPath;
        private Components.Rounded.RoundedButton buttonExamPath;
        private Components.Rounded.RoundedTextBox textBoxExamPath;
        private Components.Rounded.RoundedButton buttonSelectTwainSource;
        private Components.Rounded.RoundedTextBox textBoxTwainSource;
        private Components.Rounded.RoundedComboBox comboBoxAcquireMode;
        private Components.Rounded.RoundedComboBox comboBoxSensorModel;
        private System.Windows.Forms.Panel panel1;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedButton buttonSave;
        private Components.Rounded.RoundedNumericUpDown numericUpDownTextSize;
        private Components.Rounded.RoundedNumericUpDown numericUpDownDrawingSize;
        private System.Windows.Forms.Panel panelHeader;
        private Components.Rounded.RoundedButton buttonDrawingColorPicker;
        private Components.Rounded.RoundedButton buttonTextColorPicker;
        private Components.Rounded.RoundedButton buttonRulerColorPicker;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedComboBox comboBoxLanguage;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label16;
        private Components.Rounded.RoundedButton buttonConfigureFilters;
        private Components.Rounded.RoundedButton roundedButtonMigrateWimDesktop;
        private Components.Rounded.RoundedButton roundedButtonMigrateCDR;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label3;
    }
}