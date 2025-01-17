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

            ConfigRepository configRepository = new ConfigRepository();

            configDatabase();

            string culture = "";

            try
            {
                culture = configRepository.getLanguage();
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

            var connectionStringSettings = connectionStringsSection.ConnectionStrings[connectionStringName];
            if (connectionStringSettings != null)
            {
                DbConnectionStringBuilder builder = new DbConnectionStringBuilder();
                builder.ConnectionString = connectionStringSettings.ConnectionString;

                builder["ClientLibrary"] = newClientLibraryPath;

                connectionStringSettings.ConnectionString = builder.ConnectionString;

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }
    }
}
