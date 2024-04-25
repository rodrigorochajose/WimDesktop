using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class TemplateHandlerPresenter
    {
        private readonly ITemplateHandlerView templateHandlerView;
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateHandlerPresenter(ITemplateHandlerView view, ITemplateRepository repository) 
        { 
            templateHandlerView = view;
            templateRepository = repository;

            templateHandlerView.eventSaveTemplate += saveTemplate;

            (templateHandlerView as Form).ShowDialog();
        }

        private void saveTemplate(object sender, EventArgs e)
        {
            try
            {
                int templateId = templateRepository.add(new Models.TemplateModel { name = templateHandlerView.templateName });
                MessageBox.Show(templateFrameRepository.add(templateId, templateHandlerView.framesList));
                (templateHandlerView as Form).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
