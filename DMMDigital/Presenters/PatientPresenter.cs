using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IPatientView patientView;
        private readonly IPatientRepository patientRepository;
        private PatientModel selectedPatient;
        private readonly BindingSource patientBindingSource;
        private IEnumerable<PatientModel> patientList;

        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly IExamImageDrawingRepository examImageDrawingRepository = new ExamImageDrawingRepository();
        private readonly IConfigRepository configRepository = new ConfigRepository();
        private IEnumerable<ExamModel> examList;
        private readonly BindingSource examBindingSource;

        private readonly string examOpeningMode;

        public PatientPresenter(IPatientView view, IPatientRepository repository, string examOpeningMode)
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
            this.examOpeningMode = examOpeningMode;
        }

        private void searchPatient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(patientView.searchedValue);
            patientList = emptyValue == false ? patientRepository.getPatientsByName(patientView.searchedValue) : patientRepository.getAllPatients();
            patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone });
        }

        private void showAddPatientForm(object sender, EventArgs e)
        {
            IPatientHandlerView manipulatePatientView = new PatientHandlerView("add");
            manipulatePatientView.eventAddNewPatient += addNewPatient;
            (manipulatePatientView as Form).ShowDialog();
            getPatients();
        }

        private void showEditPatientForm(object sender, EventArgs e)
        {
            IPatientHandlerView manipulatePatientView = new PatientHandlerView("edit");
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
                selectedPatient.id = (sender as PatientHandlerView).patientId;
                selectedPatient.name = (sender as PatientHandlerView).patientName;
                selectedPatient.birthDate = (sender as PatientHandlerView).patientBirthDate;
                selectedPatient.phone = (sender as PatientHandlerView).patientPhone;
                selectedPatient.recommendation = (sender as PatientHandlerView).patientRecommendation;
                selectedPatient.observation = (sender as PatientHandlerView).patientObservation;

                new Common.ModelDataValidation().Validate(selectedPatient);
                MessageBox.Show(patientRepository.edit());
                (sender as PatientHandlerView).Close();
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
                    name = (sender as PatientHandlerView).patientName,
                    birthDate = (sender as PatientHandlerView).patientBirthDate,
                    phone = (sender as PatientHandlerView).patientPhone,
                    recommendation = (sender as PatientHandlerView).patientRecommendation,
                    observation = (sender as PatientHandlerView).patientObservation,
                };

                new Common.ModelDataValidation().Validate(selectedPatient);
                MessageBox.Show(patientRepository.add(selectedPatient));
                (sender as PatientHandlerView).Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getPatients()
        {
            patientList = patientRepository.getAllPatients();

            if (patientList.Any())
            {
                patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone});
                patientView.selectedPatientId = patientList.First().id;
                patientView.patientDataGridViewHandler();
            }
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
            if (examList.Any())
            {
                examBindingSource.DataSource = examList.Select(ex => new { ex.id, ex.templateId, ex.sessionName, ex.createdAt, ex.template.name});
                patientView.examDataGridViewHandler();
            }
            else if (examBindingSource.DataSource != null)
            {
                examBindingSource.DataSource = null;
            }
        }

        private void openExam(object sender, EventArgs e)
        {
            new ExamPresenter(new ExamView(patientView.selectedExamId, patientView.selectedPatientId), new ExamRepository(), true, examOpeningMode);
            Application.OpenForms.Cast<Form>().First().Hide();
            (patientView as Form).Hide();
            (patientView as Form).Close();
        }

        private void deleteExam(object sender, EventArgs e)
        {
            OperationStatus examImageDrawingStatus = examImageDrawingRepository.delete(patientView.selectedExamId);

            if (examImageDrawingStatus.code == -1)
            {
                MessageBox.Show(examImageDrawingStatus.message);
                return;
            }

            OperationStatus examImageStatus = examImageRepository.delete(patientView.selectedExamId);

            if (examImageStatus.code == -1)
            {
                MessageBox.Show(examImageStatus.message);
                return;
            }

            OperationStatus examStatus = examRepository.delete(patientView.selectedExamId);

            if (examStatus.code == -1)
            {
                MessageBox.Show(examStatus.message);
                return;
            }

            string fullPath = configRepository.getExamPath() + patientView.selectedExamPath;

            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }

            MessageBox.Show(examStatus.message);
            getExamByPatient(this, EventArgs.Empty);
        }

        private void exportExam(object sender, EventArgs e)
        {

        }
    }
}
