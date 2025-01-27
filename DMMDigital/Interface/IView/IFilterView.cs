using Emgu.CV;

namespace DMMDigital.Interface.IView
{
    public interface IFilterView
    {
        Mat originalImage { get; set; }
        Mat editedImage { get; set; }
    }
}
