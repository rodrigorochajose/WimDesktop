using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamImageRepository
    {
        void save();
        void addExamImage(ExamImageModel examImage);
        void deleteExamImage(ExamImageModel examImageToDelete);
        OperationStatus deleteAllExamImages(int examId);
        IEnumerable<ExamImageModel> getExamImages(int examId);
        ExamImageModel getExamImageById(int frameId);
    }
}
