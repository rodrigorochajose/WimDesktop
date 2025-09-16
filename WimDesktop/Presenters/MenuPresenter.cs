using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Views;

namespace WimDesktop.Presenters
{
    public class MenuPresenter
    {
        private readonly IMenuView menuView;

        private readonly IClinicRepository clinicRepository = new ClinicRepository();

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

            menuView.showProfileView += delegate
            {
                FormManager.instance.openForm<ClinicProfileView>(() => new ClinicProfilePresenter(new ClinicProfileView()));
            };

            view.eventLogout += logout;

            generateDatabaseBackup();

            (menuView as Form).Show();
        }

        private void logout(object sender, EventArgs ev)
        {
            clinicRepository.updateLoginMethod(false);
            Application.Restart();
            Application.Exit();
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
