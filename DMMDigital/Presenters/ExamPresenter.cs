using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Views;
using iDetector;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DMMDigital.Presenters
{
    public class ExamPresenter : EventReceiver
    {
        private IExamView examView;
        private IExamRepository examRepository;
        private IConfigRepository configRepository = new ConfigRepository();


        int m_nId;

        public ExamPresenter(IExamView view,  IExamRepository repository)
        {
            examView = view;
            examRepository = repository;

            examView.eventGetExamPath += getExamPath;

            m_nId = Detector.CreateDetector(this);
            Detector d = Detector.DetectorList[m_nId];
            d?.Connect();

            (examView as Form).ShowDialog();
        }

        private void getExamPath(object sender, EventArgs e)
        {
            examView.examPath = configRepository.getExamPath();
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
                                //sensorConnection.Image = Properties.Resources.icon_32x32_green;
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
                                examView.loadImageOnMainPictureBox();
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
                        if (examView.selectedFrame.photoTook == true)
                        {
                            examView.deleteCurrentImageToReplace();
                        }
                        IRayImage image = (IRayImage)Marshal.PtrToStructure(pParam, typeof(IRayImage));
                        int imageWidth = image.nWidth;
                        int imageHeight = image.nHeight;
                        short[] imageData = new short[imageWidth * imageHeight];
                        Marshal.Copy(image.pData, imageData, 0, imageData.Length);
                        for (int counter = 0; counter < imageData.Length; counter++)
                        {
                            if (imageData[counter] > 0)
                            {
                                imageData[counter] = (short)(short.MaxValue - imageData[counter]);
                            }
                        }
                        ConvertToBitmap(imageData, imageWidth, imageHeight);
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
                examView.selectedFrame.photoTook = true;
                examView.selectedFrame.datePhotoTook = DateTime.Now.ToString();

                Bitmap pic = new Bitmap(widht, height, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);

                Rectangle dimension = new Rectangle(0, 0, pic.Width, pic.Height);
                BitmapData picData = pic.LockBits(dimension, ImageLockMode.ReadWrite, pic.PixelFormat);

                IntPtr pixelStartAddress = picData.Scan0;

                Marshal.Copy(data, 0, pixelStartAddress, data.Length);

                pic.UnlockBits(picData);

                if (examView.selectedFrame.orientation == "Horizontal Esquerda")
                {
                    pic.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else if (examView.selectedFrame.orientation == "Horizontal Direita")
                {
                    pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                else if (examView.selectedFrame.orientation == "Vertical Baixo")
                {
                    pic.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }

                SaveBmp(pic, Path.Combine(examView.examPath, examView.selectedFrame.order + "-radiografia.png"));

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

            System.Windows.Media.PixelFormat pixelFormats = ConvertBmpPixelFormat(bmp.PixelFormat);

            BitmapSource source = BitmapSource.Create(bmp.Width, bmp.Height, bmp.HorizontalResolution, bmp.VerticalResolution, pixelFormats, null, bitmapData.Scan0, bitmapData.Stride * bmp.Height, bitmapData.Stride);

            bmp.UnlockBits(bitmapData);

            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Read))
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
