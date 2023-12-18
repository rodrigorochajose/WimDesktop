using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Models;
using DMMDigital.Views;

namespace DMMDigital.Presenters
{
    public class PatientPresenter
    {
        private IPatientView patientView;
        private IPatientRepository patientRepository;
        private PatientModel selectedPatient;
        private BindingSource patientBindingSource;
        private IEnumerable<PatientModel> patientList;

        private IExamRepository examRepository = new ExamRepository();
        private IEnumerable<ExamModel> examList;
        private BindingSource examBindingSource;

        public PatientPresenter(IPatientView view, IPatientRepository repository)
        {
            patientBindingSource = new BindingSource();
            examBindingSource = new BindingSource();

            patientView = view;
            patientRepository = repository;

            patientView.eventSearchPatient += searchPatient;
            patientView.eventShowAddPatientForm += showAddPatientForm;
            patientView.eventShowEditPatientForm += showEditPatientForm;
            patientView.eventDeletePatient += deletePatient;

            patientView.eventShowFormNewExam += newExam;
            patientView.eventGetPatientExams += getExamByPatient;
            patientView.eventOpenExam += openExam;
            patientView.eventDeleteExam += deleteExam;
            patientView.eventExportExam += exportExam;

            patientView.setPatientList(patientBindingSource);
            patientView.setExamList(examBindingSource);

            getPatients();
            getExamByPatient(this, EventArgs.Empty);

            (patientView as Form).Show();
        }

        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(patientView.searchedValue);
            if (emptyValue == false)
            {
                patientList = patientRepository.getPatientsByName(patientView.searchedValue);
            } else
            {
                patientList = patientRepository.getAllPatients();
            }
            patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
        }

        private void showAddPatientForm(object sender, EventArgs e)
        {
            IManipulatePatientView manipulatePatientView = new ManipulatePatientView("add");
            manipulatePatientView.eventAddNewPatient += addNewPatient;
            (manipulatePatientView as Form).ShowDialog();
            getPatients();
        }

        private void showEditPatientForm(object sender, EventArgs e)
        {
            IManipulatePatientView manipulatePatientView = new ManipulatePatientView("edit");
            manipulatePatientView.eventSaveEditedPatient += saveEditedPatient;

            selectedPatient = patientRepository.getPatientById(patientView.selectedPatientId);
            manipulatePatientView.patientId = selectedPatient.id;
            manipulatePatientView.patientName = selectedPatient.name;
            manipulatePatientView.patientBirthDate = selectedPatient.birthDate;
            manipulatePatientView.patientPhone = selectedPatient.phone;
            manipulatePatientView.patientRecommendation = selectedPatient.recommendation;
            manipulatePatientView.patientObservation = selectedPatient.observation;
            (manipulatePatientView as Form).ShowDialog();

            getPatients();
        }

        private void deletePatient(object sender, EventArgs e)
        {
            DialogResult confirmacao = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(confirmacao))
            {
                MessageBox.Show(patientRepository.delete(patientView.selectedPatientId));
                getPatients();
            }
        }

        private void saveEditedPatient(object sender, EventArgs e)
        {
            try
            {
                selectedPatient.id = (sender as ManipulatePatientView).patientId;
                selectedPatient.name = (sender as ManipulatePatientView).patientName;
                selectedPatient.birthDate = (sender as ManipulatePatientView).patientBirthDate;
                selectedPatient.phone = (sender as ManipulatePatientView).patientPhone;
                selectedPatient.recommendation = (sender as ManipulatePatientView).patientRecommendation;
                selectedPatient.observation = (sender as ManipulatePatientView).patientObservation;

                new Common.ModelDataValidation().Validate(selectedPatient);
                MessageBox.Show(patientRepository.edit());
                (sender as ManipulatePatientView).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addNewPatient(object sender, EventArgs e)
        {
            try
            {
                selectedPatient = new PatientModel
                {
                    name = (sender as ManipulatePatientView).patientName,
                    birthDate = (sender as ManipulatePatientView).patientBirthDate,
                    phone = (sender as ManipulatePatientView).patientPhone,
                    recommendation = (sender as ManipulatePatientView).patientRecommendation,
                    observation = (sender as ManipulatePatientView).patientObservation,
                };

                new Common.ModelDataValidation().Validate(selectedPatient);
                MessageBox.Show(patientRepository.add(selectedPatient));
                (sender as ManipulatePatientView).Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getPatients()
        {
            patientList = patientRepository.getAllPatients();
            patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone});
            patientView.selectedPatientId = patientList.First().id;
            patientView.manipulatePatientDataGridView();
        }

        private void newExam(object sender, EventArgs e)
        {
            IChooseTemplateExamView chooseTemplateView = new ChooseTemplateExamView();

            PatientModel selectedPatient = patientRepository.getPatientById(patientView.selectedPatientId);
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

            new ChooseTemplateExamPresenter(chooseTemplateView, new TemplateRepository(), "patientView");
        }

        private void getExamByPatient(object sender, EventArgs e)
        {
            examList = examRepository.getPatientExams(patientView.selectedPatientId);
            if (examList.Count() > 0)
            {
                examBindingSource.DataSource = examList.Select(ex => new { ex.id, ex.templateId, ex.sessionName, ex.createdAt, ex.template.name});
                patientView.manipulateExamDataGridView();
            }
            else if (examBindingSource.DataSource != null)
            {
                examBindingSource.DataSource = null;
            }
        }

        private void openExam(object sender, EventArgs e)
        {
            new ExamPresenter(new ExamView(patientView.selectedExamId), new ExamRepository(), true, "open");
            Application.OpenForms.Cast<Form>().First().Hide();
            (patientView as Form).Hide();
            (patientView as Form).Close();
        }

        private void deleteExam(object sender, EventArgs e)
        {

        }

        private void exportExam(object sender, EventArgs e)
        {

        }
    }
}
