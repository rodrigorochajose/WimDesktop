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
            this.buttonNewFrame = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxOrientation = new System.Windows.Forms.TextBox();
            this.buttonRotateRight = new System.Windows.Forms.Button();
            this.buttonRotateLeft = new System.Windows.Forms.Button();
            this.buttonDeleteFrame = new System.Windows.Forms.Button();
            this.buttonSaveTemplate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSelectedFrame = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNewFrame
            // 
            this.buttonNewFrame.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonNewFrame.Location = new System.Drawing.Point(37, 286);
            this.buttonNewFrame.Name = "buttonNewFrame";
            this.buttonNewFrame.Size = new System.Drawing.Size(128, 30);
            this.buttonNewFrame.TabIndex = 1;
            this.buttonNewFrame.Text = "Novo Filme";
            this.buttonNewFrame.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.textBoxOrientation);
            this.panel1.Controls.Add(this.buttonRotateRight);
            this.panel1.Controls.Add(this.buttonRotateLeft);
            this.panel1.Controls.Add(this.buttonDeleteFrame);
            this.panel1.Controls.Add(this.buttonSaveTemplate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxSelectedFrame);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonNewFrame);
            this.panel1.Location = new System.Drawing.Point(700, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 460);
            this.panel1.TabIndex = 2;
            // 
            // textBoxOrientation
            // 
            this.textBoxOrientation.Enabled = false;
            this.textBoxOrientation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxOrientation.Location = new System.Drawing.Point(13, 117);
            this.textBoxOrientation.Name = "textBoxOrientation";
            this.textBoxOrientation.Size = new System.Drawing.Size(157, 26);
            this.textBoxOrientation.TabIndex = 14;
            // 
            // buttonRotateRight
            // 
            this.buttonRotateRight.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_right;
            this.buttonRotateRight.Location = new System.Drawing.Point(101, 155);
            this.buttonRotateRight.Name = "buttonRotateRight";
            this.buttonRotateRight.Size = new System.Drawing.Size(43, 38);
            this.buttonRotateRight.TabIndex = 12;
            this.buttonRotateRight.UseVisualStyleBackColor = true;
            // 
            // buttonRotateLeft
            // 
            this.buttonRotateLeft.Image = global::DMMDigital.Properties.Resources.icon_32x32_rotate_left;
            this.buttonRotateLeft.Location = new System.Drawing.Point(33, 155);
            this.buttonRotateLeft.Name = "buttonRotateLeft";
            this.buttonRotateLeft.Size = new System.Drawing.Size(43, 38);
            this.buttonRotateLeft.TabIndex = 11;
            this.buttonRotateLeft.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteFrame
            // 
            this.buttonDeleteFrame.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonDeleteFrame.Location = new System.Drawing.Point(37, 322);
            this.buttonDeleteFrame.Name = "buttonDeleteFrame";
            this.buttonDeleteFrame.Size = new System.Drawing.Size(128, 30);
            this.buttonDeleteFrame.TabIndex = 10;
            this.buttonDeleteFrame.Text = "Excluir Filme";
            this.buttonDeleteFrame.UseVisualStyleBackColor = true;
            // 
            // buttonSaveTemplate
            // 
            this.buttonSaveTemplate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.buttonSaveTemplate.Location = new System.Drawing.Point(55, 406);
            this.buttonSaveTemplate.Name = "buttonSaveTemplate";
            this.buttonSaveTemplate.Size = new System.Drawing.Size(84, 30);
            this.buttonSaveTemplate.TabIndex = 9;
            this.buttonSaveTemplate.Text = "Salvar";
            this.buttonSaveTemplate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Orientação";
            // 
            // textBoxSelectedFrame
            // 
            this.textBoxSelectedFrame.Enabled = false;
            this.textBoxSelectedFrame.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.textBoxSelectedFrame.Location = new System.Drawing.Point(13, 40);
            this.textBoxSelectedFrame.Name = "textBoxSelectedFrame";
            this.textBoxSelectedFrame.Size = new System.Drawing.Size(157, 26);
            this.textBoxSelectedFrame.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filme";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 460);
            this.panel2.TabIndex = 11;
            // 
            // ManipulateTemplateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManipulateTemplateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Template";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonNewFrame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSelectedFrame;
        private System.Windows.Forms.Button buttonSaveTemplate;
        private System.Windows.Forms.Button buttonDeleteFrame;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRotateLeft;
        private System.Windows.Forms.Button buttonRotateRight;
        private System.Windows.Forms.TextBox textBoxOrientation;
    }
}

