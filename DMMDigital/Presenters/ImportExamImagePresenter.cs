using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System;
using System.IO;

namespace DMMDigital.Presenters
{
    public class ImportExamImagePresenter
    {
        private readonly IImportExamImageView view;
        private readonly IExamRepository examRepository = new ExamRepository();
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly IConfigRepository configRepository = new ConfigRepository();
        private readonly BindingSource examBindingSource;

        private string basePath = "";

        public ImportExamImagePresenter(IImportExamImageView importExamImage, int patientId = 0)
        {
            examBindingSource = new BindingSource();

            view = importExamImage;
            view.eventGetExamImages += getImages;
            view.patientId = patientId;

            view.setExamList(examBindingSource);
            getExams();

            basePath = configRepository.getExamPath();

            (view as Form).ShowDialog();
        }

        private void getExams()
        {
            List<ExamModel> exams = examRepository.getPatientExams(view.patientId).ToList();

            view.examId = exams.First().id;

            examBindingSource.DataSource = exams.Select(ex => new { ex.id, ex.sessionName, ex.template.name, ex.createdAt });
        }

        private void getImages(object sender, EventArgs e)
        {
            List<string> imageFiles = examImageRepository.getExamImagesPath(view.examId).ToList();

            string examPath = $"{basePath}\\{view.patientId}\\{view.examId}";

            for (int counter = 0; counter < imageFiles.Count(); counter++)
            {
                imageFiles[counter] = Path.Combine(examPath, imageFiles[counter].Replace("original", "filtered"));
            }

            view.imageFiles = imageFiles;
        }
    }
}
