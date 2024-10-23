using DMMDigital._Repositories;
using DMMDigital.Components;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class TemplateCreationPresenter
    {
        private readonly ITemplateCreationView templateCreationView;
        private readonly ITemplateRepository templateRepository;
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateCreationPresenter(ITemplateCreationView view, ITemplateRepository repository) 
        { 
            templateCreationView = view;
            templateRepository = repository;

            templateCreationView.eventSaveTemplate += saveTemplate;

            (templateCreationView as Form).ShowDialog();
        }

        private void saveTemplate(object sender, EventArgs e)
        {
            try
            {
                templateRepository.addTemplate(new Models.TemplateModel { name = templateCreationView.templateName });

                int templateId = templateRepository.getLastTemplateId();

                templateFrameRepository.addTemplateFrame(templateId, templateCreationView.framesList.Cast<Frame>().ToList());
                (templateCreationView as Form).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
