using DMMDigital.Models;
using System.Collections.Generic;
using System.Drawing;

namespace DMMDigital.Interface
{
    public interface IExamImageDrawingPointsRepository
    {
        void save();
        void addExamImageDrawingPoints(List<ExamImageDrawingPointsModel> pointsToSave);
        void updatePoints(int drawingId, List<Point> points);
        void deleteExamImageDrawingPointsByDrawings(List<int> drawingsIdToDelete);
        void deleteExamImageDrawingPoints(int examId);
        IEnumerable<ExamImageDrawingPointsModel> getExamImageDrawingPoints(int examId);
        IEnumerable<ExamImageDrawingPointsModel> getExamImageDrawingPointsByExamImage(int examId, int examImageId);
    }
}
