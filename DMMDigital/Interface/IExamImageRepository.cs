using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamImageRepository
    {
        void save(List<ExamImageModel> examImages);
        OperationStatus delete(int examId);
        IEnumerable<ExamImageModel> getExamImages(int examId);
    }
}
