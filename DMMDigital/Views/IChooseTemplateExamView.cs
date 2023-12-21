using DMMDigital.Models;
using System;
using System.Collections.Generic;

namespace DMMDigital.Views
{
    public interface IChooseTemplateExamView
    {
        int patientId { get; set; }
        string patientName { get; set; }
        DateTime patientBirthDate { get; set; }
        string patientPhone { get; set; }
        string patientRecommendation { get; set; }
        string patientObservation { get; set; }
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
