using WimDesktop.Models;
using System.Collections.Generic;

namespace WimDesktop.Interface.IRepository
{
    public interface IExamImageRepository
    {
        void save();
        void addExamImage(ExamImageModel examImage);
        void deleteExamImage(ExamImageModel examImages);
        IEnumerable<ExamImageModel> getExamImages(int examId);
        IEnumerable<string> getExamImagesPath(int examId);
        ExamImageModel getExamImageById(int examId, int frameId);
        bool examHasImages(int examId);
        void importExamImages(List<ExamImageModel> examImages);
    }
}
