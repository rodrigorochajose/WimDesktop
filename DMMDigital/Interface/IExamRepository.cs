using DMMDigital.Modelos;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamRepository
    {
        void add(ExamModel exam);
        void edit(ExamModel exam);
        string delete(int examId);
        IEnumerable<ExamModel> selectExamsByPatient(int patientId);
    }
}
