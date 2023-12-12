using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Models;
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
        private IPatientRepository patientRepository;
        private BindingSource pacientesBindingSource;
        private IEnumerable<PatientModel> patientList;

        public ChoosePatientExamPresenter(IChoosePatientExamView view, IPatientRepository repository)
        {
            pacientesBindingSource = new BindingSource();
            choosePatientExamView = view;
            patientRepository = repository;

            choosePatientExamView.eventSearchPatient += searchPatient;
            choosePatientExamView.eventShowAddPatientView += showAddPatientForm;
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
                patientList = patientRepository.getPatientsByName(choosePatientExamView.searchedValue);
            }
            else
            {
                patientList = patientRepository.getAllPatients();
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

        private void showSelectTemplateForm(object sender, EventArgs e)
        {
            IChooseTemplateExamView chooseTemplateView = new ChooseTemplateExamView();

            PatientModel selectedPatient = patientRepository.getPatientById(choosePatientExamView.selectedPatientId);
            chooseTemplateView.patientId = selectedPatient.id;
            chooseTemplateView.patientName = selectedPatient.name;
            chooseTemplateView.patientBirthDate = selectedPatient.birthDate;
            chooseTemplateView.patientPhone = selectedPatient.phone;
            chooseTemplateView.patientRecommendation = selectedPatient.recommendation;
            chooseTemplateView.patientObservation = selectedPatient.observation;

            new ChooseTemplateExamPresenter(chooseTemplateView, new TemplateRepository());
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
                MessageBox.Show(patientRepository.add(newPatient));
                (sender as ManipulatePatientView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarTodosPacientes()
        {
            patientList = patientRepository.getAllPatients();
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
            choosePatientExamView.manipulateDataGridView();
        }
    }
}
