using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DMMDigital._Repositories;
using DMMDigital.Components;
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
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
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
            IPatientHandlerView patientHandlerView = new PatientHandlerView("add");
            patientHandlerView.eventAddNewPatient += addNewPatient;
            (patientHandlerView as Form).ShowDialog();
            getPatients();
        }

        private void showEditPatientForm(object sender, EventArgs e)
        {
            IPatientHandlerView patientHandlerView = new PatientHandlerView("edit");
            patientHandlerView.eventSaveEditedPatient += saveEditedPatient;

            selectedPatient = patientRepository.getPatientById(patientView.selectedPatientId);
            patientHandlerView.patientId = selectedPatient.id;
            patientHandlerView.patientName = selectedPatient.name;
            patientHandlerView.patientBirthDate = selectedPatient.birthDate;
            patientHandlerView.patientPhone = selectedPatient.phone;
            patientHandlerView.patientRecommendation = selectedPatient.recommendation;
            patientHandlerView.patientObservation = selectedPatient.observation;
            (patientHandlerView as Form).ShowDialog();

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
            ConfigModel config = configRepository.getAllConfig();
            new ExamPresenter(new ExamView(patientView.selectedExamId, patientView.selectedPatientId, config), new ExamRepository(), true, examOpeningMode);
            Application.OpenForms.Cast<Form>().First().Hide();
            (patientView as Form).Hide();
            (patientView as Form).Close();
        }

        private void deleteExam(object sender, EventArgs e)
        {
            if (examImageRepository.getExamImages(patientView.selectedExamId).Any())
            {
                MessageBox.Show("Exame possui imagens, não será possível excluí-lo.");
                return;
            }

            examImageDrawingRepository.delete(patientView.selectedExamId);
            examImageRepository.delete(patientView.selectedExamId);
            examRepository.delete(patientView.selectedExamId);

            string fullPath = configRepository.getExamPath() + patientView.selectedExamPath;

            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }

            MessageBox.Show("Exame deletado com sucesso!");
            getExamByPatient(this, EventArgs.Empty);
        }

        private void exportExam(object sender, EventArgs e)
        {
            ExamModel selectedExam = examRepository.getExam(patientView.selectedExamId);

            string examPath = configRepository.getExamPath() + $"\\Paciente-{selectedExam.patient.id}\\{selectedExam.sessionName}_{selectedExam.createdAt.ToString("dd-MM-yyyy")}";

            List<TemplateFrameModel> templateFrames = templateFrameRepository.getTemplateFrame(selectedExam.templateId);
            List<ExamImageModel> examImages = examImageRepository.getExamImages(patientView.selectedExamId).ToList();

            List<Frame> frames = new List<Frame>();

            foreach (TemplateFrameModel frame in templateFrames)
            {
                int height;
                int width;
                if (frame.orientation.Contains("Vertical"))
                {
                    height = 35;
                    width = 25;
                }
                else
                {
                    height = 25;
                    width = 35;
                }

                Frame newFrame = new Frame
                {
                    Width = width,
                    Height = height,
                    BackColor = Color.Black,
                    order = frame.order,
                    Name = "filme" + frame.id,
                    orientation = frame.orientation,
                    Tag = Color.Black,
                    Location = new Point(frame.locationX / 2, frame.locationY / 2),

                };

                ExamImageModel selectedExamImage = examImages.FirstOrDefault(ex => ex.frameId == newFrame.order);

                if (selectedExamImage != null)
                {
                    using (FileStream fs = new FileStream(Path.Combine(examPath, selectedExamImage.file), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        Bitmap image = new Bitmap(Image.FromStream(fs));

                        newFrame.originalImage = new Bitmap(image);
                        newFrame.Image = image.GetThumbnailImage(newFrame.Width, newFrame.Height, () => false, IntPtr.Zero);
                        newFrame.notes = selectedExamImage.notes;
                        newFrame.datePhotoTook = selectedExamImage.createdAt.ToString();

                        image.Dispose();
                    }
                }
                frames.Add(newFrame);
            }

            IExportExamView exportView = new ExportExamView
            {
                pathImages = examPath,
                framesToExport = frames,
                sessionName = selectedExam.sessionName
            };
            (exportView as Form).ShowDialog();
        }
    }
}
