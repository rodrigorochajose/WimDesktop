using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ManipulateTemplatePresenter
    {
        private IManipulateTemplateView manipulateTemplateView;
        private ITemplateRepository templateRepository;
        private ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public ManipulateTemplatePresenter(IManipulateTemplateView view, ITemplateRepository repository) 
        { 
            manipulateTemplateView = view;
            templateRepository = repository;

            manipulateTemplateView.eventSaveTemplate += saveTemplate;

            (manipulateTemplateView as Form).ShowDialog();
        }

        private void saveTemplate(object sender, EventArgs e)
        {
            try
            {
                int templateId = templateRepository.add(new Modelos.TemplateModel { name = manipulateTemplateView.templateName });
                MessageBox.Show(templateFrameRepository.add(templateId, manipulateTemplateView.framesList));
                (manipulateTemplateView as Form).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
