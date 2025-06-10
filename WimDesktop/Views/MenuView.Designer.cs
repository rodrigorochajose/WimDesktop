namespace WimDesktop.Views
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
            this.buttonSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.roundedButtonLogout = new WimDesktop.Components.Rounded.RoundedButton();
            this.roundedButtonProfile = new WimDesktop.Components.Rounded.RoundedButton();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonNewExam,
            this.buttonPatient,
            this.buttonTemplate,
            this.buttonSettings});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // buttonNewExam
            // 
            this.buttonNewExam.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonNewExam, "buttonNewExam");
            this.buttonNewExam.ForeColor = System.Drawing.Color.Black;
            this.buttonNewExam.Image = global::WimDesktop.Properties.Resources.icon_32x32_xray_new;
            this.buttonNewExam.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.buttonNewExam.Name = "buttonNewExam";
            // 
            // buttonPatient
            // 
            resources.ApplyResources(this.buttonPatient, "buttonPatient");
            this.buttonPatient.ForeColor = System.Drawing.Color.Black;
            this.buttonPatient.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.buttonPatient.Name = "buttonPatient";
            // 
            // buttonTemplate
            // 
            resources.ApplyResources(this.buttonTemplate, "buttonTemplate");
            this.buttonTemplate.ForeColor = System.Drawing.Color.Black;
            this.buttonTemplate.Image = global::WimDesktop.Properties.Resources.icon_32x32_template;
            this.buttonTemplate.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.buttonTemplate.Name = "buttonTemplate";
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.ForeColor = System.Drawing.Color.Black;
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.buttonSettings.Name = "buttonSettings";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.roundedButtonLogout);
            this.panel1.Controls.Add(this.roundedButtonProfile);
            this.panel1.Controls.Add(this.menuStrip1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // roundedButtonLogout
            // 
            resources.ApplyResources(this.roundedButtonLogout, "roundedButtonLogout");
            this.roundedButtonLogout.BorderColor = System.Drawing.Color.White;
            this.roundedButtonLogout.BorderWidth = 5;
            this.roundedButtonLogout.CornerRadius = 15;
            this.roundedButtonLogout.Image = global::WimDesktop.Properties.Resources.icon_32x32_exit;
            this.roundedButtonLogout.Name = "roundedButtonLogout";
            this.roundedButtonLogout.UseVisualStyleBackColor = true;
            this.roundedButtonLogout.Click += new System.EventHandler(this.roundedButtonLogoutClick);
            // 
            // roundedButtonProfile
            // 
            resources.ApplyResources(this.roundedButtonProfile, "roundedButtonProfile");
            this.roundedButtonProfile.BorderColor = System.Drawing.Color.White;
            this.roundedButtonProfile.BorderWidth = 5;
            this.roundedButtonProfile.CornerRadius = 15;
            this.roundedButtonProfile.Image = global::WimDesktop.Properties.Resources.icon_32x32_dentist;
            this.roundedButtonProfile.Name = "roundedButtonProfile";
            this.roundedButtonProfile.UseVisualStyleBackColor = true;
            // 
            // MenuView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::WimDesktop.Properties.Resources.IMAGEMBG;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.menuViewLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem buttonNewExam;
        private System.Windows.Forms.ToolStripMenuItem buttonPatient;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem buttonSettings;
        private System.Windows.Forms.ToolStripMenuItem buttonTemplate;
        private System.Windows.Forms.Panel panel1;
        private Components.Rounded.RoundedButton roundedButtonProfile;
        private Components.Rounded.RoundedButton roundedButtonLogout;
    }
}