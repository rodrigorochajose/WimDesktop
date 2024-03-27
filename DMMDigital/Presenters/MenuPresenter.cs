using DMMDigital.Views;
using DMMDigital._Repositories;
using DMMDigital.Interface;

namespace DMMDigital.Presenters
{
    public class MenuPresenter
    {
        private readonly IMenuView menuView;
        private readonly IConfigRepository configRepository = new ConfigRepository();

        public MenuPresenter(IMenuView view)
        {
            menuView = view;
            menuView.showConfigView += delegate { new ConfigPresenter(new ConfigView(), new ConfigRepository()); };
            menuView.showPatientView += delegate { new PatientPresenter(new PatientView(), new PatientRepository(), "newContainer"); };
            menuView.showTemplateView += delegate { new TemplatePresenter(new TemplateView()); };
            menuView.showNewExamView += delegate { new ChoosePatientExamPresenter(new ChoosePatientExamView(), new PatientRepository()); };

            generateDatabaseBackup();
        }

        public void generateDatabaseBackup()
        {

        }
    }
}
