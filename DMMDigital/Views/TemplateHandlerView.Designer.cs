namespace DMMDigital.Views
{
    partial class TemplateHandlerView
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateHandlerView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSaveTemplate = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonDeleteFrame = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonRotateRight = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonNewFrame = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonRotateLeft = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBoxOrientation = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.textBoxSelectedFrame = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTemplate = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.buttonSaveTemplate);
            this.panel1.Controls.Add(this.buttonDeleteFrame);
            this.panel1.Controls.Add(this.buttonRotateRight);
            this.panel1.Controls.Add(this.buttonNewFrame);
            this.panel1.Controls.Add(this.buttonRotateLeft);
            this.panel1.Controls.Add(this.textBoxOrientation);
            this.panel1.Controls.Add(this.textBoxSelectedFrame);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(700, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 450);
            this.panel1.TabIndex = 2;
            // 
            // buttonSaveTemplate
            // 
            this.buttonSaveTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSaveTemplate.BorderColor = System.Drawing.Color.White;
            this.buttonSaveTemplate.BorderWidth = 5F;
            this.buttonSaveTemplate.CornerRadius = 10;
            this.buttonSaveTemplate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSaveTemplate.Location = new System.Drawing.Point(45, 377);
            this.buttonSaveTemplate.Name = "buttonSaveTemplate";
            this.buttonSaveTemplate.Size = new System.Drawing.Size(122, 46);
            this.buttonSaveTemplate.TabIndex = 65;
            this.buttonSaveTemplate.Text = "Salvar";
            this.buttonSaveTemplate.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteFrame
            // 
            this.buttonDeleteFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonDeleteFrame.BorderColor = System.Drawing.Color.White;
            this.buttonDeleteFrame.BorderWidth = 5F;
            this.buttonDeleteFrame.CornerRadius = 10;
            this.buttonDeleteFrame.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonDeleteFrame.Location = new System.Drawing.Point(45, 300);
            this.buttonDeleteFrame.Name = "buttonDeleteFrame";
            this.buttonDeleteFrame.Size = new System.Drawing.Size(122, 46);
            this.buttonDeleteFrame.TabIndex = 64;
            this.buttonDeleteFrame.Text = "Excluir Filme";
            this.buttonDeleteFrame.UseVisualStyleBackColor = false;
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRotateRight.BorderColor = System.Drawing.Color.White;
            this.buttonRotateRight.BorderWidth = 5F;
            this.buttonRotateRight.CornerRadius = 10;
            this.buttonRotateRight.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.buttonRotateRight.Location = new System.Drawing.Point(111, 182);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Size = new System.Drawing.Size(56, 53);
            this.buttonRotateRight.TabIndex = 62;
            this.buttonRotateRight.UseVisualStyleBackColor = false;
            // 
            // buttonNewFrame
            // 
            this.buttonNewFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonNewFrame.BorderColor = System.Drawing.Color.White;
            this.buttonNewFrame.BorderWidth = 5F;
            this.buttonNewFrame.CornerRadius = 10;
            this.buttonNewFrame.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonNewFrame.Location = new System.Drawing.Point(45, 248);
            this.buttonNewFrame.Name = "buttonNewFrame";
            this.buttonNewFrame.Size = new System.Drawing.Size(122, 46);
            this.buttonNewFrame.TabIndex = 63;
            this.buttonNewFrame.Text = "Novo Filme";
            this.buttonNewFrame.UseVisualStyleBackColor = false;
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRotateLeft.BorderColor = System.Drawing.Color.White;
            this.buttonRotateLeft.BorderWidth = 5F;
            this.buttonRotateLeft.CornerRadius = 10;
            this.buttonRotateLeft.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_left;
            this.buttonRotateLeft.Location = new System.Drawing.Point(32, 182);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Size = new System.Drawing.Size(56, 53);
            this.buttonRotateLeft.TabIndex = 61;
            this.buttonRotateLeft.UseVisualStyleBackColor = false;
            // 
            // textBoxOrientation
            // 
            this.textBoxOrientation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxOrientation.BorderColor = System.Drawing.Color.White;
            this.textBoxOrientation.BorderRadius = 10;
            this.textBoxOrientation.BorderSize = 10;
            this.textBoxOrientation.Enabled = false;
            this.textBoxOrientation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxOrientation.ForeColor = System.Drawing.Color.Gray;
            this.textBoxOrientation.Location = new System.Drawing.Point(20, 118);
            this.textBoxOrientation.Name = "textBoxOrientation";
            this.textBoxOrientation.PlaceholderText = null;
            this.textBoxOrientation.Size = new System.Drawing.Size(171, 44);
            this.textBoxOrientation.TabIndex = 60;
            // 
            // textBoxSelectedFrame
            // 
            this.textBoxSelectedFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxSelectedFrame.BorderColor = System.Drawing.Color.White;
            this.textBoxSelectedFrame.BorderRadius = 10;
            this.textBoxSelectedFrame.BorderSize = 10;
            this.textBoxSelectedFrame.Enabled = false;
            this.textBoxSelectedFrame.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxSelectedFrame.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSelectedFrame.Location = new System.Drawing.Point(20, 41);
            this.textBoxSelectedFrame.Name = "textBoxSelectedFrame";
            this.textBoxSelectedFrame.PlaceholderText = null;
            this.textBoxSelectedFrame.Size = new System.Drawing.Size(171, 44);
            this.textBoxSelectedFrame.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(16, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Orientação";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filme";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelTemplate
            // 
            this.panelTemplate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTemplate.Location = new System.Drawing.Point(0, 0);
            this.panelTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.panelTemplate.Name = "panelTemplate";
            this.panelTemplate.Size = new System.Drawing.Size(700, 450);
            this.panelTemplate.TabIndex = 11;
            this.panelTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTemplatePaint);
            // 
            // TemplateHandlerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 450);
            this.Controls.Add(this.panelTemplate);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateHandlerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Template";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTemplate;
        private Components.Rounded.RoundedTextBox textBoxSelectedFrame;
        private Components.Rounded.RoundedTextBox textBoxOrientation;
        private Components.Rounded.RoundedButton buttonRotateLeft;
        private Components.Rounded.RoundedButton buttonRotateRight;
        private Components.Rounded.RoundedButton buttonNewFrame;
        private Components.Rounded.RoundedButton buttonDeleteFrame;
        private Components.Rounded.RoundedButton buttonSaveTemplate;
    }
}

