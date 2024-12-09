namespace DMMDigital.Views
{
    partial class FramesComparisonView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FramesComparisonView));
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
            this.buttonImportExamImage = new System.Windows.Forms.Button();
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
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.Image = global::DMMDigital.Properties.Resources.icon_32x32_cancel;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonBack
            // 
            this.buttonBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonBack, "buttonBack");
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.Image = global::DMMDigital.Properties.Resources.icon_32x32_left_arrow;
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // panelTools
            // 
            this.panelTools.BackColor = System.Drawing.Color.White;
            this.panelTools.Controls.Add(this.buttonImportExamImage);
            this.panelTools.Controls.Add(this.buttonRotate);
            this.panelTools.Controls.Add(this.trackBarOpacity);
            this.panelTools.Controls.Add(this.labelOpacity);
            this.panelTools.Controls.Add(this.buttonImportImage);
            this.panelTools.Controls.Add(this.buttonChangeSides);
            this.panelTools.Controls.Add(this.buttonOverlay);
            resources.ApplyResources(this.panelTools, "panelTools");
            this.panelTools.Name = "panelTools";
            // 
            // buttonRotate
            // 
            resources.ApplyResources(this.buttonRotate, "buttonRotate");
            this.buttonRotate.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotateClick);
            // 
            // trackBarOpacity
            // 
            resources.ApplyResources(this.trackBarOpacity, "trackBarOpacity");
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacityScroll);
            // 
            // labelOpacity
            // 
            resources.ApplyResources(this.labelOpacity, "labelOpacity");
            this.labelOpacity.Name = "labelOpacity";
            // 
            // buttonImportImage
            // 
            resources.ApplyResources(this.buttonImportImage, "buttonImportImage");
            this.buttonImportImage.Image = global::DMMDigital.Properties.Resources.icon_32x32_import;
            this.buttonImportImage.Name = "buttonImportImage";
            this.buttonImportImage.UseVisualStyleBackColor = true;
            this.buttonImportImage.Click += new System.EventHandler(this.buttonImportImageClick);
            // 
            // buttonChangeSides
            // 
            resources.ApplyResources(this.buttonChangeSides, "buttonChangeSides");
            this.buttonChangeSides.Image = global::DMMDigital.Properties.Resources.icon_32x32_change_sides;
            this.buttonChangeSides.Name = "buttonChangeSides";
            this.buttonChangeSides.UseVisualStyleBackColor = true;
            this.buttonChangeSides.Click += new System.EventHandler(this.buttonChangeSidesClick);
            // 
            // buttonOverlay
            // 
            resources.ApplyResources(this.buttonOverlay, "buttonOverlay");
            this.buttonOverlay.Image = global::DMMDigital.Properties.Resources.icon_32x32_compare_overlap;
            this.buttonOverlay.Name = "buttonOverlay";
            this.buttonOverlay.UseVisualStyleBackColor = true;
            this.buttonOverlay.Click += new System.EventHandler(this.buttonOverlayClick);
            // 
            // dialogFileImage
            // 
            resources.ApplyResources(this.dialogFileImage, "dialogFileImage");
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // buttonImportExamImage
            // 
            resources.ApplyResources(this.buttonImportExamImage, "buttonImportExamImage");
            this.buttonImportExamImage.Image = global::DMMDigital.Properties.Resources.icon_32x32_import;
            this.buttonImportExamImage.Name = "buttonImportExamImage";
            this.buttonImportExamImage.UseVisualStyleBackColor = true;
            this.buttonImportExamImage.Click += new System.EventHandler(this.buttonImportExamImageClick);
            // 
            // FramesComparisonView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.panelTools);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FramesComparisonView";
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
        private System.Windows.Forms.Button buttonImportExamImage;
    }
}