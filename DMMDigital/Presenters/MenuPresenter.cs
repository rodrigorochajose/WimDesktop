using System;
using DMMDigital.Views;
using DMMDigital.Modelos;
using DMMDigital._Repositories;
using DMMDigital.Forms;
using DMMDigital.Interface;

namespace DMMDigital.Presenters
{
    public class MenuPresenter
    {
        private IMenuView menuView;
        
        public MenuPresenter(IMenuView menuView)
        {
            this.menuView = menuView;
            this.menuView.showNewExamView += showNewExam;
            this.menuView.showPatientView += showPatient;
            this.menuView.showConfigView += showConfig;
        }

        private void showConfig(object sender, EventArgs e)
        {
            IConfigView view = new ConfigView();
            IConfigRepository repository = new ConfigRepository();
            new ConfigPresenter(view, repository);

        }

        private void showPatient(object sender, EventArgs e)
        {
            IPatientView view = new PatientView();
            IPatientRepository repository = new PatientRepository();
            new PatientPresenter(view, repository);
        }

        private void showNewExam(object sender, EventArgs e)
        {
            IChoosePatientExamView view = new ChoosePatientExamView();
            IPatientRepository repository = new PatientRepository();
            new ChoosePatientExamPresenter(view, repository);
        }
    }
}
