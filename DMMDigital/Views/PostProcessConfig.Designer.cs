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
            this.buttonRestoreImage = new System.Windows.Forms.Button();
            this.numericUpDownGamma = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEdge = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNoise = new System.Windows.Forms.NumericUpDown();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonRestoreValues = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFilteredImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoise)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxOriginalImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(13, 26);
            this.pictureBoxOriginalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(400, 500);
            this.pictureBoxOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginalImage.TabIndex = 0;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxFilteredImage
            // 
            this.pictureBoxFilteredImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxFilteredImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxFilteredImage.Location = new System.Drawing.Point(431, 26);
            this.pictureBoxFilteredImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxFilteredImage.Name = "pictureBoxFilteredImage";
            this.pictureBoxFilteredImage.Size = new System.Drawing.Size(400, 500);
            this.pictureBoxFilteredImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFilteredImage.TabIndex = 1;
            this.pictureBoxFilteredImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Gamma";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Edge";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Noise";
            // 
            // buttonRestoreImage
            // 
            this.buttonRestoreImage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRestoreImage.Location = new System.Drawing.Point(82, 341);
            this.buttonRestoreImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRestoreImage.Name = "buttonRestoreImage";
            this.buttonRestoreImage.Size = new System.Drawing.Size(66, 42);
            this.buttonRestoreImage.TabIndex = 9;
            this.buttonRestoreImage.Text = "Restaurar Imagem";
            this.buttonRestoreImage.UseVisualStyleBackColor = true;
            this.buttonRestoreImage.Click += new System.EventHandler(this.buttonRestoreImageClick);
            // 
            // numericUpDownGamma
            // 
            this.numericUpDownGamma.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numericUpDownGamma.DecimalPlaces = 2;
            this.numericUpDownGamma.Location = new System.Drawing.Point(41, 126);
            this.numericUpDownGamma.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownGamma.Name = "numericUpDownGamma";
            this.numericUpDownGamma.Size = new System.Drawing.Size(85, 23);
            this.numericUpDownGamma.TabIndex = 10;
            // 
            // numericUpDownEdge
            // 
            this.numericUpDownEdge.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numericUpDownEdge.DecimalPlaces = 2;
            this.numericUpDownEdge.Location = new System.Drawing.Point(41, 180);
            this.numericUpDownEdge.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownEdge.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericUpDownEdge.Name = "numericUpDownEdge";
            this.numericUpDownEdge.Size = new System.Drawing.Size(85, 23);
            this.numericUpDownEdge.TabIndex = 11;
            // 
            // numericUpDownNoise
            // 
            this.numericUpDownNoise.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.numericUpDownNoise.DecimalPlaces = 2;
            this.numericUpDownNoise.Location = new System.Drawing.Point(41, 237);
            this.numericUpDownNoise.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numericUpDownNoise.Name = "numericUpDownNoise";
            this.numericUpDownNoise.Size = new System.Drawing.Size(85, 23);
            this.numericUpDownNoise.TabIndex = 12;
            // 
            // buttonApply
            // 
            this.buttonApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonApply.Location = new System.Drawing.Point(34, 282);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(88, 39);
            this.buttonApply.TabIndex = 13;
            this.buttonApply.Text = "Aplicar";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApplyClick);
            // 
            // buttonImport
            // 
            this.buttonImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonImport.Location = new System.Drawing.Point(21, 23);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(120, 36);
            this.buttonImport.TabIndex = 15;
            this.buttonImport.Text = "Importar Imagem";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImportClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.buttonImport);
            this.panel3.Controls.Add(this.buttonRestoreValues);
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Controls.Add(this.buttonRestoreImage);
            this.panel3.Controls.Add(this.numericUpDownGamma);
            this.panel3.Controls.Add(this.buttonApply);
            this.panel3.Controls.Add(this.numericUpDownEdge);
            this.panel3.Controls.Add(this.numericUpDownNoise);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(837, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(154, 534);
            this.panel3.TabIndex = 18;
            // 
            // buttonRestoreValues
            // 
            this.buttonRestoreValues.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonRestoreValues.Location = new System.Drawing.Point(10, 341);
            this.buttonRestoreValues.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRestoreValues.Name = "buttonRestoreValues";
            this.buttonRestoreValues.Size = new System.Drawing.Size(66, 42);
            this.buttonRestoreValues.TabIndex = 15;
            this.buttonRestoreValues.Text = "Zerar Valores";
            this.buttonRestoreValues.UseVisualStyleBackColor = true;
            this.buttonRestoreValues.Click += new System.EventHandler(this.buttonRestoreValuesClick);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(38, 464);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(91, 39);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Confirmar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(153, 6);
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
            this.label5.Location = new System.Drawing.Point(590, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Imagem Editada";
            // 
            // PostProcessConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(991, 534);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNoise)).EndInit();
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
        private System.Windows.Forms.Button buttonRestoreImage;
        private System.Windows.Forms.NumericUpDown numericUpDownGamma;
        private System.Windows.Forms.NumericUpDown numericUpDownEdge;
        private System.Windows.Forms.NumericUpDown numericUpDownNoise;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonRestoreValues;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}