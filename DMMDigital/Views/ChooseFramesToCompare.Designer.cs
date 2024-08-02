namespace DMMDigital.Views
{
    partial class ChooseFramesToCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseFramesToCompare));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTemplate = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCompare = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Image = global::DMMDigital.Properties.Resources.icon_32x32_compare;
            this.label1.Name = "label1";
            // 
            // panelTemplate
            // 
            this.panelTemplate.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.panelTemplate, "panelTemplate");
            this.panelTemplate.Name = "panelTemplate";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonCompare);
            this.panel3.Controls.Add(this.buttonCancel);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // buttonCompare
            // 
            resources.ApplyResources(this.buttonCompare, "buttonCompare");
            this.buttonCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCompare.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCompare.BorderWidth = 5F;
            this.buttonCompare.CornerRadius = 5;
            this.buttonCompare.FlatAppearance.BorderSize = 0;
            this.buttonCompare.ForeColor = System.Drawing.Color.White;
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.UseVisualStyleBackColor = false;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompareClick);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderWidth = 5F;
            this.buttonCancel.CornerRadius = 5;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // ChooseFramesToCompare
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelTemplate);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseFramesToCompare";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTemplate;
        private System.Windows.Forms.Panel panel3;
        private Components.Rounded.RoundedButton buttonCompare;
        private Components.Rounded.RoundedButton buttonCancel;
    }
}