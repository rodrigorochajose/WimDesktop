using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace WimDesktop._Repositories
{
    public class ExamImageRepository : IExamImageRepository
    {
        private readonly Context context = new Context();

        public void save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void addExamImage(ExamImageModel examImage)
        {
            try
            {
                context.examImage.Add(examImage);
                context.SaveChanges();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteExamImage(ExamImageModel examImages)
        {
            try
            {
                context.examImage.Remove(examImages);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable<ExamImageModel> getExamImages(int examId)
        {
            return context.examImage.Where(e => e.examId == examId);
        }

        public IEnumerable<string> getExamImagesPath(int examId)
        {
            return context.examImage.Where(e => e.examId == examId).Select(e => e.file);
        }

        public ExamImageModel getExamImageById(int examId, int frameId)
        {
            return context.examImage.FirstOrDefault(e => e.examId == examId && e.templateFrameId == frameId);
        }

        public void importExamImages(List<ExamImageModel> examImages)
        {
            try
            {
                foreach (ExamImageModel examImage in examImages)
                {
                    if (examImage.file.Contains("original.png"))
                    {
                        context.examImage.Add(examImage);
                    }
                }

                context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var errorMessages = dbEx.EntityValidationErrors
                    .SelectMany(e => e.ValidationErrors)
                    .Select(e => $"Property: {e.PropertyName} Error: {e.ErrorMessage}");

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = $"Validation failed: {fullErrorMessage}";

                MessageBox.Show(exceptionMessage);
            }
        }
    }
}
