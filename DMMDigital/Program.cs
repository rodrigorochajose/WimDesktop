using DMMDigital._Repositories;
using DMMDigital.Interface.IView;
using DMMDigital.Presenters;
using DMMDigital.Views;
using System;
using System.Configuration;
using System.Data.Common;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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

            IMenuView view = new MenuView();
            new MenuPresenter(view);
            Application.Run((Form)view);
        }

        static void configDatabase()
        {
            string connectionStringName = "Database";
            string newClientLibraryPath = @"C:\WimDesktopDB\db\Firebird\fbclient.dll";

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)configFile.GetSection("connectionStrings");

            var connectionStringConfig = connectionStringsSection.ConnectionStrings[connectionStringName];
            if (connectionStringConfig != null)
            {
                DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
                builder.ConnectionString = connectionStringConfig.ConnectionString;

                builder["ClientLibrary"] = newClientLibraryPath;

                builder["Password"] = "q6xG3yyJGwOPIHmFh6m1";
                builder["Database"] = "env-7096808.sp1.br.saveincloud.net.br:/opt/firebird/data/WIMDESKTOPDB.FDB";
                builder["DataSource"] = "env-7096808.sp1.br.saveincloud.net.br";
                builder["Port"] = "3050";
                builder["Dialect"] = "3";
                builder["ServerType"] = "0";


                connectionStringConfig.ConnectionString = builder.ConnectionString;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }
    }
}
