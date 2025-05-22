namespace WimDesktop.Views
{
    partial class FilterView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxOriginalImage = new Emgu.CV.UI.ImageBox();
            this.pictureBoxEditedImage = new Emgu.CV.UI.ImageBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.roundedPanel1 = new WimDesktop.Components.Rounded.RoundedPanel();
            this.buttonApplyChanges = new WimDesktop.Components.Rounded.RoundedButton();
            this.buttonRestoreImage = new WimDesktop.Components.Rounded.RoundedButton();
            this.numericUpDownGamma = new WimDesktop.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownNoise = new WimDesktop.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownEdge = new WimDesktop.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownSmartSharpen = new WimDesktop.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownReveal = new WimDesktop.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownContrast = new WimDesktop.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownBrightness = new WimDesktop.Components.Rounded.RoundedNumericUpDown();
            this.trackBarNoise = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.trackBarEdge = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBarGamma = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.checkBoxColorImage = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxPositiveNegative = new System.Windows.Forms.CheckBox();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.trackBarReveal = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trackBarSmartSharpen = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditedImage)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNoise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReveal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmartSharpen)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxOriginalImage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxEditedImage, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // pictureBoxOriginalImage
            // 
            resources.ApplyResources(this.pictureBoxOriginalImage, "pictureBoxOriginalImage");
            this.pictureBoxOriginalImage.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxEditedImage
            // 
            resources.ApplyResources(this.pictureBoxEditedImage, "pictureBoxEditedImage");
            this.pictureBoxEditedImage.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.pictureBoxEditedImage.Name = "pictureBoxEditedImage";
            this.pictureBoxEditedImage.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Image = global::WimDesktop.Properties.Resources.icon_32x32_left_arrow;
            resources.ApplyResources(this.buttonBack, "buttonBack");
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBackClick);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedPanel1.BorderWidth = 5F;
            this.roundedPanel1.Controls.Add(this.buttonApplyChanges);
            this.roundedPanel1.Controls.Add(this.buttonRestoreImage);
            this.roundedPanel1.Controls.Add(this.numericUpDownGamma);
            this.roundedPanel1.Controls.Add(this.numericUpDownNoise);
            this.roundedPanel1.Controls.Add(this.numericUpDownEdge);
            this.roundedPanel1.Controls.Add(this.numericUpDownSmartSharpen);
            this.roundedPanel1.Controls.Add(this.numericUpDownReveal);
            this.roundedPanel1.Controls.Add(this.numericUpDownContrast);
            this.roundedPanel1.Controls.Add(this.numericUpDownBrightness);
            this.roundedPanel1.Controls.Add(this.trackBarNoise);
            this.roundedPanel1.Controls.Add(this.label12);
            this.roundedPanel1.Controls.Add(this.trackBarEdge);
            this.roundedPanel1.Controls.Add(this.label11);
            this.roundedPanel1.Controls.Add(this.trackBarGamma);
            this.roundedPanel1.Controls.Add(this.label10);
            this.roundedPanel1.Controls.Add(this.trackBarBrightness);
            this.roundedPanel1.Controls.Add(this.checkBoxColorImage);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Controls.Add(this.checkBoxPositiveNegative);
            this.roundedPanel1.Controls.Add(this.trackBarContrast);
            this.roundedPanel1.Controls.Add(this.label4);
            this.roundedPanel1.Controls.Add(this.label9);
            this.roundedPanel1.Controls.Add(this.label8);
            this.roundedPanel1.Controls.Add(this.trackBarReveal);
            this.roundedPanel1.Controls.Add(this.label5);
            this.roundedPanel1.Controls.Add(this.label6);
            this.roundedPanel1.Controls.Add(this.trackBarSmartSharpen);
            this.roundedPanel1.CornerRadius = 20;
            resources.ApplyResources(this.roundedPanel1, "roundedPanel1");
            this.roundedPanel1.Name = "roundedPanel1";
            // 
            // buttonApplyChanges
            // 
            this.buttonApplyChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonApplyChanges.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonApplyChanges.BorderWidth = 5;
            this.buttonApplyChanges.CornerRadius = 10;
            resources.ApplyResources(this.buttonApplyChanges, "buttonApplyChanges");
            this.buttonApplyChanges.ForeColor = System.Drawing.Color.White;
            this.buttonApplyChanges.Name = "buttonApplyChanges";
            this.buttonApplyChanges.UseVisualStyleBackColor = false;
            this.buttonApplyChanges.Click += new System.EventHandler(this.buttonApplyChangesClick);
            // 
            // buttonRestoreImage
            // 
            this.buttonRestoreImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreImage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreImage.BorderWidth = 5;
            this.buttonRestoreImage.CornerRadius = 10;
            resources.ApplyResources(this.buttonRestoreImage, "buttonRestoreImage");
            this.buttonRestoreImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonRestoreImage.Name = "buttonRestoreImage";
            this.buttonRestoreImage.UseVisualStyleBackColor = false;
            this.buttonRestoreImage.Click += new System.EventHandler(this.buttonRestoreImageClick);
            // 
            // numericUpDownGamma
            // 
            this.numericUpDownGamma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownGamma.BorderColor = System.Drawing.Color.White;
            this.numericUpDownGamma.BorderRadius = 10;
            this.numericUpDownGamma.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownGamma, "numericUpDownGamma");
            this.numericUpDownGamma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownGamma.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownGamma.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.numericUpDownGamma.Name = "numericUpDownGamma";
            // 
            // numericUpDownNoise
            // 
            this.numericUpDownNoise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownNoise.BorderColor = System.Drawing.Color.White;
            this.numericUpDownNoise.BorderRadius = 10;
            this.numericUpDownNoise.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownNoise, "numericUpDownNoise");
            this.numericUpDownNoise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownNoise.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownNoise.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numericUpDownNoise.Name = "numericUpDownNoise";
            // 
            // numericUpDownEdge
            // 
            this.numericUpDownEdge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownEdge.BorderColor = System.Drawing.Color.White;
            this.numericUpDownEdge.BorderRadius = 10;
            this.numericUpDownEdge.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownEdge, "numericUpDownEdge");
            this.numericUpDownEdge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownEdge.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownEdge.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            -2147483648});
            this.numericUpDownEdge.Name = "numericUpDownEdge";
            // 
            // numericUpDownSmartSharpen
            // 
            this.numericUpDownSmartSharpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownSmartSharpen.BorderColor = System.Drawing.Color.White;
            this.numericUpDownSmartSharpen.BorderRadius = 10;
            this.numericUpDownSmartSharpen.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownSmartSharpen, "numericUpDownSmartSharpen");
            this.numericUpDownSmartSharpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.numericUpDownReveal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownReveal.Maximum = new decimal(new int[] {
            15,
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
            // numericUpDownContrast
            // 
            this.numericUpDownContrast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownContrast.BorderColor = System.Drawing.Color.White;
            this.numericUpDownContrast.BorderRadius = 10;
            this.numericUpDownContrast.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownContrast, "numericUpDownContrast");
            this.numericUpDownContrast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownContrast.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownContrast.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownContrast.Name = "numericUpDownContrast";
            // 
            // numericUpDownBrightness
            // 
            this.numericUpDownBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownBrightness.BorderColor = System.Drawing.Color.White;
            this.numericUpDownBrightness.BorderRadius = 10;
            this.numericUpDownBrightness.BorderSize = 10;
            resources.ApplyResources(this.numericUpDownBrightness, "numericUpDownBrightness");
            this.numericUpDownBrightness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownBrightness.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownBrightness.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownBrightness.Name = "numericUpDownBrightness";
            // 
            // trackBarNoise
            // 
            resources.ApplyResources(this.trackBarNoise, "trackBarNoise");
            this.trackBarNoise.Maximum = 50;
            this.trackBarNoise.Minimum = -50;
            this.trackBarNoise.Name = "trackBarNoise";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // trackBarEdge
            // 
            resources.ApplyResources(this.trackBarEdge, "trackBarEdge");
            this.trackBarEdge.Maximum = 50;
            this.trackBarEdge.Minimum = -50;
            this.trackBarEdge.Name = "trackBarEdge";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // trackBarGamma
            // 
            resources.ApplyResources(this.trackBarGamma, "trackBarGamma");
            this.trackBarGamma.Maximum = 20;
            this.trackBarGamma.Minimum = -20;
            this.trackBarGamma.Name = "trackBarGamma";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // trackBarBrightness
            // 
            resources.ApplyResources(this.trackBarBrightness, "trackBarBrightness");
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Minimum = -100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            // 
            // checkBoxColorImage
            // 
            resources.ApplyResources(this.checkBoxColorImage, "checkBoxColorImage");
            this.checkBoxColorImage.Name = "checkBoxColorImage";
            this.checkBoxColorImage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // checkBoxPositiveNegative
            // 
            resources.ApplyResources(this.checkBoxPositiveNegative, "checkBoxPositiveNegative");
            this.checkBoxPositiveNegative.Name = "checkBoxPositiveNegative";
            this.checkBoxPositiveNegative.UseVisualStyleBackColor = true;
            // 
            // trackBarContrast
            // 
            resources.ApplyResources(this.trackBarContrast, "trackBarContrast");
            this.trackBarContrast.Maximum = 100;
            this.trackBarContrast.Minimum = -100;
            this.trackBarContrast.Name = "trackBarContrast";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // trackBarReveal
            // 
            resources.ApplyResources(this.trackBarReveal, "trackBarReveal");
            this.trackBarReveal.Maximum = 15;
            this.trackBarReveal.Name = "trackBarReveal";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // trackBarSmartSharpen
            // 
            resources.ApplyResources(this.trackBarSmartSharpen, "trackBarSmartSharpen");
            this.trackBarSmartSharpen.Maximum = 100;
            this.trackBarSmartSharpen.Name = "trackBarSmartSharpen";
            // 
            // FilterView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FilterView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.filterViewFormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditedImage)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarNoise)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarGamma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReveal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSmartSharpen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarReveal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackBarSmartSharpen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxPositiveNegative;
        private System.Windows.Forms.CheckBox checkBoxColorImage;
        private Components.Rounded.RoundedPanel roundedPanel1;
        private System.Windows.Forms.TrackBar trackBarNoise;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trackBarEdge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBarGamma;
        private System.Windows.Forms.Label label10;
        private Components.Rounded.RoundedNumericUpDown numericUpDownBrightness;
        private Components.Rounded.RoundedNumericUpDown numericUpDownNoise;
        private Components.Rounded.RoundedNumericUpDown numericUpDownEdge;
        private Components.Rounded.RoundedNumericUpDown numericUpDownSmartSharpen;
        private Components.Rounded.RoundedNumericUpDown numericUpDownReveal;
        private Components.Rounded.RoundedNumericUpDown numericUpDownContrast;
        private Components.Rounded.RoundedNumericUpDown numericUpDownGamma;
        private Components.Rounded.RoundedButton buttonApplyChanges;
        private Components.Rounded.RoundedButton buttonRestoreImage;
        private Emgu.CV.UI.ImageBox pictureBoxOriginalImage;
        private Emgu.CV.UI.ImageBox pictureBoxEditedImage;
    }
}