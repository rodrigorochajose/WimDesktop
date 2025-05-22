using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Properties;
using WimDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class TemplateSwitchPresenter
    {
        private readonly int examId;
        private readonly int currentTemplateId;

        private readonly ITemplateSwitchView templateSwitchView;
        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateSwitchPresenter(ITemplateSwitchView templateSwitchView, int examId, int templateId) 
        {
            this.templateSwitchView = templateSwitchView;
            this.examId = examId;
            currentTemplateId = templateId;

            templateSwitchView.setTemplateList(templateRepository.getAllTemplates());
            templateSwitchView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
            templateSwitchView.showCurrentTemplate(currentTemplateId, templateRepository.getTemplateNameById(currentTemplateId));

            templateSwitchView.eventAddNewTemplate += showAddTemplateForm;
            templateSwitchView.eventSwitchTemplate += switchTemplate;
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new TemplateCreationSetupPresenter(new TemplateCreationSetupView());
            templateSwitchView.setTemplateList(templateRepository.getAllTemplates());
            templateSwitchView.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
        }

        private void switchTemplate(object sender, EventArgs e)
        {
            List<ExamImageModel> examImages = examImageRepository.getExamImages(examId).ToList();

            List<TemplateFrameModel> selectedTemplateFrames = templateFrameRepository.getTemplateFrame(templateSwitchView.selectedTemplateId);

            if (examImages.Count() > selectedTemplateFrames.Count())
            {
                System.Windows.MessageBox.Show(Resources.messageSwitchTemplateNotAvailable);
                return;
            }

            examRepository.updateExamTemplate(examId, templateSwitchView.selectedTemplateId);

            for (int counter = 0; counter < examImages.Count(); counter++)
            {
                examImages[counter].templateFrameId = selectedTemplateFrames[counter].id;
            }

            examImageRepository.save();

            MessageBox.Show(Resources.messageSwitchTemplateSuccess, (templateSwitchView as Form).Text);

            (templateSwitchView as Form).Close();
        }
    }
}
