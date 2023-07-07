namespace GeraçãoDeTemplate
{
    partial class Menu
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
            System.Windows.Forms.ToolStripMenuItem botaoConfiguracoes;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.botaoNovoExame = new System.Windows.Forms.ToolStripMenuItem();
            this.botaoPaciente = new System.Windows.Forms.ToolStripMenuItem();
            botaoConfiguracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botaoNovoExame,
            this.botaoPaciente,
            botaoConfiguracoes});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.menuStrip1.Size = new System.Drawing.Size(979, 56);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // botaoNovoExame
            // 
            this.botaoNovoExame.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_autotake;
            this.botaoNovoExame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botaoNovoExame.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botaoNovoExame.Name = "botaoNovoExame";
            this.botaoNovoExame.Size = new System.Drawing.Size(163, 36);
            this.botaoNovoExame.Text = "Novo Exame";
            this.botaoNovoExame.Click += new System.EventHandler(this.botaoNovoExameClique);
            // 
            // botaoPaciente
            // 
            this.botaoPaciente.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_patients;
            this.botaoPaciente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.botaoPaciente.Name = "botaoPaciente";
            this.botaoPaciente.Size = new System.Drawing.Size(137, 36);
            this.botaoPaciente.Text = "Pacientes";
            this.botaoPaciente.Click += new System.EventHandler(this.botaoPacienteClique);
            // 
            // botaoConfiguracoes
            // 
            botaoConfiguracoes.Image = global::GeraçãoDeTemplate.Properties.Resources.icon_32x32_settings;
            botaoConfiguracoes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            botaoConfiguracoes.Name = "botaoConfiguracoes";
            botaoConfiguracoes.Size = new System.Drawing.Size(178, 36);
            botaoConfiguracoes.Text = "Configurações";
            botaoConfiguracoes.Click += new System.EventHandler(this.botaoConfiguracoesClique);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(979, 631);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem botaoNovoExame;
        private System.Windows.Forms.ToolStripMenuItem botaoPaciente;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}