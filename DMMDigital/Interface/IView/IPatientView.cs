using System;
using System.Windows.Forms;

namespace DMMDigital.Interface.IView
{
    public interface IPatientView
    {
        string searchedValue { get; set; }
        int selectedPatientId { get; set; }
        string columnNameToOrder { get; set; }
        bool isAsceding { get; set; }
        bool checkBoxFromState { get; set; }
        DateTime dateFrom { get; set; }
        bool checkBoxToState { get; set; }
        DateTime dateTo { get; set; }


        event EventHandler eventSearchPatient;
        event EventHandler eventShowAddPatientForm;
        event EventHandler eventOpenAllExams;
        event EventHandler eventOrderDataGridView;


        void setPatientList(BindingSource patientList);
    }
}
