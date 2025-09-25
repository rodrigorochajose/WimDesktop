namespace WimDesktop.Views
{
    partial class DialogOverwriteImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogOverwriteImage));
            this.labelOverwrite = new System.Windows.Forms.Label();
            this.buttonCancel = new WimDesktop.Components.Rounded.RoundedButton();
            this.buttonConfirm = new WimDesktop.Components.Rounded.RoundedButton();
            this.SuspendLayout();
            // 
            // labelOverwrite
            // 
            this.labelOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelOverwrite.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.labelOverwrite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelOverwrite.Location = new System.Drawing.Point(70, 29);
            this.labelOverwrite.Name = "labelOverwrite";
            this.labelOverwrite.Size = new System.Drawing.Size(221, 20);
            this.labelOverwrite.TabIndex = 65;
            this.labelOverwrite.Text = "Deseja Sobrescrever a Imagem?";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderWidth = 1;
            this.buttonCancel.CornerRadius = 10;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(24, 71);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Padding = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Size = new System.Drawing.Size(98, 32);
            this.buttonCancel.TabIndex = 64;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonConfirm.BorderWidth = 1;
            this.buttonConfirm.CornerRadius = 10;
            this.buttonConfirm.FlatAppearance.BorderSize = 0;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonConfirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonConfirm.Location = new System.Drawing.Point(224, 71);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Padding = new System.Windows.Forms.Padding(2);
            this.buttonConfirm.Size = new System.Drawing.Size(98, 32);
            this.buttonConfirm.TabIndex = 63;
            this.buttonConfirm.Text = "Confirmar";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            // 
            // DialogOverwriteImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(352, 124);
            this.Controls.Add(this.labelOverwrite);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogOverwriteImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sobrescrever Imagem";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelOverwrite;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedButton buttonConfirm;
    }
}