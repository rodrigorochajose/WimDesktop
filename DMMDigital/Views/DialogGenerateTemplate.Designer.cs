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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxOrientation = new System.Windows.Forms.ListBox();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownColumns = new System.Windows.Forms.NumericUpDown();
            this.textBoxTemplateName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelGenerateDefault = new System.Windows.Forms.Panel();
            this.panelGenerateByTemplate = new System.Windows.Forms.Panel();
            this.panelShowTemplate = new System.Windows.Forms.Panel();
            this.comboBoxTemplate = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxGenerateMode = new System.Windows.Forms.CheckBox();
            this.buttonGenerateTemplate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).BeginInit();
            this.panelGenerateDefault.SuspendLayout();
            this.panelGenerateByTemplate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(77, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Quantidade de Linhas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(72, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quantidade de Colunas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(128, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Orientação";
            // 
            // listBoxOrientation
            // 
            this.listBoxOrientation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxOrientation.FormattingEnabled = true;
            this.listBoxOrientation.ItemHeight = 17;
            this.listBoxOrientation.Items.AddRange(new object[] {
            "Vertical Cima",
            "Vertical Baixo",
            "Horizontal Esquerda",
            "Horizontal Direita"});
            this.listBoxOrientation.Location = new System.Drawing.Point(94, 167);
            this.listBoxOrientation.Name = "listBoxOrientation";
            this.listBoxOrientation.Size = new System.Drawing.Size(145, 72);
            this.listBoxOrientation.TabIndex = 6;
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownRows.Location = new System.Drawing.Point(229, 83);
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
            this.numericUpDownRows.Size = new System.Drawing.Size(48, 25);
            this.numericUpDownRows.TabIndex = 7;
            this.numericUpDownRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownColumns
            // 
            this.numericUpDownColumns.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownColumns.Location = new System.Drawing.Point(231, 23);
            this.numericUpDownColumns.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumns.Name = "numericUpDownColumns";
            this.numericUpDownColumns.Size = new System.Drawing.Size(48, 25);
            this.numericUpDownColumns.TabIndex = 8;
            this.numericUpDownColumns.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxTemplateName
            // 
            this.textBoxTemplateName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxTemplateName.Location = new System.Drawing.Point(146, 16);
            this.textBoxTemplateName.Name = "textBoxTemplateName";
            this.textBoxTemplateName.Size = new System.Drawing.Size(249, 25);
            this.textBoxTemplateName.TabIndex = 9;
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
            // panelGenerateDefault
            // 
            this.panelGenerateDefault.Controls.Add(this.numericUpDownColumns);
            this.panelGenerateDefault.Controls.Add(this.numericUpDownRows);
            this.panelGenerateDefault.Controls.Add(this.listBoxOrientation);
            this.panelGenerateDefault.Controls.Add(this.label1);
            this.panelGenerateDefault.Controls.Add(this.label3);
            this.panelGenerateDefault.Controls.Add(this.label2);
            this.panelGenerateDefault.Location = new System.Drawing.Point(3, 10);
            this.panelGenerateDefault.Name = "panelGenerateDefault";
            this.panelGenerateDefault.Size = new System.Drawing.Size(354, 289);
            this.panelGenerateDefault.TabIndex = 11;
            // 
            // panelGenerateByTemplate
            // 
            this.panelGenerateByTemplate.Controls.Add(this.panelShowTemplate);
            this.panelGenerateByTemplate.Controls.Add(this.comboBoxTemplate);
            this.panelGenerateByTemplate.Controls.Add(this.label5);
            this.panelGenerateByTemplate.Enabled = false;
            this.panelGenerateByTemplate.Location = new System.Drawing.Point(421, 10);
            this.panelGenerateByTemplate.Name = "panelGenerateByTemplate";
            this.panelGenerateByTemplate.Size = new System.Drawing.Size(354, 289);
            this.panelGenerateByTemplate.TabIndex = 12;
            // 
            // panelShowTemplate
            // 
            this.panelShowTemplate.BackColor = System.Drawing.Color.Silver;
            this.panelShowTemplate.Enabled = false;
            this.panelShowTemplate.Location = new System.Drawing.Point(2, 63);
            this.panelShowTemplate.Name = "panelShowTemplate";
            this.panelShowTemplate.Size = new System.Drawing.Size(350, 225);
            this.panelShowTemplate.TabIndex = 18;
            // 
            // comboBoxTemplate
            // 
            this.comboBoxTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTemplate.FormattingEnabled = true;
            this.comboBoxTemplate.Location = new System.Drawing.Point(75, 20);
            this.comboBoxTemplate.Name = "comboBoxTemplate";
            this.comboBoxTemplate.Size = new System.Drawing.Size(204, 23);
            this.comboBoxTemplate.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Template";
            // 
            // checkBoxGenerateMode
            // 
            this.checkBoxGenerateMode.AutoSize = true;
            this.checkBoxGenerateMode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxGenerateMode.Location = new System.Drawing.Point(462, 17);
            this.checkBoxGenerateMode.Name = "checkBoxGenerateMode";
            this.checkBoxGenerateMode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxGenerateMode.Size = new System.Drawing.Size(164, 23);
            this.checkBoxGenerateMode.TabIndex = 15;
            this.checkBoxGenerateMode.Text = "Usar template modelo";
            this.checkBoxGenerateMode.UseVisualStyleBackColor = true;
            this.checkBoxGenerateMode.CheckedChanged += new System.EventHandler(this.checkBoxGenerateModeCheckedChanged);
            // 
            // buttonGenerateTemplate
            // 
            this.buttonGenerateTemplate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerateTemplate.Location = new System.Drawing.Point(697, 14);
            this.buttonGenerateTemplate.Name = "buttonGenerateTemplate";
            this.buttonGenerateTemplate.Size = new System.Drawing.Size(73, 30);
            this.buttonGenerateTemplate.TabIndex = 16;
            this.buttonGenerateTemplate.Text = "Gerar";
            this.buttonGenerateTemplate.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.buttonGenerateTemplate);
            this.panel1.Controls.Add(this.textBoxTemplateName);
            this.panel1.Controls.Add(this.checkBoxGenerateMode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 60);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelGenerateDefault);
            this.panel2.Controls.Add(this.panelGenerateByTemplate);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 324);
            this.panel2.TabIndex = 17;
            // 
            // DialogGenerateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 384);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DialogGenerateTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Template";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumns)).EndInit();
            this.panelGenerateDefault.ResumeLayout(false);
            this.panelGenerateDefault.PerformLayout();
            this.panelGenerateByTemplate.ResumeLayout(false);
            this.panelGenerateByTemplate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxOrientation;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownColumns;
        private System.Windows.Forms.TextBox textBoxTemplateName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelGenerateDefault;
        private System.Windows.Forms.Panel panelGenerateByTemplate;
        private System.Windows.Forms.ComboBox comboBoxTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelShowTemplate;
        private System.Windows.Forms.CheckBox checkBoxGenerateMode;
        private System.Windows.Forms.Button buttonGenerateTemplate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}