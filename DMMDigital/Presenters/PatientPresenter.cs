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
        private readonly IExamImageDrawingRepository examImageDrawingRepository = new ExamImageDrawingRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly IConfigRepository configRepository = new ConfigRepository();
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
            IPatientHandlerView patientHandlerView = new PatientHandlerView("add");
            patientHandlerView.eventAddNewPatient += addNewPatient;
            (patientHandlerView as Form).ShowDialog();
            loadAllPatients();
        }

        private void showEditPatientForm(object sender, EventArgs e)
        {
            IPatientHandlerView patientHandlerView = new PatientHandlerView("edit");
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
                MessageBox.Show("Paciente possui exames, não será possível excluí-lo.");
                return;
            }

            DialogResult confirmacao = MessageBox.Show("Deseja realmente realizar a exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes.Equals(confirmacao))
            {
                patientRepository.deletePatient(view.selectedPatientId);
                loadAllPatients();
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
                patientRepository.editPatient();
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
                patientRepository.addPatient(selectedPatient);
                (sender as PatientHandlerView).Close();
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
            IChooseTemplateExamView chooseTemplateView = new ChooseTemplateExamView();

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

            new ChooseTemplateExamPresenter(chooseTemplateView, new TemplateRepository(), "patientView");
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
            ConfigModel config = configRepository.getAllConfig();

            PatientModel selectedPatient = patientList.FirstOrDefault(p => p.id == view.selectedPatientId);
            new ExamPresenter(new ExamView(view.selectedExamId, selectedPatient, config), new ExamRepository(), true, examOpeningMode);
            Application.OpenForms.Cast<Form>().First().Hide();
            view.Close();
        }

        private void deleteExam(object sender, EventArgs e)
        {
            if (examImageRepository.getExamImages(view.selectedExamId).Any())
            {
                MessageBox.Show("Exame possui imagens, não será possível excluí-lo.");
                return;
            }

            string fullPath = $"{configRepository.getExamPath()}{view.selectedExamPath}";

            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }

            examRepository.deleteExam(view.selectedExamId);

            MessageBox.Show("Exame deletado com sucesso!");
            getExamByPatient(this, EventArgs.Empty);
        }

        private void exportExam(object sender, EventArgs e)
        {
            ExamModel selectedExam = examRepository.getExam(view.selectedExamId);

            List<TemplateFrameModel> templateFrames = templateFrameRepository.getTemplateFrame(selectedExam.templateId);
            List<ExamImageModel> examImages = examImageRepository.getExamImages(view.selectedExamId).ToList();

            if (!examImages.Any())
            {
                MessageBox.Show("Exame não possui nenhuma imagem para exportação");
                return;
            }

            string examPath = $"{configRepository.getExamPath()}\\Paciente-{selectedExam.patient.id}\\{selectedExam.sessionName}_{selectedExam.createdAt:dd-MM-yyyy-HH-m}";

            List<Frame> frames = new List<Frame>();

            foreach (TemplateFrameModel frame in templateFrames)
            {
                ExamImageModel selectedExamImage = examImages.FirstOrDefault(ex => ex.frameId == frame.order);

                if (selectedExamImage != null)
                {
                    Frame newFrame = new Frame
                    {
                        BackColor = Color.Black,
                        order = frame.order,
                        Name = "filme" + frame.id,
                        orientation = frame.orientation
                    };

                    string imagePath = Path.Combine(examPath, selectedExamImage.file);

                    if (File.Exists(Path.Combine(examPath, $"{newFrame.order}-filtered.png")))
                    {
                        imagePath = Path.Combine(examPath, $"{newFrame.order}-filtered.png");
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
    }
}
