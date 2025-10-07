using WimDesktop.Models;
using System.Collections.Generic;
using System;

namespace WimDesktop.Interface.IRepository
{
    public interface IExamRepository
    {
        void addExam(ExamModel exam);
        void deleteExam(int examId);
        int getExamId(ExamModel exam);
        int getTemplateId(int examId);
        ExamModel getExam (int examId);
        DateTime getPatientLastUpdatedExam(int patientId);
        IEnumerable<ExamModel> getPatientExams(int patientId);
        bool examHasImages(int examId);
        void updateExamTemplate(int examId, int templateId);
        void updateExamLastChange(int examId);
        bool patientHasExams(int patientId);
    }
}
