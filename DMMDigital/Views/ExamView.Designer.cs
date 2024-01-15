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
            this.buttonArrow = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonRotateRight = new System.Windows.Forms.Button();
            this.buttonRotateLeft = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonEllipse = new System.Windows.Forms.Button();
            this.buttonText = new System.Windows.Forms.Button();
            this.buttonFreeDraw = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonRuler = new System.Windows.Forms.Button();
            this.buttonZoom = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.sensorConnection = new System.Windows.Forms.PictureBox();
            this.dialogFileImage = new System.Windows.Forms.OpenFileDialog();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorConnection)).BeginInit();
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
            this.panel3.Size = new System.Drawing.Size(363, 648);
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
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 465);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(363, 183);
            this.flowLayoutPanel1.TabIndex = 6;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, 435);
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
            this.panelTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTools.Controls.Add(this.buttonArrow);
            this.panelTools.Controls.Add(this.buttonMove);
            this.panelTools.Controls.Add(this.buttonRestore);
            this.panelTools.Controls.Add(this.buttonRotateRight);
            this.panelTools.Controls.Add(this.buttonRotateLeft);
            this.panelTools.Controls.Add(this.buttonRectangle);
            this.panelTools.Controls.Add(this.buttonEllipse);
            this.panelTools.Controls.Add(this.buttonText);
            this.panelTools.Controls.Add(this.buttonFreeDraw);
            this.panelTools.Controls.Add(this.buttonFilter);
            this.panelTools.Controls.Add(this.buttonRedo);
            this.panelTools.Controls.Add(this.buttonUndo);
            this.panelTools.Controls.Add(this.buttonRuler);
            this.panelTools.Controls.Add(this.buttonZoom);
            this.panelTools.Controls.Add(this.buttonSelect);
            this.panelTools.Controls.Add(this.buttonCompare);
            this.panelTools.Controls.Add(this.buttonDelete);
            this.panelTools.Controls.Add(this.buttonExport);
            this.panelTools.Controls.Add(this.buttonImport);
            this.panelTools.Controls.Add(this.sensorConnection);
            this.panelTools.Location = new System.Drawing.Point(0, 0);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(1375, 50);
            this.panelTools.TabIndex = 5;
            // 
            // buttonArrow
            // 
            this.buttonArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonArrow.Enabled = false;
            this.buttonArrow.FlatAppearance.BorderSize = 0;
            this.buttonArrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArrow.Image = global::DMMDigital.Properties.Resources.arrow;
            this.buttonArrow.Location = new System.Drawing.Point(882, 3);
            this.buttonArrow.Margin = new System.Windows.Forms.Padding(0);
            this.buttonArrow.Name = "buttonArrow";
            this.buttonArrow.Size = new System.Drawing.Size(50, 45);
            this.buttonArrow.TabIndex = 23;
            this.buttonArrow.Tag = "selectable";
            this.buttonArrow.UseVisualStyleBackColor = true;
            this.buttonArrow.Click += new System.EventHandler(this.buttonArrowClick);
            // 
            // buttonMove
            // 
            this.buttonMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMove.Enabled = false;
            this.buttonMove.FlatAppearance.BorderSize = 0;
            this.buttonMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMove.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMove.Image = global::DMMDigital.Properties.Resources.move;
            this.buttonMove.Location = new System.Drawing.Point(420, 3);
            this.buttonMove.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(50, 45);
            this.buttonMove.TabIndex = 22;
            this.buttonMove.Tag = "selectable";
            this.buttonMove.UseVisualStyleBackColor = true;
            this.buttonMove.Click += new System.EventHandler(this.buttonMoveClick);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRestore.Enabled = false;
            this.buttonRestore.FlatAppearance.BorderSize = 0;
            this.buttonRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestore.Image = global::DMMDigital.Properties.Resources.icon_32x32_reset;
            this.buttonRestore.Location = new System.Drawing.Point(1162, 3);
            this.buttonRestore.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(50, 45);
            this.buttonRestore.TabIndex = 21;
            this.buttonRestore.Tag = "";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestoreClick);
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRotateRight.Enabled = false;
            this.buttonRotateRight.FlatAppearance.BorderSize = 0;
            this.buttonRotateRight.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonRotateRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRotateRight.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.buttonRotateRight.Location = new System.Drawing.Point(1108, 3);
            this.buttonRotateRight.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Size = new System.Drawing.Size(50, 45);
            this.buttonRotateRight.TabIndex = 20;
            this.buttonRotateRight.Tag = "";
            this.buttonRotateRight.UseVisualStyleBackColor = true;
            this.buttonRotateRight.Click += new System.EventHandler(this.buttonRotateRightClick);
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRotateLeft.Enabled = false;
            this.buttonRotateLeft.FlatAppearance.BorderSize = 0;
            this.buttonRotateLeft.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonRotateLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRotateLeft.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_left;
            this.buttonRotateLeft.Location = new System.Drawing.Point(1054, 3);
            this.buttonRotateLeft.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Size = new System.Drawing.Size(50, 45);
            this.buttonRotateLeft.TabIndex = 19;
            this.buttonRotateLeft.Tag = "";
            this.buttonRotateLeft.UseVisualStyleBackColor = true;
            this.buttonRotateLeft.Click += new System.EventHandler(this.buttonRotateLeftClick);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRectangle.Enabled = false;
            this.buttonRectangle.FlatAppearance.BorderSize = 0;
            this.buttonRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRectangle.Image = global::DMMDigital.Properties.Resources.icon_32x32_rectangle;
            this.buttonRectangle.Location = new System.Drawing.Point(990, 3);
            this.buttonRectangle.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(50, 45);
            this.buttonRectangle.TabIndex = 18;
            this.buttonRectangle.Tag = "selectable";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangleDrawClick);
            // 
            // buttonEllipse
            // 
            this.buttonEllipse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEllipse.Enabled = false;
            this.buttonEllipse.FlatAppearance.BorderSize = 0;
            this.buttonEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEllipse.Image = global::DMMDigital.Properties.Resources.icon_32x32_circle;
            this.buttonEllipse.Location = new System.Drawing.Point(936, 3);
            this.buttonEllipse.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEllipse.Name = "buttonEllipse";
            this.buttonEllipse.Size = new System.Drawing.Size(50, 45);
            this.buttonEllipse.TabIndex = 17;
            this.buttonEllipse.Tag = "selectable";
            this.buttonEllipse.UseVisualStyleBackColor = true;
            this.buttonEllipse.Click += new System.EventHandler(this.buttonEllipseClick);
            // 
            // buttonText
            // 
            this.buttonText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonText.Enabled = false;
            this.buttonText.FlatAppearance.BorderSize = 0;
            this.buttonText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonText.Image = global::DMMDigital.Properties.Resources.icon_32x32_text;
            this.buttonText.Location = new System.Drawing.Point(828, 3);
            this.buttonText.Margin = new System.Windows.Forms.Padding(0);
            this.buttonText.Name = "buttonText";
            this.buttonText.Size = new System.Drawing.Size(50, 45);
            this.buttonText.TabIndex = 16;
            this.buttonText.Tag = "selectable";
            this.buttonText.UseVisualStyleBackColor = true;
            this.buttonText.Click += new System.EventHandler(this.buttonTextClick);
            // 
            // buttonFreeDraw
            // 
            this.buttonFreeDraw.AutoEllipsis = true;
            this.buttonFreeDraw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonFreeDraw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFreeDraw.Enabled = false;
            this.buttonFreeDraw.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonFreeDraw.FlatAppearance.BorderSize = 0;
            this.buttonFreeDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFreeDraw.Image = global::DMMDigital.Properties.Resources.icon_32x32_pencil2;
            this.buttonFreeDraw.Location = new System.Drawing.Point(774, 3);
            this.buttonFreeDraw.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFreeDraw.Name = "buttonFreeDraw";
            this.buttonFreeDraw.Size = new System.Drawing.Size(50, 45);
            this.buttonFreeDraw.TabIndex = 15;
            this.buttonFreeDraw.Tag = "selectable";
            this.buttonFreeDraw.UseVisualStyleBackColor = false;
            this.buttonFreeDraw.Click += new System.EventHandler(this.buttonFreeDrawClick);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFilter.Enabled = false;
            this.buttonFilter.FlatAppearance.BorderSize = 0;
            this.buttonFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilter.Image = global::DMMDigital.Properties.Resources.icon_32x32_exposure;
            this.buttonFilter.Location = new System.Drawing.Point(710, 3);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(0);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(50, 45);
            this.buttonFilter.TabIndex = 14;
            this.buttonFilter.Tag = "selectable";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilterClick);
            // 
            // buttonRedo
            // 
            this.buttonRedo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRedo.Enabled = false;
            this.buttonRedo.FlatAppearance.BorderSize = 0;
            this.buttonRedo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRedo.Image = global::DMMDigital.Properties.Resources.icon_32x32_redo;
            this.buttonRedo.Location = new System.Drawing.Point(646, 3);
            this.buttonRedo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(50, 45);
            this.buttonRedo.TabIndex = 13;
            this.buttonRedo.Tag = "";
            this.buttonRedo.UseVisualStyleBackColor = true;
            this.buttonRedo.Click += new System.EventHandler(this.buttonRedoClick);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUndo.Enabled = false;
            this.buttonUndo.FlatAppearance.BorderSize = 0;
            this.buttonUndo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUndo.Image = global::DMMDigital.Properties.Resources.icon_32x32_undo;
            this.buttonUndo.Location = new System.Drawing.Point(592, 3);
            this.buttonUndo.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(50, 45);
            this.buttonUndo.TabIndex = 12;
            this.buttonUndo.Tag = "";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.buttonUndoClick);
            // 
            // buttonRuler
            // 
            this.buttonRuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRuler.Enabled = false;
            this.buttonRuler.FlatAppearance.BorderSize = 0;
            this.buttonRuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRuler.Image = global::DMMDigital.Properties.Resources.icon_32x32_ruler;
            this.buttonRuler.Location = new System.Drawing.Point(528, 3);
            this.buttonRuler.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRuler.Name = "buttonRuler";
            this.buttonRuler.Size = new System.Drawing.Size(50, 45);
            this.buttonRuler.TabIndex = 11;
            this.buttonRuler.Tag = "selectable";
            this.buttonRuler.UseVisualStyleBackColor = true;
            this.buttonRuler.Click += new System.EventHandler(this.buttonRulerClick);
            // 
            // buttonZoom
            // 
            this.buttonZoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonZoom.Enabled = false;
            this.buttonZoom.FlatAppearance.BorderSize = 0;
            this.buttonZoom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoom.Image = global::DMMDigital.Properties.Resources.icon_32x32_search;
            this.buttonZoom.Location = new System.Drawing.Point(474, 3);
            this.buttonZoom.Margin = new System.Windows.Forms.Padding(0);
            this.buttonZoom.Name = "buttonZoom";
            this.buttonZoom.Size = new System.Drawing.Size(50, 45);
            this.buttonZoom.TabIndex = 10;
            this.buttonZoom.Tag = "selectable";
            this.buttonZoom.UseVisualStyleBackColor = true;
            this.buttonZoom.Click += new System.EventHandler(this.buttonZoomClick);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSelect.Enabled = false;
            this.buttonSelect.FlatAppearance.BorderSize = 0;
            this.buttonSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelect.Image = global::DMMDigital.Properties.Resources.icon_32x32_cursor;
            this.buttonSelect.Location = new System.Drawing.Point(366, 3);
            this.buttonSelect.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(50, 45);
            this.buttonSelect.TabIndex = 9;
            this.buttonSelect.Tag = "selectable";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelectClick);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCompare.Enabled = false;
            this.buttonCompare.FlatAppearance.BorderSize = 0;
            this.buttonCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCompare.Image = global::DMMDigital.Properties.Resources.icon_32x32_compare;
            this.buttonCompare.Location = new System.Drawing.Point(302, 3);
            this.buttonCompare.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(50, 45);
            this.buttonCompare.TabIndex = 8;
            this.buttonCompare.Tag = "selectable";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompareClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.buttonDelete.Location = new System.Drawing.Point(238, 3);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(50, 45);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Tag = "";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDeleteClick);
            // 
            // buttonExport
            // 
            this.buttonExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExport.Enabled = false;
            this.buttonExport.FlatAppearance.BorderSize = 0;
            this.buttonExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExport.Image = global::DMMDigital.Properties.Resources.icon_32x32_import;
            this.buttonExport.Location = new System.Drawing.Point(174, 2);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(50, 45);
            this.buttonExport.TabIndex = 6;
            this.buttonExport.Tag = "";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExportClick);
            // 
            // buttonImport
            // 
            this.buttonImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImport.FlatAppearance.BorderSize = 0;
            this.buttonImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Image = global::DMMDigital.Properties.Resources.icon_32x32_export;
            this.buttonImport.Location = new System.Drawing.Point(120, 2);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(0);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(50, 45);
            this.buttonImport.TabIndex = 5;
            this.buttonImport.Tag = "";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImportClick);
            // 
            // sensorConnection
            // 
            this.sensorConnection.Image = global::DMMDigital.Properties.Resources.icon_32x32_red;
            this.sensorConnection.InitialImage = ((System.Drawing.Image)(resources.GetObject("sensorConnection.InitialImage")));
            this.sensorConnection.Location = new System.Drawing.Point(0, 0);
            this.sensorConnection.Margin = new System.Windows.Forms.Padding(0);
            this.sensorConnection.Name = "sensorConnection";
            this.sensorConnection.Size = new System.Drawing.Size(64, 50);
            this.sensorConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.sensorConnection.TabIndex = 4;
            this.sensorConnection.TabStop = false;
            // 
            // dialogFileImage
            // 
            this.dialogFileImage.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(1012, 648);
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
            this.panel2.BackColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Controls.Add(this.mainPictureBox);
            this.panel2.Location = new System.Drawing.Point(363, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 648);
            this.panel2.TabIndex = 1;
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timerTick);
            // 
            // ExamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 699);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExamView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exame";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.examViewClosing);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sensorConnection)).EndInit();
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
        private System.Windows.Forms.PictureBox sensorConnection;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonRotateRight;
        private System.Windows.Forms.Button buttonRotateLeft;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonEllipse;
        private System.Windows.Forms.Button buttonText;
        private System.Windows.Forms.Button buttonFreeDraw;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRuler;
        private System.Windows.Forms.Button buttonZoom;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonArrow;
        private System.Windows.Forms.OpenFileDialog dialogFileImage;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ColorDialog colorDialog1;
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
    }
}