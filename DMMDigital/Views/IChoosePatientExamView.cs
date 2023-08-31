using System;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public interface IChoosePatientExamView
    {
        string searchedValue { get; set; }
        int selectedPatientId { get; set; }

        // Events
        event EventHandler eventSearchPatient;
        event EventHandler eventShowAddPatientView;
        event EventHandler eventSelectPatient;

        // Methods
        void setPatientList(BindingSource patientList);
        void manipulateDataGridView();
    }
}
