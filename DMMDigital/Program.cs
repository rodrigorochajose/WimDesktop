using DMMDigital._Repositories;
using DMMDigital.Interface.IView;
using DMMDigital.Presenters;
using DMMDigital.Views;
using System;
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

            string culture = configRepository.getLanguage();

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);

            IMenuView view = new MenuView();
            new MenuPresenter(view);
            Application.Run((Form)view);     
        }
    }
}
