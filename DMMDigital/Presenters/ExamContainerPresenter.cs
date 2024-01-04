using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Views;
using System;

namespace DMMDigital.Presenters
{
    public class ExamContainerPresenter
    {
        private readonly IExamContainerView examContainerView;
        private readonly IPatientRepository patientRepository = new PatientRepository();


        public ExamContainerPresenter(IExamContainerView view)
        {
            examContainerView = view;

            examContainerView.eventGetPatient += getPatient;
        }

        private void getPatient(object sender, EventArgs e)
        {
            examContainerView.patient = patientRepository.getPatientById(examContainerView.patientId);
        }
    }
}
