using System;
using System.Windows.Forms;

namespace DMMDigital.Interface.IView
{
    public interface IPatientView
    {
        string searchedValue { get; set; }
        int selectedPatientId { get; set; }

        event EventHandler eventSearchPatient;
        event EventHandler eventShowEditPatientForm;
        event EventHandler eventShowAddPatientForm;
        event EventHandler eventDeletePatient;
        event EventHandler eventOpenAllExams;

        void setPatientList(BindingSource patientList);
    }
}
