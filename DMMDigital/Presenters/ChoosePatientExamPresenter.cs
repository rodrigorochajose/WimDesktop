using DMMDigital._Repositories;
using DMMDigital.Forms;
using DMMDigital.Interface;
using DMMDigital.Modelos;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ChoosePatientExamPresenter
    {
        private IChoosePatientExamView choosePatientExamView;
        private IPatientRepository repository;
        private BindingSource pacientesBindingSource;
        private IEnumerable<PatientModel> patientList;


        public ChoosePatientExamPresenter(IChoosePatientExamView view, IPatientRepository repository)
        {
            this.pacientesBindingSource = new BindingSource();
            choosePatientExamView = view;
            this.repository = repository;

            choosePatientExamView.eventSearchPatient += searchPatient;
            choosePatientExamView.eventShowAddPatientForm += showAddPatientForm;
            choosePatientExamView.eventSelectPatient += showSelectTemplateForm;

            choosePatientExamView.setPatientList(pacientesBindingSource);

            carregarTodosPacientes();

            (choosePatientExamView as Form).ShowDialog();
        }


        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(choosePatientExamView.searchedValue);
            if (emptyValue == false)
            {
                patientList = repository.getPatientsByName(choosePatientExamView.searchedValue);
            }
            else
            {
                patientList = repository.getAllPatients();
            }
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
        }

        private void showAddPatientForm(object sender, EventArgs e)
        {
            IManipulatePatientView view = new ManipulatePatientView("add");
            view.eventAddNewPatient += addNewPatient;
            (view as Form).ShowDialog();
            carregarTodosPacientes();
        }

        private void showSelectTemplateForm(object sender, EventArgs e)
        {
            IChooseTemplateExamView view = new ChooseTemplateExamView();
            ITemplateRepository templateRepository = new TemplateRepository();
            new ChooseTemplateExamPresenter(view, templateRepository);

            PatientModel selectedPatient = repository.getPatientById(choosePatientExamView.selectedPatientId);
            view.patientId = selectedPatient.id;
            view.patientName = selectedPatient.name;
            view.patientBirthDate = selectedPatient.birthDate;
            view.patientPhone = selectedPatient.phone;
            view.patientRecommendation = selectedPatient.recommendation;
            view.patientObservation = selectedPatient.observation;
            (view as Form).ShowDialog();
        }

        private void addNewPatient(object sender, EventArgs e)
        {
            try
            {
                PatientModel newPatient = new PatientModel
                {
                    id = (sender as ManipulatePatientView).patientId,
                    name = (sender as ManipulatePatientView).patientName,
                    birthDate = (sender as ManipulatePatientView).patientBirthDate,
                    phone = (sender as ManipulatePatientView).patientPhone,
                    recommendation = (sender as ManipulatePatientView).patientRecommendation,
                    observation = (sender as ManipulatePatientView).patientObservation,
                };

                new Common.ModelDataValidation().Validate(newPatient);
                MessageBox.Show(repository.add(newPatient));
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
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
            choosePatientExamView.manipulateDataGridView();
        }
    }
}
