using Emgu.CV.OCR;
using DMMDigital.Interface;
using DMMDigital.Modelos;
using iDetector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;
using DMMDigital.Views;

namespace DMMDigital
{
    public partial class ExamView : Form, EventReceiver, IExamView
    {
        public string patientName { get; set; }
        public string templateName { get; set; }
        public string examPath { get; set; }

        public event EventHandler eventGetExamPath;

        int m_nId = -1, indexFrame = 0, patientId = 0, action = 0, indexHistoric = 0;
        Frame selectedFrame;
        List<Frame> frames = new List<Frame>();

        Pen pen = new Pen(Color.Red, 5);
        List<List<iDrawing>> drawingHistoric = new List<List<iDrawing>>() { new List<iDrawing>() };
        List<Point> pointsDifferenceFreeDrawing = new List<Point>();
        Point clickPosition = new Point();
        Point firstClickPosition = new Point();
        Point lastClickPosition = new Point();
        iDrawing currentDrawing, selectedDrawingToMove;
        bool draw = false;

        public ExamView(PatientModel patient, List<TemplateFrameModel> templateFrames, string templateName, string sessionName)
        {
            InitializeComponent();

            patientId = patient.id;
            labelPatient.Text = patient.name;
            labelTemplate.Text = templateName;

            int height, width;

            foreach (TemplateFrameModel frame in templateFrames)
            {
                if (frame.orientation.Contains("Vertical"))
                {
                    height = 35;
                    width = 25;
                }
                else
                {
                    height = 25;
                    width = 35;
                }

                Frame newFrame = new Frame
                {
                    Width = width,
                    Height = height,
                    BackColor = Color.Black,
                    order = frame.order,
                    Name = "filme" + frame.order,
                    orientation = frame.orientation,
                    photoTook = false,
                    Tag = Color.Black,
                };

                Bitmap image = new Bitmap(newFrame.Width, newFrame.Height);
                Graphics graphics = Graphics.FromImage(image);
                Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                graphics.DrawString(frame.order.ToString(), font, System.Drawing.Brushes.White, new Point(0, 0));
                newFrame.Image = image;
                newFrame.Location = new Point(frame.locationX / 2, frame.locationY / 2);
                newFrame.DoubleClick += frameDoubleClick;

                if (newFrame.order == 1)
                {
                    newFrame.Tag = Color.LimeGreen;
                }
                newFrame.Paint += framePaint;

                panelTemplate.Controls.Add(newFrame);
                frames.Add(newFrame);
            }
            selectedFrame = frames.First();

            eventGetExamPath?.Invoke(this, EventArgs.Empty);
            DirectoryInfo di = Directory.CreateDirectory(examPath + "\\Paciente-" + patientId + "\\" + sessionName + "_" + DateTime.Now.ToString("dd-MM-yyyy"));
            examPath = di.FullName;
        }

        private void drawTemplate(List<TemplateFrameModel> templateFrames)
        {
            int height, width;

            foreach (TemplateFrameModel frame in templateFrames)
            {
                if (frame.orientation.Contains("Vertical"))
                {
                    height = 35;
                    width = 25;
                }
                else
                {
                    height = 25;
                    width = 35;
                }

                Frame newFrame = new Frame
                {
                    Width = width,
                    Height = height,
                    BackColor = Color.Black,
                    order = frame.order,
                    Name = "filme" + frame.order,
                    orientation = frame.orientation,
                    photoTook = false,
                    Tag = Color.Black,
                };

                Bitmap image = new Bitmap(newFrame.Width, newFrame.Height);
                Graphics graphics = Graphics.FromImage(image);
                Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
                graphics.DrawString(frame.order.ToString(), font, System.Drawing.Brushes.White, new Point(0, 0));
                newFrame.Image = image;
                newFrame.Location = new Point(frame.locationX / 2, frame.locationY / 2);
                newFrame.DoubleClick += frameDoubleClick;

                if (newFrame.order == 1)
                {
                    newFrame.Tag = Color.LimeGreen;
                }
                newFrame.Paint += framePaint;

                panelTemplate.Controls.Add(newFrame);
                frames.Add(newFrame);
            }
        }

        private void examLoad(object sender, EventArgs e)
        {
            m_nId = Detector.CreateDetector(this);
            Detector d = Detector.DetectorList[m_nId];
            d?.Connect();
        }

