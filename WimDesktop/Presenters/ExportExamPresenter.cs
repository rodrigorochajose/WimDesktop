using WimDesktop._Repositories;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WimDesktop.Presenters
{
    public class ExportExamPresenter
    {
        private readonly IExportExamView exportExamView;
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public ExportExamPresenter(IExportExamView view) 
        {
            exportExamView = view;

            view.eventSaveExportPath += saveExportPath;
            view.eventGetExportPath += getExportPath;

            setWaterMark();

            (exportExamView as Form).ShowDialog();
        }

        private void saveExportPath(object sender, EventArgs e)
        {
            settingsRepository.saveExportPath(exportExamView.pathToExport);
        }

        private void getExportPath(object sender, EventArgs e)
        {
            exportExamView.pathToExport = settingsRepository.getExportPath();
        }

        private void setWaterMark()
        {
            exportExamView.waterMark = settingsRepository.getWaterMark();
        }
    }
}
