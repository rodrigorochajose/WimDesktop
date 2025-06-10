namespace WimDesktop.Views
{
    partial class ChangePasswordView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordView));
            this.roundedTextBoxConfirmNewPassword = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.labelConfirmNewPassword = new System.Windows.Forms.Label();
            this.roundedTextBoxNewPassword = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.roundedTextBoxPassword = new WimDesktop.Components.Rounded.RoundedTextBox();
            this.roundedButtonConfirm = new WimDesktop.Components.Rounded.RoundedButton();
            this.roundedButtonCancel = new WimDesktop.Components.Rounded.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roundedTextBoxConfirmNewPassword
            // 
            this.roundedTextBoxConfirmNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxConfirmNewPassword.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxConfirmNewPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxConfirmNewPassword.BorderRadius = 15;
            this.roundedTextBoxConfirmNewPassword.BorderSize = 1;
            this.roundedTextBoxConfirmNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roundedTextBoxConfirmNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxConfirmNewPassword.Location = new System.Drawing.Point(51, 286);
            this.roundedTextBoxConfirmNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.roundedTextBoxConfirmNewPassword.Multiline = false;
            this.roundedTextBoxConfirmNewPassword.Name = "roundedTextBoxConfirmNewPassword";
            this.roundedTextBoxConfirmNewPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.roundedTextBoxConfirmNewPassword.PasswordChar = true;
            this.roundedTextBoxConfirmNewPassword.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxConfirmNewPassword.PlaceholderText = "";
            this.roundedTextBoxConfirmNewPassword.Size = new System.Drawing.Size(318, 36);
            this.roundedTextBoxConfirmNewPassword.TabIndex = 123;
            this.roundedTextBoxConfirmNewPassword.Texts = "";
            this.roundedTextBoxConfirmNewPassword.UnderlinedStyle = false;
            // 
            // labelConfirmNewPassword
            // 
            this.labelConfirmNewPassword.AutoSize = true;
            this.labelConfirmNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelConfirmNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelConfirmNewPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelConfirmNewPassword.Location = new System.Drawing.Point(51, 261);
            this.labelConfirmNewPassword.Name = "labelConfirmNewPassword";
            this.labelConfirmNewPassword.Size = new System.Drawing.Size(169, 21);
            this.labelConfirmNewPassword.TabIndex = 124;
            this.labelConfirmNewPassword.Text = "Confirmar Nova Senha";
            // 
            // roundedTextBoxNewPassword
            // 
            this.roundedTextBoxNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxNewPassword.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxNewPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxNewPassword.BorderRadius = 15;
            this.roundedTextBoxNewPassword.BorderSize = 1;
            this.roundedTextBoxNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roundedTextBoxNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxNewPassword.Location = new System.Drawing.Point(51, 211);
            this.roundedTextBoxNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.roundedTextBoxNewPassword.Multiline = false;
            this.roundedTextBoxNewPassword.Name = "roundedTextBoxNewPassword";
            this.roundedTextBoxNewPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.roundedTextBoxNewPassword.PasswordChar = true;
            this.roundedTextBoxNewPassword.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxNewPassword.PlaceholderText = "";
            this.roundedTextBoxNewPassword.Size = new System.Drawing.Size(318, 36);
            this.roundedTextBoxNewPassword.TabIndex = 120;
            this.roundedTextBoxNewPassword.Texts = "";
            this.roundedTextBoxNewPassword.UnderlinedStyle = false;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelPassword.Location = new System.Drawing.Point(51, 111);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(93, 21);
            this.labelPassword.TabIndex = 121;
            this.labelPassword.Text = "Senha Atual";
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelNewPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelNewPassword.Location = new System.Drawing.Point(51, 186);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(94, 21);
            this.labelNewPassword.TabIndex = 122;
            this.labelNewPassword.Text = "Nova Senha";
            // 
            // roundedTextBoxPassword
            // 
            this.roundedTextBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxPassword.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxPassword.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxPassword.BorderRadius = 15;
            this.roundedTextBoxPassword.BorderSize = 1;
            this.roundedTextBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roundedTextBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxPassword.Location = new System.Drawing.Point(51, 136);
            this.roundedTextBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.roundedTextBoxPassword.Multiline = false;
            this.roundedTextBoxPassword.Name = "roundedTextBoxPassword";
            this.roundedTextBoxPassword.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.roundedTextBoxPassword.PasswordChar = true;
            this.roundedTextBoxPassword.PlaceholderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxPassword.PlaceholderText = "";
            this.roundedTextBoxPassword.Size = new System.Drawing.Size(318, 36);
            this.roundedTextBoxPassword.TabIndex = 119;
            this.roundedTextBoxPassword.Texts = "";
            this.roundedTextBoxPassword.UnderlinedStyle = false;
            // 
            // roundedButtonConfirm
            // 
            this.roundedButtonConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.roundedButtonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonConfirm.BorderWidth = 1;
            this.roundedButtonConfirm.CornerRadius = 10;
            this.roundedButtonConfirm.FlatAppearance.BorderSize = 0;
            this.roundedButtonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.roundedButtonConfirm.ForeColor = System.Drawing.Color.White;
            this.roundedButtonConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButtonConfirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roundedButtonConfirm.Location = new System.Drawing.Point(297, 364);
            this.roundedButtonConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.roundedButtonConfirm.Name = "roundedButtonConfirm";
            this.roundedButtonConfirm.Padding = new System.Windows.Forms.Padding(2);
            this.roundedButtonConfirm.Size = new System.Drawing.Size(96, 32);
            this.roundedButtonConfirm.TabIndex = 125;
            this.roundedButtonConfirm.Text = "Alterar";
            this.roundedButtonConfirm.UseVisualStyleBackColor = false;
            // 
            // roundedButtonCancel
            // 
            this.roundedButtonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.roundedButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedButtonCancel.BorderWidth = 1;
            this.roundedButtonCancel.CornerRadius = 10;
            this.roundedButtonCancel.FlatAppearance.BorderSize = 0;
            this.roundedButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButtonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.roundedButtonCancel.ForeColor = System.Drawing.Color.White;
            this.roundedButtonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButtonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.roundedButtonCancel.Location = new System.Drawing.Point(19, 364);
            this.roundedButtonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.roundedButtonCancel.Name = "roundedButtonCancel";
            this.roundedButtonCancel.Padding = new System.Windows.Forms.Padding(2);
            this.roundedButtonCancel.Size = new System.Drawing.Size(87, 32);
            this.roundedButtonCancel.TabIndex = 126;
            this.roundedButtonCancel.Text = "Cancelar";
            this.roundedButtonCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(131, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 30);
            this.label1.TabIndex = 127;
            this.label1.Text = "Alterar Senha";
            // 
            // ChangePasswordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 416);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedButtonCancel);
            this.Controls.Add(this.roundedButtonConfirm);
            this.Controls.Add(this.roundedTextBoxConfirmNewPassword);
            this.Controls.Add(this.labelConfirmNewPassword);
            this.Controls.Add(this.roundedTextBoxNewPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.roundedTextBoxPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Senha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Rounded.RoundedTextBox roundedTextBoxConfirmNewPassword;
        private System.Windows.Forms.Label labelConfirmNewPassword;
        private Components.Rounded.RoundedTextBox roundedTextBoxNewPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private Components.Rounded.RoundedTextBox roundedTextBoxPassword;
        private Components.Rounded.RoundedButton roundedButtonConfirm;
        private Components.Rounded.RoundedButton roundedButtonCancel;
        private System.Windows.Forms.Label label1;
    }
}