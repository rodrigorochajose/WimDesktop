namespace DMMDigital.Views
{
    partial class PostProcessConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostProcessConfig));
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxFilteredImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonRestoreImage = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonImport = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonRestoreValues = new DMMDigital.Components.Rounded.RoundedButton();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSave = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonApply = new DMMDigital.Components.Rounded.RoundedButton();
            this.numericUpDownSmartSharpen = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownReveal = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownBrightness = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownContrast = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilteredImage)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxOriginalImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(201, 18);
            this.pictureBoxOriginalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(400, 508);
            this.pictureBoxOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginalImage.TabIndex = 0;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxFilteredImage
            // 
            this.pictureBoxFilteredImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxFilteredImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxFilteredImage.Location = new System.Drawing.Point(619, 18);
            this.pictureBoxFilteredImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxFilteredImage.Name = "pictureBoxFilteredImage";
            this.pictureBoxFilteredImage.Size = new System.Drawing.Size(400, 508);
            this.pictureBoxFilteredImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFilteredImage.TabIndex = 1;
            this.pictureBoxFilteredImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(4, 88);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Brilho";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(4, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contraste";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(4, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Revelar";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonRestoreImage);
            this.panel3.Controls.Add(this.buttonImport);
            this.panel3.Controls.Add(this.buttonRestoreValues);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.buttonApply);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.numericUpDownSmartSharpen);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.numericUpDownReveal);
            this.panel3.Controls.Add(this.numericUpDownBrightness);
            this.panel3.Controls.Add(this.numericUpDownContrast);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(193, 526);
            this.panel3.TabIndex = 18;
            // 
            // buttonRestoreImage
            // 
            this.buttonRestoreImage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRestoreImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreImage.BorderColor = System.Drawing.Color.White;
            this.buttonRestoreImage.BorderWidth = 5F;
            this.buttonRestoreImage.CornerRadius = 5;
            this.buttonRestoreImage.FlatAppearance.BorderSize = 0;
            this.buttonRestoreImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestoreImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonRestoreImage.ForeColor = System.Drawing.Color.Black;
            this.buttonRestoreImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRestoreImage.Location = new System.Drawing.Point(100, 362);
            this.buttonRestoreImage.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRestoreImage.Name = "buttonRestoreImage";
            this.buttonRestoreImage.Padding = new System.Windows.Forms.Padding(2);
            this.buttonRestoreImage.Size = new System.Drawing.Size(87, 51);
            this.buttonRestoreImage.TabIndex = 72;
            this.buttonRestoreImage.Text = "Restaurar Imagem";
            this.buttonRestoreImage.UseVisualStyleBackColor = false;
            this.buttonRestoreImage.Click += new System.EventHandler(this.buttonRestoreImageClick);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonImport.BorderColor = System.Drawing.Color.White;
            this.buttonImport.BorderWidth = 5F;
            this.buttonImport.CornerRadius = 5;
            this.buttonImport.FlatAppearance.BorderSize = 0;
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonImport.ForeColor = System.Drawing.Color.Black;
            this.buttonImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImport.Location = new System.Drawing.Point(33, 11);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(0);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Padding = new System.Windows.Forms.Padding(2);
            this.buttonImport.Size = new System.Drawing.Size(131, 40);
            this.buttonImport.TabIndex = 73;
            this.buttonImport.Text = "Importar Imagem";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImportClick);
            // 
            // buttonRestoreValues
            // 
            this.buttonRestoreValues.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRestoreValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreValues.BorderColor = System.Drawing.Color.White;
            this.buttonRestoreValues.BorderWidth = 5F;
            this.buttonRestoreValues.CornerRadius = 5;
            this.buttonRestoreValues.FlatAppearance.BorderSize = 0;
            this.buttonRestoreValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestoreValues.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonRestoreValues.ForeColor = System.Drawing.Color.Black;
            this.buttonRestoreValues.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRestoreValues.Location = new System.Drawing.Point(9, 362);
            this.buttonRestoreValues.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRestoreValues.Name = "buttonRestoreValues";
            this.buttonRestoreValues.Padding = new System.Windows.Forms.Padding(2);
            this.buttonRestoreValues.Size = new System.Drawing.Size(87, 51);
            this.buttonRestoreValues.TabIndex = 71;
            this.buttonRestoreValues.Text = "Zerar Valores";
            this.buttonRestoreValues.UseVisualStyleBackColor = false;
            this.buttonRestoreValues.Click += new System.EventHandler(this.buttonRestoreValuesClick);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.Location = new System.Drawing.Point(4, 241);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 19);
            this.label6.TabIndex = 16;
            this.label6.Text = "Smart Shapen";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSave.BorderWidth = 5F;
            this.buttonSave.CornerRadius = 5;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(47, 460);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Padding = new System.Windows.Forms.Padding(2);
            this.buttonSave.Size = new System.Drawing.Size(99, 40);
            this.buttonSave.TabIndex = 70;
            this.buttonSave.Text = "Confirmar";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonApply.BorderColor = System.Drawing.Color.White;
            this.buttonApply.BorderWidth = 5F;
            this.buttonApply.CornerRadius = 5;
            this.buttonApply.FlatAppearance.BorderSize = 0;
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonApply.ForeColor = System.Drawing.Color.Black;
            this.buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonApply.Location = new System.Drawing.Point(47, 294);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(0);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Padding = new System.Windows.Forms.Padding(2);
            this.buttonApply.Size = new System.Drawing.Size(99, 40);
            this.buttonApply.TabIndex = 67;
            this.buttonApply.Text = "Aplicar";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApplyClick);
            // 
            // numericUpDownSmartSharpen
            // 
            this.numericUpDownSmartSharpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownSmartSharpen.BorderColor = System.Drawing.Color.White;
            this.numericUpDownSmartSharpen.BorderRadius = 10;
            this.numericUpDownSmartSharpen.BorderSize = 10;
            this.numericUpDownSmartSharpen.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericUpDownSmartSharpen.Location = new System.Drawing.Point(105, 230);
            this.numericUpDownSmartSharpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownSmartSharpen.Name = "numericUpDownSmartSharpen";
            this.numericUpDownSmartSharpen.Size = new System.Drawing.Size(69, 42);
            this.numericUpDownSmartSharpen.TabIndex = 66;
            // 
            // numericUpDownReveal
            // 
            this.numericUpDownReveal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownReveal.BorderColor = System.Drawing.Color.White;
            this.numericUpDownReveal.BorderRadius = 10;
            this.numericUpDownReveal.BorderSize = 10;
            this.numericUpDownReveal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericUpDownReveal.Location = new System.Drawing.Point(105, 180);
            this.numericUpDownReveal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownReveal.Name = "numericUpDownReveal";
            this.numericUpDownReveal.Size = new System.Drawing.Size(69, 42);
            this.numericUpDownReveal.TabIndex = 65;
            // 
            // numericUpDownBrightness
            // 
            this.numericUpDownBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownBrightness.BorderColor = System.Drawing.Color.White;
            this.numericUpDownBrightness.BorderRadius = 10;
            this.numericUpDownBrightness.BorderSize = 10;
            this.numericUpDownBrightness.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericUpDownBrightness.Location = new System.Drawing.Point(105, 80);
            this.numericUpDownBrightness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownBrightness.Name = "numericUpDownBrightness";
            this.numericUpDownBrightness.Size = new System.Drawing.Size(69, 42);
            this.numericUpDownBrightness.TabIndex = 63;
            // 
            // numericUpDownContrast
            // 
            this.numericUpDownContrast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownContrast.BorderColor = System.Drawing.Color.White;
            this.numericUpDownContrast.BorderRadius = 10;
            this.numericUpDownContrast.BorderSize = 10;
            this.numericUpDownContrast.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numericUpDownContrast.Location = new System.Drawing.Point(105, 130);
            this.numericUpDownContrast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDownContrast.Name = "numericUpDownContrast";
            this.numericUpDownContrast.Size = new System.Drawing.Size(69, 42);
            this.numericUpDownContrast.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(341, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Imagem Original";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(778, -2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Imagem Editada";
            // 
            // PostProcessConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1025, 526);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBoxFilteredImage);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostProcessConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Filtros";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilteredImage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.PictureBox pictureBoxFilteredImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Components.Rounded.RoundedNumericUpDown numericUpDownBrightness;
        private Components.Rounded.RoundedNumericUpDown numericUpDownContrast;
        private Components.Rounded.RoundedNumericUpDown numericUpDownReveal;
        private Components.Rounded.RoundedNumericUpDown numericUpDownSmartSharpen;
        private Components.Rounded.RoundedButton buttonApply;
        private Components.Rounded.RoundedButton buttonSave;
        private Components.Rounded.RoundedButton buttonImport;
        private Components.Rounded.RoundedButton buttonRestoreValues;
        private Components.Rounded.RoundedButton buttonRestoreImage;
    }
}