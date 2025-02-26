using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using MoreLinq.Extensions;

namespace DMMDigital.Presenters
{
    public class PatientPresenter
    {
        public PatientView view { get; }

        private PatientModel selectedPatient;
        private IEnumerable<PatientModel> patientList;
        private readonly BindingSource patientBindingSource;

        private readonly ISettingsRepository settingsRepository = new SettingsRepository();
        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly IExamRepository examRepository = new ExamRepository();

        public PatientPresenter(PatientView patientView)
        {
            patientBindingSource = new BindingSource();

            view = patientView;

            view.eventSearchPatient += searchPatient;
            view.eventShowAddPatientForm += showAddPatientForm;

            view.setPatientList(patientBindingSource);

            loadAllPatients();
        }

        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(view.searchedValue);
            patientList = emptyValue == false ? patientRepository.getPatientsByName(view.searchedValue) : patientRepository.getAllPatients();

            if (patientList.Any())
            {
                patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
            }
            else
            {
                view.selectedPatientId = 0;
                patientBindingSource.Clear();
            }
        }

        private void showAddPatientForm(object sender, EventArgs e)
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
                selectedPatient = new PatientModel
                {
                    name = (sender as PatientManagerView).patientName,
                    birthDate = (sender as PatientManagerView).patientBirthDate,
                    phone = (sender as PatientManagerView).patientPhone,
                    recommendation = (sender as PatientManagerView).patientRecommendation,
                    observation = (sender as PatientManagerView).patientObservation
                };

                new Common.ModelDataValidation().Validate(selectedPatient);
                patientRepository.addPatient(selectedPatient);
                (sender as PatientManagerView).Close();

                string examPath = settingsRepository.getExamPath();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAllPatients()
        {
            patientList = patientRepository.getAllPatients();

            if (patientList.Any())
            {
                view.selectedPatientId = patientList.First().id;

                patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, lastChange = getLastUpdatedExam(p.id)});
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
    }
}
