using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using MoreLinq;
using MoreLinq.Extensions;

namespace DMMDigital.Presenters
{
    public class PatientPresenter
    {
        public PatientView view { get; }

        private List<PatientModelDGV> patientsDGV = new List<PatientModelDGV>();
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
            view.eventOrderDataGridView += orderDataGridView;

            view.setPatientList(patientBindingSource);

            loadAllPatients();
        }

        private void searchPatient(object sender, EventArgs e)
        {
            //bool emptyValue = string.IsNullOrWhiteSpace(view.searchedValue);
            //patientList = emptyValue == false ? patientRepository.getPatientsByName(view.searchedValue) : patientRepository.getAllPatients();

            //if (patientList.Any())
            //{
            //    patientsDGV = new List<PatientModelDGV>();

            //    patientsDGV = patientList.Select(p => new PatientModelDGV 
            //    { 
            //        id = p.id, 
            //        name = p.name, 
            //        lastChange = getLastUpdatedExam(p.id) 
            //    }).ToList();



            //    patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.lastChange });
            //}
            //else
            //{
            //    view.selectedPatientId = 0;
            //    patientBindingSource.Clear();
            //}
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

