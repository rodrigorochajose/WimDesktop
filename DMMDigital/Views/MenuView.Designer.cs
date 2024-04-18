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
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNewExam,
            this.buttonPatient,
            this.buttonTemplate,
            this.buttonConfig});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.menuStrip1.Size = new System.Drawing.Size(919, 56);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // buttonNewExam
            // 
            this.buttonNewExam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonNewExam.Image = ((System.Drawing.Image)(resources.GetObject("buttonNewExam.Image")));
            this.buttonNewExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewExam.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonNewExam.Name = "buttonNewExam";
            this.buttonNewExam.Size = new System.Drawing.Size(151, 36);
            this.buttonNewExam.Text = "Novo Exame";
            // 
            // buttonPatient
            // 
            this.buttonPatient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonPatient.Image = ((System.Drawing.Image)(resources.GetObject("buttonPatient.Image")));
            this.buttonPatient.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonPatient.Name = "buttonPatient";
            this.buttonPatient.Size = new System.Drawing.Size(127, 36);
            this.buttonPatient.Text = "Pacientes";
            // 
            // buttonTemplate
            // 
            this.buttonTemplate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonTemplate.Image = global::DMMDigital.Properties.Resources.icon_32x32_template;
            this.buttonTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonTemplate.Name = "buttonTemplate";
            this.buttonTemplate.Size = new System.Drawing.Size(125, 36);
            this.buttonTemplate.Text = "Template";
            // 
            // buttonConfig
            // 
            this.buttonConfig.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonConfig.Image = ((System.Drawing.Image)(resources.GetObject("buttonConfig.Image")));
            this.buttonConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(164, 36);
            this.buttonConfig.Text = "Configurações";
            // 
            // MenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::DMMDigital.Properties.Resources.banner_principal_f3639437;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(919, 631);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WIM Desktop";
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