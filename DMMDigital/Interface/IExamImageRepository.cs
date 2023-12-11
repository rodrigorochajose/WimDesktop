using DMMDigital.Modelos;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamImageRepository
    {
        void save(List<ExamImageModel> examImages);
        IEnumerable<ExamImageModel> getExamImages(int examId);
    }
}
