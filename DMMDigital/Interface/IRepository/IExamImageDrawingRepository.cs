using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface.IRepository
{
    public interface IExamImageDrawingRepository
    { 
        void addDrawing(ExamImageDrawingModel drawing);
        void deleteRangeDrawing(List<ExamImageDrawingModel> drawings);
        void deleteAllDrawings(int examId);
        IEnumerable<ExamImageDrawingModel> getDrawings(int examId);
        IEnumerable<ExamImageDrawingModel> getDrawingsByExamImage(int examId, int examImageId);
    }
}
