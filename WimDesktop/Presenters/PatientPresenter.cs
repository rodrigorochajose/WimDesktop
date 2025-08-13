using MoreLinq;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Models.Dto;
using WimDesktop.Properties;
using WimDesktop.Views;

namespace WimDesktop.Presenters
{
    public class PatientPresenter
    {
        public PatientView view { get; }

        private List<PatientDataToListDto> patients = new List<PatientDataToListDto>();
        private readonly BindingSource patientBindingSource;
        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public PatientPresenter(PatientView patientView)
        {
            patientBindingSource = new BindingSource();

            view = patientView;

            view.eventSearchPatient += searchPatient;
            view.eventNewPatient += showCreatePatientForm;
            view.eventNewExam += showNewExamForm;
            view.eventShowPatientExams += showPatientExamsForm;
            view.eventOpenAllExams += openAllExams;
            view.eventOrderDataGridView += orderDataGridView;

            view.setPatientList(patientBindingSource);

            loadAllPatients();
        }

        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(view.searchedValue);

            string patientName = view.searchedValue == null ? "" : view.searchedValue;
            DateTime dateFrom = view.checkBoxFromState ? view.dateFrom : new DateTime(2000, 01, 01);
            DateTime dateTo = view.checkBoxToState ? view.dateTo : DateTime.Now;

            List<PatientDataToListDto> filteredPatients = patients
                .Where(p =>
                    p.name.ToLower().Contains(view.searchedValue.ToLower()) &&
                    (p.lastChange ?? dateFrom.Date).Date >= dateFrom.Date &&
                    (p.lastChange ?? dateTo.Date).Date <= dateTo.Date)
                .ToList();

            if (filteredPatients.Any())
            {
                patientBindingSource.DataSource = filteredPatients;
            }
            else
            {
                view.selectedPatientId = 0;
                patientBindingSource.Clear();
            }
        }

        private void showCreatePatientForm(object sender, EventArgs e)
        {
            IPatientCreationView patientCreationView = new PatientCreationView();
            new PatientCreationPresenter(patientCreationView);
            (patientCreationView as Form).ShowDialog();
            loadAllPatients();
        }

        private void showNewExamForm(object sender, EventArgs e)
        {
            if (view.selectedPatientId == 0)
            {
                MessageBox.Show(Resources.messagePatientNotSelected);
                return;
            }

            FormManager.instance.closeAllExceptExamAndMenu();

            new ExamTemplateSelectionPresenter(new ExamTemplateSelectionView(), view.selectedPatientId);
        }

        private void showPatientExamsForm(object sender, EventArgs e)
        {
            if (view.selectedPatientId == 0)
            {
                MessageBox.Show(Resources.messagePatientNotSelected);
                return;
            }

            PatientExamView patientExamView = new PatientExamView();

            new PatientExamPresenter(patientExamView, view.selectedPatientId);

            if (patientExamView.patientHasChanges)
            {
                loadAllPatients();
            }
        }

        private void loadAllPatients()
        {
            patients = patientRepository.getAllPatientsDataToList();

            if (patients.Any())
            {
                view.selectedPatientId = patients.First().id;

                foreach (PatientDataToListDto patient in patients)
                {
                    patient.lastChange = getLastUpdatedExam(patient.id);
                }

                patientBindingSource.DataSource = patients;
            }
        }

        private DateTime? getLastUpdatedExam(int patientId)
        {
            return examRepository.getPatientLastUpdatedExam(patientId);
        }

        private void openAllExams(object sender, EventArgs e)
        {
            try
            {
                if (!examRepository.patientHasExams(view.selectedPatientId))
                {
                    MessageBox.Show("O Paciente não possui exames");
                    return;
                }

                FormManager.instance.closeAllExceptExamAndMenu();

                List<ExamModel> patientExams = examRepository.getPatientExams(view.selectedPatientId).ToList();

                SettingsModel settings = settingsRepository.getAllSettings();

                new ExamContainerPresenter(new ExamContainerView(patientExams, view.selectedPatientId, settings));
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderDataGridView(object sender, EventArgs e)
        {
            OrderByDirection sortMode = view.isAsceding ? OrderByDirection.Ascending : OrderByDirection.Descending;

            if (view.columnNameToOrder == "columnPatientName")
            {
                patientBindingSource.DataSource = view.isAsceding ? patients.OrderBy(p => p.name) : patients.OrderByDescending(p => p.name);
            }
            else
            {
                patientBindingSource.DataSource = view.isAsceding ? patients.OrderBy(p => p.lastChange) : patients.OrderByDescending(p => p.lastChange);

            }

            view.isAsceding = !view.isAsceding;
        }
    }
}

