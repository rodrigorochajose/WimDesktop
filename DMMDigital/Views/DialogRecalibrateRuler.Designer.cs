namespace DMMDigital.Views
{
    partial class DialogRecalibrateRuler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogRecalibrateRuler));
            this.label = new System.Windows.Forms.Label();
            this.buttonConfirm = new DMMDigital.Components.Rounded.RoundedButton();
            this.numericUpDown = new DMMDigital.Components.Rounded.RoundedNumericUpDown();
            this.SuspendLayout();
            // 
            // label
            // 
            resources.ApplyResources(this.label, "label");
            this.label.Name = "label";
            // 
            // buttonConfirm
            // 
            resources.ApplyResources(this.buttonConfirm, "buttonConfirm");
            this.buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderWidth = 1;
            this.buttonConfirm.CornerRadius = 10;
            this.buttonConfirm.FlatAppearance.BorderSize = 0;
            this.buttonConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // numericUpDown
            // 
            this.numericUpDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.numericUpDown.BorderColor = System.Drawing.Color.White;
            this.numericUpDown.BorderRadius = 10;
            this.numericUpDown.BorderSize = 10;
            resources.ApplyResources(this.numericUpDown, "numericUpDown");
            this.numericUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDown.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown.Name = "numericUpDown";
            // 
            // DialogRecalibrateRuler
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogRecalibrateRuler";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private Components.Rounded.RoundedButton buttonConfirm;
        private Components.Rounded.RoundedNumericUpDown numericUpDown;
    }
}