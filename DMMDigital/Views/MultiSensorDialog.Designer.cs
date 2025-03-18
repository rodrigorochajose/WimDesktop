namespace DMMDigital.Views
{
    partial class MultiSensorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiSensorDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSensor = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.buttonConfirm = new DMMDigital.Components.Rounded.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxSensor
            // 
            this.comboBoxSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxSensor.BorderColor = System.Drawing.Color.White;
            this.comboBoxSensor.BorderRadius = 10;
            this.comboBoxSensor.BorderSize = 10;
            resources.ApplyResources(this.comboBoxSensor, "comboBoxSensor");
            this.comboBoxSensor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxSensor.Name = "comboBoxSensor";
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
            // MultiSensorDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.comboBoxSensor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MultiSensorDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedComboBox comboBoxSensor;
        private Components.Rounded.RoundedButton buttonConfirm;
    }
}