using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using System;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ExportExamPresenter
    {
        private readonly IExportExamView exportExamView;
        private readonly IExamImageDrawingRepository examImageDrawingRepository = new ExamImageDrawingRepository();
        private readonly ISettingsRepository settingsRepository = new SettingsRepository();

        public ExportExamPresenter(IExportExamView view, int examId) 
        {
            exportExamView = view;

            view.eventSaveExportPath += saveExportPath;
            view.eventGetExportPath += getExportPath;

            getImageDrawings(examId);

            (exportExamView as Form).ShowDialog();
        }

        private void getImageDrawings(int examId)
        {
            exportExamView.examImageDrawings = examImageDrawingRepository.getDrawings(examId).ToList();
        }

        private void saveExportPath(object sender, EventArgs e)
        {
            settingsRepository.saveExportPath(exportExamView.pathToExport);
        }

        private void getExportPath(object sender, EventArgs e)
        {
            exportExamView.pathToExport = settingsRepository.getExportPath();
        }
    }
}
