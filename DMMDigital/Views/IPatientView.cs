using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public interface IPatientView
    {
        string searchedValue { get; set; }
        int selectedPatientId { get; set; }
        int selectedExamId { get; set; }

        // Eventos
        event EventHandler eventSearchPatient;
        event EventHandler eventShowEditPatientForm;
        event EventHandler eventShowAddPatientForm;
        event EventHandler eventDeletePatient;

        event EventHandler eventShowFormNewExam;
        event EventHandler eventGetPatientExams;
        event EventHandler eventOpenExam;
        event EventHandler eventDeleteExam;
        event EventHandler eventExportExam;


        // Metodos
        void setPatientList(BindingSource patientList);
        void setExamList(BindingSource examList);

        void manipulatePatientDataGridView();
        void manipulateExamDataGridView();

    }
}
