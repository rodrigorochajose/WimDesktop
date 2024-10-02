namespace DMMDigital.Views
{
    partial class PostProcessView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostProcessView));
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
            resources.ApplyResources(this.pictureBoxOriginalImage, "pictureBoxOriginalImage");
            this.pictureBoxOriginalImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxFilteredImage
            // 
            resources.ApplyResources(this.pictureBoxFilteredImage, "pictureBoxFilteredImage");
            this.pictureBoxFilteredImage.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBoxFilteredImage.Name = "pictureBoxFilteredImage";
            this.pictureBoxFilteredImage.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
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
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // buttonRestoreImage
            // 
            resources.ApplyResources(this.buttonRestoreImage, "buttonRestoreImage");
            this.buttonRestoreImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreImage.BorderColor = System.Drawing.Color.White;
            this.buttonRestoreImage.BorderWidth = 5F;
            this.buttonRestoreImage.CornerRadius = 5;
            this.buttonRestoreImage.FlatAppearance.BorderSize = 0;
            this.buttonRestoreImage.ForeColor = System.Drawing.Color.Black;
            this.buttonRestoreImage.Name = "buttonRestoreImage";
            this.buttonRestoreImage.UseVisualStyleBackColor = false;
            this.buttonRestoreImage.Click += new System.EventHandler(this.buttonRestoreImageClick);
            // 
            // buttonImport
            // 
            resources.ApplyResources(this.buttonImport, "buttonImport");
            this.buttonImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonImport.BorderColor = System.Drawing.Color.White;
            this.buttonImport.BorderWidth = 5F;
            this.buttonImport.CornerRadius = 5;
            this.buttonImport.FlatAppearance.BorderSize = 0;
            this.buttonImport.ForeColor = System.Drawing.Color.Black;
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImportClick);
            // 
            // buttonRestoreValues
            // 
            resources.ApplyResources(this.buttonRestoreValues, "buttonRestoreValues");
            this.buttonRestoreValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreValues.BorderColor = System.Drawing.Color.White;
            this.buttonRestoreValues.BorderWidth = 5F;
            this.buttonRestoreValues.CornerRadius = 5;
            this.buttonRestoreValues.FlatAppearance.BorderSize = 0;
            this.buttonRestoreValues.ForeColor = System.Drawing.Color.Black;
            this.buttonRestoreValues.Name = "buttonRestoreValues";
            this.buttonRestoreValues.UseVisualStyleBackColor = false;
            this.buttonRestoreValues.Click += new System.EventHandler(this.buttonRestoreValuesClick);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
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
            this.buttonSave.Click += new System.EventHandler(this.buttonSaveClick);
            // 
            // buttonApply
            // 
            resources.ApplyResources(this.buttonApply, "buttonApply");
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonApply.BorderColor = System.Drawing.Color.White;
            this.buttonApply.BorderWidth = 5F;
            this.buttonApply.CornerRadius = 5;
            this.buttonApply.FlatAppearance.BorderSize = 0;
            this.buttonApply.ForeColor = System.Drawing.Color.Black;
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.UseVisualStyleBackColor = false;
            this.buttonApply.Click += new System.EventHandler(this.buttonApplyClick);
            // 
            // numericUpDownSmartSharpen
            // 
            this.numericUpDownSmartSharpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownSmartSharpen.BorderColor = System.Drawing.Color.White;
            this.numericUpDownSmartSharpen.BorderRadius = 10;
            this.numericUpDownSmartSharpen.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownSmartSharpen, "numericUpDownSmartSharpen");
            this.numericUpDownSmartSharpen.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownSmartSharpen.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownSmartSharpen.Name = "numericUpDownSmartSharpen";
            // 
            // numericUpDownReveal
            // 
            this.numericUpDownReveal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownReveal.BorderColor = System.Drawing.Color.White;
            this.numericUpDownReveal.BorderRadius = 10;
            this.numericUpDownReveal.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownReveal, "numericUpDownReveal");
            this.numericUpDownReveal.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownReveal.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownReveal.Name = "numericUpDownReveal";
            // 
            // numericUpDownBrightness
            // 
            this.numericUpDownBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownBrightness.BorderColor = System.Drawing.Color.White;
            this.numericUpDownBrightness.BorderRadius = 10;
            this.numericUpDownBrightness.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownBrightness, "numericUpDownBrightness");
            this.numericUpDownBrightness.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownBrightness.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownBrightness.Name = "numericUpDownBrightness";
            // 
            // numericUpDownContrast
            // 
            this.numericUpDownContrast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownContrast.BorderColor = System.Drawing.Color.White;
            this.numericUpDownContrast.BorderRadius = 10;
            this.numericUpDownContrast.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownContrast, "numericUpDownContrast");
            this.numericUpDownContrast.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownContrast.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownContrast.Name = "numericUpDownContrast";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // PostProcessView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBoxFilteredImage);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostProcessView";
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