using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Models;
using DMMDigital.Views;
using System;

namespace DMMDigital.Presenters
{
    public class ExamContainerPresenter
    {
        private int detectorId = 0;
        private readonly IExamContainerView examContainerView;
        private readonly IPatientRepository patientRepository = new PatientRepository();

        public ExamContainerPresenter(IExamContainerView view, int detectorId)
        {
            examContainerView = view;

            examContainerView.eventGetPatient += getPatient;
            examContainerView.eventDestroyDetector += destroyDetector;
            this.detectorId = detectorId;
        }

        private void destroyDetector(object sender, EventArgs e)
        {
            Detector.DestroyDetector(detectorId);
        }

        private void getPatient(object sender, EventArgs e)
        {
            examContainerView.patient = patientRepository.getPatientById(examContainerView.patientId);
        }
    }
}
