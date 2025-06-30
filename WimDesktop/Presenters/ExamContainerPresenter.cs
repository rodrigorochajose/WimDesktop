using WimDesktop._Repositories;
using WimDesktop.Interface.iRay;
using WimDesktop.Interface.IRepository;
using WimDesktop.Interface.IView;
using WimDesktop.Models;
using WimDesktop.Views;
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
using WimDesktop.Properties;
using Saraff.Twain;

namespace WimDesktop.Presenters
{
    public class ExamContainerPresenter : IEventReceiver
    {
        private int sensorId = 0;
        private SensorModel connectedSensor = new SensorModel();
        private readonly ExamContainerView examContainerView;
        private Twain32 twain;
        private bool isAcquireInterfaceOpen = false;

        private readonly ISettingsRepository settingsRepository = new SettingsRepository();
        private readonly ISensorRepository sensorRepository = new SensorRepository();

        private string previousTwainStateFlags = "";


        private readonly List<string> acquireModes = new List<string>
        {
           Resources.nativeAquireMode, "TWAIN"
        };

        public ExamContainerPresenter(IExamContainerView view, int patientId)
        {
            examContainerView = view as ExamContainerView;
            view.patientId = patientId;

            associateEvents();

            //string acquireMode = acquireModes[settingsRepository.getAcquireMode()];
            //view.selectedExamView.acquireMode = acquireMode;

            //if (acquireMode == "TWAIN")
            //{
            initializeTwain(this, EventArgs.Empty);
            examContainerView.twainInitialized = true;

            view.sensorConnected = isSensorConnected();

            setDefaultSensor();
            //}
            //else
            //{
            //    connectSensor(this, EventArgs.Empty);
            //    examContainerView.twainInitialized = false;
            //}

            examContainerView.initialize();
        }

        private void associateEvents()
        {
            examContainerView.eventConnectSensor += connectSensor;
            examContainerView.eventDestroySensor += destroySensor;
            examContainerView.eventGetSensorInfo += getSensorInfo;
            examContainerView.eventOpenTwain += openTwain;
            examContainerView.eventInitializeTwain += initializeTwain;
            examContainerView.eventCloseTwain += closeTwain;
        }

        private void initializeTwain(object sender, EventArgs ev)
        {
            twain = new Twain32();
            twain.OpenDSM();

            twain.EndXfer += twainTransferImage;
            twain.AcquireCompleted += twainAcquireCompleted;
            twain.TwainStateChanged += twainStateChanged;
        }

        private void twainStateChanged(object sender, Twain32.TwainStateEventArgs e)
        {
            string currentStateFlags = e.TwainState.ToString();

            if (isAcquireInterfaceOpen)
            {
                if (previousTwainStateFlags.Contains("DSEnabled") && !currentStateFlags.Contains("DSEnabled"))
                {
                    isAcquireInterfaceOpen = false;

                    examContainerView.selectedExamView.BeginInvoke((MethodInvoker)(() =>
                    {
                        twain.CloseDSM();
                    }));
                }
            }

            previousTwainStateFlags = currentStateFlags;
        }

        private void twainTransferImage(object sender, Twain32.EndXferEventArgs e)
        {
            ExamView selectedExamView = examContainerView.selectedExamView;

            if (e.Image != null)
            {
                if (selectedExamView.recycleImage)
                {
                    selectedExamView.recycleCurrentImage();
                }

                if (selectedExamView.twainAutoTake && selectedExamView.nextFrameSelection && selectedExamView.selectedFrame.originalImage != null)
                {
                    selectedExamView.selectFrame();
                }

                string originalImagePath = Path.Combine(selectedExamView.examPath, $"{selectedExamView.selectedFrame.order}_original.png");

                Twain32.Identity currentSource = twain.GetSourceIdentity(twain.SourceIndex);

                using (Bitmap bitmap = new Bitmap(e.Image))
                {
                    if (currentSource.Name.Contains("CDR"))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
            
                    rotateImage(bitmap);
                    bitmap.Save(originalImagePath, ImageFormat.Png);
                    bitmap.Save(originalImagePath.Replace("original", "filtered"), ImageFormat.Png);
                }

                selectedExamView.loadImageOnMainPictureBox();
            }
        }

