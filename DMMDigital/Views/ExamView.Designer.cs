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
            this.panelDetails = new System.Windows.Forms.Panel();
            this.labelImageDate = new System.Windows.Forms.Label();
            this.textBoxFrameNotes = new System.Windows.Forms.TextBox();
            this.labelNotes = new System.Windows.Forms.Label();
            this.labelImageData = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelAnnotation = new System.Windows.Forms.Panel();
            this.labelAnnotations = new System.Windows.Forms.Label();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.labelToolOptions = new System.Windows.Forms.Label();
            this.panelToolOptions = new System.Windows.Forms.Panel();
            this.labelTemplate = new System.Windows.Forms.Label();
            this.labelPatient = new System.Windows.Forms.Label();
            this.labelTemplateName = new System.Windows.Forms.Label();
            this.labelPatientName = new System.Windows.Forms.Label();
            this.panelTools = new System.Windows.Forms.Panel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonOpenExam = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonNewExam = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCloseExam = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAcquireMode = new System.Windows.Forms.ToolStripButton();
            this.buttonAutoTake = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonImport = new System.Windows.Forms.ToolStripButton();
            this.buttonRecycleBin = new System.Windows.Forms.ToolStripButton();
            this.buttonExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonDeleteImage = new System.Windows.Forms.ToolStripButton();
            this.buttonCompareFrame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonMoveDrawing = new System.Windows.Forms.ToolStripButton();
            this.buttonSelect = new System.Windows.Forms.ToolStripButton();
            this.buttonMagnifier = new System.Windows.Forms.ToolStripButton();
            this.buttonRuler = new System.Windows.Forms.ToolStripButton();
            this.buttonUndo = new System.Windows.Forms.ToolStripButton();
            this.buttonFilter = new System.Windows.Forms.ToolStripButton();
            this.buttonRedo = new System.Windows.Forms.ToolStripButton();
            this.buttonFreeDraw = new System.Windows.Forms.ToolStripButton();
            this.buttonText = new System.Windows.Forms.ToolStripButton();
            this.buttonArrow = new System.Windows.Forms.ToolStripButton();
            this.buttonRectangle = new System.Windows.Forms.ToolStripButton();
            this.buttonEllipse = new System.Windows.Forms.ToolStripButton();
            this.buttonRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.buttonRotateRight = new System.Windows.Forms.ToolStripButton();
            this.buttonRestoreImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonFitZoom = new System.Windows.Forms.ToolStripButton();
            this.buttonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.buttonZoomSquare = new System.Windows.Forms.ToolStripButton();
            this.buttonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.dialogFileImage = new System.Windows.Forms.OpenFileDialog();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.panelImage = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.timerSensorStatus = new System.Windows.Forms.Timer(this.components);
            this.panelDetails.SuspendLayout();
            this.panelAnnotation.SuspendLayout();
            this.panelOptions.SuspendLayout();
            this.panelTools.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.panelImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTemplate
            // 
            this.panelTemplate.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.panelTemplate, "panelTemplate");
            this.panelTemplate.Name = "panelTemplate";
            // 
            // panelDetails
            // 
            resources.ApplyResources(this.panelDetails, "panelDetails");
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.Controls.Add(this.labelImageDate);
            this.panelDetails.Controls.Add(this.textBoxFrameNotes);
            this.panelDetails.Controls.Add(this.labelNotes);
            this.panelDetails.Controls.Add(this.labelImageData);
            this.panelDetails.Controls.Add(this.flowLayoutPanel1);
            this.panelDetails.Controls.Add(this.panelAnnotation);
            this.panelDetails.Controls.Add(this.panelOptions);
            this.panelDetails.Controls.Add(this.panelToolOptions);
            this.panelDetails.Controls.Add(this.labelTemplate);
            this.panelDetails.Controls.Add(this.labelPatient);
            this.panelDetails.Controls.Add(this.labelTemplateName);
            this.panelDetails.Controls.Add(this.labelPatientName);
            this.panelDetails.Controls.Add(this.panelTemplate);
            this.panelDetails.Name = "panelDetails";
            // 
            // labelImageDate
            // 
            resources.ApplyResources(this.labelImageDate, "labelImageDate");
            this.labelImageDate.Name = "labelImageDate";
            // 
            // textBoxFrameNotes
            // 
            resources.ApplyResources(this.textBoxFrameNotes, "textBoxFrameNotes");
            this.textBoxFrameNotes.Name = "textBoxFrameNotes";
            this.textBoxFrameNotes.TextChanged += new System.EventHandler(this.textBoxFrameNotesTextChanged);
            // 
            // labelNotes
            // 
            resources.ApplyResources(this.labelNotes, "labelNotes");
            this.labelNotes.Name = "labelNotes";
            // 
            // labelImageData
            // 
            resources.ApplyResources(this.labelImageData, "labelImageData");
            this.labelImageData.Name = "labelImageData";
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panelAnnotation
            // 
            this.panelAnnotation.BackColor = System.Drawing.Color.Gainsboro;
            this.panelAnnotation.Controls.Add(this.labelAnnotations);
            resources.ApplyResources(this.panelAnnotation, "panelAnnotation");
            this.panelAnnotation.Name = "panelAnnotation";
            // 
            // labelAnnotations
            // 
            resources.ApplyResources(this.labelAnnotations, "labelAnnotations");
            this.labelAnnotations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelAnnotations.Name = "labelAnnotations";
            // 
            // panelOptions
            // 
            this.panelOptions.BackColor = System.Drawing.Color.Gainsboro;
            this.panelOptions.Controls.Add(this.labelToolOptions);
            resources.ApplyResources(this.panelOptions, "panelOptions");
            this.panelOptions.Name = "panelOptions";
            // 
            // labelToolOptions
            // 
            resources.ApplyResources(this.labelToolOptions, "labelToolOptions");
            this.labelToolOptions.Name = "labelToolOptions";
            // 
            // panelToolOptions
            // 
            this.panelToolOptions.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panelToolOptions, "panelToolOptions");
            this.panelToolOptions.Name = "panelToolOptions";
            // 
            // labelTemplate
            // 
            resources.ApplyResources(this.labelTemplate, "labelTemplate");
            this.labelTemplate.Name = "labelTemplate";
            // 
            // labelPatient
            // 
            resources.ApplyResources(this.labelPatient, "labelPatient");
            this.labelPatient.Name = "labelPatient";
            // 
            // labelTemplateName
            // 
            resources.ApplyResources(this.labelTemplateName, "labelTemplateName");
            this.labelTemplateName.Name = "labelTemplateName";
            // 
            // labelPatientName
            // 
            resources.ApplyResources(this.labelPatientName, "labelPatientName");
            this.labelPatientName.Name = "labelPatientName";
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTools.Controls.Add(this.toolStrip);
            resources.ApplyResources(this.panelTools, "panelTools");
            this.panelTools.Name = "panelTools";
            // 
            // toolStrip
            // 
            this.toolStrip.AllowMerge = false;
            this.toolStrip.CanOverflow = false;
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton,
            this.toolStripSeparator1,
            this.buttonAcquireMode,
            this.buttonAutoTake,
            this.toolStripSeparator2,
            this.buttonImport,
            this.buttonRecycleBin,
            this.buttonExport,
            this.toolStripSeparator3,
            this.buttonDeleteImage,
            this.buttonCompareFrame,
            this.toolStripSeparator4,
            this.buttonMoveDrawing,
            this.buttonSelect,
            this.buttonMagnifier,
            this.buttonRuler,
            this.buttonFilter,
            this.buttonUndo,
            this.buttonRedo,
            this.buttonFreeDraw,
            this.buttonText,
            this.buttonArrow,
            this.buttonRectangle,
            this.buttonEllipse,
            this.buttonRotateLeft,
            this.buttonRotateRight,
            this.buttonRestoreImage,
            this.toolStripSeparator5,
            this.buttonFitZoom,
            this.buttonZoomOut,
            this.buttonZoomSquare,
            this.buttonZoomIn});
            this.toolStrip.Name = "toolStrip";
            // 
            // toolStripDropDownButton
            // 
            this.toolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOpenExam,
            this.buttonNewExam,
            this.buttonCloseExam});
            resources.ApplyResources(this.toolStripDropDownButton, "toolStripDropDownButton");
            this.toolStripDropDownButton.Margin = new System.Windows.Forms.Padding(5, 1, 10, 2);
            this.toolStripDropDownButton.Name = "toolStripDropDownButton";
            // 
            // buttonOpenExam
            // 
            this.buttonOpenExam.Name = "buttonOpenExam";
            resources.ApplyResources(this.buttonOpenExam, "buttonOpenExam");
            this.buttonOpenExam.Click += new System.EventHandler(this.buttonOpenExamClick);
            // 
            // buttonNewExam
            // 
            this.buttonNewExam.Name = "buttonNewExam";
            resources.ApplyResources(this.buttonNewExam, "buttonNewExam");
            this.buttonNewExam.Click += new System.EventHandler(this.buttonNewExamClick);
            // 
            // buttonCloseExam
            // 
            this.buttonCloseExam.Name = "buttonCloseExam";
            resources.ApplyResources(this.buttonCloseExam, "buttonCloseExam");
            this.buttonCloseExam.Click += new System.EventHandler(this.buttonCloseExamClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // buttonAcquireMode
            // 
            this.buttonAcquireMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAcquireMode.Image = global::DMMDigital.Properties.Resources.icon_32x32_capture;
            resources.ApplyResources(this.buttonAcquireMode, "buttonAcquireMode");
            this.buttonAcquireMode.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAcquireMode.Name = "buttonAcquireMode";
            this.buttonAcquireMode.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonAcquireMode.Click += new System.EventHandler(this.buttonAcquireModeClick);
            // 
            // buttonAutoTake
            // 
            this.buttonAutoTake.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAutoTake.Image = global::DMMDigital.Properties.Resources.icon_32x32_autotake;
            resources.ApplyResources(this.buttonAutoTake, "buttonAutoTake");
            this.buttonAutoTake.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAutoTake.Name = "buttonAutoTake";
            this.buttonAutoTake.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.buttonAutoTake.Click += new System.EventHandler(this.buttonAutoTakeClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // buttonImport
            // 
            this.buttonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonImport.Image = global::DMMDigital.Properties.Resources.icon_32x32_import;
            resources.ApplyResources(this.buttonImport, "buttonImport");
            this.buttonImport.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonImport.Click += new System.EventHandler(this.buttonImportClick);
            // 
            // buttonRecycleBin
            // 
            this.buttonRecycleBin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRecycleBin.Image = global::DMMDigital.Properties.Resources.icon_32x32_recyclebin;
            resources.ApplyResources(this.buttonRecycleBin, "buttonRecycleBin");
            this.buttonRecycleBin.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRecycleBin.Name = "buttonRecycleBin";
            this.buttonRecycleBin.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonRecycleBin.Tag = "";
            this.buttonRecycleBin.Click += new System.EventHandler(this.buttonRecycleBinClick);
            // 
            // buttonExport
            // 
            this.buttonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonExport.Image = global::DMMDigital.Properties.Resources.icon_32x32_export;
            resources.ApplyResources(this.buttonExport, "buttonExport");
            this.buttonExport.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonExport.Tag = "";
            this.buttonExport.Click += new System.EventHandler(this.buttonExportClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // buttonDeleteImage
            // 
            this.buttonDeleteImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonDeleteImage, "buttonDeleteImage");
            this.buttonDeleteImage.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.buttonDeleteImage.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonDeleteImage.Name = "buttonDeleteImage";
            this.buttonDeleteImage.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonDeleteImage.Tag = "stateChangeable";
            this.buttonDeleteImage.Click += new System.EventHandler(this.buttonDeleteClick);
            // 
            // buttonCompareFrame
            // 
            this.buttonCompareFrame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonCompareFrame, "buttonCompareFrame");
            this.buttonCompareFrame.Image = global::DMMDigital.Properties.Resources.icon_32x32_compare;
            this.buttonCompareFrame.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonCompareFrame.Name = "buttonCompareFrame";
            this.buttonCompareFrame.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonCompareFrame.Tag = "stateChangeable";
            this.buttonCompareFrame.Click += new System.EventHandler(this.buttonCompareFrameClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // buttonMoveDrawing
            // 
            this.buttonMoveDrawing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonMoveDrawing, "buttonMoveDrawing");
            this.buttonMoveDrawing.Image = global::DMMDigital.Properties.Resources.icon_32x32_move;
            this.buttonMoveDrawing.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonMoveDrawing.Name = "buttonMoveDrawing";
            this.buttonMoveDrawing.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonMoveDrawing.Tag = "stateChangeable";
            this.buttonMoveDrawing.Click += new System.EventHandler(this.buttonMoveDrawingClick);
            // 
            // buttonSelect
            // 
            this.buttonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonSelect, "buttonSelect");
            this.buttonSelect.Image = global::DMMDigital.Properties.Resources.icon_32x32_cursor;
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonSelect.Tag = "stateChangeable";
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelectClick);
            // 
            // buttonMagnifier
            // 
            this.buttonMagnifier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonMagnifier, "buttonMagnifier");
            this.buttonMagnifier.Image = global::DMMDigital.Properties.Resources.icon_32x32_search;
            this.buttonMagnifier.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonMagnifier.Name = "buttonMagnifier";
            this.buttonMagnifier.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonMagnifier.Tag = "stateChangeable";
            this.buttonMagnifier.Click += new System.EventHandler(this.buttonMagnifierClick);
            // 
            // buttonRuler
            // 
            this.buttonRuler.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonRuler, "buttonRuler");
            this.buttonRuler.Image = global::DMMDigital.Properties.Resources.icon_32x32_ruler;
            this.buttonRuler.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRuler.Name = "buttonRuler";
            this.buttonRuler.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonRuler.Tag = "stateChangeable";
            this.buttonRuler.Click += new System.EventHandler(this.buttonRulerClick);
            // 
            // buttonUndo
            // 
            this.buttonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonUndo, "buttonUndo");
            this.buttonUndo.Image = global::DMMDigital.Properties.Resources.icon_32x32_undo;
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonUndo.Tag = "stateChangeable";
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndoClick);
            // 
            // buttonFilter
            // 
            this.buttonFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonFilter, "buttonFilter");
            this.buttonFilter.Image = global::DMMDigital.Properties.Resources.icon_32x32_exposure;
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFilter.Tag = "stateChangeable";
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilterClick);
            // 
            // buttonRedo
            // 
            this.buttonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonRedo, "buttonRedo");
            this.buttonRedo.Image = global::DMMDigital.Properties.Resources.icon_32x32_redo;
            this.buttonRedo.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonRedo.Tag = "stateChangeable";
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedoClick);
            // 
            // buttonFreeDraw
            // 
            this.buttonFreeDraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonFreeDraw, "buttonFreeDraw");
            this.buttonFreeDraw.Image = global::DMMDigital.Properties.Resources.icon_32x32_pencil;
            this.buttonFreeDraw.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFreeDraw.Name = "buttonFreeDraw";
            this.buttonFreeDraw.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonFreeDraw.Tag = "stateChangeable";
            this.buttonFreeDraw.Click += new System.EventHandler(this.buttonFreeDrawClick);
            // 
            // buttonText
            // 
            this.buttonText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonText, "buttonText");
            this.buttonText.Image = global::DMMDigital.Properties.Resources.icon_32x32_text;
            this.buttonText.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonText.Name = "buttonText";
            this.buttonText.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonText.Tag = "stateChangeable";
            this.buttonText.Click += new System.EventHandler(this.buttonTextClick);
            // 
            // buttonArrow
            // 
            this.buttonArrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonArrow, "buttonArrow");
            this.buttonArrow.Image = global::DMMDigital.Properties.Resources.icon_32x32_arrow;
            this.buttonArrow.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonArrow.Name = "buttonArrow";
            this.buttonArrow.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonArrow.Tag = "stateChangeable";
            this.buttonArrow.Click += new System.EventHandler(this.buttonArrowClick);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonRectangle, "buttonRectangle");
            this.buttonRectangle.Image = global::DMMDigital.Properties.Resources.icon_32x32_rectangle;
            this.buttonRectangle.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonRectangle.Tag = "stateChangeable";
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangleDrawClick);
            // 
            // buttonEllipse
            // 
            this.buttonEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonEllipse, "buttonEllipse");
            this.buttonEllipse.Image = global::DMMDigital.Properties.Resources.icon_32x32_circle;
            this.buttonEllipse.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonEllipse.Name = "buttonEllipse";
            this.buttonEllipse.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonEllipse.Tag = "stateChangeable";
            this.buttonEllipse.Click += new System.EventHandler(this.buttonEllipseClick);
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonRotateLeft, "buttonRotateLeft");
            this.buttonRotateLeft.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_left;
            this.buttonRotateLeft.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonRotateLeft.Tag = "stateChangeable";
            this.buttonRotateLeft.Click += new System.EventHandler(this.buttonRotateLeftClick);
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonRotateRight, "buttonRotateRight");
            this.buttonRotateRight.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.buttonRotateRight.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonRotateRight.Tag = "stateChangeable";
            this.buttonRotateRight.Click += new System.EventHandler(this.buttonRotateRightClick);
            // 
            // buttonRestoreImage
            // 
            this.buttonRestoreImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonRestoreImage, "buttonRestoreImage");
            this.buttonRestoreImage.Image = global::DMMDigital.Properties.Resources.icon_32x32_reset;
            this.buttonRestoreImage.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonRestoreImage.Name = "buttonRestoreImage";
            this.buttonRestoreImage.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.buttonRestoreImage.Tag = "stateChangeable";
            this.buttonRestoreImage.Click += new System.EventHandler(this.buttonRestoreImageClick);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // buttonFitZoom
            // 
            this.buttonFitZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonFitZoom, "buttonFitZoom");
            this.buttonFitZoom.Image = global::DMMDigital.Properties.Resources.icon_16x16_fit;
            this.buttonFitZoom.Margin = new System.Windows.Forms.Padding(10, 0, 0, 2);
            this.buttonFitZoom.Name = "buttonFitZoom";
            this.buttonFitZoom.Click += new System.EventHandler(this.buttonFitZoomClick);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonZoomOut, "buttonZoomOut");
            this.buttonZoomOut.Image = global::DMMDigital.Properties.Resources.icon_16x16_zoom_out;
            this.buttonZoomOut.Margin = new System.Windows.Forms.Padding(10, 0, 3, 2);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOutClick);
            // 
            // buttonZoomSquare
            // 
            this.buttonZoomSquare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonZoomSquare, "buttonZoomSquare");
            this.buttonZoomSquare.Image = global::DMMDigital.Properties.Resources.icon_16x16_original_size;
            this.buttonZoomSquare.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.buttonZoomSquare.Name = "buttonZoomSquare";
            this.buttonZoomSquare.Click += new System.EventHandler(this.buttonZoomSquareClick);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.buttonZoomIn, "buttonZoomIn");
            this.buttonZoomIn.Image = global::DMMDigital.Properties.Resources.icon_16x16_zoom_in;
            this.buttonZoomIn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomInClick);
            // 
            // dialogFileImage
            // 
            resources.ApplyResources(this.dialogFileImage, "dialogFileImage");
            // 
            // mainPictureBox
            // 
            resources.ApplyResources(this.mainPictureBox, "mainPictureBox");
            this.mainPictureBox.BackColor = System.Drawing.Color.Black;
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPictureBoxPaint);
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainPictureBoxMouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mainPictureBoxMouseMove);
            this.mainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mainPictureBoxMouseUp);
            // 
            // panelImage
            // 
            resources.ApplyResources(this.panelImage, "panelImage");
            this.panelImage.BackColor = System.Drawing.Color.Black;
            this.panelImage.Controls.Add(this.mainPictureBox);
            this.panelImage.Name = "panelImage";
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // timerSensorStatus
            // 
            this.timerSensorStatus.Interval = 500;
            this.timerSensorStatus.Tick += new System.EventHandler(this.timerSensorStatusTick);
            // 
            // ExamView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExamView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.examViewFormClosing);
            this.Resize += new System.EventHandler(this.examViewResize);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelAnnotation.ResumeLayout(false);
            this.panelAnnotation.PerformLayout();
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.panelImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTemplate;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label labelPatientName;
        private System.Windows.Forms.Label labelTemplate;
        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.Label labelTemplateName;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.OpenFileDialog dialogFileImage;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel panelToolOptions;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label labelToolOptions;
        private Panel panelAnnotation;
        private Label labelAnnotations;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label labelNotes;
        private Label labelImageData;
        private TextBox textBoxFrameNotes;
        private Label labelImageDate;
        private ToolStrip toolStrip;
        private ToolStripDropDownButton toolStripDropDownButton;
        private ToolStripMenuItem buttonOpenExam;
        private ToolStripMenuItem buttonNewExam;
        private ToolStripMenuItem buttonCloseExam;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton buttonAcquireMode;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton buttonImport;
        private ToolStripButton buttonExport;
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
        private ToolStripButton buttonRectangle;
        private ToolStripButton buttonEllipse;
        private ToolStripButton buttonRotateLeft;
        private ToolStripButton buttonRotateRight;
        private ToolStripButton buttonRestoreImage;
        private ToolStripButton buttonFitZoom;
        private ToolStripButton buttonZoomOut;
        private ToolStripButton buttonZoomSquare;
        private ToolStripButton buttonZoomIn;
        private ToolStripSeparator toolStripSeparator5;
        private Timer timerSensorStatus;
        private ToolStripButton buttonAutoTake;
        private ToolStripButton buttonRecycleBin;
    }
}