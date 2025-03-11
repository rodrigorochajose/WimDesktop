using System;
using System.Windows.Forms;

namespace DMMDigital.Interface.IView
{
    public interface IPatientExamView
    {
        int selectedExamId { get; set; }
        int selectedTemplateId { get; set; }
        string selectedExamPath { get; set; }
        int patientId { get; set; }
        string patientName { get; set; }
        DateTime patientBirthDate { get; set; }
        string patientPhone { get; set; }
        string patientRecommendation { get; set; }
        string patientObservation { get; set; }
        bool patientHasChanges { get; set; }


        event EventHandler eventEditPatient;
        event EventHandler eventDeletePatient;

        event EventHandler eventShowFormNewExam;
        event EventHandler eventOpenExam;
        event EventHandler eventDeleteExam;
        event EventHandler eventExportExam;
        event EventHandler eventSwitchTemplate;

        void setExamList(BindingSource examList);
    }
}
