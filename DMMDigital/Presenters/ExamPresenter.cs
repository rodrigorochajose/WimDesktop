using DMMDigital._Repositories;
using DMMDigital.Interface;
using DMMDigital.Interface.iRay;
using DMMDigital.Models;
using DMMDigital.Views;
using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DMMDigital.Presenters
{
    public class ExamPresenter : IEventReceiver
    {
        private readonly IExamView examView;
        private readonly IExamRepository examRepository;
        private readonly IExamImageRepository examImageRepository = new ExamImageRepository();
        private readonly ITemplateFrameRepository templateFrameRepository = new TemplateFrameRepository();
        private readonly IExamImageDrawingRepository examImageDrawingRepository = new ExamImageDrawingRepository();
        private readonly IExamImageDrawingPointsRepository examImageDrawingPointsRepository = new ExamImageDrawingPointsRepository();
        private readonly IPatientRepository patientRepository = new PatientRepository();

        private readonly string examOpeningMode;
        private int m_nId;

        public ExamPresenter(IExamView view, IExamRepository repository, bool openingExam, string examOpeningMode)
        {
            examView = view;
            examRepository = repository;
            this.examOpeningMode = examOpeningMode;

            examView.eventSaveExam += saveExam;
            examView.eventSaveExamImage += saveExamImage;
            examView.eventSaveExamImageDrawing += saveExamImageDrawing;
            examView.eventGetPatient += getPatient;

            if (openingExam)
            {
                loadFullExam();
            }

            initializeExam();
        }

        public void initializeExam()
        {
            if (examOpeningMode == "newContainer")
            {
                try
                {
                    string path = getSensorPath();

                    if (path.Any())
                    {
                        m_nId = Detector.CreateDetector(this, path);
                        Detector d = Detector.DetectorList[m_nId];
                        d?.Connect();
                        examView.detectorConnected = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Não foi possível conectar o sensor, verifique se o apontamento está correto.");
                }

                new ExamContainerPresenter(new ExamContainerView(examView as ExamView), examView.patient.id, m_nId);
            }
            else
            {
                Form examContainerView = Application.OpenForms.Cast<Form>().First(f => f.Text == "Exame");

                if ((examContainerView as ExamContainerView).patientId != examView.patient.id)
                {
                    examContainerView.Close();
                    new ExamContainerPresenter(new ExamContainerView(examView as ExamView), examView.patient.id, m_nId);
                }
                else if (!(examContainerView as ExamContainerView).openExamsId.Contains(examView.examId))
                {
                    (examContainerView as ExamContainerView).addNewPage(examView);
                }
            }
        }

        private void loadFullExam()
        {
            try
            {
                ExamModel exam = examRepository.getExam(examView.examId);
                examView.examId = exam.id;
                examView.patient.id = exam.patientId;
                examView.sessionName = exam.sessionName;

                examView.setLabelPatientTemplate(exam.patient.name, exam.template.name);

                examView.examPath += $"\\Paciente-{examView.patient.id}\\{examView.sessionName}_{exam.createdAt:dd-MM-yyyy}";
                examView.templateId = exam.templateId;
                examView.templateFrames = new List<TemplateFrameModel>();
                examView.templateFrames = templateFrameRepository.getTemplateFrame(exam.templateId);
                examView.examImages = examImageRepository.getExamImages(examView.examId).ToList();
                examView.examImageDrawings = examImageDrawingRepository.getExamImageDrawings(examView.examId).ToList();
                associateDrawingsToPoint();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar exame - {ex.Message}");
            }
        }

        private void associateDrawingsToPoint()
        {
            List<ExamImageDrawingPointsModel> examImageDrawingPoints = examImageDrawingPointsRepository.getExamImageDrawingPoints(examView.examId).ToList();

            foreach (ExamImageDrawingModel drawing in examView.examImageDrawings)
            {
                drawing.points = new List<Point>();
                IEnumerable currentDrawingPoints = examImageDrawingPoints.Where(dp => dp.examId == drawing.examId && dp.examImageDrawingId == drawing.id);

                foreach (ExamImageDrawingPointsModel drawingPoints in currentDrawingPoints)
                {
                    drawing.points.Add(new Point(drawingPoints.pointX, drawingPoints.pointY));
                }
            }
        }

        private void saveExam(object sender, EventArgs e)
        {
            try
            {
                ExamModel exam = new ExamModel
                {
                    patientId = examView.patient.id,
                    templateId = examView.templateId,
                    sessionName = examView.sessionName,
                    createdAt = DateTime.Now
                };
            
                examView.examId = examRepository.add(exam);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exam - {ex.Message}");
            }
        }

        private void saveExamImage(object sender, EventArgs e)
        {
            try
            {
                List<ExamImageModel> examImagesToSave = examView.examImages;
                List<ExamImageModel> currentExamImages = examImageRepository.getExamImages(examView.examId).ToList();

                List<ExamImageModel> imagesToDelete = currentExamImages.ExceptBy(examImagesToSave, item => item.frameId).ToList();

                if (imagesToDelete.Any())
                {
                    examImageRepository.deleteRangeExamImages(imagesToDelete);
                }

                foreach (ExamImageModel item in examImagesToSave)
                {
                    ExamImageModel existingExamImage = currentExamImages.Find(ei => ei.frameId == item.frameId);
                    if (existingExamImage == null)
                    {
                        examImageRepository.addExamImage(item);
                    }
                    else
                    {
                        existingExamImage.notes = item.notes;
                        existingExamImage.createdAt = item.createdAt;
                        examImageRepository.save();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ExamImage - {ex.Message}");
            }
        }

        private void saveExamImageDrawing(object sender, EventArgs e)
        {
            try
            {
                List<ExamImageDrawingModel> currentExamImageDrawings = examImageDrawingRepository.getExamImageDrawings(examView.examId).ToList();

                List<ExamImageDrawingModel> drawingsToDelete = currentExamImageDrawings.ExceptBy(examView.examImageDrawings, item => item.id).ToList();

                if (drawingsToDelete.Any())
                {
                    List<int> drawingsIdToDelete = drawingsToDelete.Select(d => d.id).ToList();
                    examImageDrawingPointsRepository.deleteExamImageDrawingPointsByDrawings(drawingsIdToDelete);
                    examImageDrawingRepository.deleteRangeExamImageDrawings(drawingsToDelete);
                }

                foreach (ExamImageDrawingModel item in examView.examImageDrawings)
                {
                    ExamImageDrawingModel existingExamImageDrawing = currentExamImageDrawings.FirstOrDefault(eid => eid.id == item.id);
                    if (existingExamImageDrawing == null)
                    {
                        examImageDrawingRepository.addExamImageDrawing(item);

                        int drawingId = examImageDrawingRepository.getExamImageDrawings(examView.examId).Last().id;

                        List<ExamImageDrawingPointsModel> pointsToSave = new List<ExamImageDrawingPointsModel>();

                        foreach (Point point in item.points)
                        {
                            pointsToSave.Add(new ExamImageDrawingPointsModel
                            {
                                examId = item.examId,
                                examImageId = item.examImageId,
                                examImageDrawingId = drawingId,
                                pointX = point.X,
                                pointY = point.Y
                            });
                        }

                        examImageDrawingPointsRepository.addExamImageDrawingPoints(pointsToSave);
                    }
                    else if (item.points != existingExamImageDrawing.points)
                    {
                        examImageDrawingPointsRepository.updatePoints(item.id, item.points);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ExamImageDrawing - {ex.Message}");
            }
        }

        private void getPatient(object sender, EventArgs e)
        {
            examView.patient = patientRepository.getPatientById(examView.patient.id);
        }

        private string getSensorPath()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE DeviceID LIKE '%IRAY%'")) {

                ManagementObjectCollection objectCollection = searcher.Get();

                if (objectCollection.Count > 0)
                {
                    List<string> sensorUsbDevices = new List<string>();

                    foreach (ManagementObject obj in objectCollection)
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
                        using (Form dialogChooseSensor = new DialogChooseSensor(sensorUsbDevices))
                        {
                            dialogChooseSensor.ShowDialog();
                            selectedSensor = (dialogChooseSensor as DialogChooseSensor).selectedSensor;
                        }
                    }

                    string[] directories = Directory.GetDirectories("C:\\IRay\\IRayIntraoral_x86\\work_dir");

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
                        examView.selectFrame();
                        bool getImage = true;
                        if (examView.selectedFrame.originalImage != null)
                        {
                            getImage = examView.dialogOverrideCurrentImage();
                        }

                        if (getImage)
                        {
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

                SaveBmp(pic, Path.Combine(examView.examPath, examView.selectedFrame.order + "-original.png"));

                pic.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            examView.loadImageOnMainPictureBox();
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
