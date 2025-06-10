namespace WimDesktop.Views
{
    partial class ClinicProfileView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClinicProfileView));
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelFields = new System.Windows.Forms.Panel();
            this.roundedButtonChangePassword = new WimDesktop.Components.Rounded.RoundedButton();
            this.roundedButtonEditEmail = new WimDesktop.Components.Rounded.RoundedButton();
            this.roundedTextBoxName = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.roundedTextBoxEmail = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.roundedButtonConfirm = new WimDesktop.Components.Rounded.RoundedButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelFields.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            resources.ApplyResources(this.labelDescription, "labelDescription");
            this.labelDescription.ForeColor = System.Drawing.Color.Black;
            this.labelDescription.Name = "labelDescription";
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.labelName.Name = "labelName";
            // 
            // labelEmail
            // 
            resources.ApplyResources(this.labelEmail, "labelEmail");
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.labelEmail.Name = "labelEmail";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBoxIcon);
            this.panel1.Controls.Add(this.labelDescription);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Image = global::WimDesktop.Properties.Resources.icon_32x32_dentist;
            resources.ApplyResources(this.pictureBoxIcon, "pictureBoxIcon");
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.roundedButtonConfirm);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panelFields
            // 
            this.panelFields.BackColor = System.Drawing.Color.White;
            this.panelFields.Controls.Add(this.roundedButtonChangePassword);
            this.panelFields.Controls.Add(this.labelName);
            this.panelFields.Controls.Add(this.roundedButtonEditEmail);
            this.panelFields.Controls.Add(this.roundedTextBoxName);
            this.panelFields.Controls.Add(this.labelEmail);
            this.panelFields.Controls.Add(this.roundedTextBoxEmail);
            resources.ApplyResources(this.panelFields, "panelFields");
            this.panelFields.Name = "panelFields";
            // 
            // roundedButtonChangePassword
            // 
            resources.ApplyResources(this.roundedButtonChangePassword, "roundedButtonChangePassword");
            this.roundedButtonChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonChangePassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonChangePassword.BorderWidth = 1;
            this.roundedButtonChangePassword.CornerRadius = 10;
            this.roundedButtonChangePassword.FlatAppearance.BorderSize = 0;
            this.roundedButtonChangePassword.ForeColor = System.Drawing.Color.White;
            this.roundedButtonChangePassword.Name = "roundedButtonChangePassword";
            this.roundedButtonChangePassword.UseVisualStyleBackColor = false;
            this.roundedButtonChangePassword.Click += new System.EventHandler(this.roundedButtonEditPasswordClick);
            // 
            // roundedButtonEditEmail
            // 
            resources.ApplyResources(this.roundedButtonEditEmail, "roundedButtonEditEmail");
            this.roundedButtonEditEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonEditEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonEditEmail.BorderWidth = 1;
            this.roundedButtonEditEmail.CornerRadius = 10;
            this.roundedButtonEditEmail.FlatAppearance.BorderSize = 0;
            this.roundedButtonEditEmail.ForeColor = System.Drawing.Color.White;
            this.roundedButtonEditEmail.Name = "roundedButtonEditEmail";
            this.roundedButtonEditEmail.UseVisualStyleBackColor = false;
            // 
            // roundedTextBoxName
            // 
            this.roundedTextBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxName.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.roundedTextBoxName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxName.BorderRadius = 15;
            this.roundedTextBoxName.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBoxName, "roundedTextBoxName");
            this.roundedTextBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxName.Multiline = false;
            this.roundedTextBoxName.Name = "roundedTextBoxName";
            this.roundedTextBoxName.PasswordChar = false;
            this.roundedTextBoxName.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxName.PlaceholderText = "";
            this.roundedTextBoxName.Texts = "";
            this.roundedTextBoxName.UnderlinedStyle = false;
            // 
            // roundedTextBoxEmail
            // 
            this.roundedTextBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxEmail.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.roundedTextBoxEmail.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxEmail.BorderRadius = 15;
            this.roundedTextBoxEmail.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBoxEmail, "roundedTextBoxEmail");
            this.roundedTextBoxEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxEmail.Multiline = false;
            this.roundedTextBoxEmail.Name = "roundedTextBoxEmail";
            this.roundedTextBoxEmail.PasswordChar = false;
            this.roundedTextBoxEmail.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxEmail.PlaceholderText = "";
            this.roundedTextBoxEmail.Texts = "";
            this.roundedTextBoxEmail.UnderlinedStyle = false;
            // 
            // roundedButtonConfirm
            // 
            resources.ApplyResources(this.roundedButtonConfirm, "roundedButtonConfirm");
            this.roundedButtonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonConfirm.BorderWidth = 1;
            this.roundedButtonConfirm.CornerRadius = 10;
            this.roundedButtonConfirm.FlatAppearance.BorderSize = 0;
            this.roundedButtonConfirm.ForeColor = System.Drawing.Color.White;
            this.roundedButtonConfirm.Name = "roundedButtonConfirm";
            this.roundedButtonConfirm.UseVisualStyleBackColor = false;
            this.roundedButtonConfirm.Click += new System.EventHandler(this.roundedButtonConfirmClick);
            // 
            // ClinicProfileView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelFields);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClinicProfileView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelFields.ResumeLayout(false);
            this.panelFields.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelName;
        private Components.Rounded.RoundedTextBox roundedTextBoxName;
        private System.Windows.Forms.Label labelEmail;
        private Components.Rounded.RoundedTextBox roundedTextBoxEmail;
        private Components.Rounded.RoundedButton roundedButtonConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelFields;
        private Components.Rounded.RoundedButton roundedButtonChangePassword;
        private Components.Rounded.RoundedButton roundedButtonEditEmail;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}