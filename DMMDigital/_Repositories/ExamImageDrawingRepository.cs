using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class ExamImageDrawingRepository : IExamImageDrawingRepository
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

        public void addExamImageDrawing(ExamImageDrawingModel examImageDrawing)
        {
            try
            {
                context.examImageDrawing.Add(examImageDrawing);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteRangeExamImageDrawings(List<ExamImageDrawingModel> examImageDrawings)
        {
            try
            {
                context.examImageDrawing.RemoveRange(examImageDrawings);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteAllExamImageDrawings(int examId)
        {
            try
            {
                context.examImageDrawing.RemoveRange(getExamImageDrawings(examId));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable<ExamImageDrawingModel> getExamImageDrawings(int examId)
        {
            List<ExamImageDrawingModel> examImageDrawings = context.examImageDrawing.Where(e => e.examId == examId).ToList();

            foreach (ExamImageDrawingModel drawing in examImageDrawings)
            {
                getDrawingPoints(examId, drawing);
            }

            return examImageDrawings;
        }

        public IEnumerable<ExamImageDrawingModel> getExamImageDrawingsByExamImage(int examId, int examImageId)
        {
            return context.examImageDrawing.Where(e => e.examId == examId && e.examImageId == examImageId);
        }

        private void getDrawingPoints(int examId, ExamImageDrawingModel drawing)
        {
            List<ExamImageDrawingPointsModel> drawingPoints = context.examImageDrawingPoints.Where(e => e.examId == examId && e.examImageDrawingId == drawing.id).ToList();

            drawing.points = new List<System.Drawing.Point>();

            foreach (ExamImageDrawingPointsModel point in drawingPoints)
            {
                drawing.points.Add(new System.Drawing.Point(point.pointX, point.pointY));
            }
        }
    }
}
