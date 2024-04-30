using DMMDigital.Models;
using System.Collections.Generic;
using System.Drawing;

namespace DMMDigital.Interface.IRepository
{
    public interface IExamImageDrawingPointsRepository
    {
        void addDrawingPoints(List<ExamImageDrawingPointsModel> drawingPoints);
        void updateDrawingPoints(int drawingId, List<Point> drawingPoints);
        void deleteRangeDrawingPoints(List<int> drawingsId);
        List<Point> getExamImageDrawingPointsByDrawing(int drawingId);
    }
}
