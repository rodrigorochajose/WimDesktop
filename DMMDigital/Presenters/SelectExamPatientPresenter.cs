using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class SelectExamPatientPresenter
    {
        public SelectExamPatientView view { get; }

        private IEnumerable<PatientModel> patientList;
        private readonly BindingSource pacientesBindingSource;

        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public SelectExamPatientPresenter(SelectExamPatientView view)
        {
            pacientesBindingSource = new BindingSource();
            this.view = view;

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
            IPatientManagerView patientHandlerView = new PatientManagerView("add");
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
                    id = (sender as PatientManagerView).patientId,
                    name = (sender as PatientManagerView).patientName,
                    birthDate = (sender as PatientManagerView).patientBirthDate,
                    phone = (sender as PatientManagerView).patientPhone,
                    recommendation = (sender as PatientManagerView).patientRecommendation,
                    observation = (sender as PatientManagerView).patientObservation,
                };

                new Common.ModelDataValidation().Validate(newPatient);
                patientRepository.addPatient(newPatient);
                (sender as PatientManagerView).Close();

                string examPath = settingsRepository.getExamPath();
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
            ITemplateExamView templateView = new TemplateExamView();
            
            PatientModel selectedPatient = patientRepository.getPatientById(view.selectedPatientId);
            templateView.patientId = selectedPatient.id;
            templateView.patientName = selectedPatient.name;
            templateView.patientBirthDate = selectedPatient.birthDate;
            templateView.patientPhone = selectedPatient.phone;
            templateView.patientRecommendation = selectedPatient.recommendation;
            templateView.patientObservation = selectedPatient.observation;

            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                //loadAllPatients();
                form.Hide();
            }

            new TemplateExamPresenter(templateView, new TemplateRepository(), view.GetType());
        }
    }
}
