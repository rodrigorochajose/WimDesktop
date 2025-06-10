namespace WimDesktop.Views
{
    partial class DialogForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForgotPassword));
            this.buttonReset = new WimDesktop.Components.Rounded.RoundedButton();
            this.buttonCancel = new WimDesktop.Components.Rounded.RoundedButton();
            this.roundedTextBox = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonReset.BorderWidth = 1;
            this.buttonReset.CornerRadius = 10;
            this.buttonReset.FlatAppearance.BorderSize = 0;
            this.buttonReset.ForeColor = System.Drawing.Color.White;
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderWidth = 1;
            this.buttonCancel.CornerRadius = 10;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // roundedTextBox
            // 
            this.roundedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBox.BorderColor = System.Drawing.Color.White;
            this.roundedTextBox.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBox.BorderRadius = 10;
            this.roundedTextBox.BorderSize = 2;
            resources.ApplyResources(this.roundedTextBox, "roundedTextBox");
            this.roundedTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBox.Multiline = false;
            this.roundedTextBox.Name = "roundedTextBox";
            this.roundedTextBox.PasswordChar = true;
            this.roundedTextBox.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.roundedTextBox.PlaceholderText = "";
            this.roundedTextBox.Texts = "";
            this.roundedTextBox.UnderlinedStyle = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DialogForgotPassword
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.roundedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogForgotPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Components.Rounded.RoundedButton buttonReset;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedTextBox roundedTextBox;
        private System.Windows.Forms.Label label1;
    }
}