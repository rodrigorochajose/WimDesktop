using DMMDigital._Repositories;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using System.Linq;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ExportExamPresenter
    {
        private readonly IExportExamView exportExamView;

        private readonly IExamImageDrawingRepository examImageDrawingRepository = new ExamImageDrawingRepository();

        public ExportExamPresenter(IExportExamView view, int examId) 
        {
            exportExamView = view;

            getImageDrawings(examId);

            (exportExamView as Form).ShowDialog();
        }

        private void getImageDrawings(int examId)
        {
            exportExamView.examImageDrawings = examImageDrawingRepository.getDrawings(examId).ToList();
        }
    }
}
