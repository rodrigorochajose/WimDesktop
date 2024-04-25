using DMMDigital.Models;
using System.Collections.Generic;

namespace DMMDigital.Interface.IRepository
{
    public interface IPatientRepository
    {
        string add(PatientModel paciente);
        string edit();
        string delete(int patientId);
        IEnumerable<PatientModel> getAllPatients();
        PatientModel getPatientById(int id);
        IEnumerable<PatientModel> getPatientsByName(string value);
    }
}
