using DMMDigital.Interface.IRepository;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace DMMDigital._Repositories
{
    public class ExamImageDrawingPointsRepository : IExamImageDrawingPointsRepository
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

        public void addExamImageDrawingPoints(List<ExamImageDrawingPointsModel> pointsToSave)
        {
            try
            {
                context.examImageDrawingPoints.AddRange(pointsToSave);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updatePoints(int drawingId, List<System.Drawing.Point> points)
        {
            try
            {
                List<ExamImageDrawingPointsModel> currentPoints = getExamImageDrawingPointsByDrawingId(drawingId).ToList();
                for (int counter = 0; counter < currentPoints.Count; counter++)
                {
                    currentPoints[counter].pointX = points[counter].X;
                    currentPoints[counter].pointY = points[counter].Y;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteExamImageDrawingPointsByDrawings(List<int> drawingsIdToDelete)
        {
            try
            {
                foreach (int drawingId in drawingsIdToDelete)
                {
                    context.examImageDrawingPoints.RemoveRange(getExamImageDrawingPointsByDrawingId(drawingId));
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteExamImageDrawingPoints(int examId)
        {
            try
            {
                context.examImageDrawingPoints.RemoveRange(getExamImageDrawingPoints(examId));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable<ExamImageDrawingPointsModel> getExamImageDrawingPoints(int examId)
        {
            return context.examImageDrawingPoints.Where(e => e.examId == examId);
        }

        public IEnumerable<ExamImageDrawingPointsModel> getExamImageDrawingPointsByExamImage(int examId, int examImageId)
        {
            return context.examImageDrawingPoints.Where(e => e.examId == examId && e.examImageId == examImageId);
        }

        private IEnumerable<ExamImageDrawingPointsModel> getExamImageDrawingPointsByDrawingId(int drawingId)
        {
            return context.examImageDrawingPoints.Where(e => e.examImageDrawingId == drawingId);
        }
    }
}
