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
    public class DialogGenerateTemplatePresenter
    {
        private readonly IDialogGenerateTemplate dialogGenerateTemplate;

        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public DialogGenerateTemplatePresenter(IDialogGenerateTemplate view)
        {
            dialogGenerateTemplate = view;

            dialogGenerateTemplate.eventShowTemplateHandlerView += showTemplateHandlerView;

            dialogGenerateTemplate.setTemplateList(templateRepository.getAllTemplates());
            dialogGenerateTemplate.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());

            (dialogGenerateTemplate as Form).ShowDialog();
        }

        private void showTemplateHandlerView(object sender, EventArgs e)
        {
            try
            {
                new Common.ModelDataValidation().Validate(dialogGenerateTemplate);

                if (dialogGenerateTemplate.generateByTemplate)
                {
                    List<TemplateFrameModel> selectedFrames = dialogGenerateTemplate.templateFrames.Where(t => t.templateId == dialogGenerateTemplate.selectedTemplateId).ToList();

                    TemplateHandlerView templateHandlerView = new TemplateHandlerView(
                        dialogGenerateTemplate.templateName,
                        selectedFrames
                    );

                    (dialogGenerateTemplate as Form).Close();
                    new TemplateHandlerPresenter(templateHandlerView, new TemplateRepository());
                }
                else
                {
                    TemplateHandlerView templateHandlerView = new TemplateHandlerView(
                        dialogGenerateTemplate.templateName,
                        dialogGenerateTemplate.rows,
                        dialogGenerateTemplate.columns,
                        dialogGenerateTemplate.orientation
                    );

                    (dialogGenerateTemplate as Form).Close();
                    new TemplateHandlerPresenter(templateHandlerView, new TemplateRepository());
                }
                
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
