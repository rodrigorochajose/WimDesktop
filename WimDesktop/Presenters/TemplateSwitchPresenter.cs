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

        private readonly ITemplateSwitchView view;
        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly ITemplateRepository templateRepository = new TemplateRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

        public TemplateSwitchPresenter(ITemplateSwitchView view, int examId, int templateId) 
        {
            this.view = view;
            this.examId = examId;
            currentTemplateId = templateId;

            setTemplateAndTemplateFrameList();
            view.showCurrentTemplate(currentTemplateId, templateRepository.getTemplateNameById(currentTemplateId));

            view.eventAddNewTemplate += showAddTemplateForm;
            view.eventSwitchTemplate += switchTemplate;
        }

        private void showAddTemplateForm(object sender, EventArgs e)
        {
            new TemplateCreationSetupPresenter(new TemplateCreationSetupView());
            setTemplateAndTemplateFrameList();
        }

        private void setTemplateAndTemplateFrameList()
        {
            view.setTemplateList(templateRepository.getAllTemplates());
            view.setTemplateFrameList(templateFrameRepository.getAllTemplateFrame());
        }

        private void switchTemplate(object sender, EventArgs e)
        {
            List<ExamImageModel> examImages = examImageRepository.getExamImages(examId).ToList();

            if (examImages.Count() > view.templateFrameList.Count())
            {
                System.Windows.MessageBox.Show(Resources.messageSwitchTemplateNotAvailable);
                return;
            }

            examRepository.updateExamTemplate(examId, view.selectedTemplateId);

            for (int counter = 0; counter < examImages.Count(); counter++)
            {
                examImages[counter].templateFrameId = view.templateFrameList[counter].id;
            }

            examImageRepository.save();

            MessageBox.Show(Resources.messageSwitchTemplateSuccess, (view as Form).Text);

            (view as Form).Close();
        }

    }
}
