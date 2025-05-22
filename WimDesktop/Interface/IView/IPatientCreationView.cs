using System;

namespace WimDesktop.Interface.IView
{
    public interface IPatientCreationView
    {
        int patientId { get; set; }
        string patientName { get; set; }
        DateTime patientBirthDate { get; set; }
        string patientPhone { get; set; }
        string patientRecommendation { get; set; }
        string patientObservation { get; set; }

        event EventHandler eventAddNewPatient;
    }
}
