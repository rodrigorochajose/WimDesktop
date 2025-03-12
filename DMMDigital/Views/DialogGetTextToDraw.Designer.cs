namespace DMMDigital.Views
{
    partial class DialogGetTextToDraw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogGetTextToDraw));
            this.buttonConfirm = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.labelInserText = new System.Windows.Forms.Label();
            this.roundedTextBox = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.SuspendLayout();
            // 
            // buttonConfirm
            // 
            resources.ApplyResources(this.buttonConfirm, "buttonConfirm");
            this.buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderWidth = 5F;
            this.buttonConfirm.CornerRadius = 5;
            this.buttonConfirm.FlatAppearance.BorderSize = 0;
            this.buttonConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
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
            // labelInserText
            // 
            resources.ApplyResources(this.labelInserText, "labelInserText");
            this.labelInserText.Name = "labelInserText";
            // 
            // roundedTextBox
            // 
            this.roundedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBox.BorderColor = System.Drawing.Color.White;
            this.roundedTextBox.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBox.BorderRadius = 10;
            this.roundedTextBox.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBox, "roundedTextBox");
            this.roundedTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBox.Multiline = false;
            this.roundedTextBox.Name = "roundedTextBox";
            this.roundedTextBox.PasswordChar = false;
            this.roundedTextBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.roundedTextBox.PlaceholderText = "";
            this.roundedTextBox.Texts = "";
            this.roundedTextBox.UnderlinedStyle = false;
            // 
            // DialogGetTextToDraw
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.roundedTextBox);
            this.Controls.Add(this.labelInserText);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogGetTextToDraw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Rounded.RoundedButton buttonConfirm;
        private Components.Rounded.RoundedButton buttonCancel;
        private System.Windows.Forms.Label labelInserText;
        private Components.Rounded.RoundedTextBox roundedTextBox;
    }
}