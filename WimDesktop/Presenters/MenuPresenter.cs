using WimDesktop.Views;
using WimDesktop.Interface.IView;
using System.IO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class MenuPresenter
    {
        private readonly IMenuView menuView;

        public MenuPresenter(IMenuView view)
        {
            menuView = view;

            menuView.showSettingsView += delegate 
            {
                FormManager.instance.openForm<SettingsView>(() => new SettingsPresenter(new SettingsView())); 
            };

            menuView.showPatientView += delegate 
            {
                FormManager.instance.openForm<PatientView>(() => new PatientPresenter(new PatientView())); 
            };

            menuView.showTemplateView += delegate 
            {
                FormManager.instance.openForm<TemplateView>(() => new TemplatePresenter(new TemplateView())); 
            };

            menuView.showNewExamView += delegate 
            {
                FormManager.instance.openForm<ExamPatientSelectionView>(() => new ExamPatientSelectionPresenter(new ExamPatientSelectionView())); 
            };

            generateDatabaseBackup();

            (menuView as Form).Show();
        }

        public void generateDatabaseBackup()
        {
            string backupDirectory = "C:\\WimDesktopDB\\bkp\\";

            string currentDatabaseFilePath = "C:\\WimDesktopDB\\db\\WIMDESKTOPDB.FDB";

            string targetDirectoryPath = Path.Combine(backupDirectory, $"BKP_{DateTime.Now:dd-MM-yyyy-HH-m-ss}");

            if (!Directory.Exists(targetDirectoryPath))
            {
                Directory.CreateDirectory(targetDirectoryPath);
            }

            File.Copy(currentDatabaseFilePath, Path.Combine(targetDirectoryPath, "WIMDESKTOPDB.FDB"));

            var directories = Directory.GetDirectories("C:\\WimDesktopDB\\bkp");

            if (directories.Length > 200)
            {
                var oldest = directories.Select(f => new FileInfo(f)).OrderBy(fi => fi.CreationTime).First();
                Directory.Delete(oldest.FullName, true);
            }
        }
    }
}