        private void twainAcquireCompleted(object sender, EventArgs e)
        {
            if (examContainerView.selectedExamView.twainAutoTake)
            {
                int examImages = examContainerView.selectedExamView.examImages.Count();
                int frames = examContainerView.selectedExamView.templateFrames.Count();

                if (examImages < frames)
                {
                    if (frames - examImages == 1)
                    {
                        twain.DisableAfterAcquire = true;
                    }

                    isAcquireInterfaceOpen = true;
                    twain.Acquire();
                }
            }
        }

        private void openTwain(object sender, EventArgs e)
        {
            twain.OpenDSM();
            twain.OpenDataSource();
            
            twain.DisableAfterAcquire = !examContainerView.selectedExamView.twainAutoTake;
            twain.Capabilities.XferMech.Set(TwSX.Native);

            isAcquireInterfaceOpen = true;
            twain.Acquire();
        }

        private void closeTwain(object sender, EventArgs e)
        {
            if (twain != null)
            {
                twain.CloseDSM();
                twain.Dispose();
            }
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

        private bool isSensorConnected()
        {
            Twain32.Identity currentSource = twain.GetSourceIdentity(twain.SourceIndex);

            string source = currentSource.Name;

            if (source.Contains("iRay"))
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE '%IRAY%'"))
                {
                    ManagementObjectCollection objectCollection = searcher.Get();

                    if (objectCollection.Count > 0)
                    {
                        return true;
                    }
                }
            }

            string query = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE ";

            if (source.Contains("CDR"))
            {
                query += "'CDR%'";
            }
            else
            {
                query += "'Intra-oral%'";
            }

            using (var searcher = new ManagementObjectSearcher(query))
            {
                var results = searcher.Get();
                if (results.Count > 0)
                {
                    return true;
                }
            }

            return false;
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

        private void destroySensor(object sender, EventArgs e)
        {
            if (sensorId == 0) return;

            Detector d = Detector.DetectorList[sensorId];
            if (d == null) return;

            d.Disconnect();
            Detector.DestroyDetector(sensorId);
            sensorId = 0;
        }

        void IEventReceiver.SdkCallbackHandler(int nDetectorID, int nEventID, int nEventLevel, IntPtr pszMsg, int nParam1, int nParam2, int nPtrParamLen, IntPtr pParam)
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
                        //examContainerView.selectedExamView.selectFrame();
                        //bool getImage = true;
                        //if (examContainerView.selectedExamView.selectedFrame.originalImage != null)
                        //{
                        //    getImage = examContainerView.selectedExamView.dialogOverwriteCurrentImage();
                        //}

                        //if (getImage)
                        //{
                        //    if (examContainerView.selectedExamView.recycleImage)
                        //    {
                        //        examContainerView.selectedExamView.recycleCurrentImage();
                        //    }

                        //    IRayImage image = (IRayImage)Marshal.PtrToStructure(pParam, typeof(IRayImage));
                        //    //saveImg(image);
                        //    int imageWidth = image.nWidth;
                        //    int imageHeight = image.nHeight;
                        //    short[] imageData = new short[imageWidth * imageHeight];
                        //    Marshal.Copy(image.pData, imageData, 0, imageData.Length);

                        //    for (int counter = 0; counter < imageData.Length; counter++)
                        //    {
                        //        if (imageData[counter] > 0)
                        //        {
                        //            imageData[counter] = (short)(short.MaxValue - imageData[counter]);
                        //        }
                        //    }

                        //    convertToBitmap(imageData, imageWidth, imageHeight);

                        //    examContainerView.selectedExamView.loadImageOnMainPictureBox();
                        //}
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
