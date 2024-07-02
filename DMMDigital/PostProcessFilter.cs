using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Drawing;

namespace DMMDigital
{
    public static class PostProcessFilter
    {
        public static Bitmap applyFilters(Bitmap image, float[] values)
        {
            Image<Gray, Byte> img = image.ToImage<Gray, Byte>();

            float gamma = values[0];
            float edge = values[1];
            float noise = values[2];

            if (gamma != 0)
                img = applyGamma(img, gamma);

            if (edge != 0)
                img = applyEdge(img, edge);

            if (noise != 0)
                img = applyNoise(img, noise);

            return img.ToBitmap();
        }

        private static Image<Gray, Byte> applyGamma(Image<Gray, Byte> image, float value)
        {
            Image<Gray, Byte> imagemGamma = new Image<Gray, Byte>(image.Size);

            value = 1.0f / value;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    byte valor = (byte)(Math.Pow((double)image.Data[y, x, 0] / 255, value) * 255);
                    imagemGamma.Data[y, x, 0] = valor;
                }
            }

            return imagemGamma;
        }

        private static Image<Gray, Byte> applyEdge(Image<Gray, Byte> image, float value)
        {
            Image<Gray, Byte> imagemEdge = new Image<Gray, Byte>(image.Size);
            CvInvoke.Sobel(image, imagemEdge, DepthType.Cv8U, 1, 0, 3);

            CvInvoke.AddWeighted(imagemEdge, 1.2, image, 0.8, value, imagemEdge);

            return imagemEdge;
        }

        private static Image<Gray, Byte> applyNoise(Image<Gray, Byte> image, float value)
        {
            CvInvoke.GaussianBlur(image, image, new Size(5, 5), 0);

            CvInvoke.AddWeighted(image, 1, image, 0, value, image);

            return image;
        }
    }
}
