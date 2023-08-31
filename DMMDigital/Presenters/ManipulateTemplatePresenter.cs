using DMMDigital.Interface;
using DMMDigital.Views;
using System.Windows.Forms;

namespace DMMDigital.Presenters
{
    public class ManipulateTemplatePresenter
    {
        private ManipulateTemplateView manipulateTemplateView;
        private ITemplateRepository templateRepository;

        public ManipulateTemplatePresenter(ManipulateTemplateView view, ITemplateRepository repository) 
        { 
            manipulateTemplateView = view;
            templateRepository = repository;

            (manipulateTemplateView as Form).ShowDialog();
        }
    }
}
