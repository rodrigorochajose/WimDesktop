using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Properties;
using WimDesktop.Views;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class ExamPresenter
    {
        private readonly IExamView examView;
        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly IExamImageDrawingRepository examImageDrawingRepository = new ExamImageDrawingRepository();
        private readonly IExamImageDrawingPointsRepository examImageDrawingPointsRepository = new ExamImageDrawingPointsRepository();
        private readonly IRulerLengthRepository rulerLengthRepository = new RulerLengthRepository();
        private readonly IPatientRepository patientRepository = new PatientRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();
        private readonly string examOpeningMode;

        public ExamPresenter(IExamView view, bool openingExam, string examOpeningMode)
        {
            this.examOpeningMode = examOpeningMode;
            
            examView = view;
            examView.settings = settingsRepository.getAllSettings();
            associateEvents();

            if (openingExam)
            {
                loadFullExam();
            }
            else
            {
                saveExam(this, EventArgs.Empty);
            }

            initializeExam();
        }

        public void associateEvents()
        {
            examView.eventSaveExam += saveExam;
            examView.eventUpdateExamLastChange += updateExamLastChange;
            examView.eventSaveExamImage += saveExamImage;
            examView.eventSaveExamImageDrawing += saveExamImageDrawing;
            examView.eventGetPatient += getPatient;
        }

        public void initializeExam()
        {
            if (examOpeningMode == "newContainer")
            {
                new ExamContainerPresenter(new ExamContainerView(examView as ExamView), examView.patient.id);
            }
            else
            {
                Form examContainerView = Application.OpenForms.OfType<ExamContainerView>().FirstOrDefault();

                if ((examContainerView as ExamContainerView).patientId != examView.patient.id)
                {
                    examContainerView.Close();
                    new ExamContainerPresenter(new ExamContainerView(examView as ExamView), examView.patient.id);
                }
                else if (!(examContainerView as ExamContainerView).openExamsId.Contains(examView.exam.id))
                {
                    (examContainerView as ExamContainerView).addNewPage(examView);
                }
                else
                {
                    MessageBox.Show(Resources.messageExamIsOpened);
                }
            }
        }

        private void loadFullExam()
        {
            try
            {
                ExamModel exam = examRepository.getExam(examView.exam.id);
                examView.exam.sessionName = exam.sessionName;

                examView.setLabelPatientTemplate(exam.patient.name, exam.template.name);

                examView.examPath = Path.Combine(settingsRepository.getExamPath(), $"{examView.patient.id}\\{examView.exam.id}");
                examView.templateId = exam.templateId;
                examView.templateFrames = templateFrameRepository.getTemplateFrame(exam.templateId);
                examView.examImages = examImageRepository.getExamImages(examView.exam.id).ToList();
                examView.examImageDrawings = examImageDrawingRepository.getDrawings(examView.exam.id).ToList();

                getExamImageDrawingPoints();
                getRulerLineLengths();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{Resources.messageExamErrorOnLoad} - {ex.Message}");
            }
        }

        private void getRulerLineLengths()
        {
            List<ExamImageDrawingModel> rulerDrawings = examView.examImageDrawings.Where(d => d.drawingType == "Ruler").ToList();

            if (rulerDrawings.Any())
            {
                foreach (ExamImageDrawingModel drawing in rulerDrawings)
                {
                    drawing.lineLength = rulerLengthRepository.getRulerLengthByDrawing(drawing.id);
                }
            }
        }

        private void getExamImageDrawingPoints()
        {
            foreach (ExamImageDrawingModel drawing in examView.examImageDrawings)
            {
                drawing.points = examImageDrawingPointsRepository.getExamImageDrawingPointsByDrawing(drawing.id);
            }
        }

        private void saveExam(object sender, EventArgs e)
        {
            try
            {
                ExamModel exam = new ExamModel
                {
                    patientId = examView.patient.id,
                    templateId = examView.templateId,
                    sessionName = examView.exam.sessionName,
                    createdAt = DateTime.Now
                };
            
                examRepository.addExam(exam);
                examView.exam = exam;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exam - {ex.Message}");
            }
        }

        private void updateExamLastChange(object sender, EventArgs e)
        {
            examRepository.updateExamLastChange(examView.exam.id);
        }

        private void saveExamImage(object sender, EventArgs e)
        {
            try
            {
                int currentFrameId = examView.selectedFrame.id;

                ExamImageModel currentExamImage = examImageRepository.getExamImageById(examView.exam.id, currentFrameId);
                ExamImageModel examImageToSave = examView.examImages.FirstOrDefault(ei => ei.templateFrameId == currentFrameId);

                if (examImageToSave == null && currentExamImage != null)
                {
                    deleteExamImageDrawings(currentExamImage.id);
                    examImageRepository.deleteExamImage(currentExamImage);
                }
                else if (examImageToSave != null && currentExamImage == null)
                {
                    examImageRepository.addExamImage(examImageToSave);
                }
                else if (examImageToSave != null && currentExamImage != null)
                {
                    currentExamImage.notes = examImageToSave.notes;
                    currentExamImage.createdAt = examImageToSave.createdAt;
                    examImageRepository.save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ExamImage - {ex.Message}");
            }
        }

        private void deleteExamImageDrawings(int examImageId)
        {
            List<ExamImageDrawingModel> examImageDrawingsToDelete = examImageDrawingRepository.getDrawingsByExamImage(examView.exam.id, examImageId).ToList();

            if (examImageDrawingsToDelete.Any())
            {
                List<int> drawingsIdToDelete = examImageDrawingsToDelete.Select(d => d.id).ToList();

                rulerLengthRepository.deleteRangeRulerLength(drawingsIdToDelete);
                examImageDrawingPointsRepository.deleteRangeDrawingPoints(drawingsIdToDelete);
                examImageDrawingRepository.deleteRangeDrawing(examImageDrawingsToDelete);
            }
        }

        private void saveExamImageDrawing(object sender, EventArgs e)
        {
            try
            {
                ExamImageModel examImage = examView.examImages.FirstOrDefault(ei => ei.templateFrameId == examView.selectedFrame.id);

                if (examImage == null)
                {
                    return;
                }

                List<ExamImageDrawingModel> selectedFrameExamImageDrawings = examView.examImageDrawings.Where(eid => eid.examImageId == examImage.id).ToList();

                List<ExamImageDrawingModel> currentFrameExamImageDrawings = examImageDrawingRepository.getDrawingsByExamImage(examView.exam.id, examImage.id).ToList();

                List<ExamImageDrawingModel> drawingsToDelete = currentFrameExamImageDrawings.ExceptBy(selectedFrameExamImageDrawings, item => item.id).ToList();

                if (drawingsToDelete.Any())
                {
                    List<int> drawingsIdToDelete = drawingsToDelete.Select(d => d.id).ToList();
                    rulerLengthRepository.deleteRangeRulerLength(drawingsIdToDelete);
                    examImageDrawingPointsRepository.deleteRangeDrawingPoints(drawingsIdToDelete);
                    examImageDrawingRepository.deleteRangeDrawing(drawingsToDelete);

                    currentFrameExamImageDrawings = examImageDrawingRepository.getDrawingsByExamImage(examView.exam.id, examImage.id).ToList();
                }

                foreach (ExamImageDrawingModel item in selectedFrameExamImageDrawings)
                {
                    ExamImageDrawingModel existingExamImageDrawing = currentFrameExamImageDrawings.FirstOrDefault(eid => eid.id == item.id);
                    if (existingExamImageDrawing == null)
                    {
                        examImageDrawingRepository.addDrawing(item);

                        List<ExamImageDrawingPointsModel> pointsToSave = new List<ExamImageDrawingPointsModel>();

                        foreach (Point point in item.points)
                        {
                            pointsToSave.Add(new ExamImageDrawingPointsModel
                            {
                                examImageDrawingId = item.id,
                                pointX = point.X,
                                pointY = point.Y
                            });
                        }

                        examImageDrawingPointsRepository.addDrawingPoints(pointsToSave);

                        if (item.lineLength != null)
                        {
                            List<RulerLengthModel> rulerLengths = new List<RulerLengthModel>();

                            foreach (float length in item.lineLength)
                            {
                                rulerLengths.Add(new RulerLengthModel
                                {
                                    examImageDrawingId = item.id,
                                    lineLength = length,
                                });
                            }

                            rulerLengthRepository.addRulerLength(rulerLengths);
                        }
                    }
                    else if (item.points != existingExamImageDrawing.points)
                    {
                        examImageDrawingPointsRepository.updateDrawingPoints(item.id, item.points);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ExamImageDrawing - {ex.Message}");
            }
        }

        private void getPatient(object sender, EventArgs e)
        {
            examView.patient = patientRepository.getPatientById(examView.patient.id);
        }
        
    }
}