        private void loadImageOnMainFrame()
        {
            using (FileStream fs = File.Open(Path.Combine(examPath, selectedFrame.order + "-radiografia.tiff"), FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
            {
                Image img = Image.FromStream(fs);
                mainFrame.Image = img;
                selectedFrame.Image = img;
                selectedFrame.Tag = Color.Black;

                indexFrame++;
                selectedFrame = frames[indexFrame];
                selectedFrame.Tag = Color.LimeGreen;
                selectedFrame.Invoke((MethodInvoker)(() => selectedFrame.Refresh()));
            }
        }

        private void framePaint(object sender, PaintEventArgs e)
        {
            Frame frame = (Frame)sender;
            if ((Color)frame.Tag == Color.Black)
            {
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, ButtonBorderStyle.None);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, 2, ButtonBorderStyle.Solid, (Color)frame.Tag, 2, ButtonBorderStyle.Solid, (Color)frame.Tag, 2, ButtonBorderStyle.Solid, (Color)frame.Tag, 2, ButtonBorderStyle.Solid);
            }
        }

        private void frameDoubleClick(object sender, EventArgs e)
        {
            selectedFrame = frames.Find(t => (Color)t.Tag == Color.LimeGreen);
            selectedFrame.Tag = Color.Black;
            selectedFrame.Refresh();

            selectedFrame = (Frame)sender;
            selectedFrame.Tag = Color.LimeGreen;
            selectedFrame.Refresh();
            indexFrame = selectedFrame.order - 1;

            if (selectedFrame.photoTook == true)
            {
                mainFrame.Image = selectedFrame.Image;
            }
        }


        // ferramentas 
        private void enableTools()
        {
            foreach (Button tool in panelTools.Controls.OfType<Button>())
            {
                tool.Invoke((MethodInvoker)(() => tool.Enabled = true));
            }

        }

        private void buttonImportClick(object sender, EventArgs e)
        {
            if (selectedFrame.Image != null)
            {
                var res = MessageBox.Show("Confirma sobreescrever a imagem atual ?", "Sobrescrever Imagem", MessageBoxButtons.YesNo);
                if (res == DialogResult.No) { return; }

                try
                {
                    importImage.ShowDialog();
                    Image selectedImage = Image.FromStream(importImage.OpenFile());
                    selectedFrame.Image = selectedImage;
                    mainFrame.Image = selectedFrame.Image;
                    enableTools();
                }
                catch { return; }
            }
        }

        private void buttonExportClick(object sender, EventArgs e)
        {
            
        }

        private void buttonDeleteClick(object sender, EventArgs e)
        {
            selectedFrame.Image = null;
            mainFrame.Image = null;
        }

        private void buttonCompareClick(object sender, EventArgs e)
        {

        }

        private void buttonSelectClick(object sender, EventArgs e)
        {
            action = 0;
        }

        private void buttonMoveClick(object sender, EventArgs e)
        {
            action = 1;
        }

        private void buttonZoomClick(object sender, EventArgs e)
        {

        }

        private void buttonRulerClick(object sender, EventArgs e)
        {
            action = 2;
        }

        private void buttonUndoClick(object sender, EventArgs e)
        {
            if (indexHistoric - 1 > -1)
            {
                indexHistoric--;
            }
            mainFrame.Invalidate();
        }

        private void buttonRedoClick(object sender, EventArgs e)
        {
            if (indexHistoric + 1 < drawingHistoric.Count)
            {
                indexHistoric++;
            }
            mainFrame.Invalidate();
        }

        private void buttonFilterClick(object sender, EventArgs e)
        {
            
        }

        private void buttonFreeDrawClick(object sender, EventArgs e)
        {
            action = 3;
        }

        private void buttonTextClick(object sender, EventArgs e)
        {
            action = 4;
        }

        private void buttonArrowClick(object sender, EventArgs e)
        {
            action = 5;
        }

        private void buttonEllipseClick(object sender, EventArgs e)
        {
            action = 6;
        }

        private void buttonRectangleDrawClick(object sender, EventArgs e)
        {
            action = 7;
        }

        private void buttonRotateLeftClick(object sender, EventArgs e)
        {
            Image currentFrame = mainFrame.Image;
            currentFrame.RotateFlip(RotateFlipType.Rotate270FlipNone);
            mainFrame.Image = currentFrame;
            frames[indexFrame - 1].Image = currentFrame;
            selectedFrame.Refresh();
        }

        private void buttonRotateRightClick(object sender, EventArgs e)
        {
            Image currentFrame = mainFrame.Image;
            currentFrame.RotateFlip(RotateFlipType.Rotate90FlipNone);
            mainFrame.Image = currentFrame;
            frames[indexFrame - 1].Image = currentFrame;
            selectedFrame.Refresh();
        }

