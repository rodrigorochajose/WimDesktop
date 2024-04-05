using System.Windows.Forms;

namespace DMMDigital.Views
{
    partial class ExamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamView));
            this.panelTemplate = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelImageDate = new System.Windows.Forms.Label();
            this.textBoxFrameNotes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelToolOptions = new System.Windows.Forms.Panel();
            this.labelTemplate = new System.Windows.Forms.Label();
            this.labelPatient = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTools = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonOpenExam = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNewExam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.detectorConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonImport = new System.Windows.Forms.ToolStripButton();
            this.buttonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonDeleteImage = new System.Windows.Forms.ToolStripButton();
            this.buttonCompareFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonSelect = new System.Windows.Forms.ToolStripButton();
            this.buttonMoveDrawing = new System.Windows.Forms.ToolStripButton();
            this.buttonMagnifier = new System.Windows.Forms.ToolStripButton();
            this.buttonRuler = new System.Windows.Forms.ToolStripButton();
            this.buttonUndo = new System.Windows.Forms.ToolStripButton();
            this.buttonRedo = new System.Windows.Forms.ToolStripButton();
            this.buttonFilter = new System.Windows.Forms.ToolStripButton();
            this.buttonFreeDraw = new System.Windows.Forms.ToolStripButton();
            this.buttonText = new System.Windows.Forms.ToolStripButton();
            this.buttonArrow = new System.Windows.Forms.ToolStripButton();
            this.buttonRectangle = new System.Windows.Forms.ToolStripButton();
            this.buttonEllipse = new System.Windows.Forms.ToolStripButton();
            this.buttonRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.buttonRotateRight = new System.Windows.Forms.ToolStripButton();
            this.buttonRestoreExam = new System.Windows.Forms.ToolStripButton();
            this.dialogFileImage = new System.Windows.Forms.OpenFileDialog();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelTools.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTemplate
            // 
            this.panelTemplate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTemplate.Location = new System.Drawing.Point(0, 55);
            this.panelTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.panelTemplate.Name = "panelTemplate";
            this.panelTemplate.Size = new System.Drawing.Size(363, 185);
            this.panelTemplate.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.labelImageDate);
            this.panel3.Controls.Add(this.textBoxFrameNotes);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panelToolOptions);
            this.panel3.Controls.Add(this.labelTemplate);
            this.panel3.Controls.Add(this.labelPatient);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panelTemplate);
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(363, 619);
            this.panel3.TabIndex = 0;
            // 
            // labelImageDate
            // 
            this.labelImageDate.AutoSize = true;
            this.labelImageDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageDate.Location = new System.Drawing.Point(111, 248);
            this.labelImageDate.Name = "labelImageDate";
            this.labelImageDate.Size = new System.Drawing.Size(0, 15);
            this.labelImageDate.TabIndex = 9;
            // 
            // textBoxFrameNotes
            // 
            this.textBoxFrameNotes.Location = new System.Drawing.Point(11, 294);
            this.textBoxFrameNotes.Multiline = true;
            this.textBoxFrameNotes.Name = "textBoxFrameNotes";
            this.textBoxFrameNotes.Size = new System.Drawing.Size(330, 43);
            this.textBoxFrameNotes.TabIndex = 0;
            this.textBoxFrameNotes.TextChanged += new System.EventHandler(this.textBoxFrameNotesTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 274);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Observações";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 248);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Data da Imagem:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 464);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(363, 156);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 434);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(363, 29);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Anotações";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(0, 347);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(363, 29);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(12, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Opções da Ferramenta";
            // 
            // panelToolOptions
            // 
            this.panelToolOptions.BackColor = System.Drawing.Color.White;
            this.panelToolOptions.Location = new System.Drawing.Point(0, 376);
            this.panelToolOptions.Name = "panelToolOptions";
            this.panelToolOptions.Size = new System.Drawing.Size(363, 58);
            this.panelToolOptions.TabIndex = 4;
            // 
            // labelTemplate
            // 
            this.labelTemplate.AutoSize = true;
            this.labelTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemplate.Location = new System.Drawing.Point(80, 32);
            this.labelTemplate.Name = "labelTemplate";
            this.labelTemplate.Size = new System.Drawing.Size(113, 15);
            this.labelTemplate.TabIndex = 3;
            this.labelTemplate.Text = "Nome do Template";
            // 
            // labelPatient
            // 
            this.labelPatient.AutoSize = true;
            this.labelPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPatient.Location = new System.Drawing.Point(80, 9);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(109, 15);
            this.labelPatient.TabIndex = 2;
            this.labelPatient.Text = "Nome do Paciente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 31);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Template:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Paciente:";
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTools.Controls.Add(this.toolStrip);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(1375, 50);
            this.panelTools.TabIndex = 5;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton,
            this.toolStripSeparator1,
            this.detectorConnection,
            this.toolStripSeparator2,
            this.buttonImport,
            this.buttonExport,
            this.toolStripSeparator3,
            this.buttonDeleteImage,
            this.buttonCompareFrame,
            this.toolStripSeparator4,
            this.buttonSelect,
            this.buttonMoveDrawing,
            this.buttonMagnifier,
            this.buttonRuler,
            this.buttonUndo,
            this.buttonRedo,
            this.buttonFilter,
            this.buttonFreeDraw,
            this.buttonText,
            this.buttonArrow,
            this.buttonRectangle,
            this.buttonEllipse,
            this.buttonRotateLeft,
            this.buttonRotateRight,
            this.buttonRestoreExam});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.toolStrip.Size = new System.Drawing.Size(1375, 50);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolStripDropDownButton
            // 
            this.toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOpenExam,
            this.buttonNewExam});
            this.toolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton.Image")));
            this.toolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton.Margin = new System.Windows.Forms.Padding(2, 1, 2, 2);
            this.toolStripDropDownButton.Name = "toolStripDropDownButton";
            this.toolStripDropDownButton.Size = new System.Drawing.Size(59, 39);
            this.toolStripDropDownButton.Text = "Exame";
            // 
            // buttonOpenExam
            // 
            this.buttonOpenExam.Name = "buttonOpenExam";
            this.buttonOpenExam.Size = new System.Drawing.Size(150, 22);
            this.buttonOpenExam.Text = "Abrir Exame";
            this.buttonOpenExam.Click += new System.EventHandler(this.buttonOpenExamClick);
            // 
            // buttonNewExam
            // 
            this.buttonNewExam.Name = "buttonNewExam";
            this.buttonNewExam.Size = new System.Drawing.Size(150, 22);
            this.buttonNewExam.Text = "Novo Exame";
            this.buttonNewExam.Click += new System.EventHandler(this.buttonNewExamClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // detectorConnection
            // 
            this.detectorConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.detectorConnection.Image = global::DMMDigital.Properties.Resources.icon_32x32_red;
            this.detectorConnection.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detectorConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.detectorConnection.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.detectorConnection.Name = "detectorConnection";
            this.detectorConnection.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.detectorConnection.Size = new System.Drawing.Size(50, 40);
            this.detectorConnection.Text = "detectorConnection";
            this.detectorConnection.ToolTipText = "Sensor não localizado";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // buttonImport
            // 
            this.buttonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonImport.Image = global::DMMDigital.Properties.Resources.icon_32x32_export;
            this.buttonImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonImport.Size = new System.Drawing.Size(50, 40);
            this.buttonImport.Text = "buttonImport";
            this.buttonImport.ToolTipText = "Importar Imagem";
            this.buttonImport.Click += new System.EventHandler(this.buttonImportClick);
            // 
            // buttonExport
            // 
            this.buttonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExport.Enabled = false;
            this.buttonExport.Image = global::DMMDigital.Properties.Resources.icon_32x32_import;
            this.buttonExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonExport.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonExport.Size = new System.Drawing.Size(50, 40);
            this.buttonExport.Text = "buttonExport";
            this.buttonExport.ToolTipText = "Exportar Exame";
            this.buttonExport.Click += new System.EventHandler(this.buttonExportClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // buttonDeleteImage
            // 
            this.buttonDeleteImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonDeleteImage.Enabled = false;
            this.buttonDeleteImage.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.buttonDeleteImage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonDeleteImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonDeleteImage.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonDeleteImage.Name = "buttonDeleteImage";
            this.buttonDeleteImage.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonDeleteImage.Size = new System.Drawing.Size(50, 40);
            this.buttonDeleteImage.Text = "buttonDeleteImage";
            this.buttonDeleteImage.ToolTipText = "Excluir Imagem";
            this.buttonDeleteImage.Click += new System.EventHandler(this.buttonDeleteClick);
            // 
            // buttonCompareFrame
            // 
            this.buttonCompareFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonCompareFrame.Enabled = false;
            this.buttonCompareFrame.Image = global::DMMDigital.Properties.Resources.icon_32x32_compare;
            this.buttonCompareFrame.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonCompareFrame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonCompareFrame.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonCompareFrame.Name = "buttonCompareFrame";
            this.buttonCompareFrame.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonCompareFrame.Size = new System.Drawing.Size(50, 40);
            this.buttonCompareFrame.Text = "buttonCompareFrame";
            this.buttonCompareFrame.ToolTipText = "Comparar Imagens";
            this.buttonCompareFrame.Click += new System.EventHandler(this.buttonCompareFrameClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
            // 
            // buttonSelect
            // 
            this.buttonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSelect.Enabled = false;
            this.buttonSelect.Image = global::DMMDigital.Properties.Resources.icon_32x32_cursor;
            this.buttonSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonSelect.Size = new System.Drawing.Size(50, 40);
            this.buttonSelect.Text = "buttonSelect";
            this.buttonSelect.ToolTipText = "Selecionar";
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelectClick);
            // 
            // buttonMoveDrawing
            // 
            this.buttonMoveDrawing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMoveDrawing.Enabled = false;
            this.buttonMoveDrawing.Image = global::DMMDigital.Properties.Resources.icon_32x32_move;
            this.buttonMoveDrawing.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonMoveDrawing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMoveDrawing.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonMoveDrawing.Name = "buttonMoveDrawing";
            this.buttonMoveDrawing.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonMoveDrawing.Size = new System.Drawing.Size(50, 40);
            this.buttonMoveDrawing.Text = "buttonMoveDrawing";
            this.buttonMoveDrawing.ToolTipText = "Mover";
            this.buttonMoveDrawing.Click += new System.EventHandler(this.buttonMoveDrawingClick);
            // 
            // buttonMagnifier
            // 
            this.buttonMagnifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonMagnifier.Enabled = false;
            this.buttonMagnifier.Image = global::DMMDigital.Properties.Resources.icon_32x32_search;
            this.buttonMagnifier.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonMagnifier.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonMagnifier.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonMagnifier.Name = "buttonMagnifier";
            this.buttonMagnifier.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonMagnifier.Size = new System.Drawing.Size(50, 40);
            this.buttonMagnifier.Text = "buttonMagnifier";
            this.buttonMagnifier.ToolTipText = "Lupa";
            this.buttonMagnifier.Click += new System.EventHandler(this.buttonMagnifierClick);
            // 
            // buttonRuler
            // 
            this.buttonRuler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRuler.Enabled = false;
            this.buttonRuler.Image = global::DMMDigital.Properties.Resources.icon_32x32_ruler;
            this.buttonRuler.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRuler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRuler.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRuler.Name = "buttonRuler";
            this.buttonRuler.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonRuler.Size = new System.Drawing.Size(50, 40);
            this.buttonRuler.Text = "buttonRuler";
            this.buttonRuler.ToolTipText = "Régua";
            this.buttonRuler.Click += new System.EventHandler(this.buttonRulerClick);
            // 
            // buttonUndo
            // 
            this.buttonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonUndo.Enabled = false;
            this.buttonUndo.Image = global::DMMDigital.Properties.Resources.icon_32x32_undo;
            this.buttonUndo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonUndo.Size = new System.Drawing.Size(50, 40);
            this.buttonUndo.Text = "buttonUndo";
            this.buttonUndo.ToolTipText = "Desfazer";
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndoClick);
            // 
            // buttonRedo
            // 
            this.buttonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRedo.Enabled = false;
            this.buttonRedo.Image = global::DMMDigital.Properties.Resources.icon_32x32_redo;
            this.buttonRedo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRedo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonRedo.Size = new System.Drawing.Size(50, 40);
            this.buttonRedo.Text = "buttonRedo";
            this.buttonRedo.ToolTipText = "Refazer";
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedoClick);
            // 
            // buttonFilter
            // 
            this.buttonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonFilter.Enabled = false;
            this.buttonFilter.Image = global::DMMDigital.Properties.Resources.icon_32x32_exposure;
            this.buttonFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonFilter.Size = new System.Drawing.Size(50, 40);
            this.buttonFilter.Text = "buttonFilter";
            this.buttonFilter.ToolTipText = "Filtro";
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilterClick);
            // 
            // buttonFreeDraw
            // 
            this.buttonFreeDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonFreeDraw.Enabled = false;
            this.buttonFreeDraw.Image = global::DMMDigital.Properties.Resources.icon_32x32_pencil;
            this.buttonFreeDraw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonFreeDraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonFreeDraw.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFreeDraw.Name = "buttonFreeDraw";
            this.buttonFreeDraw.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonFreeDraw.Size = new System.Drawing.Size(50, 40);
            this.buttonFreeDraw.Text = "buttonFreeDraw";
            this.buttonFreeDraw.ToolTipText = "Desenho Livre";
            this.buttonFreeDraw.Click += new System.EventHandler(this.buttonFreeDrawClick);
            // 
            // buttonText
            // 
            this.buttonText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonText.Enabled = false;
            this.buttonText.Image = global::DMMDigital.Properties.Resources.icon_32x32_text;
            this.buttonText.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonText.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonText.Name = "buttonText";
            this.buttonText.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonText.Size = new System.Drawing.Size(50, 40);
            this.buttonText.Text = "buttonText";
            this.buttonText.ToolTipText = "Texto";
            this.buttonText.Click += new System.EventHandler(this.buttonTextClick);
            // 
            // buttonArrow
            // 
            this.buttonArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonArrow.Enabled = false;
            this.buttonArrow.Image = global::DMMDigital.Properties.Resources.icon_32x32_arrow;
            this.buttonArrow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonArrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonArrow.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonArrow.Name = "buttonArrow";
            this.buttonArrow.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonArrow.Size = new System.Drawing.Size(50, 40);
            this.buttonArrow.Text = "buttonArrow";
            this.buttonArrow.ToolTipText = "Seta";
            this.buttonArrow.Click += new System.EventHandler(this.buttonArrowClick);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRectangle.Enabled = false;
            this.buttonRectangle.Image = global::DMMDigital.Properties.Resources.icon_32x32_rectangle;
            this.buttonRectangle.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRectangle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonRectangle.Size = new System.Drawing.Size(50, 40);
            this.buttonRectangle.Text = "buttonRectangle";
            this.buttonRectangle.ToolTipText = "Retângulo";
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangleDrawClick);
            // 
            // buttonEllipse
            // 
            this.buttonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonEllipse.Enabled = false;
            this.buttonEllipse.Image = global::DMMDigital.Properties.Resources.icon_32x32_circle;
            this.buttonEllipse.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonEllipse.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonEllipse.Name = "buttonEllipse";
            this.buttonEllipse.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonEllipse.Size = new System.Drawing.Size(50, 40);
            this.buttonEllipse.Text = "buttonEllipse";
            this.buttonEllipse.ToolTipText = "Círculo";
            this.buttonEllipse.Click += new System.EventHandler(this.buttonEllipseClick);
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRotateLeft.Enabled = false;
            this.buttonRotateLeft.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_left;
            this.buttonRotateLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRotateLeft.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonRotateLeft.Size = new System.Drawing.Size(50, 40);
            this.buttonRotateLeft.Text = "buttonRotateLeft";
            this.buttonRotateLeft.ToolTipText = "Girar à Esquerda";
            this.buttonRotateLeft.Click += new System.EventHandler(this.buttonRotateLeftClick);
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRotateRight.Enabled = false;
            this.buttonRotateRight.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.buttonRotateRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRotateRight.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonRotateRight.Size = new System.Drawing.Size(50, 40);
            this.buttonRotateRight.Text = "buttonRotateRight";
            this.buttonRotateRight.ToolTipText = "Girar à Direita";
            this.buttonRotateRight.Click += new System.EventHandler(this.buttonRotateRightClick);
            // 
            // buttonRestoreExam
            // 
            this.buttonRestoreExam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRestoreExam.Enabled = false;
            this.buttonRestoreExam.Image = global::DMMDigital.Properties.Resources.icon_32x32_reset;
            this.buttonRestoreExam.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonRestoreExam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRestoreExam.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRestoreExam.Name = "buttonRestoreExam";
            this.buttonRestoreExam.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonRestoreExam.Size = new System.Drawing.Size(50, 40);
            this.buttonRestoreExam.Text = "buttonRestoreExam";
            this.buttonRestoreExam.ToolTipText = "Restaurar Exame";
            this.buttonRestoreExam.Click += new System.EventHandler(this.buttonRestoreExamClick);
            // 
            // dialogFileImage
            // 
            this.dialogFileImage.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(1012, 619);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBoxPaint);
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBoxMouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBoxMouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBoxMouseUp);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.mainPictureBox);
            this.panel2.Location = new System.Drawing.Point(363, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 619);
            this.panel2.TabIndex = 1;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timerTick);
            // 
            // ExamView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1375, 668);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExamView";
            this.Text = "Exame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.examViewFormClosing);
            this.Resize += new System.EventHandler(this.examViewResize);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTemplate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTemplate;
        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.OpenFileDialog dialogFileImage;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel panelToolOptions;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private Panel panel1;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label6;
        private Label label5;
        private TextBox textBoxFrameNotes;
        private Label labelImageDate;
        private Timer timer1;
        private ToolStrip toolStrip;
        private ToolStripDropDownButton toolStripDropDownButton;
        private ToolStripMenuItem buttonOpenExam;
        private ToolStripMenuItem buttonNewExam;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton detectorConnection;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton buttonExport;
        private ToolStripButton buttonImport;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton buttonDeleteImage;
        private ToolStripButton buttonCompareFrame;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton buttonSelect;
        private ToolStripButton buttonMoveDrawing;
        private ToolStripButton buttonMagnifier;
        private ToolStripButton buttonRuler;
        private ToolStripButton buttonUndo;
        private ToolStripButton buttonRedo;
        private ToolStripButton buttonFilter;
        private ToolStripButton buttonFreeDraw;
        private ToolStripButton buttonText;
        private ToolStripButton buttonArrow;
        private ToolStripButton buttonEllipse;
        private ToolStripButton buttonRectangle;
        private ToolStripButton buttonRotateLeft;
        private ToolStripButton buttonRotateRight;
        private ToolStripButton buttonRestoreExam;
    }
}