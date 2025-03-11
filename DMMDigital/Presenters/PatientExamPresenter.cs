using DMMDigital._Repositories;
using DMMDigital.Components;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Properties;
using DMMDigital.Views;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class PatientExamPresenter
    {
        private IPatientExamView view;
        private PatientModel selectedPatient;

        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        private readonly string examOpeningMode;

        private IEnumerable<ExamModel> examList;
        private readonly BindingSource examBindingSource;

        public PatientExamPresenter(IPatientExamView view, int patientId, string examOpeningMode)
        {
            this.view = view;
            this.examOpeningMode = examOpeningMode;
            examBindingSource = new BindingSource();

            associateEvents();

            loadPatientData(patientId);
            view.setExamList(examBindingSource);
            getPatientExams(this, EventArgs.Empty);

            (view as Form).ShowDialog();
        }

        private void associateEvents()
        {
            view.eventEditPatient += editPatient;
            view.eventDeletePatient += deletePatient;

            view.eventShowFormNewExam += newExam;
            view.eventOpenExam += openExam;
            view.eventDeleteExam += deleteExam;
            view.eventExportExam += exportExam;
            view.eventSwitchTemplate += switchTemplate;
        }

        private void loadPatientData(int patientId)
        {
            selectedPatient = patientRepository.getPatientById(patientId);
            view.patientId = selectedPatient.id;
            view.patientName = selectedPatient.name;
            view.patientBirthDate = selectedPatient.birthDate;
            view.patientPhone = selectedPatient.phone;
            view.patientRecommendation = selectedPatient.recommendation;
            view.patientObservation = selectedPatient.observation;
        }

        public void editPatient(object sender, EventArgs e)
        {
            try
            {
                selectedPatient.id = (sender as IPatientExamView).patientId;
                selectedPatient.name = (sender as IPatientExamView).patientName;
                selectedPatient.birthDate = (sender as IPatientExamView).patientBirthDate;
                selectedPatient.phone = (sender as IPatientExamView).patientPhone;
                selectedPatient.recommendation = (sender as IPatientExamView).patientRecommendation;
                selectedPatient.observation = (sender as IPatientExamView).patientObservation;

                new Common.ModelDataValidation().Validate(selectedPatient);
                patientRepository.editPatient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void deletePatient(object sender, EventArgs e)
        {
            if (examRepository.getPatientExams(view.patientId).Any())
            {
                MessageBox.Show(Resources.messagePatientCannotDelete);
                return;
            }

            DialogResult res = MessageBox.Show(Resources.messageConfirmDelete, Resources.titleDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(res))
            {
                string fullPath = $"{settingsRepository.getExamPath()}\\{view.patientId}";

                if (Directory.Exists(fullPath))
                {
                    Directory.Delete(fullPath, true);
                }

                patientRepository.deletePatient(view.patientId);

                (view as Form).Close();
            }
        }

        private void newExam(object sender, EventArgs e)
        {
            IExamTemplateSelectionView examTemplateSelectionView = new ExamTemplateSelectionView();

            PatientModel selectedPatient = patientRepository.getPatientById(view.patientId);
            examTemplateSelectionView.patientId = selectedPatient.id;
            examTemplateSelectionView.patientName = selectedPatient.name;
            examTemplateSelectionView.patientBirthDate = selectedPatient.birthDate;
            examTemplateSelectionView.patientPhone = selectedPatient.phone;
            examTemplateSelectionView.patientRecommendation = selectedPatient.recommendation;
            examTemplateSelectionView.patientObservation = selectedPatient.observation;

            FormManager.instance.closeAllExceptExamAndMenu();

            new ExamTemplateSelectionPresenter(examTemplateSelectionView, view.GetType());
        }

        private void getPatientExams(object sender, EventArgs e)
        {
            examList = examRepository.getPatientExams(view.patientId);
            if (examList.Any())
            {
                view.selectedExamId = examList.First().id;
                examBindingSource.DataSource = examList.Select(ex => new { ex.id, ex.templateId, ex.sessionName, ex.createdAt, ex.template.name });
            }
            else
            {
                view.selectedExamId = 0;
                examBindingSource.Clear();
            }
        }

        private void openExam(object sender, EventArgs e)
        {
            FormManager.instance.closeAllExceptExamAndMenu();

            new ExamPresenter(new ExamView(examRepository.getExam(view.selectedExamId), selectedPatient, settingsRepository.getAllSettings()), true, examOpeningMode);
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
                getPatientExams(this, EventArgs.Empty);
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
                ExamImageModel selectedExamImage = examImages.FirstOrDefault(ex => ex.templateFrameId == frame.id);

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
            getPatientExams(sender, e);
        }
    }
}
