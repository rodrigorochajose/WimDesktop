using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class ExamImageDrawingRepository : IExamImageDrawingRepository
    {
        Context context = new Context();

        public void save(List<ExamImageDrawingModel> examImageDrawing)
        {
            try
            {
                if (examImageDrawing.Count > 0) { 
                    List<ExamImageDrawingModel> currentList = getExamImageDrawings(examImageDrawing[0].examId).ToList();

                    foreach (ExamImageDrawingModel item in examImageDrawing)
                    {
                        if (currentList.Find(e => e.file == item.file) == null)
                        {
                            context.examImageDrawing.AddOrUpdate(item);
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
        
        public IEnumerable<ExamImageDrawingModel> getExamImageDrawings(int examId)
        {
            return context.examImageDrawing.Where(e => e.examId == examId);
        }
    }
}
