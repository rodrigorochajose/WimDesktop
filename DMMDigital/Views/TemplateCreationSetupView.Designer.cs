namespace DMMDigital.Views
{
    partial class TemplateCreationSetupView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateCreationSetupView));
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxGenerateMode = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelGenerateByTemplate = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelGenerateDefault = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelGenerateTemplate = new System.Windows.Forms.Panel();
            this.comboBoxTemplate = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.panelShowTemplate = new DMMDigital.Components.Rounded.RoundedPanel();
            this.comboBoxOrientation = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.numericUpDownRows = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownColumns = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.buttonGenerateTemplate = new DMMDigital.Components.Rounded.RoundedButton();
            this.roundedTextBoxTemplateName = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelGenerateByTemplate.SuspendLayout();
            this.panelGenerateDefault.SuspendLayout();
            this.panelGenerateTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // checkBoxGenerateMode
            // 
            resources.ApplyResources(this.checkBoxGenerateMode, "checkBoxGenerateMode");
            this.checkBoxGenerateMode.Name = "checkBoxGenerateMode";
            this.checkBoxGenerateMode.UseVisualStyleBackColor = true;
            this.checkBoxGenerateMode.CheckedChanged += new System.EventHandler(this.checkBoxGenerateModeCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.roundedTextBoxTemplateName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBoxGenerateMode);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonGenerateTemplate);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panelGenerateByTemplate
            // 
            this.panelGenerateByTemplate.BackColor = System.Drawing.Color.White;
            this.panelGenerateByTemplate.Controls.Add(this.comboBoxTemplate);
            this.panelGenerateByTemplate.Controls.Add(this.panelShowTemplate);
            this.panelGenerateByTemplate.Controls.Add(this.label5);
            resources.ApplyResources(this.panelGenerateByTemplate, "panelGenerateByTemplate");
            this.panelGenerateByTemplate.Name = "panelGenerateByTemplate";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panelGenerateDefault
            // 
            this.panelGenerateDefault.BackColor = System.Drawing.Color.White;
            this.panelGenerateDefault.Controls.Add(this.comboBoxOrientation);
            this.panelGenerateDefault.Controls.Add(this.numericUpDownRows);
            this.panelGenerateDefault.Controls.Add(this.numericUpDownColumns);
            this.panelGenerateDefault.Controls.Add(this.label1);
            this.panelGenerateDefault.Controls.Add(this.label3);
            this.panelGenerateDefault.Controls.Add(this.label2);
            resources.ApplyResources(this.panelGenerateDefault, "panelGenerateDefault");
            this.panelGenerateDefault.Name = "panelGenerateDefault";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // panelGenerateTemplate
            // 
            this.panelGenerateTemplate.BackColor = System.Drawing.Color.White;
            this.panelGenerateTemplate.Controls.Add(this.panelGenerateByTemplate);
            this.panelGenerateTemplate.Controls.Add(this.panelGenerateDefault);
            resources.ApplyResources(this.panelGenerateTemplate, "panelGenerateTemplate");
            this.panelGenerateTemplate.Name = "panelGenerateTemplate";
            // 
            // comboBoxTemplate
            // 
            this.comboBoxTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxTemplate.BorderColor = System.Drawing.Color.White;
            this.comboBoxTemplate.BorderRadius = 10;
            this.comboBoxTemplate.BorderSize = 10;
            resources.ApplyResources(this.comboBoxTemplate, "comboBoxTemplate");
            this.comboBoxTemplate.ForeColor = System.Drawing.Color.Gray;
            this.comboBoxTemplate.Name = "comboBoxTemplate";
            // 
            // panelShowTemplate
            // 
            this.panelShowTemplate.BackColor = System.Drawing.Color.Silver;
            this.panelShowTemplate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.panelShowTemplate.BorderWidth = 5F;
            this.panelShowTemplate.CornerRadius = 20;
            resources.ApplyResources(this.panelShowTemplate, "panelShowTemplate");
            this.panelShowTemplate.Name = "panelShowTemplate";
            // 
            // comboBoxOrientation
            // 
            this.comboBoxOrientation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxOrientation.BorderColor = System.Drawing.Color.White;
            this.comboBoxOrientation.BorderRadius = 10;
            this.comboBoxOrientation.BorderSize = 10;
            resources.ApplyResources(this.comboBoxOrientation, "comboBoxOrientation");
            this.comboBoxOrientation.ForeColor = System.Drawing.Color.Gray;
            this.comboBoxOrientation.Name = "comboBoxOrientation";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownRows.BorderColor = System.Drawing.Color.White;
            this.numericUpDownRows.BorderRadius = 10;
            this.numericUpDownRows.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownRows, "numericUpDownRows");
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownColumns.BorderColor = System.Drawing.Color.White;
            this.numericUpDownColumns.BorderRadius = 10;
            this.numericUpDownColumns.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownColumns, "numericUpDownColumns");
            this.numericUpDownColumns.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            // 
            // buttonGenerateTemplate
            // 
            resources.ApplyResources(this.buttonGenerateTemplate, "buttonGenerateTemplate");
            this.buttonGenerateTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonGenerateTemplate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonGenerateTemplate.BorderWidth = 5F;
            this.buttonGenerateTemplate.CornerRadius = 5;
            this.buttonGenerateTemplate.FlatAppearance.BorderSize = 0;
            this.buttonGenerateTemplate.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateTemplate.Name = "buttonGenerateTemplate";
            this.buttonGenerateTemplate.UseVisualStyleBackColor = false;
            // 
            // roundedTextBoxTemplateName
            // 
            this.roundedTextBoxTemplateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxTemplateName.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxTemplateName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxTemplateName.BorderRadius = 10;
            this.roundedTextBoxTemplateName.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBoxTemplateName, "roundedTextBoxTemplateName");
            this.roundedTextBoxTemplateName.ForeColor = System.Drawing.Color.Gray;
            this.roundedTextBoxTemplateName.Multiline = false;
            this.roundedTextBoxTemplateName.Name = "roundedTextBoxTemplateName";
            this.roundedTextBoxTemplateName.PasswordChar = false;
            this.roundedTextBoxTemplateName.PlaceholderColor = System.Drawing.Color.Gray;
            this.roundedTextBoxTemplateName.PlaceholderText = "";
            this.roundedTextBoxTemplateName.Texts = "";
            this.roundedTextBoxTemplateName.UnderlinedStyle = false;
            // 
            // TemplateCreationSetupView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGenerateTemplate);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateCreationSetupView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panelGenerateByTemplate.ResumeLayout(false);
            this.panelGenerateByTemplate.PerformLayout();
            this.panelGenerateDefault.ResumeLayout(false);
            this.panelGenerateDefault.PerformLayout();
            this.panelGenerateTemplate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxGenerateMode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelGenerateByTemplate;
        private Components.Rounded.RoundedComboBox comboBoxTemplate;
        private Components.Rounded.RoundedPanel panelShowTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelGenerateDefault;
        private Components.Rounded.RoundedComboBox comboBoxOrientation;
        private Components.Rounded.RoundedNumericUpDown numericUpDownRows;
        private Components.Rounded.RoundedNumericUpDown numericUpDownColumns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Components.Rounded.RoundedButton buttonGenerateTemplate;
        private System.Windows.Forms.Panel panelGenerateTemplate;
        private Components.Rounded.RoundedTextBox roundedTextBoxTemplateName;
    }
}