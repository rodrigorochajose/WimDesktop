using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
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

        public ExamImageModel getExamImageById(int examId, int frameId)
        {
            return context.examImage.FirstOrDefault(e => e.examId == examId && e.frameId == frameId);
        }
    }
}
