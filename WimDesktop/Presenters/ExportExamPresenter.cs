using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WimDesktop._Repositories;
using WimDesktop.Components;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;

namespace WimDesktop.Presenters
{
    public class ExportExamPresenter
    {
        private readonly IExportExamView exportExamView;
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public ExportExamPresenter(IExportExamView view, int patientId, int examId) 
        {
            exportExamView = view;

            view.eventSaveExportPath += saveExportPath;
            view.eventGetExportPath += getExportPath;

            setWaterMark();

            exportExamView.pathImages = $"{settingsRepository.getExamPath()}\\{patientId}\\{examId}";
            exportExamView.framesToExport = getFrames(examId);
            exportExamView.patientName = getPatientName(patientId);

            (exportExamView as Form).ShowDialog();
        }

        private List<Frame> getFrames(int examId)
        {
            IExamRepository examRepository = new ExamRepository();
            IExamImageRepository examImageRepository = new ExamImageRepository();
            ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();

            int templateId = examRepository.getTemplateId(examId);

            List<TemplateFrameModel> templateFrames = templateFrameRepository.getTemplateFrame(templateId);
            List<ExamImageModel> examImages = examImageRepository.getExamImages(examId).ToList();

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

                    string filteredImagePath = Path.Combine(exportExamView.pathImages, $"{newFrame.order}_filtered.png"); 

                    string imagePath = File.Exists(filteredImagePath) ? filteredImagePath : Path.Combine(exportExamView.pathImages, selectedExamImage.file);

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

            return frames;
        }

        private string getPatientName(int patientId)
        {
            IPatientRepository patientRepository = new PatientRepository();

            return patientRepository.getPatientName(patientId);
        }

        private void saveExportPath(object sender, EventArgs e)
        {
            settingsRepository.saveExportPath(exportExamView.pathToExport);
        }

        private void getExportPath(object sender, EventArgs e)
        {
            exportExamView.pathToExport = settingsRepository.getExportPath();
        }

        private void setWaterMark()
        {
            exportExamView.waterMark = settingsRepository.getWaterMark();
        }
    }
}
