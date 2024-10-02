namespace DMMDigital.Views
{
    partial class DialogAdvancedSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogAdvancedSettings));
            this.labelInserText = new System.Windows.Forms.Label();
            this.buttonUnlock = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBox = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.SuspendLayout();
            // 
            // labelInserText
            // 
            resources.ApplyResources(this.labelInserText, "labelInserText");
            this.labelInserText.Name = "labelInserText";
            // 
            // buttonUnlock
            // 
            resources.ApplyResources(this.buttonUnlock, "buttonUnlock");
            this.buttonUnlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonUnlock.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonUnlock.BorderWidth = 5F;
            this.buttonUnlock.CornerRadius = 5;
            this.buttonUnlock.FlatAppearance.BorderSize = 0;
            this.buttonUnlock.ForeColor = System.Drawing.Color.White;
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.UseVisualStyleBackColor = false;
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
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBox.BorderColor = System.Drawing.Color.White;
            this.textBox.BorderRadius = 10;
            this.textBox.BorderSize = 10;
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.Name = "textBox";
            this.textBox.PlaceholderText = null;
            // 
            // DialogAdvancedSettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelInserText);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogAdvancedSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Rounded.RoundedTextBox textBox;
        private System.Windows.Forms.Label labelInserText;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedButton buttonUnlock;
    }
}