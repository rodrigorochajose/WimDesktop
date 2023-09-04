using DMMDigital.Modelos;
using System.Collections.Generic;

namespace DMMDigital.Interface
{
    public interface IExamRepository
    {
        void add(ExamModel exam);
        void edit(ExamModel exam);
        void delete(int id);
        IEnumerable<PatientModel> selectExamsByPatient(int patientId);
    }
}
