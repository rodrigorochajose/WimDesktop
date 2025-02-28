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
        private readonly ITemplateCreationView view;
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateCreationPresenter(ITemplateCreationView view) 
        { 
            this.view = view;

            view.eventSaveTemplate += saveTemplate;

            (view as Form).ShowDialog();
        }

        private void saveTemplate(object sender, EventArgs e)
        {
            try
            {
                templateRepository.addTemplate(new Models.TemplateModel { name = view.templateName });

                int templateId = templateRepository.getLastTemplateId();

                templateFrameRepository.addTemplateFrame(templateId, view.framesList.Cast<Frame>().ToList());
                (view as Form).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
