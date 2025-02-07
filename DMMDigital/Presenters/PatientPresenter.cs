using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DMMDigital._Repositories;
using DMMDigital.Components;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Properties;
using DMMDigital.Views;
using MoreLinq.Extensions;

namespace DMMDigital.Presenters
{
    public class PatientPresenter
    {
        public PatientView view { get; }

        private readonly IPatientRepository patientRepository;
        private PatientModel selectedPatient;
        private readonly BindingSource patientBindingSource;
        private IEnumerable<PatientModel> patientList;

        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();
        private IEnumerable<ExamModel> examList;
        private readonly BindingSource examBindingSource;

        private readonly string examOpeningMode;

        public PatientPresenter(PatientView patientView, IPatientRepository repository, string examOpeningMode)
        {
            patientBindingSource = new BindingSource();
            examBindingSource = new BindingSource();

            view = patientView;
            patientRepository = repository;

            view.eventSearchPatient += searchPatient;
            view.eventShowAddPatientForm += showAddPatientForm;
            view.eventShowEditPatientForm += showEditPatientForm;
            view.eventDeletePatient += deletePatient;

            view.eventShowFormNewExam += newExam;
            view.eventGetPatientExams += getExamByPatient;
            view.eventOpenExam += openExam;
            view.eventDeleteExam += deleteExam;
            view.eventExportExam += exportExam;
            view.eventSwitchTemplate += switchTemplate;

            view.setPatientList(patientBindingSource);
            view.setExamList(examBindingSource);

            loadAllPatients();
            getExamByPatient(this, EventArgs.Empty);
            this.examOpeningMode = examOpeningMode;
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
                examBindingSource.Clear();
            }
        }

        private void showAddPatientForm(object sender, EventArgs e)
        {
            IPatientManagerView patientHandlerView = new PatientManagerView("add");
            patientHandlerView.eventAddNewPatient += addNewPatient;
            (patientHandlerView as Form).ShowDialog();
            loadAllPatients();
        }

        private void showEditPatientForm(object sender, EventArgs e)
        {
            IPatientManagerView patientHandlerView = new PatientManagerView("edit");
            patientHandlerView.eventSaveEditedPatient += saveEditedPatient;

            selectedPatient = patientRepository.getPatientById(view.selectedPatientId);
            patientHandlerView.patientId = selectedPatient.id;
            patientHandlerView.patientName = selectedPatient.name;
            patientHandlerView.patientBirthDate = selectedPatient.birthDate;
            patientHandlerView.patientPhone = selectedPatient.phone;
            patientHandlerView.patientRecommendation = selectedPatient.recommendation;
            patientHandlerView.patientObservation = selectedPatient.observation;
            (patientHandlerView as Form).ShowDialog();

            loadAllPatients();
        }

