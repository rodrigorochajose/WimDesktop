namespace DMMDigital.Views
{
    partial class MenuView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.buttonNewExam = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNewExam,
            this.buttonPatient,
            this.buttonTemplate,
            this.buttonConfig});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Name = "menuStrip1";
            // 
            // buttonNewExam
            // 
            resources.ApplyResources(this.buttonNewExam, "buttonNewExam");
            this.buttonNewExam.Image = global::DMMDigital.Properties.Resources.icon_32x32_xray_new;
            this.buttonNewExam.Name = "buttonNewExam";
            // 
            // buttonPatient
            // 
            resources.ApplyResources(this.buttonPatient, "buttonPatient");
            this.buttonPatient.Name = "buttonPatient";
            // 
            // buttonTemplate
            // 
            resources.ApplyResources(this.buttonTemplate, "buttonTemplate");
            this.buttonTemplate.Image = global::DMMDigital.Properties.Resources.icon_32x32_template;
            this.buttonTemplate.Name = "buttonTemplate";
            // 
            // buttonConfig
            // 
            resources.ApplyResources(this.buttonConfig, "buttonConfig");
            this.buttonConfig.Name = "buttonConfig";
            // 
            // MenuView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::DMMDigital.Properties.Resources.banner_principal_f3639437;
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuView";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.menuViewLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem buttonNewExam;
        private System.Windows.Forms.ToolStripMenuItem buttonPatient;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buttonConfig;
        private System.Windows.Forms.ToolStripMenuItem buttonTemplate;
    }
}