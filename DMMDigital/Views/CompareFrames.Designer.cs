namespace DMMDigital.Views
{
    partial class CompareFrames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareFrames));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelTools = new System.Windows.Forms.Panel();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.buttonImportImage = new System.Windows.Forms.Button();
            this.buttonChangeSides = new System.Windows.Forms.Button();
            this.buttonOverlay = new System.Windows.Forms.Button();
            this.dialogFileImage = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1375, 41);
            this.panel1.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = global::DMMDigital.Properties.Resources.icon_32x32_cancel;
            this.buttonClose.Location = new System.Drawing.Point(1333, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(42, 41);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonCloseClick);
            // 
            // buttonBack
            // 
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = global::DMMDigital.Properties.Resources.icon_32x32_left_arrow;
            this.buttonBack.Location = new System.Drawing.Point(0, 0);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(42, 41);
            this.buttonBack.TabIndex = 4;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBackClick);
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.White;
            this.panelTools.Controls.Add(this.buttonRotate);
            this.panelTools.Controls.Add(this.trackBarOpacity);
            this.panelTools.Controls.Add(this.labelOpacity);
            this.panelTools.Controls.Add(this.buttonImportImage);
            this.panelTools.Controls.Add(this.buttonChangeSides);
            this.panelTools.Controls.Add(this.buttonOverlay);
            this.panelTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTools.Location = new System.Drawing.Point(0, 609);
            this.panelTools.Name = "panelTools";
            this.panelTools.Size = new System.Drawing.Size(1375, 59);
            this.panelTools.TabIndex = 2;
            this.panelTools.Visible = false;
            // 
            // buttonRotate
            // 
            this.buttonRotate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRotate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonRotate.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.buttonRotate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRotate.Location = new System.Drawing.Point(709, 7);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(80, 44);
            this.buttonRotate.TabIndex = 8;
            this.buttonRotate.Text = "Girar";
            this.buttonRotate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotateClick);
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trackBarOpacity.Location = new System.Drawing.Point(998, 13);
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(192, 45);
            this.trackBarOpacity.TabIndex = 11;
            this.trackBarOpacity.Visible = false;
            // 
            // labelOpacity
            // 
            this.labelOpacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelOpacity.Location = new System.Drawing.Point(925, 21);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(67, 15);
            this.labelOpacity.TabIndex = 10;
            this.labelOpacity.Text = "Opacidade:";
            this.labelOpacity.Visible = false;
            // 
            // buttonImportImage
            // 
            this.buttonImportImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonImportImage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonImportImage.Image = global::DMMDigital.Properties.Resources.icon_32x32_export;
            this.buttonImportImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImportImage.Location = new System.Drawing.Point(411, 8);
            this.buttonImportImage.Name = "buttonImportImage";
            this.buttonImportImage.Size = new System.Drawing.Size(147, 44);
            this.buttonImportImage.TabIndex = 9;
            this.buttonImportImage.Text = "Importar Imagem";
            this.buttonImportImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonImportImage.UseVisualStyleBackColor = true;
            this.buttonImportImage.Click += new System.EventHandler(this.buttonImportImageClick);
            // 
            // buttonChangeSides
            // 
            this.buttonChangeSides.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonChangeSides.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonChangeSides.Image = global::DMMDigital.Properties.Resources.icon_32x32_change_sides;
            this.buttonChangeSides.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonChangeSides.Location = new System.Drawing.Point(578, 7);
            this.buttonChangeSides.Name = "buttonChangeSides";
            this.buttonChangeSides.Size = new System.Drawing.Size(111, 44);
            this.buttonChangeSides.TabIndex = 7;
            this.buttonChangeSides.Text = "Trocar Lados";
            this.buttonChangeSides.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonChangeSides.UseVisualStyleBackColor = true;
            this.buttonChangeSides.Click += new System.EventHandler(this.buttonChangeSidesClick);
            // 
            // buttonOverlay
            // 
            this.buttonOverlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOverlay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonOverlay.Image = global::DMMDigital.Properties.Resources.icon_32x32_compare_overlap;
            this.buttonOverlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOverlay.Location = new System.Drawing.Point(809, 7);
            this.buttonOverlay.Name = "buttonOverlay";
            this.buttonOverlay.Size = new System.Drawing.Size(96, 44);
            this.buttonOverlay.TabIndex = 6;
            this.buttonOverlay.Text = "Sobrepor";
            this.buttonOverlay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOverlay.UseVisualStyleBackColor = true;
            this.buttonOverlay.Click += new System.EventHandler(this.buttonOverlayClick);
            // 
            // dialogFileImage
            // 
            this.dialogFileImage.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 41);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(1375, 568);
            this.tableLayoutPanel.TabIndex = 6;
            // 
            // CompareFrames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 668);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompareFrames";
            this.Text = "Comparar Filmes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.compareFramesLoad);
            this.panel1.ResumeLayout(false);
            this.panelTools.ResumeLayout(false);
            this.panelTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Panel panelTools;
        private System.Windows.Forms.Button buttonOverlay;
        private System.Windows.Forms.Button buttonImportImage;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.Button buttonChangeSides;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.OpenFileDialog dialogFileImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
}