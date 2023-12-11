using DMMDigital.Modelos;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamImageDrawingRepository
    {
        void save(List<ExamImageDrawingModel> examImageDrawing);
     
        IEnumerable<ExamImageDrawingModel> getExamImageDrawings(int examId);
    }
}
