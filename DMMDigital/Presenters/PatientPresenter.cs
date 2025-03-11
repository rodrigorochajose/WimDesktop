using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Properties;
using DMMDigital.Views;
using MoreLinq;
using MoreLinq.Extensions;

namespace DMMDigital.Presenters
{
    public class PatientPresenter
    {
        public PatientView view { get; }

        private List<PatientModelDGV> patientsDGV = new List<PatientModelDGV>();
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

            IEnumerable<PatientModelDGV> filteredPatients = patientsDGV.Where(p => p.name.ToLower().Contains(view.searchedValue.ToLower()) && p.lastChange?.Date > dateFrom.Date && p.lastChange?.Date < dateTo.Date);

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

            IExamTemplateSelectionView examTemplateSelectionView = new ExamTemplateSelectionView();

            PatientModel selectedPatient = patientRepository.getPatientById(view.selectedPatientId);
            examTemplateSelectionView.patientId = selectedPatient.id;
            examTemplateSelectionView.patientName = selectedPatient.name;
            examTemplateSelectionView.patientBirthDate = selectedPatient.birthDate;
            examTemplateSelectionView.patientPhone = selectedPatient.phone;
            examTemplateSelectionView.patientRecommendation = selectedPatient.recommendation;
            examTemplateSelectionView.patientObservation = selectedPatient.observation;

            FormManager.instance.closeAllExceptExamAndMenu();

            new ExamTemplateSelectionPresenter(examTemplateSelectionView, view.GetType());
        }

        private void showPatientExamsForm(object sender, EventArgs e)
        {
            if (view.selectedPatientId == 0)
            {
                MessageBox.Show(Resources.messagePatientNotSelected);
                return;
            }

            PatientExamView patientExamView = new PatientExamView();

            new PatientExamPresenter(patientExamView, view.selectedPatientId, "newContainer");

            if (patientExamView.patientHasChanges)
            {
                loadAllPatients();
            }
        }

        private void loadAllPatients()
        {
            IEnumerable<PatientModel> patients = patientRepository.getAllPatients();

            if (patients.Any())
            {
                view.selectedPatientId = patients.First().id;

                patientsDGV = patients.Select(p => new PatientModelDGV
                {
                    id = p.id,
                    name = p.name,
                    lastChange = getLastUpdatedExam(p.id)
                }).ToList();

                patientBindingSource.DataSource = patientsDGV;
            }
        }

        private DateTime? getLastUpdatedExam(int patientId)
        {
            List<ExamModel> patientExams = examRepository.getPatientExams(patientId).OrderBy(pe => pe.updatedAt).ToList();

            if (patientExams.Any())
            {
                return patientExams.First().updatedAt;
            }

            return null;
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

                PatientModel patient = patientRepository.getPatientById(view.selectedPatientId);

                List<ExamModel> patientExams = examRepository.getPatientExams(view.selectedPatientId).ToList();

                new ExamPresenter(new ExamView(patientExams.First().id, patient, settingsRepository.getAllSettings()), true, "newContainer");

                foreach (ExamModel exam in patientExams.Skip(1))
                {
                    new ExamPresenter(new ExamView(exam.id, patient, settingsRepository.getAllSettings()), true, "newPage");
                }
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
                patientBindingSource.DataSource = view.isAsceding ? patientsDGV.OrderBy(p => p.name) : patientsDGV.OrderByDescending(p => p.name);
            }
            else
            {
                patientBindingSource.DataSource = view.isAsceding ? patientsDGV.OrderBy(p => p.lastChange) : patientsDGV.OrderByDescending(p => p.lastChange);

            }

            view.isAsceding = !view.isAsceding;
        }
    }
}

