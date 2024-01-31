using System;

namespace DMMDigital.Views
{
    public interface IPatientHandlerView
    {
        int patientId { get; set; }
        string patientName { get; set; }
        DateTime patientBirthDate { get; set; }
        string patientPhone { get; set; }
        string patientRecommendation { get; set; }
        string patientObservation { get; set; }

        event EventHandler eventAddNewPatient;
        event EventHandler eventSaveEditedPatient;
    }
}
