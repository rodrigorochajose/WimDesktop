using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace DMMDigital.Presenters
{
    public class TemplateCreationSetupPresenter
    {
        private readonly ITemplateCreationSetupView view;

        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateCreationSetupPresenter(ITemplateCreationSetupView view)
        {
            this.view = view;

            view.eventShowTemplateHandlerView += showTemplateHandlerView;

            view.setTemplateList(templateRepository.getAllTemplates());
            view.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (view as Form).ShowDialog();
        }

        private void showTemplateHandlerView(object sender, EventArgs e)
        {
            try
            {
                TemplateCreationView templateHandlerView;

                new Common.ModelDataValidation().Validate(view);

                if (view.generateByTemplate)
                {
                    List<TemplateFrameModel> selectedFrames = view.templateFrames.Where(t => t.templateId == view.selectedTemplateId).ToList();

                    templateHandlerView = new TemplateCreationView(
                        view.templateName,
                        selectedFrames
                    );
                }
                else
                {
                    templateHandlerView = new TemplateCreationView(
                        view.templateName,
                        view.rows,
                        view.columns,
                        view.orientation
                    );
                }

                (view as Form).Close();
                new TemplateCreationPresenter(templateHandlerView);

            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
