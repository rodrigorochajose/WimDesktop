using DMMDigital.Interface.IRepository;
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

        public void addDrawing(ExamImageDrawingModel drawing)
        {
            try
            {
                context.examImageDrawing.Add(drawing);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteRangeDrawing(List<ExamImageDrawingModel> drawings)
        {
            try
            {
                context.examImageDrawing.RemoveRange(drawings);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteAllDrawings(int examId)
        {
            try
            {
                context.examImageDrawing.RemoveRange(getDrawings(examId));
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public IEnumerable<ExamImageDrawingModel> getDrawings(int examId)
        {
            List<ExamImageDrawingModel> examImageDrawings = context.examImageDrawing.Where(e => e.examId == examId).ToList();

            foreach (ExamImageDrawingModel drawing in examImageDrawings)
            {
                getDrawingPoints(examId, drawing);
                
                if (drawing.drawingType == "Ruler")
                {
                    getRulerLineLength(drawing);
                }
            }

            return examImageDrawings;
        }

        public IEnumerable<ExamImageDrawingModel> getDrawingsByExamImage(int examId, int examImageId)
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

        private void getRulerLineLength(ExamImageDrawingModel drawing)
        {
            List<RulerLengthModel> rulerLengths = context.rulerLength.Where(rl => rl.examImageDrawingId == drawing.id).ToList();

            drawing.lineLength = new List<float>();

            foreach (RulerLengthModel rulerLengthModel in rulerLengths)
            {
                drawing.lineLength.Add(rulerLengthModel.lineLength);
            }
        }
    }
}
