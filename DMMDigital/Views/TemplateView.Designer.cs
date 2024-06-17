namespace DMMDigital.Views
{
    partial class TemplateView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateView));
            this.buttonNewTemplate = new System.Windows.Forms.Button();
            this.dataGridViewTemplate = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelShowTemplate = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNewTemplate
            // 
            this.buttonNewTemplate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNewTemplate.Location = new System.Drawing.Point(647, 44);
            this.buttonNewTemplate.Name = "buttonNewTemplate";
            this.buttonNewTemplate.Size = new System.Drawing.Size(112, 34);
            this.buttonNewTemplate.TabIndex = 1;
            this.buttonNewTemplate.Text = "Novo Template";
            this.buttonNewTemplate.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTemplate
            // 
            this.dataGridViewTemplate.AllowUserToAddRows = false;
            this.dataGridViewTemplate.AllowUserToDeleteRows = false;
            this.dataGridViewTemplate.AllowUserToResizeColumns = false;
            this.dataGridViewTemplate.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewTemplate.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTemplate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.delete});
            this.dataGridViewTemplate.EnableHeadersVisualStyles = false;
            this.dataGridViewTemplate.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewTemplate.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewTemplate.MultiSelect = false;
            this.dataGridViewTemplate.Name = "dataGridViewTemplate";
            this.dataGridViewTemplate.ReadOnly = true;
            this.dataGridViewTemplate.RowHeadersVisible = false;
            this.dataGridViewTemplate.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dataGridViewTemplate.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTemplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTemplate.Size = new System.Drawing.Size(352, 298);
            this.dataGridViewTemplate.TabIndex = 45;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.Frozen = true;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.Frozen = true;
            this.name.HeaderText = "Nome";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 250;
            // 
            // delete
            // 
            this.delete.Frozen = true;
            this.delete.HeaderText = "Excluir";
            this.delete.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panelShowTemplate
            // 
            this.panelShowTemplate.BackColor = System.Drawing.Color.Silver;
            this.panelShowTemplate.Location = new System.Drawing.Point(409, 117);
            this.panelShowTemplate.Name = "panelShowTemplate";
            this.panelShowTemplate.Size = new System.Drawing.Size(350, 225);
            this.panelShowTemplate.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 47;
            this.label1.Text = "Templates";
            // 
            // TemplateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewTemplate);
            this.Controls.Add(this.panelShowTemplate);
            this.Controls.Add(this.buttonNewTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Template";
            this.Load += new System.EventHandler(this.templateViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonNewTemplate;
        private System.Windows.Forms.DataGridView dataGridViewTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewImageColumn delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelShowTemplate;
    }
}