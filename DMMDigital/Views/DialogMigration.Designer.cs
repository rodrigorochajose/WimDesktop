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
            this.textBoxPath = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonSelectPath = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonCancel = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonContinue = new DMMDigital.Components.Rounded.RoundedButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(61, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione o caminho dos arquivos";
            // 
            // textBoxPath
            // 
            this.textBoxPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxPath.BorderColor = System.Drawing.Color.White;
            this.textBoxPath.BorderRadius = 10;
            this.textBoxPath.BorderSize = 10;
            this.textBoxPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxPath.Location = new System.Drawing.Point(54, 58);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.PlaceholderText = null;
            this.textBoxPath.Size = new System.Drawing.Size(356, 42);
            this.textBoxPath.TabIndex = 32;
            // 
            // buttonSelectPath
            // 
            this.buttonSelectPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonSelectPath.BorderColor = System.Drawing.Color.White;
            this.buttonSelectPath.BorderWidth = 5F;
            this.buttonSelectPath.CornerRadius = 10;
            this.buttonSelectPath.Image = global::DMMDigital.Properties.Resources.icon_16x16_folder;
            this.buttonSelectPath.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSelectPath.Location = new System.Drawing.Point(416, 58);
            this.buttonSelectPath.Name = "buttonSelectPath";
            this.buttonSelectPath.Size = new System.Drawing.Size(42, 42);
            this.buttonSelectPath.TabIndex = 31;
            this.buttonSelectPath.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonCancel.BorderWidth = 5F;
            this.buttonCancel.CornerRadius = 5;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCancel.Location = new System.Drawing.Point(9, 125);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Padding = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Size = new System.Drawing.Size(87, 32);
            this.buttonCancel.TabIndex = 60;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // buttonContinue
            // 
            this.buttonContinue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonContinue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonContinue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonContinue.BorderWidth = 5F;
            this.buttonContinue.CornerRadius = 5;
            this.buttonContinue.FlatAppearance.BorderSize = 0;
            this.buttonContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContinue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonContinue.ForeColor = System.Drawing.Color.White;
            this.buttonContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonContinue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonContinue.Location = new System.Drawing.Point(413, 125);
            this.buttonContinue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Padding = new System.Windows.Forms.Padding(2);
            this.buttonContinue.Size = new System.Drawing.Size(87, 32);
            this.buttonContinue.TabIndex = 59;
            this.buttonContinue.Text = "Continuar";
            this.buttonContinue.UseVisualStyleBackColor = false;
            // 
            // DialogMigrationMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(509, 166);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.buttonSelectPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DialogMigrationMode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modo de Migração";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedTextBox textBoxPath;
        private Components.Rounded.RoundedButton buttonSelectPath;
        private Components.Rounded.RoundedButton buttonCancel;
        private Components.Rounded.RoundedButton buttonContinue;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}