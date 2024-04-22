using DMMDigital.Interface;
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

        public void deleteExamImage(ExamImageModel examImageToDelete)
        {
            try
            {
                context.examImage.Remove(examImageToDelete);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public OperationStatus deleteAllExamImages(int examId)
        {
            try
            {
                foreach (ExamImageModel examImage in context.examImage.Where(e => e.examId == examId))
                {
                    context.examImage.Remove(examImage);
                }

                context.SaveChanges();
                return new OperationStatus
                {
                    code = 1,
                    status = "Sucess",
                    message = "Imagens deletadas!"
                };
            }
            catch (Exception ex)
            {
                return new OperationStatus
                {
                    code = -1,
                    status = "Error",
                    message = "Erro ao deletar imagens: " + ex.Message
                };
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
