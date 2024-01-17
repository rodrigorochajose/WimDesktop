using DMMDigital._Repositories;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class DialogGenerateTemplatePresenter
    {
        private readonly IDialogGenerateTemplateView dialogGenerateTemplateView;

        public DialogGenerateTemplatePresenter(IDialogGenerateTemplateView view)
        {
            dialogGenerateTemplateView = view;

            dialogGenerateTemplateView.eventShowManipulateTemplateView += showManipulateTemplateView;

            (dialogGenerateTemplateView as Form).ShowDialog();
        }

        private void showManipulateTemplateView(object sender, EventArgs e)
        {
            try
            {
                new Common.ModelDataValidation().Validate(dialogGenerateTemplateView);

                ManipulateTemplateView manipulateTemplateView = new ManipulateTemplateView(
                    dialogGenerateTemplateView.templateName, 
                    dialogGenerateTemplateView.rows, 
                    dialogGenerateTemplateView.columns, 
                    dialogGenerateTemplateView.orientation
                );

                (dialogGenerateTemplateView as Form).Close();
                new ManipulateTemplatePresenter(manipulateTemplateView, new TemplateRepository());
                
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
