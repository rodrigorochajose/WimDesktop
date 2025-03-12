namespace DMMDigital.Views
{
    partial class TemplateCreationView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateCreationView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTemplate = new System.Windows.Forms.Panel();
            this.roundedTextBoxOrientation = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.roundedTextBoxSelectedFrame = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonSaveTemplate = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonDeleteFrame = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonRotateRight = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonNewFrame = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonRotateLeft = new DMMDigital.Components.Rounded.RoundedButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.roundedTextBoxOrientation);
            this.panel1.Controls.Add(this.roundedTextBoxSelectedFrame);
            this.panel1.Controls.Add(this.buttonSaveTemplate);
            this.panel1.Controls.Add(this.buttonDeleteFrame);
            this.panel1.Controls.Add(this.buttonRotateRight);
            this.panel1.Controls.Add(this.buttonNewFrame);
            this.panel1.Controls.Add(this.buttonRotateLeft);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panelTemplate
            // 
            this.panelTemplate.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.panelTemplate, "panelTemplate");
            this.panelTemplate.Name = "panelTemplate";
            this.panelTemplate.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTemplatePaint);
            // 
            // roundedTextBoxOrientation
            // 
            this.roundedTextBoxOrientation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxOrientation.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxOrientation.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxOrientation.BorderRadius = 10;
            this.roundedTextBoxOrientation.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBoxOrientation, "roundedTextBoxOrientation");
            this.roundedTextBoxOrientation.ForeColor = System.Drawing.Color.Gray;
            this.roundedTextBoxOrientation.Multiline = false;
            this.roundedTextBoxOrientation.Name = "roundedTextBoxOrientation";
            this.roundedTextBoxOrientation.PasswordChar = false;
            this.roundedTextBoxOrientation.PlaceholderColor = System.Drawing.Color.Gray;
            this.roundedTextBoxOrientation.PlaceholderText = "";
            this.roundedTextBoxOrientation.Texts = "";
            this.roundedTextBoxOrientation.UnderlinedStyle = false;
            // 
            // roundedTextBoxSelectedFrame
            // 
            this.roundedTextBoxSelectedFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxSelectedFrame.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxSelectedFrame.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxSelectedFrame.BorderRadius = 10;
            this.roundedTextBoxSelectedFrame.BorderSize = 1;
            resources.ApplyResources(this.roundedTextBoxSelectedFrame, "roundedTextBoxSelectedFrame");
            this.roundedTextBoxSelectedFrame.ForeColor = System.Drawing.Color.Gray;
            this.roundedTextBoxSelectedFrame.Multiline = false;
            this.roundedTextBoxSelectedFrame.Name = "roundedTextBoxSelectedFrame";
            this.roundedTextBoxSelectedFrame.PasswordChar = false;
            this.roundedTextBoxSelectedFrame.PlaceholderColor = System.Drawing.Color.Gray;
            this.roundedTextBoxSelectedFrame.PlaceholderText = "";
            this.roundedTextBoxSelectedFrame.Texts = "";
            this.roundedTextBoxSelectedFrame.UnderlinedStyle = false;
            // 
            // buttonSaveTemplate
            // 
            this.buttonSaveTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonSaveTemplate.BorderColor = System.Drawing.Color.White;
            this.buttonSaveTemplate.BorderWidth = 5F;
            this.buttonSaveTemplate.CornerRadius = 10;
            resources.ApplyResources(this.buttonSaveTemplate, "buttonSaveTemplate");
            this.buttonSaveTemplate.Name = "buttonSaveTemplate";
            this.buttonSaveTemplate.UseVisualStyleBackColor = false;
            // 
            // buttonDeleteFrame
            // 
            this.buttonDeleteFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonDeleteFrame.BorderColor = System.Drawing.Color.White;
            this.buttonDeleteFrame.BorderWidth = 5F;
            this.buttonDeleteFrame.CornerRadius = 10;
            resources.ApplyResources(this.buttonDeleteFrame, "buttonDeleteFrame");
            this.buttonDeleteFrame.Name = "buttonDeleteFrame";
            this.buttonDeleteFrame.UseVisualStyleBackColor = false;
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRotateRight.BorderColor = System.Drawing.Color.White;
            this.buttonRotateRight.BorderWidth = 5F;
            this.buttonRotateRight.CornerRadius = 10;
            this.buttonRotateRight.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            resources.ApplyResources(this.buttonRotateRight, "buttonRotateRight");
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.UseVisualStyleBackColor = false;
            // 
            // buttonNewFrame
            // 
            this.buttonNewFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonNewFrame.BorderColor = System.Drawing.Color.White;
            this.buttonNewFrame.BorderWidth = 5F;
            this.buttonNewFrame.CornerRadius = 10;
            resources.ApplyResources(this.buttonNewFrame, "buttonNewFrame");
            this.buttonNewFrame.Name = "buttonNewFrame";
            this.buttonNewFrame.UseVisualStyleBackColor = false;
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.buttonRotateLeft.BorderColor = System.Drawing.Color.White;
            this.buttonRotateLeft.BorderWidth = 5F;
            this.buttonRotateLeft.CornerRadius = 10;
            this.buttonRotateLeft.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_left;
            resources.ApplyResources(this.buttonRotateLeft, "buttonRotateLeft");
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.UseVisualStyleBackColor = false;
            // 
            // TemplateCreationView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelTemplate);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateCreationView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTemplate;
        private Components.Rounded.RoundedButton buttonRotateLeft;
        private Components.Rounded.RoundedButton buttonRotateRight;
        private Components.Rounded.RoundedButton buttonNewFrame;
        private Components.Rounded.RoundedButton buttonDeleteFrame;
        private Components.Rounded.RoundedButton buttonSaveTemplate;
        private Components.Rounded.RoundedTextBox roundedTextBoxSelectedFrame;
        private Components.Rounded.RoundedTextBox roundedTextBoxOrientation;
    }
}

