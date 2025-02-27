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
    public class TemplateCreationDialogPresenter
    {
        private readonly ITemplateCreationDialog templateCreationDialog;

        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateCreationDialogPresenter(ITemplateCreationDialog view)
        {
            templateCreationDialog = view;

            templateCreationDialog.eventShowTemplateHandlerView += showTemplateHandlerView;

            templateCreationDialog.setTemplateList(templateRepository.getAllTemplates());
            templateCreationDialog.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (templateCreationDialog as Form).ShowDialog();
        }

        private void showTemplateHandlerView(object sender, EventArgs e)
        {
            try
            {
                TemplateCreationView templateHandlerView;

                new Common.ModelDataValidation().Validate(templateCreationDialog);

                if (templateCreationDialog.generateByTemplate)
                {
                    List<TemplateFrameModel> selectedFrames = templateCreationDialog.templateFrames.Where(t => t.templateId == templateCreationDialog.selectedTemplateId).ToList();

                    templateHandlerView = new TemplateCreationView(
                        templateCreationDialog.templateName,
                        selectedFrames
                    );
                }
                else
                {
                    templateHandlerView = new TemplateCreationView(
                        templateCreationDialog.templateName,
                        templateCreationDialog.rows,
                        templateCreationDialog.columns,
                        templateCreationDialog.orientation
                    );
                }

                (templateCreationDialog as Form).Close();
                new TemplateCreationPresenter(templateHandlerView);

            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
