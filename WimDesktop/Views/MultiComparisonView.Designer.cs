namespace WimDesktop.Views
{
    partial class MultiComparisonView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiComparisonView));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonImportImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonImportExamImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateLeft = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRotateRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCloseAll = new System.Windows.Forms.ToolStripButton();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panelHeader.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.toolStrip1);
            resources.ApplyResources(this.panelHeader, "panelHeader");
            this.panelHeader.Name = "panelHeader";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonImportImage,
            this.toolStripButtonImportExamImage,
            this.toolStripSeparator1,
            this.toolStripButtonZoomIn,
            this.toolStripButtonZoomOut,
            this.toolStripButtonRotateLeft,
            this.toolStripButtonRotateRight,
            this.toolStripSeparator2,
            this.toolStripButtonCloseAll});
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripButtonImportImage
            // 
            this.toolStripButtonImportImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.toolStripButtonImportImage, "toolStripButtonImportImage");
            this.toolStripButtonImportImage.Image = global::WimDesktop.Properties.Resources.icon_32x32_import;
            this.toolStripButtonImportImage.Margin = new System.Windows.Forms.Padding(35, 1, 3, 1);
            this.toolStripButtonImportImage.Name = "toolStripButtonImportImage";
            this.toolStripButtonImportImage.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            // 
            // toolStripButtonImportExamImage
            // 
            this.toolStripButtonImportExamImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImportExamImage.Image = global::WimDesktop.Properties.Resources.icon_32x32_open_exam;
            resources.ApplyResources(this.toolStripButtonImportExamImage, "toolStripButtonImportExamImage");
            this.toolStripButtonImportExamImage.Margin = new System.Windows.Forms.Padding(3, 1, 45, 1);
            this.toolStripButtonImportExamImage.Name = "toolStripButtonImportExamImage";
            this.toolStripButtonImportExamImage.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripButtonZoomOut
            // 
            this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomOut.Image = global::WimDesktop.Properties.Resources.icon_32x32_zoomout;
            resources.ApplyResources(this.toolStripButtonZoomOut, "toolStripButtonZoomOut");
            this.toolStripButtonZoomOut.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
            this.toolStripButtonZoomOut.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            // 
            // toolStripButtonZoomIn
            // 
            this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomIn.Image = global::WimDesktop.Properties.Resources.icon_32x32_zoomin;
            resources.ApplyResources(this.toolStripButtonZoomIn, "toolStripButtonZoomIn");
            this.toolStripButtonZoomIn.Margin = new System.Windows.Forms.Padding(45, 1, 3, 1);
            this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
            this.toolStripButtonZoomIn.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            // 
            // toolStripButtonRotateLeft
            // 
            this.toolStripButtonRotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateLeft.Image = global::WimDesktop.Properties.Resources.icon_32x32_rotate_left;
            resources.ApplyResources(this.toolStripButtonRotateLeft, "toolStripButtonRotateLeft");
            this.toolStripButtonRotateLeft.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripButtonRotateLeft.Name = "toolStripButtonRotateLeft";
            this.toolStripButtonRotateLeft.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            // 
            // toolStripButtonRotateRight
            // 
            this.toolStripButtonRotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRotateRight.Image = global::WimDesktop.Properties.Resources.icon_32x32_rotate_right;
            resources.ApplyResources(this.toolStripButtonRotateRight, "toolStripButtonRotateRight");
            this.toolStripButtonRotateRight.Margin = new System.Windows.Forms.Padding(3, 1, 45, 1);
            this.toolStripButtonRotateRight.Name = "toolStripButtonRotateRight";
            this.toolStripButtonRotateRight.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripButtonCloseAll
            // 
            this.toolStripButtonCloseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCloseAll.Image = global::WimDesktop.Properties.Resources.icon_32x32_cancel;
            resources.ApplyResources(this.toolStripButtonCloseAll, "toolStripButtonCloseAll");
            this.toolStripButtonCloseAll.Margin = new System.Windows.Forms.Padding(110, 1, 0, 2);
            this.toolStripButtonCloseAll.Name = "toolStripButtonCloseAll";
            this.toolStripButtonCloseAll.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            // 
            // panelContent
            // 
            resources.ApplyResources(this.panelContent, "panelContent");
            this.panelContent.Controls.Add(this.pictureBox);
            this.panelContent.Name = "panelContent";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            this.openFileDialog.Multiselect = true;
            // 
            // MultiComparisonView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelHeader);
            this.Name = "MultiComparisonView";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonImportImage;
        private System.Windows.Forms.ToolStripButton toolStripButtonImportExamImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateLeft;
        private System.Windows.Forms.ToolStripButton toolStripButtonRotateRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCloseAll;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;
    }
}