using System.Collections.Generic;

namespace DMMDigital.Modelos
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
