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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateView));
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTemplate = new DMMDigital.Components.Rounded.RoundedDataGridView();
            this.columnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDeleteTemplate = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelShowTemplate = new DMMDigital.Components.Rounded.RoundedPanel();
            this.buttonNewTemplate = new DMMDigital.Components.Rounded.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "Templates";
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
            this.dataGridViewTemplate.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewTemplate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewTemplate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTemplate.BorderWidth = 5F;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTemplate.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTemplate.ColumnHeadersHeight = 30;
            this.dataGridViewTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnId,
            this.columnName,
            this.columnDeleteTemplate});
            this.dataGridViewTemplate.CornerRadius = 2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTemplate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTemplate.EnableHeadersVisualStyles = false;
            this.dataGridViewTemplate.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewTemplate.Location = new System.Drawing.Point(17, 54);
            this.dataGridViewTemplate.MultiSelect = false;
            this.dataGridViewTemplate.Name = "dataGridViewTemplate";
            this.dataGridViewTemplate.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTemplate.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTemplate.RowHeadersVisible = false;
            this.dataGridViewTemplate.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(144)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTemplate.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTemplate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewTemplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTemplate.Size = new System.Drawing.Size(327, 283);
            this.dataGridViewTemplate.TabIndex = 48;
            // 
            // columnId
            // 
            this.columnId.Frozen = true;
            this.columnId.HeaderText = "id";
            this.columnId.Name = "columnId";
            this.columnId.ReadOnly = true;
            this.columnId.Visible = false;
            // 
            // columnName
            // 
            this.columnName.DataPropertyName = "name";
            this.columnName.Frozen = true;
            this.columnName.HeaderText = "Nome";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnName.Width = 250;
            // 
            // columnDeleteTemplate
            // 
            this.columnDeleteTemplate.Frozen = true;
            this.columnDeleteTemplate.HeaderText = "Excluir";
            this.columnDeleteTemplate.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.columnDeleteTemplate.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnDeleteTemplate.Name = "columnDeleteTemplate";
            this.columnDeleteTemplate.ReadOnly = true;
            this.columnDeleteTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnDeleteTemplate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnDeleteTemplate.Width = 75;
            // 
            // panelShowTemplate
            // 
            this.panelShowTemplate.BackColor = System.Drawing.Color.Silver;
            this.panelShowTemplate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.panelShowTemplate.BorderWidth = 5F;
            this.panelShowTemplate.CornerRadius = 20;
            this.panelShowTemplate.Location = new System.Drawing.Point(377, 112);
            this.panelShowTemplate.Name = "panelShowTemplate";
            this.panelShowTemplate.Size = new System.Drawing.Size(350, 225);
            this.panelShowTemplate.TabIndex = 49;
            // 
            // buttonNewTemplate
            // 
            this.buttonNewTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewTemplate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewTemplate.BorderWidth = 5F;
            this.buttonNewTemplate.CornerRadius = 5;
            this.buttonNewTemplate.FlatAppearance.BorderSize = 0;
            this.buttonNewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewTemplate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNewTemplate.ForeColor = System.Drawing.Color.White;
            this.buttonNewTemplate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewTemplate.Location = new System.Drawing.Point(575, 54);
            this.buttonNewTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNewTemplate.Name = "buttonNewTemplate";
            this.buttonNewTemplate.Padding = new System.Windows.Forms.Padding(2);
            this.buttonNewTemplate.Size = new System.Drawing.Size(141, 42);
            this.buttonNewTemplate.TabIndex = 58;
            this.buttonNewTemplate.Text = "Novo Template";
            this.buttonNewTemplate.UseVisualStyleBackColor = false;
            // 
            // TemplateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(741, 355);
            this.Controls.Add(this.buttonNewTemplate);
            this.Controls.Add(this.panelShowTemplate);
            this.Controls.Add(this.dataGridViewTemplate);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedDataGridView dataGridViewTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewImageColumn columnDeleteTemplate;
        private Components.Rounded.RoundedPanel panelShowTemplate;
        private Components.Rounded.RoundedButton buttonNewTemplate;
    }
}