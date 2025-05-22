using WimDesktop.Interface.IRepository;
using WimDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WimDesktop._Repositories
{
    public class ExamImageDrawingPointsRepository : IExamImageDrawingPointsRepository
    {
        private readonly Context context = new Context();

        public void addDrawingPoints(List<ExamImageDrawingPointsModel> drawingPoints)
        {
            try
            {
                context.examImageDrawingPoints.AddRange(drawingPoints);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateDrawingPoints(int drawingId, List<System.Drawing.Point> drawingPoints)
        {
            try
            {
                List<ExamImageDrawingPointsModel> currentPoints = getPointsByDrawing(drawingId).ToList();
                for (int counter = 0; counter < currentPoints.Count; counter++)
                {
                    currentPoints[counter].pointX = drawingPoints[counter].X;
                    currentPoints[counter].pointY = drawingPoints[counter].Y;
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteRangeDrawingPoints(List<int> drawingsId)
        {
            try
            {
                IEnumerable<ExamImageDrawingPointsModel> drawingPointsToDelete = drawingsId.SelectMany(drawingId => getPointsByDrawing(drawingId));

                context.examImageDrawingPoints.RemoveRange(drawingPointsToDelete);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IEnumerable<ExamImageDrawingPointsModel> getPointsByDrawing(int drawingId)
        {
            return context.examImageDrawingPoints.Where(e => e.examImageDrawingId == drawingId);
        }

        public List<System.Drawing.Point> getExamImageDrawingPointsByDrawing(int drawingId)
        {
            return context.examImageDrawingPoints.Where(d => d.examImageDrawingId == drawingId).ToList().Select(dp => new System.Drawing.Point(dp.pointX, dp.pointY)).ToList();
        }
    }
}
