using System.Drawing;

namespace DMMDigital.Views
{
    public interface IFilterView
    {
        Bitmap originalImage { get; set; }
        Bitmap editedImage { get; set; }
    }
}
