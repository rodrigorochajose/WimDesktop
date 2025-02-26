using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface.IRepository
{
    public interface IExamRepository
    {
        void addExam(ExamModel exam);
        void deleteExam(int examId);
        int getExamId(ExamModel exam);
        ExamModel getExam (int examId);
        IEnumerable<ExamModel> getPatientExams(int patientId);
        bool examHasImages(int examId);
        void updateExamTemplate(int examId, int templateId);
        void updateExamLastChange(int examId);
    }
}