        private void buttonRestoreClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja restaurar a imagem original ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                drawingHistoric = new List<List<iDrawing>>() { new List<iDrawing>() };
                pointsDifferenceFreeDrawing = new List<Point>();
                clickPosition = new Point();
                firstClickPosition = new Point();
                lastClickPosition = new Point();
                currentDrawing = new Arrow();
                selectedDrawingToMove = new Arrow();
                indexHistoric = 0;
                action = 0;
                mainFrame.Invalidate();
            }
        }

        private void mainFrameMouseDown(object sender, MouseEventArgs e)
        {
            clickPosition = e.Location;
            if (action != 0)
            {
                draw = true;

                switch (action)
                {
                    case 3:
                        currentDrawing = new FreeDraw
                        {
                            graphicsPath = new GraphicsPath(),
                            points = new List<Point>()
                        };

                        (currentDrawing as FreeDraw).points.Add(e.Location);

                        drawingHistoric.Add(new List<iDrawing>(drawingHistoric[indexHistoric])
                        {
                            currentDrawing
                        });

                        indexHistoric = drawingHistoric.LastIndexOf(drawingHistoric.Last());

                        break;
                    case 5:
                        currentDrawing = new Arrow
                        {
                            initialPosition = clickPosition,
                            finalPosition = clickPosition
                        };

                        break;
                    case 7:
                        currentDrawing = new RectangleDraw
                        {
                            initialPosition = clickPosition,
                            finalPosition = clickPosition
                        };

                        break;
                    case 6:
                        currentDrawing = new Ellipse
                        {
                            initialPosition = clickPosition,
                            finalPosition = clickPosition
                        };

                        break;
                    case 4:
                        currentDrawing = new Text
                        {
                            initialPosition = clickPosition,
                            text = setTextToDraw().ToString(),
                            font = new Font("Arial", 16),
                            brush = new SolidBrush(Color.Red),
                        };


                        drawingHistoric.Add(new List<iDrawing>(drawingHistoric[indexHistoric]){
                            currentDrawing
                        });
                        indexHistoric = drawingHistoric.LastIndexOf(drawingHistoric.Last());

                        mainFrame.Invalidate();

                        break;
                    case 1:
                        currentDrawing = drawingHistoric[indexHistoric].FirstOrDefault(d => d.graphicsPath.IsOutlineVisible(clickPosition, pen));

                        if (currentDrawing != null)
                        {
                            firstClickPosition = currentDrawing.initialPosition;
                            lastClickPosition = currentDrawing.finalPosition;

                            switch (currentDrawing)
                            {
                                case Ellipse el:
                                    selectedDrawingToMove = new Ellipse();

                                    break;
                                case RectangleDraw r:
                                    selectedDrawingToMove = new RectangleDraw();

                                    break;
                                case Arrow a:
                                    selectedDrawingToMove = new Arrow();

                                    break;
                                case FreeDraw ds:
                                    selectedDrawingToMove = new FreeDraw
                                    {
                                        points = (currentDrawing as FreeDraw).points,
                                    };

                                    pointsDifferenceFreeDrawing = new List<Point>();

                                    firstClickPosition = (selectedDrawingToMove as FreeDraw).points.First();
                                    List<Point> pointsSelectedDrawing = (selectedDrawingToMove as FreeDraw).points;

                                    for (int counter = 1; counter <= (selectedDrawingToMove as FreeDraw).points.Count - 1; counter++)
                                    {
                                        pointsDifferenceFreeDrawing.Add(new Point(pointsSelectedDrawing[counter].X - firstClickPosition.X, pointsSelectedDrawing[counter].Y - firstClickPosition.Y));
                                    }

                                    break;
                                case Text t:
                                    selectedDrawingToMove = new Text
                                    {
                                        text = (currentDrawing as Text).text,
                                        font = (currentDrawing as Text).font,
                                        brush = (currentDrawing as Text).brush,
                                    };

                                    break;
                            }
                            selectedDrawingToMove.initialPosition = new Point(currentDrawing.initialPosition.X, currentDrawing.initialPosition.Y);
                            selectedDrawingToMove.finalPosition = new Point(currentDrawing.finalPosition.X, currentDrawing.finalPosition.Y);

                            drawingHistoric.Add(new List<iDrawing>(drawingHistoric[indexHistoric])
                            {
                                selectedDrawingToMove
                            });
                            indexHistoric = drawingHistoric.LastIndexOf(drawingHistoric.Last());
                            drawingHistoric[indexHistoric].Remove(currentDrawing);
                        }
                        break;
                }

            }
        }

        private void mainFrameMouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                if (action == 3)
                {
                    (currentDrawing as FreeDraw).points.Add(e.Location);
                }
                else if (action == 1)
                {
                    if (selectedDrawingToMove != null)
                    {
                        selectedDrawingToMove.initialPosition = new Point(e.X + firstClickPosition.X - clickPosition.X, e.Y + firstClickPosition.Y - clickPosition.Y);
                        selectedDrawingToMove.finalPosition = new Point(e.X + lastClickPosition.X - clickPosition.X, e.Y + lastClickPosition.Y - clickPosition.Y);

                        if (currentDrawing is FreeDraw)
                        {
                            Point firstPoint = (selectedDrawingToMove as FreeDraw).points.First();
                            int counter = 1;

                            (selectedDrawingToMove as FreeDraw).points[0] = new Point(e.X + firstClickPosition.X - clickPosition.X, e.Y + firstClickPosition.Y - clickPosition.Y);

                            pointsDifferenceFreeDrawing.ForEach(differencePoint =>
                            {
                                (selectedDrawingToMove as FreeDraw).points[counter] = new Point(firstPoint.X + differencePoint.X, firstPoint.Y + differencePoint.Y);

                                if (counter + 1 < (selectedDrawingToMove as FreeDraw).points.Count)
                                {
                                    counter++;
                                }
                            });
                        }
                    }
                }
                else
                {
                    currentDrawing.finalPosition = e.Location;
                }
                mainFrame.Invalidate();
            }
        }

        private void mainFrameMouseUp(object sender, MouseEventArgs e)
        {
            if (action != 0)
            {
                if (indexHistoric == 0)
                {
                    drawingHistoric = new List<List<iDrawing>>() { new List<iDrawing>() };
                }

                if (action != 1 && action != 3)
                {
                    drawingHistoric.Add(new List<iDrawing>(drawingHistoric[indexHistoric]){
                            currentDrawing
                    });
                    indexHistoric = drawingHistoric.LastIndexOf(drawingHistoric.Last());

                }

                draw = false;
                mainFrame.Invalidate();
            }
        }

        private void mainFramePaint(object sender, PaintEventArgs e)
        {
            drawingHistoric[indexHistoric].ForEach(d => d.draw(e.Graphics, pen));

            if (draw)
            {
                if (action == 3)
                {
                    selectedDrawingToMove?.drawPreview(e.Graphics, pen);
                }
                else
                {
                    currentDrawing.drawPreview(e.Graphics, pen);
                }
            }
        }

        private string setTextToDraw()
        {
            draw = false;

            Size size = new Size(250, 100);

            Form inputBox = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ClientSize = size,
                Text = "Inserir Texto"
            };

            Label label = new Label
            {
                Text = "Digite o texto a ser inserido",
                Location = new Point(5, 15),
                Width = size.Width - 10,
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            inputBox.Controls.Add(label);

            TextBox textBox = new TextBox
            {
                Size = new Size(size.Width - 10, 23),
                Location = new Point(5, label.Location.Y + 25),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };
            inputBox.Controls.Add(textBox);

            Button okButton = new Button
            {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new Size(75, 23),
                Text = "&OK",
                Location = new Point(size.Width - 80 - 80, size.Height - 25)
            };
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new Size(75, 23),
                Text = "&Cancel",
                Location = new Point(size.Width - 80, size.Height - 25)
            };
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            inputBox.ShowDialog();

            return textBox.Text;
        }

        // sdk
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
                                sensorConnection.Image = Properties.Resources.icon_32x32_green;
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
                                loadImageOnMainFrame();
                                if (selectedFrame.Image != null)
                                {
                                    enableTools();
                                }
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
                        selectedFrame = frames[indexFrame];

                        if (selectedFrame.photoTook == true)
                        {
                            DialogResult res = MessageBox.Show("Confirma sobreescrever a imagem atual ?", "Sobrescrever Imagem", MessageBoxButtons.YesNo);
                            if (res == DialogResult.No)
                            {
                                return;
                            }
                            selectedFrame.Image = null;
                            mainFrame.Image = null;
                            File.Delete(Path.Combine(examPath, selectedFrame.order + "-radiografia.tiff"));
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
                selectedFrame.photoTook = true;
                
                Bitmap pic = new Bitmap(widht, height, System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);

                Rectangle dimension = new Rectangle(0, 0, pic.Width, pic.Height);
                BitmapData picData = pic.LockBits(dimension, ImageLockMode.ReadWrite, pic.PixelFormat);

                IntPtr pixelStartAddress = picData.Scan0;

                Marshal.Copy(data, 0, pixelStartAddress, data.Length);

                pic.UnlockBits(picData);

                if (selectedFrame.orientation == "Horizontal Esquerda")
                {
                    pic.RotateFlip(RotateFlipType.Rotate270FlipNone);
                } 
                else if (selectedFrame.orientation == "Horizontal Direita")
                {
                    pic.RotateFlip(RotateFlipType.Rotate90FlipNone);
                } 
                else if (selectedFrame.orientation == "Vertical Baixo")
                {
                    pic.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }

                SaveBmp(pic, Path.Combine(examPath, selectedFrame.order + "-radiografia.tiff"));

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
