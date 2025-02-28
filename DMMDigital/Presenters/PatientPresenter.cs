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
        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly IExamRepository examRepository = new ExamRepository();

        public PatientPresenter(PatientView patientView)
        {
            patientBindingSource = new BindingSource();

            view = patientView;

            view.eventSearchPatient += searchPatient;
            view.eventShowAddPatientForm += showAddPatientForm;
            view.eventOpenAllExams += openAllExams;

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
            IPatientCreationView patientCreationView = new PatientCreationView();
            new PatientCreationPresenter(patientCreationView);
            (patientCreationView as Form).ShowDialog();
            loadAllPatients();
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

        private void openAllExams(object sender, EventArgs e)
        {
            try
            {
                if (!examRepository.patientHasExams(view.selectedPatientId))
                {
                    MessageBox.Show("O Paciente não possui exames");
                    return;
                }

                PatientModel patient = patientRepository.getPatientById(view.selectedPatientId);

                List<ExamModel> patientExams = examRepository.getPatientExams(view.selectedPatientId).ToList();

                new ExamPresenter(new ExamView(patientExams.First().id, patient), true, "newContainer");

                foreach (ExamModel exam in patientExams.Skip(1))
                {
                    new ExamPresenter(new ExamView(exam.id, patient), true, "newPage");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

