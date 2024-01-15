using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamRepository
    {
        int add(ExamModel exam);
        void edit(ExamModel exam);
        OperationStatus delete(int examId);
        IEnumerable<ExamModel> getPatientExams(int patientId);
        ExamModel getExam (int examId);
    }
}
