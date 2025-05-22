using WimDesktop.Models;
using System.Collections.Generic;

namespace WimDesktop.Interface.IRepository
{
    public interface IPatientRepository
    {
        void addPatient(PatientModel patient);
        void editPatient();
        void deletePatient(int patientId);
        IEnumerable<PatientModel> getAllPatients();
        PatientModel getPatientById(int patientid);
        IEnumerable<PatientModel> getPatientsByName(string value);
        void importPatient(PatientModel patient);
    }
}
