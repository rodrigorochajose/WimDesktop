using GeraçãoDeTemplate.Modelos;
using iDetector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace GeraçãoDeTemplate
{
    public partial class Exame : Form, EventReceiver
    {

        private int m_nId = -1, indice = 0, pacienteId = 0;
        string caminho = "";
        Filme filmeSelecionado;
        List<Filme> listaFilmes;
        Contexto<Configuracao> contextoConfig = new Contexto<Configuracao>();

        public Exame(Paciente paciente, List<TemplateLayout> listaTemplateLayout, string nomeTemplate, string nomeSessao)
        {
            InitializeComponent();

            pacienteId = paciente.id;
            labelPaciente.Text = paciente.nome;
            labelTemplate.Text = nomeTemplate;
            int altura, largura;


            foreach (TemplateLayout tl in listaTemplateLayout)
            {
                if (tl.orientacao == "Vertical")
                {
                    altura = 35;
                    largura = 25;
                }
                else
                {
                    altura = 25;
                    largura = 35;
                }

                Filme novoFilme = new Filme
                {
                    Width = largura,
                    Height = altura,
                    BackColor = System.Drawing.Color.Black,
                    Ordem = tl.ordem,
                    Name = "filme" + tl.ordem,
                    Orientacao = tl.orientacao,
                    ImagemCaptura = false,
                };

                Bitmap image = new Bitmap(novoFilme.Width, novoFilme.Height);
                Graphics graphics = Graphics.FromImage(image);
                Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                graphics.DrawString(tl.ordem.ToString(), font, System.Drawing.Brushes.White, new Point(0, 0));
                novoFilme.Image = image;
                novoFilme.Location = new Point(tl.posicaoX / 2, tl.posicaoY / 2);
                novoFilme.DoubleClick += filmeDuploClique;
                novoFilme.Paint += pintarBordaFilme;
                if (novoFilme.Ordem == 1){
                    novoFilme.Tag = System.Drawing.Color.LimeGreen;
                } else {
                    novoFilme.Tag = System.Drawing.Color.Black;
                }

                panelTemplate.Controls.Add(novoFilme);
            }
            listaFilmes = panelTemplate.Controls.Cast<Filme>().ToList();

            caminho = contextoConfig.tabela.First().caminho_radiografia;
            
            DirectoryInfo di = Directory.CreateDirectory(caminho + "\\Paciente-" + pacienteId + "\\" + nomeSessao + "_" + DateTime.Now.ToString("dd-MM-yyyy"));
            caminho = di.FullName;
        }
        private void ExameCarregar(object sender, EventArgs e)
        {
            m_nId = Detector.CreateDetector(this);
            Detector d = Detector.DetectorList[m_nId];
            d?.Connect();
        }

        private void CarregarImagemTela()
        {
            string path = Path.Combine(caminho, filmeSelecionado.Ordem + "-radiografia.tiff");

            using (Image img = Image.FromFile(path))
            {
                pictureBox1.Image = img;
                filmeSelecionado.Image = img;
                filmeSelecionado.Tag = System.Drawing.Color.Black;

                indice++;
                filmeSelecionado = listaFilmes[indice];
                filmeSelecionado.Tag = System.Drawing.Color.LimeGreen;
                filmeSelecionado.Invoke((MethodInvoker)(() => filmeSelecionado.Refresh()));
            }
        }

        private void pintarBordaFilme(object sender, PaintEventArgs e)
        {
            Filme filme = (Filme)sender;
            if ((System.Drawing.Color)filme.Tag == System.Drawing.Color.Black)
            {
                ControlPaint.DrawBorder(e.Graphics, filme.ClientRectangle, (System.Drawing.Color)filme.Tag, ButtonBorderStyle.None);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, filme.ClientRectangle, (System.Drawing.Color)filme.Tag, 2, ButtonBorderStyle.Solid, (System.Drawing.Color)filme.Tag, 2, ButtonBorderStyle.Solid, (System.Drawing.Color)filme.Tag, 2, ButtonBorderStyle.Solid, (System.Drawing.Color)filme.Tag, 2, ButtonBorderStyle.Solid);
            }
        }

        private void filmeDuploClique(object sender, EventArgs e)
        {
            filmeSelecionado = listaFilmes.Find(t => (System.Drawing.Color)t.Tag == System.Drawing.Color.LimeGreen);
            filmeSelecionado.Tag = System.Drawing.Color.Black;
            filmeSelecionado.Refresh();

            filmeSelecionado = (Filme)sender;
            filmeSelecionado.Tag = System.Drawing.Color.LimeGreen;
            filmeSelecionado.Refresh();
            indice = filmeSelecionado.Ordem - 1;

            if (filmeSelecionado.ImagemCaptura == true)
            {
                pictureBox1.Image = filmeSelecionado.Image;
            }
        }

        void EventReceiver.SdkCallbackHandler(int nDetectorID, int nEventID, int nEventLevel,
                       IntPtr pszMsg, int nParam1, int nParam2, int nPtrParamLen, IntPtr pParam)
        {
            switch (nEventID)
            {
                case SdkInterface.Evt_TaskResult_Succeed:
                    {
                        switch (nParam1)
                        {
                            case SdkInterface.Cmd_Connect:
                                conexaoSensor.Image = Properties.Resources.icon_32x32_green;
                                MessageBox.Show("Conectado");
                                break;
                            case SdkInterface.Cmd_ReadUserROM:
                                MessageBox.Show("Read ram succeed!");
                                break;
                            case SdkInterface.Cmd_WriteUserROM:
                                MessageBox.Show("Write ram succeed!");
                                break;
                            case SdkInterface.Cmd_Clear:
                                MessageBox.Show("Cmd_Clear Ack succeed");
                                break;
                            case SdkInterface.Cmd_ClearAcq:
                                MessageBox.Show("Cmd_ClearAcq Ack succeed.");
                                break;
                            case SdkInterface.Cmd_StartAcq:
                                CarregarImagemTela();
                                break;
                            case SdkInterface.Cmd_StopAcq:
                                MessageBox.Show("Cmd_StopAcq Ack succeed.");
                                break;
                            case SdkInterface.Cmd_ForceSingleAcq:
                                MessageBox.Show("Cmd_ForceSingleAcq Ack succeed.");
                                break;
                            case SdkInterface.Cmd_Disconnect:
                                MessageBox.Show("Cmd_Disconnect Ack succeed.");
                                break;
                            case SdkInterface.Cmd_ReadTemperature:
                                MessageBox.Show("Cmd_ReadTemperature Ack Succeed.");
                                break;
                            case SdkInterface.Cmd_SetCorrectOption:
                                MessageBox.Show("Cmd_SetCorrectOption Ack Succeed.");
                                break;
                            case SdkInterface.Cmd_SetCaliSubset:
                                MessageBox.Show("Cmd_SetCaliSubset Ack Succeed.");
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case SdkInterface.Evt_TaskResult_Failed:
                    switch (nParam1)
                    {
                        case SdkInterface.Cmd_Connect:
                            {
                                switch (nParam2)
                                {
                                    case SdkInterface.Err_DetectorRespTimeout:
                                        MessageBox.Show("FPD no response!");
                                        break;
                                    case SdkInterface.Err_FPD_Busy:
                                        MessageBox.Show("FPD busy!");
                                        break;
                                    case SdkInterface.Err_ProdInfoMismatch:
                                        MessageBox.Show("Init failed!");
                                        break;
                                    case SdkInterface.Err_ImgChBreak:
                                        MessageBox.Show("Image Chanel isn't ok!");
                                        break;
                                    case SdkInterface.Err_CommDeviceNotFound:
                                        MessageBox.Show("Cannot find device!");
                                        break;
                                    case SdkInterface.Err_CommDeviceOccupied:
                                        MessageBox.Show("Device is beeing occupied!");
                                        break;
                                    case SdkInterface.Err_CommParamNotMatch:
                                        MessageBox.Show("Param error, please check IP address!");
                                        break;
                                    default:
                                        MessageBox.Show("Connect failed!");
                                        break;
                                }
                            }
                            break;
                        case SdkInterface.Cmd_ReadUserROM:
                            MessageBox.Show("Read ram failed!");
                            break;
                        case SdkInterface.Cmd_WriteUserROM:
                            MessageBox.Show("Write ram failed!");
                            break;
                        case SdkInterface.Cmd_StartAcq:
                            MessageBox.Show("Cmd_StartAcq Ack failed.");
                            break;
                        case SdkInterface.Cmd_StopAcq:
                            MessageBox.Show("Cmd_StopAcq Ack failed.");
                            break;
                        case SdkInterface.Cmd_Disconnect:
                            MessageBox.Show("Cmd_Disconnect Ack failed.");
                            break;
                        case SdkInterface.Cmd_ReadTemperature:
                            MessageBox.Show("Cmd_ReadTemperature Ack failed.");
                            break;
                        case SdkInterface.Cmd_SetCorrectOption:
                            MessageBox.Show("Cmd_SetCorrectOption Ack failed.");
                            break;
                        case SdkInterface.Cmd_ClearAcq:
                            MessageBox.Show("Cmd_ClearAcq Ack failed.");
                            break;
                        case SdkInterface.Cmd_SetCaliSubset:
                            MessageBox.Show("Cmd_SetCaliSubset Ack failed.");
                            break;
                        default:
                            MessageBox.Show("Failed!");
                            break;
                    }
                    break;

                case SdkInterface.Evt_Exp_Prohibit:
                    MessageBox.Show("Evt_Exp_Prohibit.");
                    break;
                case SdkInterface.Evt_Exp_Enable:
                    MessageBox.Show("Evt_Exp_Enable.");
                    break;
                case SdkInterface.Evt_Image:
                    {
                        filmeSelecionado = listaFilmes[indice];

                        if (filmeSelecionado.ImagemCaptura == true)
                        {
                            var res = MessageBox.Show("Confirma sobreescrever a imagem atual ?", "Sobrescrever Imagem", MessageBoxButtons.YesNo);
                            if (res == DialogResult.No)
                            {
                                return;
                            }
                            
                            File.Delete(Path.Combine(caminho, filmeSelecionado.Ordem + "-radiografia.tiff"));
                        }

                        var image = (IRayImage)Marshal.PtrToStructure(pParam, typeof(IRayImage));
                        int img_width = image.nWidth;
                        int img_height = image.nHeight;
                        short[] img_data = new short[img_width * img_height];
                        Marshal.Copy(image.pData, img_data, 0, img_data.Length);
                        for (int i = 0; i < img_data.Length; i++)
                        {
                            if (img_data[i] > 0)
                            {
                                img_data[i] = (short)(short.MaxValue - img_data[i]);
                            }
                        }
                        ConvertToBitmap(img_data, img_width, img_height);
                    }
                    break;
                case SdkInterface.Evt_Prev_Image:
                    break;
                default:
                    break;
            }
            return;
        }


        private void ConvertToBitmap(short[] data, int widht, int height)
        {
            try
            {
                filmeSelecionado.ImagemCaptura = true;
                
                Bitmap pic = new Bitmap(widht, height, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);

                Rectangle dimension = new Rectangle(0, 0, pic.Width, pic.Height);
                BitmapData picData = pic.LockBits(dimension, ImageLockMode.ReadWrite, pic.PixelFormat);

                IntPtr pixelStartAddress = picData.Scan0;

                Marshal.Copy(data, 0, pixelStartAddress, data.Length);

                pic.UnlockBits(picData);

                if (filmeSelecionado.Orientacao == "Horizontal Esquerda")
                {
                    pic.RotateFlip(RotateFlipType.Rotate270FlipNone);
                } 
                else if (filmeSelecionado.Orientacao == "Horizontal Direita")
                {
                    pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
                } 
                else if (filmeSelecionado.Orientacao == "Vertical Baixo")
                {
                    pic.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }

                SaveBmp(pic, Path.Combine(caminho, filmeSelecionado.Ordem + "-radiografia.tiff"));

                pic.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void SaveBmp(Bitmap bmp, string path)
        {

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);

            var pixelFormats = ConvertBmpPixelFormat(bmp.PixelFormat);

            BitmapSource source = BitmapSource.Create(bmp.Width, bmp.Height, bmp.HorizontalResolution, bmp.VerticalResolution, pixelFormats, null, bitmapData.Scan0, bitmapData.Stride * bmp.Height, bitmapData.Stride);

            bmp.UnlockBits(bitmapData);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                TiffBitmapEncoder encoder = new TiffBitmapEncoder();

                encoder.Frames.Add(BitmapFrame.Create(source));

                encoder.Save(stream);

                stream.Close();
            }
        }

        private static System.Windows.Media.PixelFormat ConvertBmpPixelFormat(System.Drawing.Imaging.PixelFormat pixelformat)
        {
            System.Windows.Media.PixelFormat pixelFormats = PixelFormats.Default;

            switch (pixelformat)
            {
                case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                    pixelFormats = PixelFormats.Bgr32;
                    break;

                case System.Drawing.Imaging.PixelFormat.Format8bppIndexed:
                    pixelFormats = PixelFormats.Gray8;
                    break;

                case System.Drawing.Imaging.PixelFormat.Format16bppGrayScale:
                    pixelFormats = PixelFormats.Gray16;
                    break;
            }

            return pixelFormats;
        }
    }
}
