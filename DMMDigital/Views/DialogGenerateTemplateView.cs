using DMMDigital.Views;
using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace DMMDigital
{
    public partial class DialogGenerateTemplateView : Form, IDialogGenerateTemplateView
    {
        public DialogGenerateTemplateView()
        {
            InitializeComponent();

            listBoxOrientation.SelectedItem = listBoxOrientation.Items[0];

            buttonGenerateTemplate.Click += delegate { eventShowManipulateTemplateView?.Invoke(this, EventArgs.Empty); };
        }

        [Required(ErrorMessage = "Nome do Template é obrigatório.")]
        public string templateName 
        { 
            get { return textBoxTemplateName.Text; } 
            set { textBoxTemplateName.Text = value; } 
        }

        public int rows
        { 
            get { return decimal.ToInt32(numericUpDownRows.Value); }
            set { numericUpDownRows.Value = value; } 
        }

        public int columns
        { 
            get { return decimal.ToInt32(numericUpDownColumns.Value); }
            set { numericUpDownColumns.Value = value; } 
        }

        public string orientation
        { 
            get { return listBoxOrientation.Text; }
            set { listBoxOrientation.Text = value; } 
        }

        public event EventHandler eventShowManipulateTemplateView;

        private void buttonGenerateTemplate_Click(object sender, EventArgs e)
        {

        }
    }
}
