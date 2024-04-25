using DMMDigital.Interface.IView;
using DMMDigital.Models;
using System;

namespace DMMDigital.Presenters
{
    public class ExamContainerPresenter
    {
        private int detectorId = 0;
        private readonly IExamContainerView examContainerView;

        public ExamContainerPresenter(IExamContainerView view, int patientId, int detectorId)
        {
            examContainerView = view;
            view.patientId = patientId;

            examContainerView.eventDestroyDetector += destroyDetector;
            this.detectorId = detectorId;
        }

        private void destroyDetector(object sender, EventArgs e)
        {
            if (detectorId == 0) return;

            Detector d = Detector.DetectorList[detectorId];
            if (d == null) return;

            d.Disconnect();
            Detector.DestroyDetector(detectorId);
        }
    }
}
