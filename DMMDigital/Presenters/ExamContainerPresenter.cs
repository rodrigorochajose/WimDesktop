using DMMDigital._Repositories;
using DMMDigital.Interface.iRay;
using DMMDigital.Interface.IRepository;
using DMMDigital.Interface.IView;
using DMMDigital.Models;
using DMMDigital.Views;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using TwainDotNet;
using TwainDotNet.WinFroms;
using DMMDigital.Properties;

namespace DMMDigital.Presenters
{
    public class ExamContainerPresenter : IEventReceiver
    {
        private int sensorId = 0;
        private SensorModel connectedSensor = new SensorModel();
        private readonly ExamContainerView examContainerView;
        private Twain twain;
        private bool continueAcquiring = false;

        private readonly ISettingsRepository settingsRepository = new SettingsRepository();
        private readonly ISensorRepository sensorRepository = new SensorRepository();

        public ExamContainerPresenter(IExamContainerView view, int patientId)
        {
            examContainerView = view as ExamContainerView;
            view.patientId = patientId;

            associateEvents();

            if (examContainerView.selectedExamView.acquireMode == "TWAIN")
            {
                initializeTwain(this, EventArgs.Empty);
                examContainerView.twainInitialized = true;

                setDefaultSensor();
            }
            else
            {
                connectSensor(this, EventArgs.Empty);
                examContainerView.twainInitialized = false;
            }

            initialize();
        }

        private void associateEvents()
        {
            examContainerView.eventConnectSensor += connectSensor;
            examContainerView.eventDestroySensor += destroySensor;
            examContainerView.eventGetSensorInfo += getSensorInfo;
            examContainerView.eventOpenTwain += openTwain;
            examContainerView.eventInitializeTwain += initializeTwain;
        }

        private void initializeTwain(object sender, EventArgs ev)
        {
            twain = new Twain(new WinFormsWindowMessageHook(examContainerView));

            twain.TransferImage += (s, e) =>
            {
                continueAcquiring = true;

                if (e.Image != null)
                {
                    examContainerView.selectedExamView.selectFrame();

                    string originalImagePath = Path.Combine(examContainerView.selectedExamView.examPath, $"{examContainerView.selectedExamView.selectedFrame.order}_original.png");

                    using (Bitmap bitmap = new Bitmap(e.Image))
                    {
                        rotateImage(bitmap);
                        bitmap.Save(originalImagePath, ImageFormat.Png);
                        bitmap.Save(originalImagePath.Replace("original", "filtered"), ImageFormat.Png);
                    }

                    examContainerView.selectedExamView.loadImageOnMainPictureBox();
                }
            };

            twain.ScanningComplete += (s, e) =>
            {
                if (examContainerView.selectedExamView.twainAutoTake)
                {
                    int examImages = examContainerView.selectedExamView.examImages.Count();
                    int frames = examContainerView.selectedExamView.templateFrames.Count();

                    if (examImages < frames && continueAcquiring)
                    {
                        openTwain(s, e);
                    }
                }
            };
        }

        private void openTwain(object sender, EventArgs e)
        {
            ScanSettings settings = new ScanSettings
            {
                UseDocumentFeeder = true,
                ShowTwainUI = true,
                ShowProgressIndicatorUI = false,
                UseDuplex = false,
                Resolution = ResolutionSettings.Fax,
                Area = null,
                ShouldTransferAllPages = true,
                Rotation = new RotationSettings
                {
                    AutomaticRotate = true,
                    AutomaticBorderDetection = true
                }
            };

            continueAcquiring = false;

            twain.StartScanning(settings);
        }

        private void setDefaultSensor()
        {
            string sensorModel = settingsRepository.getSensorModel();
            setConnectedSensor(sensorModel);
        }

        private void connectSensor(object sender, EventArgs e)
        {
            try
            {
                string workDir = getWorkDir();

                if (workDir.Any())
                {
                    sensorId = Detector.CreateDetector(workDir, this);
                    Detector d = Detector.DetectorList[sensorId];

                    d.Connect();

                    string sensor = Regex.Match(workDir, "Pluto.*?(?=_)").ToString().ToUpper();

                    setConnectedSensor(sensor);
                }
                else
                {
                    setDefaultSensor();
                }
            }
            catch
            {
                MessageBox.Show(Resources.messageSensorCannotConnect);
            }
        }

        private void setConnectedSensor(string sensor)
        {
            List<SensorModel> sensors = sensorRepository.getAllSensors();

            SensorModel matchedSensor = sensors.FirstOrDefault(s => s.name == sensor);
            
            if (matchedSensor != null)
            {
                connectedSensor = matchedSensor;
            }
            else
            {
                setDefaultSensor();
            }

        }

        private string getWorkDir()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE '%IRAY%'"))
            {
                ManagementObjectCollection objectCollection = searcher.Get();

                if (objectCollection.Count > 0)
                {
                    List<string> sensorUsbDevices = new List<string>();

                    foreach (ManagementObject obj in objectCollection.Cast<ManagementObject>())
                    {
                        string sensorUsbDevice = obj.ToString();
                        int startIndex = sensorUsbDevice.IndexOf("IRAY");

                        if (startIndex != -1)
                        {
                            string extractedString = sensorUsbDevice.Substring(startIndex);

                            string[] parts = extractedString.Split('\\');

                            string desiredSubstring = parts.FirstOrDefault(s => s.StartsWith("IRAY"));

                            desiredSubstring = desiredSubstring.TrimEnd('"');

                            sensorUsbDevices.Add(desiredSubstring);
                        }
                    }

                    string selectedSensor = sensorUsbDevices.First();

                    if (sensorUsbDevices.Count > 1)
                    {
                        using (Form dialogChooseSensor = new MultiSensorDialog(sensorUsbDevices))
                        {
                            dialogChooseSensor.ShowDialog();
                            selectedSensor = (dialogChooseSensor as MultiSensorDialog).selectedSensor;
                        }
                    }

                    string[] directories = Directory.GetDirectories(settingsRepository.getSensorPath());

                    foreach (string directory in directories)
                    {
                        if (directory.ToUpper().Contains(selectedSensor))
                        {
                            return directory;
                        }
                    }
                }
                return "";
            }
        }

