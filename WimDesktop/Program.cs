using WimDesktop._Repositories;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Presenters;
using WimDesktop.Views;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace WimDesktop
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!connectDatabase())
            {
                return;
            }

            checkMigrations();

            loadLanguage();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            getClinicToLogin();
        }

        static bool connectDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

            try
            {
                using (FbConnection conexao = new FbConnection(connectionString))
                {
                    conexao.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar no banco de dados: {ex.Message}");
                return false;
            }
        }

        static void checkMigrations()
        {
            var configuration = new Migrations.Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();

            var seedMethod = configuration.GetType().GetMethod("Seed", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            if (seedMethod != null)
            {
                using (Context context = new Context())
                {
                    seedMethod.Invoke(configuration, new object[] { context });
                    context.SaveChanges();
                }
            }
        }

        static void loadLanguage()
        {
            SettingsRepository settingsRepository = new SettingsRepository();

            string culture = "";

            try
            {
                culture = settingsRepository.getLanguage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
        }

        static void getClinicToLogin()
        {
            ClinicRepository clinicRepository = new ClinicRepository();
            ClinicModel clinic = clinicRepository.getClinic();

            if (clinic == null)
            {
                using (var clinicView = new ClinicHandlerView())
                {
                    new ClinicPresenter(clinicView);
                    DialogResult res = clinicView.ShowDialog();

                    if (res == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            clinic = clinicRepository.getClinic();

            login(clinic);
        }

        static void login(ClinicModel clinic)
        {
            DialogResult loginResult = DialogResult.OK;

            if (clinic.automaticLogin == 0)
            {
                using (var loginView = new LoginView(clinic.email))
                {
                    new LoginPresenter(loginView);
                    loginResult = loginView.ShowDialog();
                }
            }

            if (loginResult == DialogResult.OK)
            {
                runApplication();
            }
        }

        static void runApplication()
        {
            IMenuView menuView = new MenuView();
            new MenuPresenter(menuView);
            Application.Run((Form)menuView);
        }

        static void setupAutoUpdate()
        {
            //AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent;

            //AutoUpdater.ShowRemindLaterButton = false;
            //AutoUpdater.ShowSkipButton = false;
            //AutoUpdater.Mandatory = false;

            //AutoUpdater.Start("https://wimdesktop.z15.web.core.windows.net/wimdesktop/update.xml");
        }

        private static void AutoUpdaterOnCheckForUpdateEvent()
        {
            //UpdateInfoEventArgs args

            //if (args.IsUpdateAvailable)
            //{
            //    DialogResult dialogResult = MessageBox.Show(
            //        $"Há uma nova versão {args.CurrentVersion} disponível. Deseja atualizar agora?",
            //        "Atualização disponível",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Information);

            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            AutoUpdater.DownloadUpdate(args);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }
    }
}
