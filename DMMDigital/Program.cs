using DMMDigital._Repositories;
using DMMDigital.Forms;
using DMMDigital.Interface;
using DMMDigital.Modelos;
using DMMDigital.Presenters;
using DMMDigital.Views;
using System;
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
            //IMenuView view = new MenuView();
            //new MenuPresenter(view);
            //Application.Run((Form)view);
            Application.Run(new Form1());
        }
    }
}
