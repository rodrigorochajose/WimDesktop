namespace WimDesktop.Views
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.labelForgotPassword = new System.Windows.Forms.Label();
            this.roundedTextBoxEmail = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.roundedButtonSignIn = new WimDesktop.Components.Rounded.RoundedButton();
            this.roundedTextBoxPassword = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.checkBoxAutomaticLogin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::WimDesktop.Properties.Resources.logo_wimdental_login;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Name = "label1";
            // 
            // labelLogin
            // 
            resources.ApplyResources(this.labelLogin, "labelLogin");
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelLogin.Name = "labelLogin";
            // 
            // labelForgotPassword
            // 
            resources.ApplyResources(this.labelForgotPassword, "labelForgotPassword");
            this.labelForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelForgotPassword.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelForgotPassword.Name = "labelForgotPassword";
            this.labelForgotPassword.Click += new System.EventHandler(this.labelForgotPasswordClick);
            // 
            // roundedTextBoxEmail
            // 
            this.roundedTextBoxEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxEmail.BorderColor = System.Drawing.Color.White;
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
            // roundedButtonSignIn
            // 
            resources.ApplyResources(this.roundedButtonSignIn, "roundedButtonSignIn");
            this.roundedButtonSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonSignIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonSignIn.BorderWidth = 1;
            this.roundedButtonSignIn.CornerRadius = 20;
            this.roundedButtonSignIn.FlatAppearance.BorderSize = 0;
            this.roundedButtonSignIn.ForeColor = System.Drawing.Color.White;
            this.roundedButtonSignIn.Name = "roundedButtonSignIn";
            this.roundedButtonSignIn.UseVisualStyleBackColor = false;
            // 
            // roundedTextBoxPassword
            // 
            this.roundedTextBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxPassword.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxPassword.BorderRadius = 15;
            this.roundedTextBoxPassword.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBoxPassword, "roundedTextBoxPassword");
            this.roundedTextBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxPassword.Multiline = false;
            this.roundedTextBoxPassword.Name = "roundedTextBoxPassword";
            this.roundedTextBoxPassword.PasswordChar = true;
            this.roundedTextBoxPassword.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxPassword.PlaceholderText = "";
            this.roundedTextBoxPassword.Texts = "";
            this.roundedTextBoxPassword.UnderlinedStyle = false;
            // 
            // checkBoxAutomaticLogin
            // 
            resources.ApplyResources(this.checkBoxAutomaticLogin, "checkBoxAutomaticLogin");
            this.checkBoxAutomaticLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxAutomaticLogin.Name = "checkBoxAutomaticLogin";
            this.checkBoxAutomaticLogin.UseVisualStyleBackColor = true;
            // 
            // LoginView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkBoxAutomaticLogin);
            this.Controls.Add(this.labelForgotPassword);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.roundedTextBoxEmail);
            this.Controls.Add(this.roundedButtonSignIn);
            this.Controls.Add(this.roundedTextBoxPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Components.Rounded.RoundedTextBox roundedTextBoxPassword;
        private Components.Rounded.RoundedTextBox roundedTextBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.Label labelForgotPassword;
        private Components.Rounded.RoundedButton roundedButtonSignIn;
        private System.Windows.Forms.CheckBox checkBoxAutomaticLogin;
    }
}