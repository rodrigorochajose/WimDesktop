using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamImageDrawingRepository
    {
        void save(List<ExamImageDrawingModel> examImageDrawing);
        OperationStatus delete(int examId);
     
        IEnumerable<ExamImageDrawingModel> getExamImageDrawings(int examId);
    }
}