        private void deletePatient(object sender, EventArgs e)
        {
            if (examRepository.getPatientExams(view.selectedPatientId).Any())
            {
                MessageBox.Show(Resources.messagePatientCannotDelete);
                return;
            }

            DialogResult res = MessageBox.Show(Resources.messageConfirmDelete, Resources.titleDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(res))
            {
                string fullPath = $"{settingsRepository.getExamPath()}\\{view.selectedPatientId}";

                if (Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, true);
                }

                patientRepository.deletePatient(view.selectedPatientId);
                loadAllPatients();
            }
        }

        private void saveEditedPatient(object sender, EventArgs e)
        {
            try
            {
                selectedPatient.id = (sender as PatientManagerView).patientId;
                selectedPatient.name = (sender as PatientManagerView).patientName;
                selectedPatient.birthDate = (sender as PatientManagerView).patientBirthDate;
                selectedPatient.phone = (sender as PatientManagerView).patientPhone;
                selectedPatient.recommendation = (sender as PatientManagerView).patientRecommendation;
                selectedPatient.observation = (sender as PatientManagerView).patientObservation;

                new Common.ModelDataValidation().Validate(selectedPatient);
                patientRepository.editPatient();
                (sender as PatientManagerView).Close();
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

                Directory.CreateDirectory(Path.Combine(examPath, $"\\{selectedPatient.id}\\recycle"));
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
                patientBindingSource.DataSource = patientList.Select(p => new { p.id, p.name, p.birthDate, p.phone});
            }
        }

        private void newExam(object sender, EventArgs e)
        {
            ITemplateExamView chooseTemplateView = new TemplateExamView();

            PatientModel selectedPatient = patientRepository.getPatientById(view.selectedPatientId);
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

            new TemplateExamPresenter(chooseTemplateView, new TemplateRepository(), "patientView");
        }

        private void getExamByPatient(object sender, EventArgs e)
        {
            examList = examRepository.getPatientExams(view.selectedPatientId);
            if (examList.Any())
            {
                view.selectedExamId = examList.First().id;
                examBindingSource.DataSource = examList.Select(ex => new { ex.id, ex.templateId, ex.sessionName, ex.createdAt, ex.template.name});
            }
            else
            {
                view.selectedExamId = 0;
                examBindingSource.Clear();
            }
        }

        private void openExam(object sender, EventArgs e)
        {
            SettingsModel settings = settingsRepository.getAllSettings();

            PatientModel selectedPatient = patientList.FirstOrDefault(p => p.id == view.selectedPatientId);
            new ExamPresenter(new ExamView(view.selectedExamId, selectedPatient, settings), new ExamRepository(), true, examOpeningMode);
            Application.OpenForms.Cast<Form>().First().Hide();
            view.Close();
        }

        private void deleteExam(object sender, EventArgs e)
        {
            if (examRepository.examHasImages(view.selectedExamId))
            {
                MessageBox.Show(Resources.messageExamCannotDelete);
                return;
            }

            DialogResult res = MessageBox.Show(Resources.messageConfirmDelete, Resources.titleDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(res))
            {
                string fullPath = $"{settingsRepository.getExamPath()}{view.selectedExamPath}";

                if (Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, true);
                }

                examRepository.deleteExam(view.selectedExamId);

                MessageBox.Show(Resources.messageExamDeleted);
                getExamByPatient(this, EventArgs.Empty);
            }
        }

        private void exportExam(object sender, EventArgs e)
        {
            ExamModel selectedExam = examRepository.getExam(view.selectedExamId);

            List<TemplateFrameModel> templateFrames = templateFrameRepository.getTemplateFrame(selectedExam.templateId);
            List<ExamImageModel> examImages = examImageRepository.getExamImages(view.selectedExamId).ToList();

            if (!examImages.Any())
            {
                MessageBox.Show(Resources.messageExamCannotExport);
                return;
            }

            string examPath = $"{settingsRepository.getExamPath()}\\{selectedExam.patient.id}\\{selectedExam.id}";

            List<Frame> frames = new List<Frame>();

            foreach (TemplateFrameModel frame in templateFrames)
            {
                ExamImageModel selectedExamImage = examImages.FirstOrDefault(ex => ex.templateFrameId == frame.order);

                if (selectedExamImage != null)
                {
                    Frame newFrame = new Frame
                    {
                        BackColor = Color.Black,
                        order = frame.order,
                        Name = "frame" + frame.id,
                        orientation = frame.orientation
                    };

                    string imagePath = Path.Combine(examPath, selectedExamImage.file);

                    if (File.Exists(Path.Combine(examPath, $"{newFrame.order}_filtered.png")))
                    {
                        imagePath = Path.Combine(examPath, $"{newFrame.order}_filtered.png");
                    }

                    using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        Bitmap image = new Bitmap(Image.FromStream(fs));
                        Bitmap thumb = new Bitmap(image, newFrame.Width, newFrame.Height);

                        newFrame.originalImage = new Bitmap(image);
                        newFrame.Image = thumb;
                        image.Dispose();
                    }

                    frames.Add(newFrame);
                }
            }

            new ExportExamPresenter(
                new ExportExamView
                {
                    pathImages = examPath,
                    framesToExport = frames,
                    patientName = selectedExam.patient.name
                },
                view.selectedExamId
            );
        }

        private void switchTemplate(object sender, EventArgs e)
        {
            ITemplateSwitchView templateSwitchView = new TemplateSwitchView();
            new TemplateSwitchPresenter(templateSwitchView, view.selectedExamId, view.selectedTemplateId);

            (templateSwitchView as Form).ShowDialog();
            getExamByPatient(sender, e);
        }
    }
}
