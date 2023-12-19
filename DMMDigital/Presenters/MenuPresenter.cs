using DMMDigital.Views;
using DMMDigital._Repositories;

namespace DMMDigital.Presenters
{
    public class MenuPresenter
    {
        private IMenuView menuView;
        
        public MenuPresenter(IMenuView view)
        {
            menuView = view;
            menuView.showConfigView += delegate { new ConfigPresenter(new ConfigView(), new ConfigRepository()); };
            menuView.showPatientView += delegate { new PatientPresenter(new PatientView(), new PatientRepository(), "newContainer"); };
            menuView.showNewExamView += delegate { new ChoosePatientExamPresenter(new ChoosePatientExamView(), new PatientRepository()); };
        }
    }
}
