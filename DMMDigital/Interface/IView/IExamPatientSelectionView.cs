using System;
using System.Windows.Forms;

namespace DMMDigital.Interface.IView
{
    public interface IExamPatientSelectionView
    {
        string searchedValue { get; set; }
        int selectedPatientId { get; set; }

        event EventHandler eventSearchPatient;
        event EventHandler eventAddNewPatient;
        event EventHandler eventSelectPatient;

        void setPatientList(BindingSource patientList);
        void dataGridViewHandler();
    }
}
