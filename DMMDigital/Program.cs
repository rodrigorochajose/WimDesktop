using DMMDigital._Repositories;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Presenters;
using DMMDigital.Views;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace DMMDigital
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

            loadLanguage();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            openApplication();
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

        static void openApplication()
        {
            ClinicRepository clinicRepository = new ClinicRepository();

            DialogResult result = DialogResult.Cancel;

            if (!clinicRepository.hasClinic())
            {
                using (var clinicView = new ClinicHandlerView(false))
                {
                    new ClinicPresenter(clinicView);
                    if (clinicView.ShowDialog() == DialogResult.Cancel)
                    {
                        FormManager.instance.closeAllForms();
                    }
                }
            }

            ClinicModel clinic = clinicRepository.getClinic();

            if (clinic.automaticLogin == 1)
            {
                result = DialogResult.OK;
            }
            else
            {
                string email = "";
                bool keepConnected = false;

                if (clinicRepository.keepConnected())
                {
                    email = clinic.email;
                    keepConnected = true;
                }

                using (var loginView = new LoginView(email, keepConnected))
                {
                    new LoginPresenter(loginView);
                    result = loginView.ShowDialog();
                }
            }

            if (result == DialogResult.OK)
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
    }
}
