using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMDigital.Views
{
    public interface IFilterView
    {
        Bitmap originalImage { get; set; }

        Bitmap editedImage { get; set; }
    }
}
