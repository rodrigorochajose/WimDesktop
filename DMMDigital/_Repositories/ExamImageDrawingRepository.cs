using DMMDigital.Interface;
using DMMDigital.Models;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMMDigital._Repositories
{
    public class ExamImageDrawingRepository : IExamImageDrawingRepository
    {
        private readonly Context context = new Context();

        public void save(List<ExamImageDrawingModel> examImageDrawing)
        {
            try
            {
                if (examImageDrawing.Count > 0) { 
                    List<ExamImageDrawingModel> currentList = getExamImageDrawings(examImageDrawing[0].examId).ToList();

                    List<ExamImageDrawingModel> drawingsToDelete = currentList.ExceptBy(examImageDrawing, drawing => drawing.file).ToList();

                    foreach (ExamImageDrawingModel drawing in drawingsToDelete)
                    {
                        context.examImageDrawing.Remove(drawing);
                    }
                         
                    foreach (ExamImageDrawingModel item in examImageDrawing)
                    {
                        if (currentList.Find(e => e.file == item.file) == null)
                        {
                            context.examImageDrawing.Add(item);
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OperationStatus delete(int examId)
        {
            try
            {
                foreach (ExamImageDrawingModel examImageDrawing in context.examImageDrawing.Where(e => e.examId == examId))
                {
                    context.examImageDrawing.Remove(examImageDrawing);
                }

                context.SaveChanges();
                return new OperationStatus
                {
                    code = 1,
                    status = "Sucess",
                    message = "Desenhos deletados !"
                };
            }
            catch (Exception ex)
            {
                return new OperationStatus
                {
                    code = -1,
                    status = "Error",
                    message = "Erro ao deletar desenhos: " + ex.Message
                };
            }
        }

        public IEnumerable<ExamImageDrawingModel> getExamImageDrawings(int examId)
        {
            return context.examImageDrawing.Where(e => e.examId == examId);
        }
    }
}
