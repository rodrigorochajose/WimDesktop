using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital
{
    public partial class DialogGenerateTemplateView : Form, IDialogGenerateTemplateView
    {
        public DialogGenerateTemplateView()
        {
            InitializeComponent();

            buttonGenerateTemplate.Click += delegate
            {
                this.Close();

            };
        }

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
    }
}
