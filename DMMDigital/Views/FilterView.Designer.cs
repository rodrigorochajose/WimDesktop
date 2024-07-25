namespace DMMDigital.Views
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterView));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxEditedImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.roundedPanel1 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.buttonApplyChanges = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonRestoreImage = new DMMDigital.Components.Rounded.RoundedButton();
            this.numericUpDownGamma = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownNoise = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownEdge = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownSmartSharpen = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownReveal = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownContrast = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.numericUpDownBrightness = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
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
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxOriginalImage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxEditedImage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(277, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1093, 725);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(3, 43);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(540, 679);
            this.pictureBoxOriginalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOriginalImage.TabIndex = 23;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxEditedImage
            // 
            this.pictureBoxEditedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxEditedImage.Location = new System.Drawing.Point(549, 43);
            this.pictureBoxEditedImage.Name = "pictureBoxEditedImage";
            this.pictureBoxEditedImage.Size = new System.Drawing.Size(541, 679);
            this.pictureBoxEditedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEditedImage.TabIndex = 24;
            this.pictureBoxEditedImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(758, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imagem Editada";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imagem Original";
            // 
            // buttonBack
            // 
            this.buttonBack.Image = global::DMMDigital.Properties.Resources.icon_32x32_left_arrow;
            this.buttonBack.Location = new System.Drawing.Point(12, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(46, 35);
            this.buttonBack.TabIndex = 1;
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
            this.roundedPanel1.Location = new System.Drawing.Point(2, 53);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(274, 665);
            this.roundedPanel1.TabIndex = 25;
            // 
            // buttonApplyChanges
            // 
            this.buttonApplyChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonApplyChanges.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonApplyChanges.BorderWidth = 10F;
            this.buttonApplyChanges.CornerRadius = 10;
            this.buttonApplyChanges.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.buttonApplyChanges.ForeColor = System.Drawing.Color.White;
            this.buttonApplyChanges.Location = new System.Drawing.Point(163, 605);
            this.buttonApplyChanges.Name = "buttonApplyChanges";
            this.buttonApplyChanges.Size = new System.Drawing.Size(80, 40);
            this.buttonApplyChanges.TabIndex = 73;
            this.buttonApplyChanges.Text = "Aplicar";
            this.buttonApplyChanges.UseVisualStyleBackColor = false;
            this.buttonApplyChanges.Click += new System.EventHandler(this.buttonApplyChangesClick);
            // 
            // buttonRestoreImage
            // 
            this.buttonRestoreImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreImage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRestoreImage.BorderWidth = 10F;
            this.buttonRestoreImage.CornerRadius = 10;
            this.buttonRestoreImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonRestoreImage.Location = new System.Drawing.Point(29, 605);
            this.buttonRestoreImage.Name = "buttonRestoreImage";
            this.buttonRestoreImage.Size = new System.Drawing.Size(80, 40);
            this.buttonRestoreImage.TabIndex = 72;
            this.buttonRestoreImage.Text = "Restaurar";
            this.buttonRestoreImage.UseVisualStyleBackColor = false;
            this.buttonRestoreImage.Click += new System.EventHandler(this.buttonRestoreImageClick);
            // 
            // numericUpDownGamma
            // 
            this.numericUpDownGamma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownGamma.BorderColor = System.Drawing.Color.White;
            this.numericUpDownGamma.BorderRadius = 10;
            this.numericUpDownGamma.BorderSize = 10;
            this.numericUpDownGamma.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownGamma.Location = new System.Drawing.Point(201, 324);
            this.numericUpDownGamma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.numericUpDownGamma.Size = new System.Drawing.Size(64, 39);
            this.numericUpDownGamma.TabIndex = 71;
            // 
            // numericUpDownNoise
            // 
            this.numericUpDownNoise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownNoise.BorderColor = System.Drawing.Color.White;
            this.numericUpDownNoise.BorderRadius = 10;
            this.numericUpDownNoise.BorderSize = 10;
            this.numericUpDownNoise.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownNoise.Location = new System.Drawing.Point(201, 474);
            this.numericUpDownNoise.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.numericUpDownNoise.Size = new System.Drawing.Size(64, 39);
            this.numericUpDownNoise.TabIndex = 70;
            // 
            // numericUpDownEdge
            // 
            this.numericUpDownEdge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownEdge.BorderColor = System.Drawing.Color.White;
            this.numericUpDownEdge.BorderRadius = 10;
            this.numericUpDownEdge.BorderSize = 10;
            this.numericUpDownEdge.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownEdge.Location = new System.Drawing.Point(201, 399);
            this.numericUpDownEdge.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.numericUpDownEdge.Size = new System.Drawing.Size(64, 39);
            this.numericUpDownEdge.TabIndex = 69;
            // 
            // numericUpDownSmartSharpen
            // 
            this.numericUpDownSmartSharpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownSmartSharpen.BorderColor = System.Drawing.Color.White;
            this.numericUpDownSmartSharpen.BorderRadius = 10;
            this.numericUpDownSmartSharpen.BorderSize = 10;
            this.numericUpDownSmartSharpen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownSmartSharpen.Location = new System.Drawing.Point(201, 255);
            this.numericUpDownSmartSharpen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.numericUpDownSmartSharpen.Size = new System.Drawing.Size(64, 39);
            this.numericUpDownSmartSharpen.TabIndex = 67;
            // 
            // numericUpDownReveal
            // 
            this.numericUpDownReveal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownReveal.BorderColor = System.Drawing.Color.White;
            this.numericUpDownReveal.BorderRadius = 10;
            this.numericUpDownReveal.BorderSize = 10;
            this.numericUpDownReveal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownReveal.Location = new System.Drawing.Point(201, 180);
            this.numericUpDownReveal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.numericUpDownReveal.Size = new System.Drawing.Size(64, 39);
            this.numericUpDownReveal.TabIndex = 66;
            // 
            // numericUpDownContrast
            // 
            this.numericUpDownContrast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownContrast.BorderColor = System.Drawing.Color.White;
            this.numericUpDownContrast.BorderRadius = 10;
            this.numericUpDownContrast.BorderSize = 10;
            this.numericUpDownContrast.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownContrast.Location = new System.Drawing.Point(201, 105);
            this.numericUpDownContrast.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.numericUpDownContrast.Size = new System.Drawing.Size(64, 39);
            this.numericUpDownContrast.TabIndex = 65;
            // 
            // numericUpDownBrightness
            // 
            this.numericUpDownBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDownBrightness.BorderColor = System.Drawing.Color.White;
            this.numericUpDownBrightness.BorderRadius = 10;
            this.numericUpDownBrightness.BorderSize = 10;
            this.numericUpDownBrightness.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numericUpDownBrightness.Location = new System.Drawing.Point(201, 30);
            this.numericUpDownBrightness.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
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
            this.numericUpDownBrightness.Size = new System.Drawing.Size(64, 39);
            this.numericUpDownBrightness.TabIndex = 64;
            // 
            // trackBarNoise
            // 
            this.trackBarNoise.Location = new System.Drawing.Point(27, 474);
            this.trackBarNoise.Maximum = 50;
            this.trackBarNoise.Minimum = -50;
            this.trackBarNoise.Name = "trackBarNoise";
            this.trackBarNoise.Size = new System.Drawing.Size(175, 45);
            this.trackBarNoise.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 454);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 31;
            this.label12.Text = "Noise";
            // 
            // trackBarEdge
            // 
            this.trackBarEdge.Location = new System.Drawing.Point(27, 399);
            this.trackBarEdge.Maximum = 50;
            this.trackBarEdge.Minimum = -50;
            this.trackBarEdge.Name = "trackBarEdge";
            this.trackBarEdge.Size = new System.Drawing.Size(175, 45);
            this.trackBarEdge.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 379);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 15);
            this.label11.TabIndex = 28;
            this.label11.Text = "Edge";
            // 
            // trackBarGamma
            // 
            this.trackBarGamma.Location = new System.Drawing.Point(27, 324);
            this.trackBarGamma.Maximum = 20;
            this.trackBarGamma.Minimum = -20;
            this.trackBarGamma.Name = "trackBarGamma";
            this.trackBarGamma.Size = new System.Drawing.Size(175, 45);
            this.trackBarGamma.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 304);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Gamma";
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(27, 30);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Minimum = -100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(175, 45);
            this.trackBarBrightness.TabIndex = 3;
            // 
            // checkBoxColorImage
            // 
            this.checkBoxColorImage.AutoSize = true;
            this.checkBoxColorImage.Location = new System.Drawing.Point(228, 563);
            this.checkBoxColorImage.Name = "checkBoxColorImage";
            this.checkBoxColorImage.Size = new System.Drawing.Size(15, 14);
            this.checkBoxColorImage.TabIndex = 24;
            this.checkBoxColorImage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Brilho";
            // 
            // checkBoxPositiveNegative
            // 
            this.checkBoxPositiveNegative.AutoSize = true;
            this.checkBoxPositiveNegative.Location = new System.Drawing.Point(228, 527);
            this.checkBoxPositiveNegative.Name = "checkBoxPositiveNegative";
            this.checkBoxPositiveNegative.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPositiveNegative.TabIndex = 23;
            this.checkBoxPositiveNegative.UseVisualStyleBackColor = true;
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.Location = new System.Drawing.Point(27, 105);
            this.trackBarContrast.Maximum = 100;
            this.trackBarContrast.Minimum = -100;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(175, 45);
            this.trackBarContrast.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contraste";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 562);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Colorir:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 526);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "Positivo/Negativo:";
            // 
            // trackBarReveal
            // 
            this.trackBarReveal.Location = new System.Drawing.Point(27, 180);
            this.trackBarReveal.Maximum = 15;
            this.trackBarReveal.Name = "trackBarReveal";
            this.trackBarReveal.Size = new System.Drawing.Size(175, 45);
            this.trackBarReveal.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Revelar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Smart Sharpen";
            // 
            // trackBarSmartSharpen
            // 
            this.trackBarSmartSharpen.Location = new System.Drawing.Point(27, 255);
            this.trackBarSmartSharpen.Maximum = 100;
            this.trackBarSmartSharpen.Name = "trackBarSmartSharpen";
            this.trackBarSmartSharpen.Size = new System.Drawing.Size(175, 45);
            this.trackBarSmartSharpen.TabIndex = 12;
            // 
            // FilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1370, 725);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FilterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilterView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.PictureBox pictureBoxEditedImage;
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
    }
}