using Emgu.CV;

namespace WimDesktop.Interface.IView
{
    public interface IFilterView
    {
        Mat originalImage { get; set; }
        Mat editedImage { get; set; }
    }
}
