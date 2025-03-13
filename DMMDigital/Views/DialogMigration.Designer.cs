namespace DMMDigital.Views
{
    partial class DialogMigration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogMigration));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSelectPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonContinue = new DMMDigital.Components.Rounded.RoundedButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.roundedTextBoxPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonSelectPath
            // 
            this.buttonSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSelectPath.BorderColor = System.Drawing.Color.White;
            this.buttonSelectPath.BorderWidth = 5F;
            this.buttonSelectPath.CornerRadius = 10;
            this.buttonSelectPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            resources.ApplyResources(this.buttonSelectPath, "buttonSelectPath");
            this.buttonSelectPath.Name = "buttonSelectPath";
            this.buttonSelectPath.UseVisualStyleBackColor = false;
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
            // buttonContinue
            // 
            resources.ApplyResources(this.buttonContinue, "buttonContinue");
            this.buttonContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonContinue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonContinue.BorderWidth = 5F;
            this.buttonContinue.CornerRadius = 5;
            this.buttonContinue.FlatAppearance.BorderSize = 0;
            this.buttonContinue.ForeColor = System.Drawing.Color.White;
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.UseVisualStyleBackColor = false;
            // 
            // roundedTextBoxPath
            // 
            this.roundedTextBoxPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxPath.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxPath.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxPath.BorderRadius = 10;
            this.roundedTextBoxPath.BorderSize = 2;
            resources.ApplyResources(this.roundedTextBoxPath, "roundedTextBoxPath");
            this.roundedTextBoxPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxPath.Multiline = false;
            this.roundedTextBoxPath.Name = "roundedTextBoxPath";
            this.roundedTextBoxPath.PasswordChar = false;
            this.roundedTextBoxPath.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxPath.PlaceholderText = "";
            this.roundedTextBoxPath.Texts = "";
            this.roundedTextBoxPath.UnderlinedStyle = false;
            // 
            // DialogMigration
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.roundedTextBoxPath);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.buttonSelectPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogMigration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedButton buttonSelectPath;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedButton buttonContinue;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private Components.Rounded.RoundedTextBox roundedTextBoxPath;
    }
}