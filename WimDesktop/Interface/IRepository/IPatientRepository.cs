using System.Collections.Generic;
using WimDesktop.Models;
using WimDesktop.Models.Dto;

namespace WimDesktop.Interface.IRepository
{
    public interface IPatientRepository
    {
        void addPatient(PatientModel patient);
        void editPatient();
        void deletePatient(int patientId);
        List<PatientDataToListDto> getAllPatientsDataToList();
        PatientModel getPatientById(int patientid);
        List<PatientDataToListDto> getPatientsByName(string value);
        void importPatient(PatientModel patient);
    }
}
