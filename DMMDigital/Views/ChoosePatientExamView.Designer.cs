namespace DMMDigital.Views
{
    partial class ChoosePatientExamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoosePatientExamView));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSearchPatient = new System.Windows.Forms.TextBox();
            this.dataGridViewPatient = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birthDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSelectPatient = new System.Windows.Forms.Button();
            this.buttonCancelAction = new System.Windows.Forms.Button();
            this.buttonNewPatient = new System.Windows.Forms.Button();
            this.buttonSearchPatient = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(165, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(375, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecione um paciente para o Exame";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Buscar";
            // 
            // textBoxSearchPatient
            // 
            this.textBoxSearchPatient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSearchPatient.Location = new System.Drawing.Point(61, 120);
            this.textBoxSearchPatient.Name = "textBoxSearchPatient";
            this.textBoxSearchPatient.Size = new System.Drawing.Size(309, 26);
            this.textBoxSearchPatient.TabIndex = 2;
            // 
            // dataGridViewPatient
            // 
            this.dataGridViewPatient.AllowUserToAddRows = false;
            this.dataGridViewPatient.AllowUserToDeleteRows = false;
            this.dataGridViewPatient.AllowUserToResizeColumns = false;
            this.dataGridViewPatient.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPatient.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.birthDate1,
            this.phone1});
            this.dataGridViewPatient.EnableHeadersVisualStyles = false;
            this.dataGridViewPatient.Location = new System.Drawing.Point(61, 172);
            this.dataGridViewPatient.MultiSelect = false;
            this.dataGridViewPatient.Name = "dataGridViewPatient";
            this.dataGridViewPatient.ReadOnly = true;
            this.dataGridViewPatient.RowHeadersVisible = false;
            this.dataGridViewPatient.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewPatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPatient.Size = new System.Drawing.Size(526, 313);
            this.dataGridViewPatient.TabIndex = 4;
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
            // birthDate1
            // 
            this.birthDate1.DataPropertyName = "birthDate";
            this.birthDate1.Frozen = true;
            this.birthDate1.HeaderText = "Data de Nascimento";
            this.birthDate1.Name = "birthDate1";
            this.birthDate1.ReadOnly = true;
            this.birthDate1.Width = 150;
            // 
            // phone1
            // 
            this.phone1.DataPropertyName = "phone";
            this.phone1.Frozen = true;
            this.phone1.HeaderText = "Telefone";
            this.phone1.Name = "phone1";
            this.phone1.ReadOnly = true;
            this.phone1.Width = 125;
            // 
            // buttonSelectPatient
            // 
            this.buttonSelectPatient.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.buttonSelectPatient.Location = new System.Drawing.Point(567, 510);
            this.buttonSelectPatient.Name = "buttonSelectPatient";
            this.buttonSelectPatient.Size = new System.Drawing.Size(73, 34);
            this.buttonSelectPatient.TabIndex = 6;
            this.buttonSelectPatient.Text = "Selecionar";
            this.buttonSelectPatient.UseVisualStyleBackColor = true;
            // 
            // buttonCancelAction
            // 
            this.buttonCancelAction.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.buttonCancelAction.Location = new System.Drawing.Point(30, 510);
            this.buttonCancelAction.Name = "buttonCancelAction";
            this.buttonCancelAction.Size = new System.Drawing.Size(73, 34);
            this.buttonCancelAction.TabIndex = 7;
            this.buttonCancelAction.Text = "Cancelar";
            this.buttonCancelAction.UseVisualStyleBackColor = true;
            // 
            // buttonNewPatient
            // 
            this.buttonNewPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNewPatient.Location = new System.Drawing.Point(505, 121);
            this.buttonNewPatient.Name = "buttonNewPatient";
            this.buttonNewPatient.Size = new System.Drawing.Size(82, 26);
            this.buttonNewPatient.TabIndex = 47;
            this.buttonNewPatient.Text = "Novo";
            this.buttonNewPatient.UseVisualStyleBackColor = true;
            // 
            // buttonSearchPatient
            // 
            this.buttonSearchPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSearchPatient.Location = new System.Drawing.Point(387, 120);
            this.buttonSearchPatient.Name = "buttonSearchPatient";
            this.buttonSearchPatient.Size = new System.Drawing.Size(96, 26);
            this.buttonSearchPatient.TabIndex = 46;
            this.buttonSearchPatient.Text = "Buscar";
            this.buttonSearchPatient.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DMMDigital.Properties.Resources.icon_32x32_patients;
            this.pictureBox1.Location = new System.Drawing.Point(121, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 48;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 78);
            this.panel1.TabIndex = 49;
            // 
            // ChoosePatientExamView
            // 
            this.ClientSize = new System.Drawing.Size(665, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonNewPatient);
            this.Controls.Add(this.buttonSearchPatient);
            this.Controls.Add(this.buttonCancelAction);
            this.Controls.Add(this.buttonSelectPatient);
            this.Controls.Add(this.dataGridViewPatient);
            this.Controls.Add(this.textBoxSearchPatient);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChoosePatientExamView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecione um paciente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSearchPatient;
        private System.Windows.Forms.DataGridView dataGridViewPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.Button buttonSelectPatient;
        private System.Windows.Forms.Button buttonCancelAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn birthDate1;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone1;
        private System.Windows.Forms.Button buttonNewPatient;
        private System.Windows.Forms.Button buttonSearchPatient;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}