using DMMDigital.Views;
using DMMDigital._Repositories;
using DMMDigital.Interface.IView;
using System.IO;
using System;
using System.Linq;

namespace DMMDigital.Presenters
{
    public class MenuPresenter
    {
        private readonly IMenuView menuView;

        public MenuPresenter(IMenuView view)
        {
            menuView = view;

            menuView.showConfigView += delegate 
            {
                FormManager.instance.showForm("configView", () => new ConfigPresenter(new ConfigView(), new ConfigRepository())); 
            };

            menuView.showPatientView += delegate 
            {
                FormManager.instance.showForm("patientView", () => new PatientPresenter(new PatientView(), new PatientRepository(), "newContainer")); 
            };

            menuView.showTemplateView += delegate 
            {
                FormManager.instance.showForm("templateView", () => new TemplatePresenter(new TemplateView())); 
            };

            menuView.showNewExamView += delegate 
            {
                FormManager.instance.showForm("choosePatientExamView", () => new ChoosePatientExamPresenter(new PatientExamView(), new PatientRepository())); 
            };

            generateDatabaseBackup();
        }

        public void generateDatabaseBackup()
        {
            string backupDirectory = @"C:\\WimDesktopDB\\bkp\\";

            string currentDatabaseFilePath = @"C:\WimDesktopDB\db\WIMDESKTOPDB.FDB";

            string targetDirectoryPath = Path.Combine(backupDirectory, $"BKP_{DateTime.Now:dd-MM-yyyy-HH-m-ss}");

            if (!Directory.Exists(targetDirectoryPath))
            {
                Directory.CreateDirectory(targetDirectoryPath);
            }

            File.Copy(currentDatabaseFilePath, Path.Combine(targetDirectoryPath, "WIMDESKTOPDB.FDB"));

            var directories = Directory.GetDirectories(@"C:\WimDesktopDB\bkp");


            if (directories.Length > 200)
            {
                var oldest = directories.Select(f => new FileInfo(f)).OrderBy(fi => fi.CreationTime).First();
                Directory.Delete(oldest.FullName, true);
            }
        }
    }
}
