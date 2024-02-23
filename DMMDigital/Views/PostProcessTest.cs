using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.IntensityTransform;
using Emgu.CV.Structure;

namespace DMMDigital.Views
{
    public partial class PostProcessTest : Form
    {
        private bool useEmguCv = false;

        public PostProcessTest()
        {
            InitializeComponent();

            pictureBox1.Image = Image.FromFile(@"C:\Users\USER\Desktop\semfiltro.bmp");
            pictureBox2.Image = Image.FromFile(@"C:\Users\USER\Desktop\semfiltro.bmp");
        }

        public Bitmap applyGamma(Bitmap image, float value)
        {
            Mat img = image.ToMat();

            IntensityTransformInvoke.GammaCorrection(img, img, value);

            return img.ToBitmap();
        }

        public Bitmap applyGammaCV(Bitmap image, float value)
        {
            Mat img = image.ToMat();

            Mat pb2 = new Bitmap(image).ToMat();
            Mat pb3 = new Bitmap(image).ToMat();
            Mat pb4 = new Bitmap(image).ToMat();

            IntensityTransformInvoke.GammaCorrection(img, pb2, (float)0.5);
            IntensityTransformInvoke.GammaCorrection(img, pb3, (float)0.8);
            IntensityTransformInvoke.GammaCorrection(img, pb4, (float)0.9);

            pb2.Save(@"C:\Users\USER\Desktop\05gamma.bmp");
            pb3.Save(@"C:\Users\USER\Desktop\08gamma.bmp");
            pb4.Save(@"C:\Users\USER\Desktop\09gamma.bmp");

            return image;
        }

        public Bitmap applyEdge(Bitmap image, float value)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(0.2989 * pixel.R + 0.5870 * pixel.G + 0.1140 * pixel.B); // Convert to grayscale

                    // Apply edge enhancement filter
                    int edgeValue = (int)(gray + value * LaplacianFilter(image, x, y));
                    edgeValue = Math.Max(0, Math.Min(255, edgeValue)); // Ensure pixel value is within [0, 255]

                    result.SetPixel(x, y, Color.FromArgb(edgeValue, edgeValue, edgeValue));
                }
            }

            return result;
        }

        public Bitmap applyEdgeCV(Bitmap image, float value)
        {
            // Convertendo a imagem para um formato aceito pelo OpenCV (escala de cinza)
            Image<Gray, byte> srcImage = image.ToImage<Gray, byte>();

            Image<Gray, byte> pb2 = srcImage.Canny(0.25, 0.25);
            Image<Gray, byte> pb3 = srcImage.Canny(0.50, 0.50);
            Image<Gray, byte> pb4 = srcImage.Canny(0.75, 0.75);
            Image<Gray, byte> pb5 = srcImage.Canny(1, 1);

            pb2.Save(@"C:\Users\USER\Desktop\025.bmp");
            pb3.Save(@"C:\Users\USER\Desktop\050.bmp");
            pb4.Save(@"C:\Users\USER\Desktop\075.bmp");
            pb5.Save(@"C:\Users\USER\Desktop\100.bmp");

            pictureBox2.Image = pb2.ToBitmap();
            pictureBox2.Refresh();

            pictureBox3.Image = pb3.ToBitmap();
            pictureBox3.Refresh();

            pictureBox4.Image = pb4.ToBitmap();
            pictureBox4.Refresh();

            return srcImage.ToBitmap();
        }

        public Bitmap applyNoise(Bitmap image, float value)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = ApplyMedianFilter(image, x, y, (int)value);
                    result.SetPixel(x, y, pixel);
                }
            }

            return result;
        }

        public Bitmap applyNoiseCV(Bitmap image, float value)
        {
            Image<Gray, byte> imagemOriginal = image.ToImage<Gray, byte>();

            Image<Gray, byte> imagemComRuidoReduzido = imagemOriginal.SmoothGaussian(9); // Ajuste o tamanho do kernel conforme necessário
            return imagemComRuidoReduzido.ToBitmap();
        }

        private void button_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = new Bitmap(pictureBox1.Image);
        }

        private static double LaplacianFilter(Bitmap image, int x, int y)
        {
            double[,] kernel = {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            double sum = 0;
            int kernelSize = 3;

            for (int i = 0; i < kernelSize; i++)
            {
                for (int j = 0; j < kernelSize; j++)
                {
                    int pixelX = x - kernelSize / 2 + i;
                    int pixelY = y - kernelSize / 2 + j;

                    if (pixelX >= 0 && pixelX < image.Width && pixelY >= 0 && pixelY < image.Height)
                    {
                        Color pixel = image.GetPixel(pixelX, pixelY);
                        double gray = 0.2989 * pixel.R + 0.5870 * pixel.G + 0.1140 * pixel.B; // Convert to grayscale
                        sum += gray * kernel[i, j];
                    }
                }
            }

            return sum;
        }

        private static Color ApplyMedianFilter(Bitmap image, int x, int y, int kernelSize)
        {
            int radius = kernelSize / 2;
            int[] redValues = new int[kernelSize * kernelSize];
            int[] greenValues = new int[kernelSize * kernelSize];
            int[] blueValues = new int[kernelSize * kernelSize];
            int index = 0;

            // Collect pixel values within the kernel
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    int pixelX = x + j;
                    int pixelY = y + i;

                    if (pixelX >= 0 && pixelX < image.Width && pixelY >= 0 && pixelY < image.Height)
                    {
                        Color pixel = image.GetPixel(pixelX, pixelY);
                        redValues[index] = pixel.R;
                        greenValues[index] = pixel.G;
                        blueValues[index] = pixel.B;
                    }
                    else
                    {
                        redValues[index] = 0;
                        greenValues[index] = 0;
                        blueValues[index] = 0;
                    }

                    index++;
                }
            }

            // Sort the pixel values
            Array.Sort(redValues);
            Array.Sort(greenValues);
            Array.Sort(blueValues);

            // Get the median value
            int medianIndex = kernelSize * kernelSize / 2;
            int medianRed = redValues[medianIndex];
            int medianGreen = greenValues[medianIndex];
            int medianBlue = blueValues[medianIndex];

            return Color.FromArgb(medianRed, medianGreen, medianBlue);
        }

        private void buttonApplyCV_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox2.Image);
            image = applyGammaCV(image, (float)numericUpDownGamma.Value);
          
            //image = applyEdgeCV(image, (float)numericUpDownEdge.Value);
            
            //image = applyNoiseCV(image, (float)numericUpDownNoise.Value);
            

            //MessageBox.Show("mudando img");
            //pictureBox2.Image = image;
            //Refresh();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox2.Image);
            image = applyGamma(image, (float)numericUpDownGamma.Value);
            image = applyEdge(image, (float)numericUpDownEdge.Value);
            image = applyNoise(image, (float)numericUpDownNoise.Value);

            MessageBox.Show("mudando img");
            pictureBox2.Image = image;
            Refresh();
        }
    }
}
