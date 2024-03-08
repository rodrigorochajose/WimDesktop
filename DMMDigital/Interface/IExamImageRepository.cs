using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamImageRepository
    {
        void save();
        void addExamImage(ExamImageModel examImage);
        void deleteRangeExamImages(List<ExamImageModel> examImagesToDelete);
        OperationStatus deleteAllExamImages(int examId);
        IEnumerable<ExamImageModel> getExamImages(int examId);
    }
}
