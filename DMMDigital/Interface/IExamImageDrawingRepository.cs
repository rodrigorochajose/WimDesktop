using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamImageDrawingRepository
    { 
        void save();
        void addExamImageDrawing(ExamImageDrawingModel examImageDrawing);
        void deleteRangeExamImageDrawings(List<ExamImageDrawingModel> examImageDrawings);
        void deleteAllExamImageDrawings(int examId);
        IEnumerable<ExamImageDrawingModel> getExamImageDrawings(int examId);
        IEnumerable<ExamImageDrawingModel> getExamImageDrawingsByExamImage(int examImageId);
    }
}