        private void getSensorInfo(object sender, EventArgs e)
        {
            examContainerView.selectedExamView.sensorConnected = true;
            examContainerView.selectedExamView.sensor = connectedSensor;
        }

        private void setSensorOption()
        {
            Detector d = Detector.DetectorList[sensorId];

            int correction = (int)(Enm_CorrectOption.Enm_CorrectOp_SW_PostOffset | Enm_CorrectOption.Enm_CorrectOp_SW_Gain | Enm_CorrectOption.Enm_CorrectOp_SW_Defect);
            d.SetCorrectionOption(correction);
        }

        private void initialize()
        {
            examContainerView.initialize();
        }

        private void destroySensor(object sender, EventArgs e)
        {
            if (sensorId == 0) return;

            Detector d = Detector.DetectorList[sensorId];
            if (d == null) return;

            d.Disconnect();
            Detector.DestroyDetector(sensorId);
            sensorId = 0;
        }


        void IEventReceiver.SdkCallbackHandler(int nDetectorID, int nEventID, int nEventLevel,
                       IntPtr pszMsg, int nParam1, int nParam2, int nPtrParamLen, IntPtr pParam)
        {
            switch (nEventID)
            {
                case SdkInterface.Evt_TaskResult_Succeed:
                    {
                        switch (nParam1)
                        {
                            case SdkInterface.Cmd_Connect:
                                //MessageBox.Show("Sensor Conectado");
                                setSensorOption();
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
                                //MessageBox.Show("Começando captura....");
                                break;
                            case SdkInterface.Cmd_StopAcq:
                                MessageBox.Show("Cmd_StopAcq Ack succeed.");
                                break;
                            case SdkInterface.Cmd_ForceSingleAcq:
                                MessageBox.Show("Cmd_ForceSingleAcq Ack succeed.");
                                break;
                            case SdkInterface.Cmd_Disconnect:
                                //MessageBox.Show("Cmd_Disconnect Ack succeed.");
                                break;
                            case SdkInterface.Cmd_ReadTemperature:
                                MessageBox.Show("Cmd_ReadTemperature Ack Succeed.");
                                break;
                            case SdkInterface.Cmd_SetCorrectOption:
                                //MessageBox.Show("Cmd_SetCorrectOption Ack Succeed.");
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
                                        //MessageBox.Show("Sensor não localizado!");
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
                        examContainerView.selectedExamView.selectFrame();
                        bool getImage = true;
                        if (examContainerView.selectedExamView.selectedFrame.originalImage != null)
                        {
                            getImage = examContainerView.selectedExamView.dialogOverwriteCurrentImage();
                        }

                        if (getImage)
                        {
                            IRayImage image = (IRayImage)Marshal.PtrToStructure(pParam, typeof(IRayImage));
                            //saveImg(image);
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

                            convertToBitmap(imageData, imageWidth, imageHeight);

                            examContainerView.selectedExamView.loadImageOnMainPictureBox();
                        }
                    }
                    break;
                case SdkInterface.Evt_Prev_Image:
                    break;
                default:
                    break;
            }
            return;
        }

        private void convertToBitmap(short[] data, int widht, int height)
        {
            try
            {
                Bitmap pic = new Bitmap(widht, height, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);

                Rectangle dimension = new Rectangle(0, 0, pic.Width, pic.Height);
                BitmapData picData = pic.LockBits(dimension, ImageLockMode.ReadWrite, pic.PixelFormat);

                IntPtr pixelStartAddress = picData.Scan0;

                Marshal.Copy(data, 0, pixelStartAddress, data.Length);

                pic.UnlockBits(picData);

                rotateImage(pic);

                saveBmp(pic);

                pic.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rotateImage(Bitmap img)
        {
            switch (examContainerView.selectedExamView.selectedFrame.orientation)
            {
                case 1:
                    img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case 2:
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;

                case 3:
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
            }
        }

        private void saveBmp(Bitmap bmp)
        {
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            BitmapData bitmapData = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);

            System.Windows.Media.PixelFormat pixelFormats = convertBmpPixelFormat(bmp.PixelFormat);

            BitmapSource source = BitmapSource.Create(bmp.Width, bmp.Height, bmp.HorizontalResolution, bmp.VerticalResolution, pixelFormats, null, bitmapData.Scan0, bitmapData.Stride * bmp.Height, bitmapData.Stride);

            bmp.UnlockBits(bitmapData);

            using (FileStream stream = new FileStream(Path.Combine(examContainerView.selectedExamView.examPath, $"{examContainerView.selectedExamView.selectedFrame.order}_original.png"), FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();

                encoder.Frames.Add(BitmapFrame.Create(source));

                encoder.Save(stream);

                stream.Close();
            }

            using (FileStream stream = new FileStream(Path.Combine(examContainerView.selectedExamView.examPath, $"{examContainerView.selectedExamView.selectedFrame.order}_filtered.png"), FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();

                encoder.Frames.Add(BitmapFrame.Create(source));

                encoder.Save(stream);

                stream.Close();
            }
        }

        private static System.Windows.Media.PixelFormat convertBmpPixelFormat(System.Drawing.Imaging.PixelFormat pixelformat)
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
