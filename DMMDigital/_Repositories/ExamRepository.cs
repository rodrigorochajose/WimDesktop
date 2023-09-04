using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital._Repositories
{
    public class ExamRepository : IExamRepository
    {
        public void add(ExamModel exam)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public void edit(ExamModel exam)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientModel> selectExamsByPatient(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
