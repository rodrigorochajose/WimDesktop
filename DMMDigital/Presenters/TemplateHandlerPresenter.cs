using DMMDigital._Repositories;
using DMMDigital.Components;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class TemplateHandlerPresenter
    {
        private readonly ITemplateCreationView templateHandlerView;
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateHandlerPresenter(ITemplateCreationView view, ITemplateRepository repository) 
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
                templateRepository.addTemplate(new Models.TemplateModel { name = templateHandlerView.templateName });

                int templateId = templateRepository.getLastTemplateId();

                templateFrameRepository.addTemplateFrame(templateId, templateHandlerView.framesList.Cast<Frame>().ToList());
                (templateHandlerView as Form).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
