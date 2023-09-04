using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Views;
using System;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ExamPresenter
    {
        private IExamView examView;
        private IExamRepository examRepository;
        private IConfigRepository configRepository = new ConfigRepository();

        public ExamPresenter(IExamView view,  IExamRepository repository)
        {
            this.examView = view;
            this.examRepository = repository;

            examView.eventGetExamPath += getExamPath;

            (examView as Form).ShowDialog();
        }

        private void getExamPath(object sender, EventArgs e)
        {
            examView.examPath = configRepository.getExamPath();
        }
    }
}
