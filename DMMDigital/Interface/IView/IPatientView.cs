using System;
using System.Windows.Forms;

namespace DMMDigital.Interface.IView
{
    public interface IPatientView
    {
        string searchedValue { get; set; }
        int selectedPatientId { get; set; }
        int selectedExamId { get; set; }
        string selectedExamPath { get; set; }

        event EventHandler eventSearchPatient;
        event EventHandler eventShowEditPatientForm;
        event EventHandler eventShowAddPatientForm;
        event EventHandler eventDeletePatient;

        event EventHandler eventShowFormNewExam;
        event EventHandler eventGetPatientExams;
        event EventHandler eventOpenExam;
        event EventHandler eventDeleteExam;
        event EventHandler eventExportExam;

        void setPatientList(BindingSource patientList);
        void setExamList(BindingSource examList);

        void patientDataGridViewHandler();
        void examDataGridViewHandler();

    }
}
