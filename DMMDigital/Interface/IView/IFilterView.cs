using System.Drawing;

namespace DMMDigital.Interface.IView
{
    public interface IFilterView
    {
        Bitmap originalImage { get; set; }
        Bitmap editedImage { get; set; }
    }
}
