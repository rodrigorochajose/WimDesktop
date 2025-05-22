using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class ExamPatientSelectionPresenter
    {
        public ExamPatientSelectionView view { get; }

        private IEnumerable<PatientModel> patientList;
        private readonly BindingSource pacientesBindingSource;

        private readonly IPatientRepository patientRepository = new PatientRepository();

        public ExamPatientSelectionPresenter(ExamPatientSelectionView view)
        {
            pacientesBindingSource = new BindingSource();
            this.view = view;

            view.eventSearchPatient += searchPatient;
            view.eventAddNewPatient += showAddPatientForm;
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

        private void showAddPatientForm(object sender, EventArgs e)
        {
            IPatientCreationView patientCreationView = new PatientCreationView();
            new PatientCreationPresenter(patientCreationView);
            (patientCreationView as Form).ShowDialog();
            loadAllPatients();
        }

        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(view.searchedValue);
            patientList = emptyValue == false ? patientRepository.getPatientsByName(view.searchedValue) : patientRepository.getAllPatients();
            pacientesBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
        }

        private void showSelectTemplateForm(object sender, EventArgs e)
        {
            IExamTemplateSelectionView templateView = new ExamTemplateSelectionView();
            
            PatientModel selectedPatient = patientRepository.getPatientById(view.selectedPatientId);
            templateView.patientId = selectedPatient.id;
            templateView.patientName = selectedPatient.name;
            templateView.patientBirthDate = selectedPatient.birthDate;
            templateView.patientPhone = selectedPatient.phone;
            templateView.patientRecommendation = selectedPatient.recommendation;
            templateView.patientObservation = selectedPatient.observation;

            foreach (Form form in Application.OpenForms)
            {
                form.Hide();
            }

            new ExamTemplateSelectionPresenter(templateView, view.GetType());
        }
    }
}
