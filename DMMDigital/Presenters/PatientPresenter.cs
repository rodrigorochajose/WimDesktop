using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Forms;
using DMMDigital.Modelos;
using DMMDigital.Views;

namespace DMMDigital.Presenters
{
    public class PatientPresenter
    {
        private IPatientView patientView;
        private IPatientRepository repository;
        private PatientModel selectedPatient;
        private BindingSource pacientesBindingSource;
        private IEnumerable<PatientModel> patientList;

        public PatientPresenter(IPatientView view, IPatientRepository repository)
        {
            pacientesBindingSource = new BindingSource();
            patientView = view;
            this.repository = repository;

            patientView.eventSearchPatient += searchPatient;
            patientView.eventShowAddPatientForm += showAddPatientForm;
            patientView.eventShowEditPatientForm += showEditPatientForm;
            patientView.eventDeletePatient += deletePatient;

            patientView.setPatientList(pacientesBindingSource);

            carregarTodosPacientes();

            (patientView as Form).ShowDialog();
        }

        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(patientView.searchedValue);
            if (emptyValue == false)
            {
                patientList = repository.getPatientsByName(patientView.searchedValue);
            } else
            {
                patientList = repository.getAllPatients();
            }
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
        }

        private void showAddPatientForm(object sender, EventArgs e)
        {
            IManipulatePatientView manipulatePatientView = new ManipulatePatientView("add");
            manipulatePatientView.eventAddNewPatient += addNewPatient;
            (manipulatePatientView as Form).ShowDialog();
            carregarTodosPacientes();
        }

        private void showEditPatientForm(object sender, EventArgs e)
        {
            IManipulatePatientView manipulatePatientView = new ManipulatePatientView("edit");
            manipulatePatientView.eventSaveEditedPatient += saveEditedPatient;

            selectedPatient = repository.getPatientById(patientView.selectedPatientId);
            manipulatePatientView.patientId = selectedPatient.id;
            manipulatePatientView.patientName = selectedPatient.name;
            manipulatePatientView.patientBirthDate = selectedPatient.birthDate;
            manipulatePatientView.patientPhone = selectedPatient.phone;
            manipulatePatientView.patientRecommendation = selectedPatient.recommendation;
            manipulatePatientView.patientObservation = selectedPatient.observation;
            (manipulatePatientView as Form).ShowDialog();

            carregarTodosPacientes();
        }

        private void deletePatient(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(confirmacao))
            {
                MessageBox.Show(repository.delete(patientView.selectedPatientId));
                carregarTodosPacientes();
            }
        }

        private void saveEditedPatient(object sender, EventArgs e)
        {
            try
            {
                selectedPatient.id = (sender as ManipulatePatientView).patientId;
                selectedPatient.name = (sender as ManipulatePatientView).patientName;
                selectedPatient.birthDate = (sender as ManipulatePatientView).patientBirthDate;
                selectedPatient.phone = (sender as ManipulatePatientView).patientPhone;
                selectedPatient.recommendation = (sender as ManipulatePatientView).patientRecommendation;
                selectedPatient.observation = (sender as ManipulatePatientView).patientObservation;

                new Common.ModelDataValidation().Validate(selectedPatient);
                MessageBox.Show(repository.edit(selectedPatient));
                (sender as ManipulatePatientView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addNewPatient(object sender, EventArgs e)
        {
            try
            {
                selectedPatient = new PatientModel
                {
                    name = (sender as ManipulatePatientView).patientName,
                    birthDate = (sender as ManipulatePatientView).patientBirthDate,
                    phone = (sender as ManipulatePatientView).patientPhone,
                    recommendation = (sender as ManipulatePatientView).patientRecommendation,
                    observation = (sender as ManipulatePatientView).patientObservation,
                };

                new Common.ModelDataValidation().Validate(selectedPatient);
                MessageBox.Show(repository.add(selectedPatient));
                (sender as ManipulatePatientView).Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarTodosPacientes()
        {
            patientList = repository.getAllPatients();
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone});
            patientView.manipulateDataGridView();
        }
    }
}
