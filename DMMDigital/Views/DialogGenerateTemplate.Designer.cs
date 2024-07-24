namespace DMMDigital.Views
{
    partial class DialogGenerateTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogGenerateTemplate));
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxGenerateMode = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelGenerateByTemplate = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelGenerateDefault = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGenerateTemplate = new System.Windows.Forms.Panel();
            this.comboBoxTemplate = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.panelShowTemplate = new DMMDigital.Components.Rounded.RoundedPanel();
            this.comboBoxOrientation = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.numericUpDownRows = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownColumns = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.buttonGenerateTemplate = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBoxTemplateName = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelGenerateByTemplate.SuspendLayout();
            this.panelGenerateDefault.SuspendLayout();
            this.panelGenerateTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nome do Template";
            // 
            // checkBoxGenerateMode
            // 
            this.checkBoxGenerateMode.AutoSize = true;
            this.checkBoxGenerateMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGenerateMode.Location = new System.Drawing.Point(427, 18);
            this.checkBoxGenerateMode.Name = "checkBoxGenerateMode";
            this.checkBoxGenerateMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxGenerateMode.Size = new System.Drawing.Size(164, 23);
            this.checkBoxGenerateMode.TabIndex = 15;
            this.checkBoxGenerateMode.Text = "Usar template modelo";
            this.checkBoxGenerateMode.UseVisualStyleBackColor = true;
            this.checkBoxGenerateMode.CheckedChanged += new System.EventHandler(this.checkBoxGenerateModeCheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBoxTemplateName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBoxGenerateMode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 54);
            this.panel1.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonGenerateTemplate);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 333);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 57);
            this.panel3.TabIndex = 18;
            // 
            // panelGenerateByTemplate
            // 
            this.panelGenerateByTemplate.BackColor = System.Drawing.Color.White;
            this.panelGenerateByTemplate.Controls.Add(this.comboBoxTemplate);
            this.panelGenerateByTemplate.Controls.Add(this.panelShowTemplate);
            this.panelGenerateByTemplate.Controls.Add(this.label5);
            this.panelGenerateByTemplate.Location = new System.Drawing.Point(248, 0);
            this.panelGenerateByTemplate.Name = "panelGenerateByTemplate";
            this.panelGenerateByTemplate.Size = new System.Drawing.Size(376, 278);
            this.panelGenerateByTemplate.TabIndex = 12;
            this.panelGenerateByTemplate.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Template";
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
            this.panelGenerateDefault.Location = new System.Drawing.Point(0, 0);
            this.panelGenerateDefault.Name = "panelGenerateDefault";
            this.panelGenerateDefault.Size = new System.Drawing.Size(248, 278);
            this.panelGenerateDefault.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade de Colunas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(75, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Orientação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(8, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantidade de Linhas";
            // 
            // panelGenerateTemplate
            // 
            this.panelGenerateTemplate.BackColor = System.Drawing.Color.White;
            this.panelGenerateTemplate.Controls.Add(this.panelGenerateByTemplate);
            this.panelGenerateTemplate.Controls.Add(this.panelGenerateDefault);
            this.panelGenerateTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGenerateTemplate.Location = new System.Drawing.Point(0, 54);
            this.panelGenerateTemplate.Name = "panelGenerateTemplate";
            this.panelGenerateTemplate.Size = new System.Drawing.Size(624, 279);
            this.panelGenerateTemplate.TabIndex = 20;
            // 
            // comboBoxTemplate
            // 
            this.comboBoxTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxTemplate.BorderColor = System.Drawing.Color.White;
            this.comboBoxTemplate.BorderRadius = 10;
            this.comboBoxTemplate.BorderSize = 10;
            this.comboBoxTemplate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxTemplate.Location = new System.Drawing.Point(106, 6);
            this.comboBoxTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxTemplate.Name = "comboBoxTemplate";
            this.comboBoxTemplate.Size = new System.Drawing.Size(222, 43);
            this.comboBoxTemplate.TabIndex = 61;
            // 
            // panelShowTemplate
            // 
            this.panelShowTemplate.BackColor = System.Drawing.Color.Silver;
            this.panelShowTemplate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.panelShowTemplate.BorderWidth = 5F;
            this.panelShowTemplate.CornerRadius = 20;
            this.panelShowTemplate.Location = new System.Drawing.Point(14, 51);
            this.panelShowTemplate.Name = "panelShowTemplate";
            this.panelShowTemplate.Size = new System.Drawing.Size(350, 225);
            this.panelShowTemplate.TabIndex = 50;
            // 
            // comboBoxOrientation
            // 
            this.comboBoxOrientation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxOrientation.BorderColor = System.Drawing.Color.White;
            this.comboBoxOrientation.BorderRadius = 10;
            this.comboBoxOrientation.BorderSize = 10;
            this.comboBoxOrientation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxOrientation.Location = new System.Drawing.Point(8, 199);
            this.comboBoxOrientation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxOrientation.Name = "comboBoxOrientation";
            this.comboBoxOrientation.Size = new System.Drawing.Size(224, 46);
            this.comboBoxOrientation.TabIndex = 62;
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownRows.BorderColor = System.Drawing.Color.White;
            this.numericUpDownRows.BorderRadius = 10;
            this.numericUpDownRows.BorderSize = 10;
            this.numericUpDownRows.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericUpDownRows.Location = new System.Drawing.Point(163, 96);
            this.numericUpDownRows.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(69, 42);
            this.numericUpDownRows.TabIndex = 63;
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownColumns.BorderColor = System.Drawing.Color.White;
            this.numericUpDownColumns.BorderRadius = 10;
            this.numericUpDownColumns.BorderSize = 10;
            this.numericUpDownColumns.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericUpDownColumns.Location = new System.Drawing.Point(163, 21);
            this.numericUpDownColumns.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(69, 42);
            this.numericUpDownColumns.TabIndex = 62;
            // 
            // buttonGenerateTemplate
            // 
            this.buttonGenerateTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonGenerateTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonGenerateTemplate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonGenerateTemplate.BorderWidth = 5F;
            this.buttonGenerateTemplate.CornerRadius = 5;
            this.buttonGenerateTemplate.FlatAppearance.BorderSize = 0;
            this.buttonGenerateTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateTemplate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonGenerateTemplate.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerateTemplate.Location = new System.Drawing.Point(250, 7);
            this.buttonGenerateTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonGenerateTemplate.Name = "buttonGenerateTemplate";
            this.buttonGenerateTemplate.Padding = new System.Windows.Forms.Padding(2);
            this.buttonGenerateTemplate.Size = new System.Drawing.Size(99, 40);
            this.buttonGenerateTemplate.TabIndex = 58;
            this.buttonGenerateTemplate.Text = "Gerar";
            this.buttonGenerateTemplate.UseVisualStyleBackColor = false;
            // 
            // textBoxTemplateName
            // 
            this.textBoxTemplateName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxTemplateName.BorderColor = System.Drawing.Color.White;
            this.textBoxTemplateName.BorderRadius = 10;
            this.textBoxTemplateName.BorderSize = 10;
            this.textBoxTemplateName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxTemplateName.ForeColor = System.Drawing.Color.Black;
            this.textBoxTemplateName.Location = new System.Drawing.Point(143, 6);
            this.textBoxTemplateName.Name = "textBoxTemplateName";
            this.textBoxTemplateName.PlaceholderText = null;
            this.textBoxTemplateName.Size = new System.Drawing.Size(261, 44);
            this.textBoxTemplateName.TabIndex = 31;
            // 
            // DialogGenerateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 390);
            this.Controls.Add(this.panelGenerateTemplate);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogGenerateTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Template";
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
        private Components.Rounded.RoundedTextBox textBoxTemplateName;
        private System.Windows.Forms.Panel panelGenerateTemplate;
    }
}