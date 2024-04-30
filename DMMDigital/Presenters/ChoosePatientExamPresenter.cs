using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
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
        private readonly IChoosePatientExamView choosePatientExamView;
        private readonly IPatientRepository patientRepository;
        private readonly BindingSource pacientesBindingSource;
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

            loadAllPatients();

            (choosePatientExamView as Form).ShowDialog();
        }

        private void loadAllPatients()
        {
            patientList = patientRepository.getAllPatients();

            if (patientList.Any())
            {
                choosePatientExamView.selectedPatientId = patientList.First().id;
                pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
                choosePatientExamView.dataGridViewHandler();
            }
        }

        private void showAddPatientForm(object sender, EventArgs e)
        {
            IPatientHandlerView patientHandlerView = new PatientHandlerView("add");
            patientHandlerView.eventAddNewPatient += addNewPatient;
            (patientHandlerView as Form).ShowDialog();

            loadAllPatients();
        }

        private void addNewPatient(object sender, EventArgs e)
        {
            try
            {
                PatientModel newPatient = new PatientModel
                {
                    id = (sender as PatientHandlerView).patientId,
                    name = (sender as PatientHandlerView).patientName,
                    birthDate = (sender as PatientHandlerView).patientBirthDate,
                    phone = (sender as PatientHandlerView).patientPhone,
                    recommendation = (sender as PatientHandlerView).patientRecommendation,
                    observation = (sender as PatientHandlerView).patientObservation,
                };

                new Common.ModelDataValidation().Validate(newPatient);
                patientRepository.addPatient(newPatient);
                (sender as PatientHandlerView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(choosePatientExamView.searchedValue);
            patientList = emptyValue == false ? patientRepository.getPatientsByName(choosePatientExamView.searchedValue) : patientRepository.getAllPatients();
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
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

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                form.Hide();
            }

            new ChooseTemplateExamPresenter(chooseTemplateView, new TemplateRepository(), "choosePatientView");
        }
    }
}
