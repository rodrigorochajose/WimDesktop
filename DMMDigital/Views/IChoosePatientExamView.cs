using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public interface IChoosePatientExamView
    {
        string searchedValue { get; set; }
        int selectedPatientId { get; set; }

        // Eventos
        event EventHandler eventSearchPatient;
        event EventHandler eventShowAddPatientForm;

        event EventHandler eventSelectPatient;


        // Metodos
        void setPatientList(BindingSource patientList);

        void manipulateDataGridView();
    }
}
