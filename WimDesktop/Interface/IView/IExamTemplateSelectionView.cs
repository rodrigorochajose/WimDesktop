using WimDesktop.Models;
using System;
using System.Collections.Generic;

namespace WimDesktop.Interface.IView
{
    public interface IExamTemplateSelectionView
    {
        int patientId { get; set; }
        string patientName { get; set; }
        DateTime patientBirthDate { set; }
        string patientPhone { set; }
        string patientRecommendation { set; }
        string patientObservation { set; }
        string sessionName { get; set; }
        int selectedTemplateId { get; }
        string selectedTemplateName { get; }
        List<TemplateFrameModel> templateFrames { get; }

        event EventHandler eventAddNewTemplate;
        event EventHandler eventInitializeExam;

        void setTemplateList(List<TemplateModel> templateList);
        void setTemplateFrameList(List<TemplateFrameModel> templateFrameList);

    }
}
