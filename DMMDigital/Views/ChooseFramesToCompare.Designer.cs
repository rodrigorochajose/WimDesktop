namespace DMMDigital.Views
{
    partial class ChooseFramesToCompare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseFramesToCompare));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTemplate = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 55);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::DMMDigital.Properties.Resources.icon_32x32_compare;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(237, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "       Comparar Filmes";
            // 
            // panelTemplate
            // 
            this.panelTemplate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTemplate.Location = new System.Drawing.Point(0, 55);
            this.panelTemplate.Name = "panelTemplate";
            this.panelTemplate.Size = new System.Drawing.Size(700, 450);
            this.panelTemplate.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.buttonCancel);
            this.panel3.Controls.Add(this.buttonCompare);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 449);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 56);
            this.panel3.TabIndex = 2;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 13);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(84, 31);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancelar";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonCompare
            // 
            this.buttonCompare.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCompare.Location = new System.Drawing.Point(597, 13);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(84, 31);
            this.buttonCompare.TabIndex = 0;
            this.buttonCompare.Text = "Comparar";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompareClick);
            // 
            // ChooseFramesToCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(700, 505);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelTemplate);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseFramesToCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comparar Filmes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTemplate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCompare;
    }
}