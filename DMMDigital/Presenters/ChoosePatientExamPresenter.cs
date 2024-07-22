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
        public ChoosePatientExamView view { get; }

        private readonly IPatientRepository patientRepository;
        private readonly BindingSource pacientesBindingSource;
        private IEnumerable<PatientModel> patientList;

        public ChoosePatientExamPresenter(ChoosePatientExamView choosePatientExamView, IPatientRepository repository)
        {
            pacientesBindingSource = new BindingSource();
            view = choosePatientExamView;
            patientRepository = repository;

            view.eventSearchPatient += searchPatient;
            view.eventNewPatient += newPatient;
            view.eventSelectPatient += showSelectTemplateForm;

            view.setPatientList(pacientesBindingSource);

            loadAllPatients();
        }

        private void loadAllPatients()
        {
            patientList = patientRepository.getAllPatients();

            if (patientList.Any())
            {
                view.selectedPatientId = patientList.First().id;
                pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
                view.dataGridViewHandler();
            }
        }

        private void newPatient(object sender, EventArgs e)
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
            bool emptyValue = string.IsNullOrWhiteSpace(view.searchedValue);
            patientList = emptyValue == false ? patientRepository.getPatientsByName(view.searchedValue) : patientRepository.getAllPatients();
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
        }

        private void showSelectTemplateForm(object sender, EventArgs e)
        {
            IChooseTemplateExamView chooseTemplateView = new ChooseTemplateExamView();
            
            PatientModel selectedPatient = patientRepository.getPatientById(view.selectedPatientId);
            chooseTemplateView.patientId = selectedPatient.id;
            chooseTemplateView.patientName = selectedPatient.name;
            chooseTemplateView.patientBirthDate = selectedPatient.birthDate;
            chooseTemplateView.patientPhone = selectedPatient.phone;
            chooseTemplateView.patientRecommendation = selectedPatient.recommendation;
            chooseTemplateView.patientObservation = selectedPatient.observation;

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                loadAllPatients();
                form.Hide();
            }

            new ChooseTemplateExamPresenter(chooseTemplateView, new TemplateRepository(), "choosePatientView");
        }
    }
}
