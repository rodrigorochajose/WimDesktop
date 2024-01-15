using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using MoreLinq;

namespace DMMDigital._Repositories
{
    public class ExamImageRepository : IExamImageRepository
    {
        private readonly Context context = new Context();

        public void save(List<ExamImageModel> examImages)
        {
            try
            {
                List<ExamImageModel> currentList = getExamImages(examImages[0].examId).ToList();

                List<ExamImageModel> imagesToRemove = currentList.ExceptBy(examImages, item => item.file).ToList();
                
                foreach(ExamImageModel item in imagesToRemove)
                {
                    context.examImage.Remove(item);
                }

                foreach (ExamImageModel item in examImages)
                {
                    if (!currentList.Contains(item))
                    {
                        context.examImage.AddOrUpdate(item);
                    }
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public OperationStatus delete(int examId)
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
    }
}
