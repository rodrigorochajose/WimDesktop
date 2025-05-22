using WimDesktop._Repositories;
using WimDesktop.Components;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
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
