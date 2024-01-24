using DMMDigital.Views;
using DMMDigital._Repositories;

namespace DMMDigital.Presenters
{
    public class MenuPresenter
    {
        private readonly IMenuView menuView;
        
        public MenuPresenter(IMenuView view)
        {
            menuView = view;
            menuView.showConfigView += delegate { new ConfigPresenter(new ConfigView(), new ConfigRepository()); };
            menuView.showPatientView += delegate { new PatientPresenter(new PatientView(), new PatientRepository(), "newContainer"); };
            menuView.showTemplateView += delegate { new TemplatePresenter(new TemplateView()); };
            menuView.showNewExamView += delegate { new ChoosePatientExamPresenter(new ChoosePatientExamView(), new PatientRepository()); };
        }
    }
}
