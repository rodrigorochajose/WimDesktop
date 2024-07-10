using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DMMDigital
{
    public static class PostProcessFilter
    {
        public static Bitmap applyFilters(Bitmap image, float[] values)
        {
            //Image<Gray, Byte> img = image.ToImage<Gray, Byte>();

            //float gamma = values[0];
            //float edge = values[1];
            //float noise = values[2];

            //if (gamma != 0)
            //    img = applyGamma(img, gamma);

            //if (edge != 0)
            //    img = applyEdge(img, edge);

            //if (noise != 0)
            //    img = applyNoise(img, noise);

            Bitmap img = apply(image, values[0], values[1]);

            return img;
        }

        private static Image<Gray, Byte> applyGamma(Image<Gray, Byte> image, float value)
        {
            Image<Gray, Byte> imagemGamma = new Image<Gray, Byte>(image.Size);

            value = 1.0f / (1.0f + value * 0.1f);
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

        public static Bitmap apply(Bitmap img, float c, float b)
        {
            Bitmap contrastAdjusted = AdjustContrast(img, c); // Aumente ou diminua o fator conforme necessário
            Bitmap brightnessAdjusted = AdjustBrightness(contrastAdjusted, b); // Ajuste o brilho conforme necessário
            Bitmap sharpenedImage = ApplySharpen(brightnessAdjusted);

            return sharpenedImage;
        }

        public static Bitmap AdjustContrast(Bitmap image, float contrast)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);
            float[][] contrastMatrix = {
                new float[] {contrast, 0, 0, 0, 0},
                new float[] {0, contrast, 0, 0, 0},
                new float[] {0, 0, contrast, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0.5f * (1.0f - contrast), 0.5f * (1.0f - contrast), 0.5f * (1.0f - contrast), 0, 1}
                };

            ColorMatrix colorMatrix = new ColorMatrix(contrastMatrix);
            using (Graphics g = Graphics.FromImage(adjustedImage))
            {
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);
                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }

            return adjustedImage;
        }

        public static Bitmap AdjustBrightness(Bitmap image, float brightness)
        {
            Bitmap adjustedImage = new Bitmap(image.Width, image.Height);
            float[][] brightnessMatrix = {
                new float[] {1, 0, 0, 0, 0},
                new float[] {0, 1, 0, 0, 0},
                new float[] {0, 0, 1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {brightness, brightness, brightness, 0, 1}
            };

            ColorMatrix colorMatrix = new ColorMatrix(brightnessMatrix);
            using (Graphics g = Graphics.FromImage(adjustedImage))
            {
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);
                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                    0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            }

            return adjustedImage;
        }

        public static Bitmap ApplySharpen(Bitmap image)
        {
            Bitmap sharpenedImage = new Bitmap(image.Width, image.Height);
            float[][] sharpenMatrix = {
                new float[] {-1, -1, -1},
                new float[] {-1,  9, -1},
                new float[] {-1, -1, -1}
            };

            using (Graphics g = Graphics.FromImage(sharpenedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
            }

            return ConvolutionFilter(sharpenedImage, sharpenMatrix, 1.0f, 0);
        }

        private static Bitmap ConvolutionFilter(Bitmap sourceBitmap, float[][] filterMatrix, float factor = 1, int bias = 0)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                                                          ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            int filterWidth = filterMatrix[0].Length;
            int filterHeight = filterMatrix.Length;
            int filterOffset = (filterWidth - 1) / 2;

            for (int offsetY = filterOffset; offsetY < sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < sourceBitmap.Width - filterOffset; offsetX++)
                {
                    float blue = 0, green = 0, red = 0;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            int calcOffset = ((offsetY + filterY) * sourceData.Stride) + ((offsetX + filterX) * 4);
                            blue += (float)(pixelBuffer[calcOffset]) * filterMatrix[filterY + filterOffset][filterX + filterOffset];
                            green += (float)(pixelBuffer[calcOffset + 1]) * filterMatrix[filterY + filterOffset][filterX + filterOffset];
                            red += (float)(pixelBuffer[calcOffset + 2]) * filterMatrix[filterY + filterOffset][filterX + filterOffset];
                        }
                    }

                    int byteOffset = (offsetY * sourceData.Stride) + (offsetX * 4);
                    resultBuffer[byteOffset] = Clamp(blue * factor + bias);
                    resultBuffer[byteOffset + 1] = Clamp(green * factor + bias);
                    resultBuffer[byteOffset + 2] = Clamp(red * factor + bias);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height),
                                                          ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private static byte Clamp(double value)
        {
            return (byte)(value > 255 ? 255 : (value < 0 ? 0 : value));
        }
    }
}
