using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class PatientCreationPresenter
    {
        private IPatientCreationView view;
        private readonly IPatientRepository patientRepository = new PatientRepository();

        public PatientCreationPresenter(IPatientCreationView view)
        {
            this.view = view;

            view.eventAddNewPatient += addNewPatient;
        }

        private void addNewPatient(object sender, EventArgs e)
        {
            try
            {
                PatientModel newPatient = new PatientModel
                {
                    id = view.patientId,
                    name = view.patientName,
                    birthDate = view.patientBirthDate,
                    phone = view.patientPhone,
                    recommendation = view.patientRecommendation,
                    observation = view.patientObservation,
                };

                new Common.ModelDataValidation().Validate(newPatient);
                patientRepository.addPatient(newPatient);
                (view as Form).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
