namespace DMMDigital.Views
{
    partial class DialogChooseSensor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogChooseSensor));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSensor = new DMMDigital.Components.Rounded.RoundedComboBox();
            this.buttonConfirm = new DMMDigital.Components.Rounded.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Há mais de um sensor detectado. Escolha um para utilizar";
            // 
            // comboBoxSensor
            // 
            this.comboBoxSensor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.comboBoxSensor.BorderColor = System.Drawing.Color.White;
            this.comboBoxSensor.BorderRadius = 10;
            this.comboBoxSensor.BorderSize = 10;
            this.comboBoxSensor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxSensor.Location = new System.Drawing.Point(106, 54);
            this.comboBoxSensor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxSensor.Name = "comboBoxSensor";
            this.comboBoxSensor.Size = new System.Drawing.Size(203, 47);
            this.comboBoxSensor.TabIndex = 3;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderWidth = 5F;
            this.buttonConfirm.CornerRadius = 5;
            this.buttonConfirm.FlatAppearance.BorderSize = 0;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfirm.Location = new System.Drawing.Point(161, 114);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Padding = new System.Windows.Forms.Padding(2);
            this.buttonConfirm.Size = new System.Drawing.Size(98, 32);
            this.buttonConfirm.TabIndex = 58;
            this.buttonConfirm.Text = "Confirmar";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // DialogChooseSensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 155);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.comboBoxSensor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogChooseSensor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar sensor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedComboBox comboBoxSensor;
        private Components.Rounded.RoundedButton buttonConfirm;
    }
}