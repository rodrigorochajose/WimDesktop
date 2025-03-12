namespace DMMDigital.Views
{
    partial class PatientExamView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientExamView));
            this.roundedPanel1 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.roundedTextBoxObservation = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.roundedTextBoxRecommendation = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.roundedTextBoxName = new DMMDigital.Components.Rounded.RoundedTextBox();
            this.buttonDeletePatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonEditPatient = new DMMDigital.Components.Rounded.RoundedButton();
            this.textBoxPhone = new DMMDigital.Components.Rounded.RoundedMaskedTextBox();
            this.textBoxBirthDate = new DMMDigital.Components.Rounded.RoundedMaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new DMMDigital.Components.Rounded.RoundedPanel();
            this.dataGridViewExam = new DMMDigital.Components.Rounded.RoundedDataGridView();
            this.columnExamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSessionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnExamDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnEditExam = new System.Windows.Forms.DataGridViewImageColumn();
            this.columnDeleteExam = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonExportExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonNewExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.buttonOpenExam = new DMMDigital.Components.Rounded.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).BeginInit();
            this.SuspendLayout();
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedPanel1.BorderWidth = 5F;
            this.roundedPanel1.Controls.Add(this.roundedTextBoxObservation);
            this.roundedPanel1.Controls.Add(this.roundedTextBoxRecommendation);
            this.roundedPanel1.Controls.Add(this.roundedTextBoxName);
            this.roundedPanel1.Controls.Add(this.buttonDeletePatient);
            this.roundedPanel1.Controls.Add(this.buttonEditPatient);
            this.roundedPanel1.Controls.Add(this.textBoxPhone);
            this.roundedPanel1.Controls.Add(this.textBoxBirthDate);
            this.roundedPanel1.Controls.Add(this.label9);
            this.roundedPanel1.Controls.Add(this.label11);
            this.roundedPanel1.Controls.Add(this.label12);
            this.roundedPanel1.Controls.Add(this.label13);
            this.roundedPanel1.Controls.Add(this.label14);
            this.roundedPanel1.CornerRadius = 20;
            this.roundedPanel1.Location = new System.Drawing.Point(26, 48);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(348, 480);
            this.roundedPanel1.TabIndex = 19;
            // 
            // roundedTextBoxObservation
            // 
            this.roundedTextBoxObservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxObservation.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxObservation.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxObservation.BorderRadius = 10;
            this.roundedTextBoxObservation.BorderSize = 1;
            this.roundedTextBoxObservation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roundedTextBoxObservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxObservation.Location = new System.Drawing.Point(30, 326);
            this.roundedTextBoxObservation.Margin = new System.Windows.Forms.Padding(4);
            this.roundedTextBoxObservation.Multiline = true;
            this.roundedTextBoxObservation.Name = "roundedTextBoxObservation";
            this.roundedTextBoxObservation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.roundedTextBoxObservation.PasswordChar = false;
            this.roundedTextBoxObservation.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.roundedTextBoxObservation.PlaceholderText = "";
            this.roundedTextBoxObservation.Size = new System.Drawing.Size(302, 96);
            this.roundedTextBoxObservation.TabIndex = 84;
            this.roundedTextBoxObservation.Texts = "";
            this.roundedTextBoxObservation.UnderlinedStyle = false;
            // 
            // roundedTextBoxRecommendation
            // 
            this.roundedTextBoxRecommendation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxRecommendation.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxRecommendation.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxRecommendation.BorderRadius = 10;
            this.roundedTextBoxRecommendation.BorderSize = 1;
            this.roundedTextBoxRecommendation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roundedTextBoxRecommendation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxRecommendation.Location = new System.Drawing.Point(30, 255);
            this.roundedTextBoxRecommendation.Margin = new System.Windows.Forms.Padding(4);
            this.roundedTextBoxRecommendation.Multiline = false;
            this.roundedTextBoxRecommendation.Name = "roundedTextBoxRecommendation";
            this.roundedTextBoxRecommendation.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.roundedTextBoxRecommendation.PasswordChar = false;
            this.roundedTextBoxRecommendation.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.roundedTextBoxRecommendation.PlaceholderText = "";
            this.roundedTextBoxRecommendation.Size = new System.Drawing.Size(302, 36);
            this.roundedTextBoxRecommendation.TabIndex = 83;
            this.roundedTextBoxRecommendation.Texts = "";
            this.roundedTextBoxRecommendation.UnderlinedStyle = false;
            // 
            // roundedTextBoxName
            // 
            this.roundedTextBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedTextBoxName.BorderColor = System.Drawing.Color.White;
            this.roundedTextBoxName.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.roundedTextBoxName.BorderRadius = 10;
            this.roundedTextBoxName.BorderSize = 1;
            this.roundedTextBoxName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.roundedTextBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.roundedTextBoxName.Location = new System.Drawing.Point(30, 42);
            this.roundedTextBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.roundedTextBoxName.Multiline = false;
            this.roundedTextBoxName.Name = "roundedTextBoxName";
            this.roundedTextBoxName.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.roundedTextBoxName.PasswordChar = false;
            this.roundedTextBoxName.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.roundedTextBoxName.PlaceholderText = "";
            this.roundedTextBoxName.Size = new System.Drawing.Size(302, 36);
            this.roundedTextBoxName.TabIndex = 82;
            this.roundedTextBoxName.Texts = "";
            this.roundedTextBoxName.UnderlinedStyle = false;
            // 
            // buttonDeletePatient
            // 
            this.buttonDeletePatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonDeletePatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonDeletePatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonDeletePatient.BorderWidth = 5F;
            this.buttonDeletePatient.CornerRadius = 5;
            this.buttonDeletePatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeletePatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonDeletePatient.ForeColor = System.Drawing.Color.White;
            this.buttonDeletePatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeletePatient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonDeletePatient.Location = new System.Drawing.Point(35, 437);
            this.buttonDeletePatient.Name = "buttonDeletePatient";
            this.buttonDeletePatient.Size = new System.Drawing.Size(118, 30);
            this.buttonDeletePatient.TabIndex = 45;
            this.buttonDeletePatient.Text = "Excluir";
            this.buttonDeletePatient.UseVisualStyleBackColor = false;
            this.buttonDeletePatient.Click += new System.EventHandler(this.buttonDeletePatientClick);
            // 
            // buttonEditPatient
            // 
            this.buttonEditPatient.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonEditPatient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonEditPatient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonEditPatient.BorderWidth = 5F;
            this.buttonEditPatient.CornerRadius = 5;
            this.buttonEditPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonEditPatient.ForeColor = System.Drawing.Color.White;
            this.buttonEditPatient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditPatient.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEditPatient.Location = new System.Drawing.Point(214, 437);
            this.buttonEditPatient.Name = "buttonEditPatient";
            this.buttonEditPatient.Size = new System.Drawing.Size(118, 30);
            this.buttonEditPatient.TabIndex = 44;
            this.buttonEditPatient.Text = "Editar";
            this.buttonEditPatient.UseVisualStyleBackColor = false;
            this.buttonEditPatient.Click += new System.EventHandler(this.buttonEditPatientClick);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxPhone.BorderColor = System.Drawing.Color.White;
            this.textBoxPhone.BorderRadius = 10;
            this.textBoxPhone.BorderSize = 10;
            this.textBoxPhone.Enabled = false;
            this.textBoxPhone.ForeColor = System.Drawing.Color.Gray;
            this.textBoxPhone.Location = new System.Drawing.Point(25, 183);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(185, 44);
            this.textBoxPhone.TabIndex = 40;
            // 
            // textBoxBirthDate
            // 
            this.textBoxBirthDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.textBoxBirthDate.BorderColor = System.Drawing.Color.White;
            this.textBoxBirthDate.BorderRadius = 10;
            this.textBoxBirthDate.BorderSize = 10;
            this.textBoxBirthDate.Enabled = false;
            this.textBoxBirthDate.ForeColor = System.Drawing.Color.Gray;
            this.textBoxBirthDate.Location = new System.Drawing.Point(25, 112);
            this.textBoxBirthDate.Name = "textBoxBirthDate";
            this.textBoxBirthDate.Size = new System.Drawing.Size(185, 44);
            this.textBoxBirthDate.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(26, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 19);
            this.label9.TabIndex = 37;
            this.label9.Text = "Observação";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(26, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 19);
            this.label11.TabIndex = 36;
            this.label11.Text = "Indicação";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(26, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 19);
            this.label12.TabIndex = 35;
            this.label12.Text = "Telefone";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(26, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 19);
            this.label13.TabIndex = 34;
            this.label13.Text = "Data de Nascimento";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(26, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 19);
            this.label14.TabIndex = 33;
            this.label14.Text = "Nome";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(36, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Paciente";
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.White;
            this.roundedPanel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(242)))), ((int)(((byte)(246)))));
            this.roundedPanel2.BorderWidth = 5F;
            this.roundedPanel2.Controls.Add(this.dataGridViewExam);
            this.roundedPanel2.Controls.Add(this.buttonExportExam);
            this.roundedPanel2.Controls.Add(this.buttonNewExam);
            this.roundedPanel2.Controls.Add(this.buttonOpenExam);
            this.roundedPanel2.CornerRadius = 20;
            this.roundedPanel2.Location = new System.Drawing.Point(407, 48);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(643, 480);
            this.roundedPanel2.TabIndex = 48;
            // 
            // dataGridViewExam
            // 
            this.dataGridViewExam.AllowUserToAddRows = false;
            this.dataGridViewExam.AllowUserToDeleteRows = false;
            this.dataGridViewExam.AllowUserToResizeColumns = false;
            this.dataGridViewExam.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridViewExam.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewExam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridViewExam.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridViewExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewExam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewExam.BorderWidth = 5F;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewExam.ColumnHeadersHeight = 30;
            this.dataGridViewExam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewExam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnExamId,
            this.columnTemplateId,
            this.columnSessionName,
            this.columnExamDate,
            this.columnTemplate,
            this.columnEditExam,
            this.columnDeleteExam});
            this.dataGridViewExam.CornerRadius = 2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewExam.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewExam.EnableHeadersVisualStyles = false;
            this.dataGridViewExam.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.dataGridViewExam.Location = new System.Drawing.Point(13, 99);
            this.dataGridViewExam.MultiSelect = false;
            this.dataGridViewExam.Name = "dataGridViewExam";
            this.dataGridViewExam.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewExam.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewExam.RowHeadersVisible = false;
            this.dataGridViewExam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(144)))), ((int)(((byte)(153)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewExam.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewExam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewExam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExam.Size = new System.Drawing.Size(609, 369);
            this.dataGridViewExam.TabIndex = 38;
            this.dataGridViewExam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExamCellClick);
            this.dataGridViewExam.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewExamCellDoubleClick);
            this.dataGridViewExam.SelectionChanged += new System.EventHandler(this.dataGridViewExamSelectionChanged);
            // 
            // columnExamId
            // 
            this.columnExamId.DataPropertyName = "id";
            this.columnExamId.Frozen = true;
            this.columnExamId.HeaderText = "examId";
            this.columnExamId.Name = "columnExamId";
            this.columnExamId.ReadOnly = true;
            this.columnExamId.Visible = false;
            // 
            // columnTemplateId
            // 
            this.columnTemplateId.DataPropertyName = "templateId";
            this.columnTemplateId.Frozen = true;
            this.columnTemplateId.HeaderText = "templateId";
            this.columnTemplateId.Name = "columnTemplateId";
            this.columnTemplateId.ReadOnly = true;
            this.columnTemplateId.Visible = false;
            // 
            // columnSessionName
            // 
            this.columnSessionName.DataPropertyName = "sessionName";
            this.columnSessionName.Frozen = true;
            this.columnSessionName.HeaderText = "Nome da Sessão";
            this.columnSessionName.Name = "columnSessionName";
            this.columnSessionName.ReadOnly = true;
            this.columnSessionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnSessionName.Width = 197;
            // 
            // columnExamDate
            // 
            this.columnExamDate.DataPropertyName = "createdAt";
            this.columnExamDate.Frozen = true;
            this.columnExamDate.HeaderText = "Data do Exame";
            this.columnExamDate.Name = "columnExamDate";
            this.columnExamDate.ReadOnly = true;
            this.columnExamDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnExamDate.Width = 130;
            // 
            // columnTemplate
            // 
            this.columnTemplate.DataPropertyName = "name";
            this.columnTemplate.Frozen = true;
            this.columnTemplate.HeaderText = "Template";
            this.columnTemplate.Name = "columnTemplate";
            this.columnTemplate.ReadOnly = true;
            this.columnTemplate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.columnTemplate.Width = 150;
            // 
            // columnEditExam
            // 
            this.columnEditExam.Frozen = true;
            this.columnEditExam.HeaderText = "Editar";
            this.columnEditExam.Image = global::DMMDigital.Properties.Resources.icon_32x32_pencil;
            this.columnEditExam.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnEditExam.Name = "columnEditExam";
            this.columnEditExam.ReadOnly = true;
            this.columnEditExam.Width = 55;
            // 
            // columnDeleteExam
            // 
            this.columnDeleteExam.Frozen = true;
            this.columnDeleteExam.HeaderText = "Excluir";
            this.columnDeleteExam.Image = global::DMMDigital.Properties.Resources.icon_32x32_delete;
            this.columnDeleteExam.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.columnDeleteExam.Name = "columnDeleteExam";
            this.columnDeleteExam.ReadOnly = true;
            this.columnDeleteExam.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnDeleteExam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.columnDeleteExam.Width = 75;
            // 
            // buttonExportExam
            // 
            this.buttonExportExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonExportExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonExportExam.BorderWidth = 5F;
            this.buttonExportExam.CornerRadius = 5;
            this.buttonExportExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonExportExam.ForeColor = System.Drawing.Color.White;
            this.buttonExportExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExportExam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonExportExam.Location = new System.Drawing.Point(465, 35);
            this.buttonExportExam.Name = "buttonExportExam";
            this.buttonExportExam.Size = new System.Drawing.Size(132, 42);
            this.buttonExportExam.TabIndex = 43;
            this.buttonExportExam.Text = "Exportar Exame";
            this.buttonExportExam.UseVisualStyleBackColor = false;
            this.buttonExportExam.Click += new System.EventHandler(this.buttonExportExamClick);
            // 
            // buttonNewExam
            // 
            this.buttonNewExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonNewExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonNewExam.BorderWidth = 5F;
            this.buttonNewExam.CornerRadius = 5;
            this.buttonNewExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonNewExam.ForeColor = System.Drawing.Color.White;
            this.buttonNewExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNewExam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonNewExam.Location = new System.Drawing.Point(39, 35);
            this.buttonNewExam.Name = "buttonNewExam";
            this.buttonNewExam.Size = new System.Drawing.Size(130, 42);
            this.buttonNewExam.TabIndex = 40;
            this.buttonNewExam.Text = "Novo Exame";
            this.buttonNewExam.UseVisualStyleBackColor = false;
            this.buttonNewExam.Click += new System.EventHandler(this.buttonNewExamClick);
            // 
            // buttonOpenExam
            // 
            this.buttonOpenExam.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonOpenExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExam.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(194)))), ((int)(((byte)(207)))));
            this.buttonOpenExam.BorderWidth = 5F;
            this.buttonOpenExam.CornerRadius = 5;
            this.buttonOpenExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenExam.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonOpenExam.ForeColor = System.Drawing.Color.White;
            this.buttonOpenExam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpenExam.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOpenExam.Location = new System.Drawing.Point(257, 35);
            this.buttonOpenExam.Name = "buttonOpenExam";
            this.buttonOpenExam.Size = new System.Drawing.Size(129, 42);
            this.buttonOpenExam.TabIndex = 41;
            this.buttonOpenExam.Text = "Abrir Exame";
            this.buttonOpenExam.UseVisualStyleBackColor = false;
            this.buttonOpenExam.Click += new System.EventHandler(this.buttonOpenExamClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(415, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 25);
            this.label1.TabIndex = 47;
            this.label1.Text = "Exames do Paciente";
            // 
            // PatientExamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1072, 546);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientExamView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exames do Paciente";
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.Rounded.RoundedPanel roundedPanel1;
        private Components.Rounded.RoundedMaskedTextBox textBoxPhone;
        private Components.Rounded.RoundedMaskedTextBox textBoxBirthDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private Components.Rounded.RoundedPanel roundedPanel2;
        private Components.Rounded.RoundedDataGridView dataGridViewExam;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnExamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTemplateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSessionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnExamDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTemplate;
        private System.Windows.Forms.DataGridViewImageColumn columnEditExam;
        private System.Windows.Forms.DataGridViewImageColumn columnDeleteExam;
        private Components.Rounded.RoundedButton buttonExportExam;
        private Components.Rounded.RoundedButton buttonNewExam;
        private Components.Rounded.RoundedButton buttonOpenExam;
        private System.Windows.Forms.Label label1;
        private Components.Rounded.RoundedButton buttonEditPatient;
        private Components.Rounded.RoundedButton buttonDeletePatient;
        private Components.Rounded.RoundedTextBox roundedTextBoxObservation;
        private Components.Rounded.RoundedTextBox roundedTextBoxRecommendation;
        private Components.Rounded.RoundedTextBox roundedTextBoxName;
    }
}