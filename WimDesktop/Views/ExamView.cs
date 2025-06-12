using WimDesktop.Interface.IView;
using WimDesktop.Interface;
using WimDesktop.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WimDesktop.Models.Drawings;
using WimDesktop.Components;
using WimDesktop.Presenters;
using MoreLinq;
using WimDesktop.Properties;

namespace WimDesktop.Views
{
    public partial class ExamView : Form, IExamView
    {
        public ExamModel exam { get; set; } = new ExamModel();
        public PatientModel patient { get; set; }
        public int templateId { get; set; }
        public string examPath { get; set; }
        public Frame selectedFrame { get; set; }
        public List<ExamImageModel> examImages { get; set; }
        public List<TemplateFrameModel> templateFrames { get; set; }
        public List<ExamImageDrawingModel> examImageDrawings { get; set; }
        public SettingsModel settings { get; set; }
        public SensorModel sensor { get; set; }
        public bool sensorConnected { get; set; }
        public string acquireMode { get; set; }
        public bool twainAutoTake { get; set; } = false;

        public bool recycleImage { get; set; }

        public event EventHandler eventSaveExam;
        public event EventHandler eventUpdateExamLastChange;
        public event EventHandler eventSaveExamImage;
        public event EventHandler eventSaveExamImageDrawing;
        public event EventHandler eventGetPatient;
        public event EventHandler eventCloseSingleExam;
        public event EventHandler eventChangeAcquireMode;
        public event EventHandler eventAcquireTwain;

        int action = 0;
        int indexFrame = 0;
        float drawingSize = 5;
        int counterDrawings = 0;
        int textDrawingPreviousSize = 26;
        int indexSelectedDrawingHistory = 0;

        double sensorScalingFactorWidth = 0;
        double sensorScalingFactorHeight = 0;
        double sensorModifiedScalingFactor = 0;

        bool draw = false;
        bool multiRuler = false;
        bool rulerDrawed = false;
        bool calibrated = false;
        bool recalibrate = false;
        bool examHasChanges = false;
        bool blinking = false;

        bool nextFrameSelection = true;

        Color sensorStatusColor = Color.Red;
        Color drawingColor = Color.Red;
        Color textColor = Color.Red;
        Color rulerColor = Color.Red;
        TrackBar trackBarZoom;
        Button buttonColorPicker;
        PictureBox pictureBoxMagnifier;
        NumericUpDown numericUpDownDrawingSize;
        Graphics magnifierGraphics;

        List<Frame> frames = new List<Frame>();
        List<Point> differenceBetweenPoints = new List<Point>();
        List<List<IDrawing>> selectedDrawingHistory = new List<List<IDrawing>>();
        List<FrameDrawingHistory> frameDrawingHistories = new List<FrameDrawingHistory>();

        IDrawing currentDrawing;
        IDrawing selectedDrawingToMove;
        Point clickPosition = new Point();
        Point lastMagnifierPosition = new Point(0, 0);
        Size mainPictureBoxOriginalSize = new Size();
        Size mainPictureBoxPreviousSize = new Size();

        string recyclePath;

        public ExamView(PatientModel patient, int templateId, List<TemplateFrameModel> templateFrames, string templateName, string sessionName, SettingsModel settings)
        {
            InitializeComponent();

            ActiveControl = labelPatientName;

            this.exam.sessionName = sessionName;
            this.patient = patient;
            this.templateId = templateId;
            setLabelPatientTemplate(patient.name, templateName);
            this.templateFrames = templateFrames;

            this.settings = settings;
            examImages = new List<ExamImageModel>();

            Load += delegate
            {
                toolStrip.Renderer = new CustomToolStripRenderer();

                associateSettings();

                drawTemplate();

                mainPictureBoxOriginalSize = mainPictureBox.Size;

                setInitialFrame();
                setAcquireStatus();
                timerSensorStatus.Start();
            };
        }

        public ExamView(ExamModel exam, PatientModel patient, SettingsModel settings)
        {
            InitializeComponent();

            this.exam = exam;
            this.patient = patient;

            this.settings = settings;
            associateSettings();

            Load += delegate
            {
                toolStrip.Renderer = new CustomToolStripRenderer();

                drawTemplate();

                setInitialFrame();
                loadExamDrawings();

                if (examImageDrawings.Any())
                {
                    selectedDrawingHistoryHandler();
                }

                setAcquireStatus();

                mainPictureBoxOriginalSize = mainPictureBox.Size;
                timerSensorStatus.Start();
            };
        }

        private void setAcquireStatus()
        {
            if (sensorConnected)
            {
                sensorStatusColor = Color.Green;
            }
        }

        private void setInitialFrame()
        {
            List<Frame> emptyFrames = frames.Where(f => f.originalImage == null).ToList();

            if (!emptyFrames.Any())
            {
                selectedFrame = frames.First();
                selectedFrame.Tag = Color.LimeGreen;
                indexFrame = frames.IndexOf(selectedFrame);

                return;
            }

            if (emptyFrames.Count > 1)
            {
                Frame nextEmptyFrame = emptyFrames.Skip(1).First();

                nextEmptyFrame.Tag = Color.Orange;
            }

            selectedFrame = emptyFrames.First();
            selectedFrame.Tag = Color.LimeGreen;
            indexFrame = frames.IndexOf(selectedFrame);

            if (selectedFrame.filteredImage != null)
            {
                mainPictureBox.Image = selectedFrame.filteredImage.Clone() as Image;
                provideTools(true);
                    
                resizeMainPictureBox();

                labelImageDate.Text = selectedFrame.datePhotoTook;
                textBoxFrameNotes.Text = selectedFrame.notes;
            }
        }

        private void examViewFormClosing(object sender, FormClosingEventArgs e)
        {
            checkChangesAndSave();
        }

        private void examViewResize(object sender, EventArgs e)
        {
            IExamContainerView container = Application.OpenForms.OfType<ExamContainerView>().FirstOrDefault();

            if (container == null)
            {
                return;
            }

            mainPictureBoxPreviousSize = mainPictureBox.Size;

            resizeMainPictureBox();

            if (selectedDrawingHistory.Any())
            {
                if (selectedDrawingHistory[indexSelectedDrawingHistory].Any())
                {
                    if (mainPictureBox.Height != 0)
                    {
                        if (mainPictureBoxPreviousSize.Height == 0)
                        {
                            mainPictureBoxPreviousSize = mainPictureBoxOriginalSize;
                            return;
                        }

                        frames.ForEach(f => f.resize = !f.resize);
                    }
                }
            }
        }

        private void resizeDrawings(float scale)
        {
            foreach (FrameDrawingHistory fdh in frameDrawingHistories)
            {
                if (fdh.drawingHistory.Count() > 1)
                {
                    foreach (IDrawing d in fdh.drawingHistory.Last())
                    {
                        for (int counter = 0; counter < d.points.Count; counter++)
                        {
                            d.points[counter] = Point.Round(new PointF(d.points[counter].X * scale, d.points[counter].Y * scale));
                        }
                    }
                }
            }

            selectedFrame.resize = false;
            mainPictureBox.Invoke((MethodInvoker)(() => mainPictureBox.Refresh()));
        }

        private void associateSettings()
        {
            examPath = Path.Combine(settings.examPath, $"{patient.id}\\{exam.id}");
            recyclePath = Path.Combine(examPath, "recycle");

            if (!Directory.Exists(examPath))
            {
                Directory.CreateDirectory(examPath);
                Directory.CreateDirectory(recyclePath);
            }

            drawingColor = Color.FromArgb(int.Parse(settings.drawingColor));
            textColor = Color.FromArgb(int.Parse(settings.textColor));
            rulerColor = Color.FromArgb(int.Parse(settings.rulerColor));
            textDrawingPreviousSize = settings.textSize;
            drawingSize = settings.drawingSize;

            //if (acquireMode == "TWAIN")
            //{
                eventChangeAcquireMode?.Invoke(this, EventArgs.Empty);
                buttonAcquireMode.Image = Resources.icon_32x32_scanner;
                buttonAcquireMode.ToolTipText = acquireMode;
            //}
        }

        public void setLabelPatientTemplate(string patient, string template)
        {
            labelPatient.Text = patient;
            labelTemplate.Text = template;
        }

        private void drawTemplate()
        {
            foreach (TemplateFrameModel frame in templateFrames)
            {
                int height;
                int width;
                if (frame.orientation < 2)
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
                    id = frame.id,
                    Width = width,
                    Height = height,
                    BackColor = Color.Black,
                    order = frame.order,
                    Name = $"frame{frame.id}",
                    orientation = frame.orientation,
                    Tag = Color.Black,
                    Location = new Point(frame.locationX / 2, frame.locationY / 2),
                    resize = false
                };

                newFrame.Click += frameClick;
                newFrame.DoubleClick += frameDoubleClick;

                ExamImageModel selectedExamImage = examImages.FirstOrDefault(e => e.templateFrameId == newFrame.id);

                if (selectedExamImage != null)
                {
                    Image img;
                    string path = Path.Combine(examPath, selectedExamImage.file);

                    if (File.Exists(path))
                    {
                        using (Bitmap bmpTemp = new Bitmap(path))
                        {
                            img = new Bitmap(bmpTemp);
                        }
                        newFrame.originalImage = img;
                        newFrame.filteredImage = img;
                        newFrame.notes = selectedExamImage.notes;
                        newFrame.datePhotoTook = selectedExamImage.createdAt.ToString();

                        string filteredFile = $"{newFrame.order}_filtered.png";

                        if (File.Exists(Path.Combine(examPath, filteredFile)))
                        {
                            using (var bmpTemp = new Bitmap(Path.Combine(examPath, filteredFile)))
                            {
                                img = new Bitmap(bmpTemp);
                            }
                            newFrame.filteredImage = img;
                        }

                        newFrame.Image = img.GetThumbnailImage(newFrame.Width, newFrame.Height, () => false, IntPtr.Zero);
                    }
                    else
                    {
                        MessageBox.Show(Resources.messageImageRegisteredNotFound);
                    }
                }

                frameDrawingHistories.Add(new FrameDrawingHistory(frame.id, new List<List<IDrawing>> { new List<IDrawing>() }));

                frames.Add(newFrame);
                panelTemplate.Controls.Add(newFrame);
            }
        }

        private Image drawFrameDefaultImage(Frame currentFrame)
        {
            Bitmap image = new Bitmap(currentFrame.Width, currentFrame.Height);
            Graphics graphics = Graphics.FromImage(image);
            Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            graphics.DrawString(currentFrame.order.ToString(), font, Brushes.White, new Point(0, 0));

            return image;
        }

        private void loadExamDrawings()
        {
            if (examImageDrawings != null)
            {
                Dictionary<string, Func<ExamImageDrawingModel, IDrawing>> getDrawingModelByType = new Dictionary<string, Func<ExamImageDrawingModel, IDrawing>>
                {
                    {
                        "Arrow",
                        (drawing) => {
                            return new Arrow
                            {
                                id = drawing.id,
                                examImageId = drawing.examImageId,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = Color.FromArgb(int.Parse(drawing.drawingColor)),
                                drawingSize = drawing.drawingSize,
                                points = drawing.points
                            };
                        }
                    },
                    {
                        "Ellipse",
                        (drawing) => {
                            return new Ellipse
                            {
                                id = drawing.id,
                                examImageId = drawing.examImageId,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = Color.FromArgb(int.Parse(drawing.drawingColor)),
                                drawingSize = drawing.drawingSize,
                                points = drawing.points
                            };
                        }
                    },
                    {
                        "RectangleDraw",
                        (drawing) => {
                            return new RectangleDraw
                            {
                                id = drawing.id,
                                examImageId = drawing.examImageId,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = Color.FromArgb(int.Parse(drawing.drawingColor)),
                                drawingSize = drawing.drawingSize,
                                points = drawing.points
                            };
                        }
                    },
                    {
                        "FreeDraw",
                        (drawing) => {
                            return new FreeDraw
                            {
                                id = drawing.id,
                                examImageId = drawing.examImageId,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = Color.FromArgb(int.Parse(drawing.drawingColor)),
                                drawingSize = drawing.drawingSize,
                                points = drawing.points,
                            };
                        }
                    },
                    {
                        "Text",
                        (drawing) => {
                            return new Text
                            {
                                id = drawing.id,
                                examImageId = drawing.examImageId,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = Color.FromArgb(int.Parse(drawing.drawingColor)),
                                drawingSize = drawing.drawingSize,
                                points = drawing.points,
                                text = drawing.drawingText,
                                font = new Font("Arial", drawing.drawingSize),
                                brush = new SolidBrush(Color.FromArgb(int.Parse(drawing.drawingColor))),
                            };
                        }
                    },
                    {
                        "Ruler",
                        (drawing) =>
                        {
                            Ruler ruler = new Ruler
                            {
                                id = drawing.id,
                                examImageId = drawing.examImageId,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = Color.FromArgb(int.Parse(drawing.drawingColor)),
                                drawingSize = drawing.drawingSize,
                                points = drawing.points,
                                lineLength = drawing.lineLength,
                                multiple = false,
                            };

                            if (ruler.points.Count > 2)
                            {
                                ruler.multiple = true;
                            }

                            return ruler;
                        }
                    }
                };

                List<IDrawing> frameDrawings = new List<IDrawing>();
                foreach (ExamImageDrawingModel examImageDrawing in examImageDrawings)
                {
                    frameDrawings.Add(getDrawingModelByType[examImageDrawing.drawingType].Invoke(examImageDrawing));
                }

                foreach (IDrawing drawing in frameDrawings)
                {
                    List<List<IDrawing>> currentDrawingHistory = frameDrawingHistories.FirstOrDefault(f => f.frameId == examImages.FirstOrDefault(ei => ei.id == drawing.examImageId).templateFrameId).drawingHistory;

                    currentDrawingHistory.Add(new List<IDrawing>(currentDrawingHistory.Last())
                    {
                        drawing
                    });
                }

                selectedDrawingHistory = frameDrawingHistories[indexFrame].drawingHistory;
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
            }
        }

        private void frameHandler(Image image)
        {
            selectFrame();

            if (selectedFrame.originalImage != null)
            {
                examImages.RemoveAll(i => i.templateFrameId == selectedFrame.id);
            }

            examImages.Add(new ExamImageModel
            {
                examId = exam.id,
                templateFrameId = selectedFrame.id,
                file = $"{selectedFrame.order}_original.png",
                notes = selectedFrame.notes
            });

            selectedFrame.datePhotoTook = DateTime.Now.ToString();

            labelImageDate.Invoke((MethodInvoker)(() => labelImageDate.Text = selectedFrame.datePhotoTook));
            textBoxFrameNotes.Invoke((MethodInvoker)(() => textBoxFrameNotes.Text = selectedFrame.notes));

            selectedFrame.originalImage = new Bitmap(image);
            selectedFrame.filteredImage = new Bitmap(image);

            selectedFrame.Invoke((MethodInvoker)(() =>
            {
                selectedFrame.Image = image.GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
                selectedFrame.Refresh();
            }));
        }

        private void clearNextFrameSelection()
        {
            Frame nextFrameSelected = frames.FirstOrDefault(f => (Color)f.Tag == Color.Orange);

            if (nextFrameSelected != null)
            {
                nextFrameSelected.Tag = Color.Black;
                nextFrameSelected.Refresh();
            }
        }

        private void setFrame()
        {
            selectedFrame.Tag = Color.Black;
            selectedFrame.Refresh();

            List<Frame> emptyFrames = frames.Where(f => f.originalImage == null).ToList();

            if (indexFrame + 1 > frames.Count || !emptyFrames.Any())
            {
                nextFrameSelection = false;
                clearNextFrameSelection();
                return;
            }

            Frame frame = emptyFrames.FirstOrDefault(f => frames.IndexOf(f) > indexFrame) ?? emptyFrames.First();

            indexFrame = frames.IndexOf(frame);

            Invoke((MethodInvoker)(() =>
            {
                frames[indexFrame].Tag = Color.LimeGreen;
                frames[indexFrame].Refresh();
            }));

            setNextFrame();
        }

        private void setNextFrame()
        {
            if (!nextFrameSelection)
            {
                clearNextFrameSelection();
                return;
            }

            List<Frame> emptyFrames = frames.Where(f => f.originalImage == null).ToList();

            if (indexFrame + 1 > frames.Count || !emptyFrames.Any())
            {
                nextFrameSelection = false;
                clearNextFrameSelection();
                return;
            }

            Frame nextFrame = emptyFrames.FirstOrDefault(f => frames.IndexOf(f) > indexFrame) ?? emptyFrames.First();

            nextFrame.Tag = Color.Orange;
            nextFrame.Refresh();
        }

        public void selectFrame(Frame frameToSelect = null)
        {
            selectedFrame.BackColor = Color.Black;

            checkChangesAndSave();
            selectedFrame = frameToSelect ?? frames[indexFrame];
            selectedFrame.Tag = Color.LimeGreen;

            selectedDrawingHistory = frameDrawingHistories.First(f => f.frameId == selectedFrame.id).drawingHistory;
            indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
            selectedDrawingHistoryHandler();

            provideTools(selectedFrame.originalImage != null);

            labelImageDate.Invoke((MethodInvoker)(() => labelImageDate.Text = selectedFrame.datePhotoTook));
            textBoxFrameNotes.Invoke((MethodInvoker)(() => textBoxFrameNotes.Text = selectedFrame.notes));

            panelTemplate.Invoke((MethodInvoker)(() => panelTemplate.Refresh()));
        }

        private bool checkOverwriteImage()
        {
            selectTool(buttonSelect);

            bool overwrite = dialogOverwriteCurrentImage();

            if (overwrite)
            {
                restoreFrameDrawings();
                recycleImage = true;
            }

            return overwrite;
        }

        private void frameClick(object sender, EventArgs e)
        {
            nextFrameSelection = false;
            clearNextFrameSelection();

            selectTool(buttonSelect);

            frames.Find(t => (Color)t.Tag == Color.LimeGreen).Tag = Color.Black;

            selectFrame((Frame)sender);
            indexFrame = selectedFrame.order - 1;

            mainPictureBox.Image = selectedFrame.filteredImage;

            resizeMainPictureBox();
        }

        private void frameDoubleClick(object sender, EventArgs e)
        {
            //if (acquireMode == "TWAIN")
            //{

            if (nextFrameSelection)
            {
                setFrame();
            }

            if (frames[indexFrame].originalImage != null && !checkOverwriteImage()) return;
            
            twainAutoTake = false;
            nextFrameSelection = true;
            setNextFrame();
            eventAcquireTwain?.Invoke(this, EventArgs.Empty);
            //}
        }

        public bool dialogOverwriteCurrentImage()
        {
            DialogResult res = MessageBox.Show(Resources.messageImageConfirmOverwrite, Resources.titleOverwriteImage, MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return false;
            }
            return true;
        }

        public void loadImageOnMainPictureBox()
        {
            Image image;
            using (FileStream fs = File.Open(Path.Combine(examPath, $"{selectedFrame.order}_original.png"), FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
            {
                image = Image.FromStream(fs);
            }

            frameHandler(image);
            mainPictureBox.Image = image;
            resizeMainPictureBox();
            provideTools(true);

            examHasChanges = true;

            if (twainAutoTake)
            {
                setFrame();
            }
        }

        public void resizeMainPictureBox()
        {
            if (mainPictureBox.Image != null)
            {
                Size previousSizeMainPictureBox = mainPictureBox.Size;

                mainPictureBox.Invoke((MethodInvoker)(() =>
                {
                    mainPictureBox.Size = new Size(
                        panelImage.Height * mainPictureBox.Image.Width / mainPictureBox.Image.Height,
                        panelImage.Height
                    );

                    mainPictureBox.Location = new Point((panelImage.Width - mainPictureBox.Width) / 2, 0);
                }));

                if (selectedDrawingHistory.Count > 1)
                {
                    if (previousSizeMainPictureBox != mainPictureBox.Size)
                    {
                        float scale = (float)mainPictureBox.Height / previousSizeMainPictureBox.Height;

                        if (scale > 0 && !float.IsInfinity(scale))
                        {
                            resizeDrawings(scale);
                        }
                    }
                    mainPictureBox.Refresh();
                }
            }
        }

        private void provideTools(bool state)
        {
            IEnumerable<ToolStripButton> tools = toolStrip.Items.OfType<ToolStripButton>().Skip(5);

            Invoke((MethodInvoker)(() => tools.ForEach(i => i.Enabled = state)));
        }

        private void selectTool(object sender)
        {
            action = int.Parse((sender as ToolStripButton).Tag.ToString());

            loadToolOptions();

            ToolStripButton selectedButton = toolStrip.Items.OfType<ToolStripButton>().SingleOrDefault(b => b.Checked);

            if (selectedButton != null)
            {
                if (selectedButton.Name == "buttonMagnifier")
                {
                    panelImage.Controls.Remove(pictureBoxMagnifier);
                    mainPictureBox.Cursor = Cursors.Default;
                }
                else if (selectedButton.Name == "buttonRuler")
                {
                    multiRuler = false;
                }

                selectedButton.Checked = false;
            }

            (sender as ToolStripButton).Checked = true;
        }

        private void loadToolOptions()
        {
            panelToolOptions.Controls.Clear();

            if (action == 0) return;

            switch (action)
            {
                case 2:
                    Label labelColor = new Label
                    {
                        Name = "labelRulerColor",
                        Text = Resources.textLabelColor,
                        AutoSize = true,
                        Size = new Size(31, 19),
                        Location = new Point(7, 18),
                        Font = new Font("Segoe UI", 10F),
                    };

                    buttonColorPicker = new Button
                    {
                        BackColor = rulerColor,
                        Cursor = Cursors.Hand,
                        FlatStyle = FlatStyle.Popup,
                        Location = new Point(41, 18),
                        Margin = new Padding(0),
                        Name = "buttonColorPicker",
                        Size = new Size(58, 23),
                        UseVisualStyleBackColor = false,
                    };
                    buttonColorPicker.FlatAppearance.BorderColor = Color.Black;
                    buttonColorPicker.Click += buttonColorPickerClick;

                    Button buttonResetCalibration = new Button
                    {
                        Location = new Point(121, 6),
                        Name = "buttonResetCalibration",
                        Text = Resources.textButtonResetCalibration,
                        Size = new Size(107, 23),
                        UseVisualStyleBackColor = false,
                    };
                    buttonResetCalibration.Click += buttonResetCalibrationClick;

                    Button buttonSetCalibration = new Button
                    {
                        Location = new Point(130, 31),
                        Name = "button3",
                        Size = new Size(90, 23),
                        Text = Resources.textButtonSetCalibration,
                        UseVisualStyleBackColor = false,
                    };
                    buttonSetCalibration.Click += buttonSetCalibrationClick;

                    CheckBox checkBoxMultiRuler = new CheckBox
                    {
                        Font = new Font("Segoe UI", 9F),
                        Location = new Point(242, 22),
                        Name = "checkBoxMultiRuler",
                        Size = new Size(119, 19),
                        Text = Resources.textCheckBoxMultiRuler,
                    };
                    checkBoxMultiRuler.CheckedChanged += checkBoxMultiRulerCheckedChanged;

                    panelToolOptions.Controls.Add(labelColor);
                    panelToolOptions.Controls.Add(buttonColorPicker);
                    panelToolOptions.Controls.Add(buttonResetCalibration);
                    panelToolOptions.Controls.Add(buttonSetCalibration);
                    panelToolOptions.Controls.Add(checkBoxMultiRuler);
                    break;

                case 3:
                    generateControlDrawingOption();
                    break;

                case 4:
                    generateControlDrawingOption();
                    break;

                case 5:
                    generateControlDrawingOption();
                    break;

                case 6:
                    generateControlDrawingOption();
                    break;

                case 7:
                    generateControlDrawingOption();
                    break;

                case 8:
                    trackBarZoom = new TrackBar
                    {
                        Location = new Point(11, 11),
                        Maximum = 60,
                        Minimum = 18,
                        Value = 18,
                        Name = "trackBarZoom",
                        Size = new Size(338, 45)
                    };

                    trackBarZoom.ValueChanged += delegate
                    {
                        adjustMagnifierImage(lastMagnifierPosition, false);
                    };

                    panelToolOptions.Controls.Add(trackBarZoom);
                    break;
            }
        }

        private void adjustMagnifierImage(Point point, bool updateLocation)
        {
            float zoomFactor = (float)(trackBarZoom.Value * 0.05);

            int rectangleWidth = (int)(pictureBoxMagnifier.Width / zoomFactor);
            int rectangleHeight = (int)(pictureBoxMagnifier.Height / zoomFactor);

            PointF rectangleInitialPosition = new PointF(
            (point.X * mainPictureBox.Image.Width / mainPictureBox.Width) - rectangleWidth / 2,
            (point.Y * (mainPictureBox.Image.Height + 10) / mainPictureBox.Height) - rectangleHeight / 2
            );

            RectangleF rectangle = new RectangleF(rectangleInitialPosition, new Size(rectangleWidth, rectangleHeight));

            magnifierGraphics.Clear(Color.White);
            magnifierGraphics.DrawImage(mainPictureBox.Image, new Rectangle(0, 0, pictureBoxMagnifier.Width, pictureBoxMagnifier.Height), rectangle, GraphicsUnit.Pixel);

            pictureBoxMagnifier.Refresh();

            if (updateLocation)
            {
                Point currentCursorPoint = panelImage.PointToClient(Cursor.Position);
                pictureBoxMagnifier.Location = new Point(currentCursorPoint.X - (pictureBoxMagnifier.Width / 2), currentCursorPoint.Y - (pictureBoxMagnifier.Height / 2));

                mainPictureBox.Update();
            }
        }

        private void generateControlDrawingOption()
        {
            int value = action == 4 ? textDrawingPreviousSize : (int)drawingSize;
            Color color = action == 4 ? textColor : drawingColor;

            numericUpDownDrawingSize = new NumericUpDown
            {
                Cursor = Cursors.Hand,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(254, 19),
                Maximum = 70,
                Minimum = 5,
                Name = "numericUpDownDrawingSize",
                Size = new Size(75, 23),
                Value = value,
            };
            numericUpDownDrawingSize.ValueChanged += numericUpDownDrawingSizeValueChanged;

            buttonColorPicker = new Button
            {
                BackColor = color,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Popup,
                Location = new Point(74, 19),
                Margin = new Padding(0),
                Name = "buttonColorPicker",
                Size = new Size(75, 21),
                UseVisualStyleBackColor = false,
            };
            buttonColorPicker.FlatAppearance.BorderColor = Color.Black;
            buttonColorPicker.Click += buttonColorPickerClick;

            Label labelColor = new Label
            {
                Name = "labelColor",
                Text = Resources.textLabelColor,
                AutoSize = true,
                Size = new Size(31, 19),
                Location = new Point(38, 21),
                Font = new Font("Segoe UI", 10F),
            };

            Label labelSize = new Label
            {
                Name = "labelSize",
                Text = Resources.textLabelSize,
                AutoSize = true,
                Size = new Size(64, 19),
                Location = new Point(182, 21),
                Font = new Font("Segoe UI", 10F),
            };

            panelToolOptions.Controls.Add(numericUpDownDrawingSize);
            panelToolOptions.Controls.Add(buttonColorPicker);
            panelToolOptions.Controls.Add(labelColor);
            panelToolOptions.Controls.Add(labelSize);
        }

        private string getTextToDraw()
        {
            using (Form dialogGetTextToDraw = new DialogGetTextToDraw())
            {
                var result = dialogGetTextToDraw.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return (dialogGetTextToDraw as DialogGetTextToDraw).textToDraw;
                }
            }

            return "";
        }

        private void getRulerFactor()
        {
            if (selectedFrame.originalImage != null)
            {
                Size imageRealSize = selectedFrame.originalImage.Size;

                if (mainPictureBox.Width < mainPictureBox.Height)
                {
                    sensorScalingFactorWidth = imageRealSize.Width / sensor.width;
                    sensorScalingFactorHeight = imageRealSize.Height / sensor.height;
                }
                else
                {
                    sensorScalingFactorWidth = imageRealSize.Width / sensor.height;
                    sensorScalingFactorHeight = imageRealSize.Height / sensor.width;
                }
            }
        }

        private float getRulerLength(Point initialPoint, Point finalPoint)
        {
            getRulerFactor();

            float initialX = initialPoint.X * selectedFrame.originalImage.Width / mainPictureBox.Width;
            float initialY = initialPoint.Y * selectedFrame.originalImage.Height / mainPictureBox.Height;
            float finalX = finalPoint.X * selectedFrame.originalImage.Width / mainPictureBox.Width;
            float finalY = finalPoint.Y * selectedFrame.originalImage.Height / mainPictureBox.Height;

            float lenghtInMilimeters = (float)Math.Sqrt(Math.Pow((initialX - finalX) / sensorScalingFactorWidth, 2) + Math.Pow((initialY - finalY) / sensorScalingFactorHeight, 2));

            if (calibrated)
            {
                lenghtInMilimeters *= (float)sensorModifiedScalingFactor;
            }

            return lenghtInMilimeters;
        }

        private void recalibrateRuler(double rulerValue)
        {
            sensorModifiedScalingFactor = rulerValue / (currentDrawing as Ruler).lineLength.First();
            calibrated = true;
        }

        private void numericUpDownDrawingSizeValueChanged(object sender, EventArgs e)
        {
            if (action == 4)
            {
                textDrawingPreviousSize = (int)numericUpDownDrawingSize.Value;
                return;
            }
            drawingSize = (int)numericUpDownDrawingSize.Value;
        }

        private void deleteDrawingOnHistory(IDrawing drawing)
        {
            selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory]));
            indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());

            IDrawing drawingToRemove = selectedDrawingHistory[indexSelectedDrawingHistory].Single(d => d.id == drawing.id);
            selectedDrawingHistory[indexSelectedDrawingHistory].Remove(drawingToRemove);

            selectedDrawingHistoryHandler();
            mainPictureBox.Invalidate();

            examHasChanges = true;
        }

        private void showDrawingHistory(IDrawing drawing)
        {
            Panel panel = new Panel
            {
                Size = new Size(340, 60),
                Name = $"panelDrawing{drawing.id}"
            };

            Button button = new Button
            {
                Font = new Font("Microsoft Sans Serif", 9F),
                Name = $"buttonDrawing{drawing.id}",
                Size = new Size(35, 25),
                Location = new Point(10, 17),
                Image = Resources.icon_16x16_trash
            };

            PictureBox pictureBox = new PictureBox
            {
                Name = $"pictureBoxDrawing{drawing.id}",
                Size = new Size(50, 50),
                Location = new Point(65, 5),
                BackColor = Color.WhiteSmoke,
            };

            Label label = new Label
            {
                Name = $"labelDrawing{drawing.id}",
                Size = new Size(150, 20),
                Location = new Point(125, 23),
                Text = $"{drawing.GetType()}-{drawing.id}",
            };

            switch (drawing)
            {
                case Ellipse _:
                    label.Text = Resources.labelEllipse;
                    break;

                case RectangleDraw _:
                    label.Text = Resources.labelRectangle;
                    break;

                case Arrow _:
                    label.Text = Resources.labelArrow;
                    break;

                case Ruler _:
                    label.Text = Resources.labelRuler;
                    break;

                case FreeDraw _:
                    label.Text = Resources.labelFreeDraw;
                    break;

                case Text _:
                    label.Text = Resources.labelText;
                    break;
            }

            pictureBox.Image = drawing.generateDrawingImageAndThumb(selectedFrame.order, examPath, mainPictureBox.Width, mainPictureBox.Height);
            button.Click += delegate { deleteDrawingOnHistory(drawing); };

            panel.Controls.Add(button);
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(panel);
            flowLayoutPanel1.ScrollControlIntoView(panel);
        }

        private void selectedDrawingHistoryHandler()
        {
            flowLayoutPanel1.Controls.Clear();
            if (selectedDrawingHistory[indexSelectedDrawingHistory].Count > 0)
            {
                selectedDrawingHistory[indexSelectedDrawingHistory].ForEach(showDrawingHistory);
            }
        }

        private void buttonAcquireModeClick(object sender, EventArgs e)
        {
            //eventChangeAcquireMode?.Invoke(this, e);

            //if (acquireMode == "TWAIN")
            //{
            //    buttonAcquireMode.Image = Resources.icon_32x32_scanner;
            //    buttonAcquireMode.ToolTipText = "TWAIN";

            //    sensorConnected = true;
            //}
            //else
            //{
            //    buttonAcquireMode.Image = Resources.icon_32x32_capture;
            //    buttonAcquireMode.ToolTipText = Resources.nativeAquireMode;

            //    if (sensorConnected)
            //    {
            //        sensorStatusColor = Color.Green;
            //    }
            //    else
            //    {
            //        sensorStatusColor = Color.Red;
            //    }
            //}
        }

        private void buttonAutoTakeClick(object sender, EventArgs e)
        {
            //if (acquireMode == "TWAIN")
            //{
            selectTool(buttonSelect);

            if (nextFrameSelection && selectedFrame.originalImage != null)
            {
                setFrame();
            }

            if (frames[indexFrame].originalImage != null && !checkOverwriteImage()) return;

            twainAutoTake = true;
            nextFrameSelection = true;
            eventAcquireTwain?.Invoke(this, EventArgs.Empty);
            //}
        }

        private void buttonNewExamClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            IExamTemplateSelectionView examTemplateSelectionView = new ExamTemplateSelectionView();
            eventGetPatient?.Invoke(this, e);

            examTemplateSelectionView.patientId = patient.id;
            examTemplateSelectionView.patientName = patient.name;
            examTemplateSelectionView.patientBirthDate = patient.birthDate;
            examTemplateSelectionView.patientPhone = patient.phone;
            examTemplateSelectionView.patientRecommendation = patient.recommendation;
            examTemplateSelectionView.patientObservation = patient.observation;

            new ExamTemplateSelectionPresenter(examTemplateSelectionView, GetType());
        }

        private void buttonOpenExamClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            FormManager.instance.openForm<PatientView>(() => new PatientPresenter(new PatientView()));
        }

        private void buttonCloseExamClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            eventCloseSingleExam?.Invoke(this, EventArgs.Empty);
        }

        private void importImage(Bitmap img)
        {
            selectFrame();

            if (img.Width > img.Height)
            {
                if (selectedFrame.orientation < 2)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }
            else
            {
                if (selectedFrame.orientation > 1)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
            }

            frameHandler(img);

            mainPictureBox.Image = img;
            img.Save(Path.Combine(examPath, $"{selectedFrame.order}_original.png"));
            img.Save(Path.Combine(examPath, $"{selectedFrame.order}_filtered.png"));
            resizeMainPictureBox();

            provideTools(true);
            examHasChanges = true;
        }

        private void buttonImportClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            if (nextFrameSelection && selectedFrame.originalImage != null)
            {
                setFrame();
            }

            if (frames[indexFrame].originalImage != null && !checkOverwriteImage()) return;

            DialogResult result = dialogFileImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (recycleImage)
                {
                    recycleCurrentImage();
                }

                nextFrameSelection = true;
                setNextFrame();

                Image selectedImage = Image.FromStream(dialogFileImage.OpenFile());

                importImage(new Bitmap(selectedImage));
            }
        }

        public void recycleCurrentImage()
        {
            string originalImagePath = Path.Combine(examPath, $"{selectedFrame.order}_original.png");
            string filteredImagePath = originalImagePath.Replace("original", "filtered");
            string editedImagePath = originalImagePath.Replace("original", "edited");

            string originalFileDestName = $"{selectedFrame.order}_original_{DateTime.Now:dd-MM-yyyy_HH-m-s}.png";

            File.Move(originalImagePath, Path.Combine(recyclePath, originalFileDestName));

            if (File.Exists(filteredImagePath))
            {
                File.Delete(filteredImagePath);
            }

            if (File.Exists(editedImagePath))
            {
                File.Delete(editedImagePath);
            }

            recycleImage = false;
        }

        private void buttonRecycleBinClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            if (!Directory.EnumerateFiles(recyclePath).Any())
            {
                MessageBox.Show(Resources.messageBinAlreadyEmpty);
                return;
            }

            if (frames[indexFrame].originalImage != null && !checkOverwriteImage()) return;


            using (Form recycleBinView = new RecycleBinView(recyclePath))
            {
                if (recycleBinView.ShowDialog() == DialogResult.OK)
                {
                    if (recycleImage)
                    {
                        recycleCurrentImage();
                    }

                    Image imageToRestore = (recycleBinView as IRecycleBinView)?.imageToRestore;

                    if (imageToRestore != null)
                    {
                        importImage(new Bitmap(imageToRestore));
                    }
                }
            }
        }

        private void buttonExportClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            List<Frame> framesWithImages = frames.Where(f => f.originalImage != null).Select(f => f.CloneToExport()).ToList();

            if (!framesWithImages.Any())
            {
                MessageBox.Show(Resources.messageExamCannotExport);
                return;
            }

            generateEditedImage();

            new ExportExamPresenter(
                new ExportExamView
                {
                    pathImages = examPath,
                    framesToExport = framesWithImages,
                    patientName = patient.name
                },
                exam.id
            );
        }

        private void buttonDeleteClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            if (selectedFrame.originalImage != null)
            {
                DialogResult result = MessageBox.Show(Resources.messageImageConfirmDelete, Resources.titleImageDelete, MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }

                recycleCurrentImage();

                frameDrawingHistories[indexFrame].drawingHistory = new List<List<IDrawing>> { new List<IDrawing>() };

                selectedDrawingHistory = frameDrawingHistories[indexFrame].drawingHistory;
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                flowLayoutPanel1.Controls.Clear();

                examImages.RemoveAll(ei => ei.templateFrameId == selectedFrame.id);

                selectedFrame.Image = drawFrameDefaultImage(selectedFrame);
                selectedFrame.originalImage = null;
                selectedFrame.filteredImage = null;
                selectedFrame.editedImage = null;
                selectedFrame.datePhotoTook = "";
                selectedFrame.notes = "";

                labelImageDate.Text = selectedFrame.datePhotoTook;
                textBoxFrameNotes.Text = selectedFrame.notes;

                mainPictureBox.Image = null;

                provideTools(false);

                examHasChanges = true;
            }
        }

        private void buttonCompareFrameClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            frames.First(f => f == selectedFrame).Tag = Color.LimeGreen;

            IFramesComparisonSelectionView compareFrames = new FramesComparisonSelectionView(frames, patient.id);
            (compareFrames as Form).ShowDialog();
        }

        private void buttonSelectClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonMoveDrawingClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonMagnifierClick(object sender, EventArgs e)
        {
            selectTool(sender);

            pictureBoxMagnifier = new PictureBox
            {
                Location = new Point(mainPictureBox.Left, mainPictureBox.Top),
                Name = "pictureBoxMagnifier",
                Size = new Size(250, 250),
                Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height),
                Enabled = false
            };

            pictureBoxMagnifier.Paint += (s, ev) =>
            {
                ControlPaint.DrawBorder(ev.Graphics, new Rectangle(1, 1, pictureBoxMagnifier.Width - 2, pictureBoxMagnifier.Height - 2),
                    Color.LightGray, 3, ButtonBorderStyle.Solid,
                    Color.LightGray, 3, ButtonBorderStyle.Solid,
                    Color.LightGray, 3, ButtonBorderStyle.Solid,
                    Color.LightGray, 3, ButtonBorderStyle.Solid
                );
            };

            magnifierGraphics = Graphics.FromImage(pictureBoxMagnifier.Image);

            panelImage.Controls.Add(pictureBoxMagnifier);
            panelImage.Controls.SetChildIndex(pictureBoxMagnifier, 0);

            adjustMagnifierImage(new Point(139, 137), false);

            mainPictureBox.Cursor = Cursors.Cross;
        }

        private void buttonRulerClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonFilterClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            string imagePath = Path.Combine(examPath, $"{selectedFrame.order}_filtered.png");

            IFilterView filterView = new FilterView(new Bitmap(selectedFrame.filteredImage), imagePath);

            DialogResult res = (filterView as Form).ShowDialog();

            if (res == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(imagePath);

                Bitmap bit = new Bitmap(bmp);

                bmp.Dispose();

                selectedFrame.Invoke((MethodInvoker)(() =>
                {
                    selectedFrame.filteredImage = bit;
                    selectedFrame.Image = bit.GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
                    selectedFrame.Refresh();
                }));

                mainPictureBox.Image = bit;

                examHasChanges = true;
            }
        }

        private void buttonUndoClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            if (indexSelectedDrawingHistory - 1 > -1)
            {
                indexSelectedDrawingHistory--;
                mainPictureBox.Invalidate();
                selectedDrawingHistoryHandler();

                examHasChanges = true;
            }
        }

        private void buttonRedoClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            if (indexSelectedDrawingHistory + 1 < selectedDrawingHistory.Count)
            {
                indexSelectedDrawingHistory++;
                mainPictureBox.Invalidate();
                selectedDrawingHistoryHandler();

                examHasChanges = true;
            }
        }

        private void buttonFreeDrawClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonTextClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonArrowClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonRectangleDrawClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonEllipseClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void rotateImage(string rotationDirection)
        {
            Bitmap currentImage = new Bitmap(mainPictureBox.Image);

            if (rotationDirection == "right")
            {
                currentImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else
            {
                currentImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }

            mainPictureBox.Image = currentImage;
            selectedFrame.filteredImage = currentImage;
            selectedFrame.Image = new Bitmap(currentImage).GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);

            if (selectedDrawingHistory.Count > 1)
            {
                rotateDrawing(rotationDirection);
            }

            resizeMainPictureBox();

            currentImage.Save(Path.Combine(examPath, $"{selectedFrame.order}_filtered.png"));
        }

        private void rotateDrawing(string rotationDirection)
        {
            SizeF newSize = new Size(panelImage.Height * mainPictureBox.Image.Width / mainPictureBox.Image.Height, panelImage.Height);

            PointF previousCenter = new PointF(mainPictureBox.Width / 2f, mainPictureBox.Height / 2f);

            PointF newCenter = new PointF(newSize.Width / 2f, newSize.Height / 2f);

            float scaleX = newSize.Width / mainPictureBox.Height;
            float scaleY = newSize.Height / mainPictureBox.Width;

            for (int currentIndex = 0; currentIndex < selectedDrawingHistory.Count; currentIndex++)
            {
                List<IDrawing> frameDrawings = new List<IDrawing>();

                foreach (IDrawing drawing in selectedDrawingHistory[currentIndex])
                {
                    IDrawing drawingCopy = drawing.deepCopy();
                    List<Point> newPoints = new List<Point>(drawingCopy.points.Count);

                    float invertX = (rotationDirection == "right") ? -1 : 1;
                    float invertY = (rotationDirection == "right") ? 1 : -1;

                    foreach (Point p in drawingCopy.points)
                    {
                        PointF distance = new PointF(invertX * (previousCenter.X - p.X), invertY * (previousCenter.Y - p.Y));

                        PointF newDistance = new PointF(distance.Y * scaleX, distance.X * scaleY);

                        newPoints.Add(Point.Round(new PointF(newCenter.X + newDistance.X, newCenter.Y + newDistance.Y)));
                    }

                    drawingCopy.points = newPoints;
                    frameDrawings.Add(drawingCopy);
                }

                selectedDrawingHistory[currentIndex] = frameDrawings;
            }
        }

        private void buttonRotateLeftClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            SizeF previousMainPictureBoxSize = new Size(mainPictureBox.Width, mainPictureBox.Height);
            string rotationDirection = "left";
            rotateImage(rotationDirection);
            examHasChanges = true;
        }

        private void buttonRotateRightClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            SizeF previousMainPictureBoxSize = new Size(mainPictureBox.Width, mainPictureBox.Height);
            string rotationDirection = "right";
            rotateImage(rotationDirection);

            examHasChanges = true;
        }

        private void buttonRestoreImageClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            if (MessageBox.Show(Resources.messageImageConfirmRestore, Resources.titleImageRestore, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Image img = selectedFrame.originalImage;
            selectedFrame.filteredImage = img;
            mainPictureBox.Image = img;

            selectedFrame.Invoke((MethodInvoker)(() =>
            {
                selectedFrame.Image = new Bitmap(img).GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
                selectedFrame.Refresh();
            }));

            File.Delete(Path.Combine(examPath, $"{selectedFrame.order}_filtered.png"));

            restoreFrameDrawings();
            resizeMainPictureBox();

            examHasChanges = true;
        }

        private void restoreFrameDrawings()
        {
            if (frameDrawingHistories[indexFrame].drawingHistory.Count > 1)
            {
                File.Delete(Path.Combine(examPath, $"{selectedFrame.order}_edited.png"));

                //new List<List<IDrawing>> { new List<IDrawing>() })

                selectedDrawingHistory = new List<List<IDrawing>> { new List<IDrawing>() };
                frameDrawingHistories[indexFrame].drawingHistory = selectedDrawingHistory;
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                flowLayoutPanel1.Controls.Clear();

                if (examImageDrawings != null)
                {
                    examImageDrawings.RemoveAll(eid => eid.examImageId == selectedFrame.order);
                }

                mainPictureBox.Refresh();
            }
        }

        private void buttonFitZoomClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            mainPictureBoxPreviousSize = mainPictureBox.Size;

            resizeMainPictureBox();

            panelImage.AutoScroll = false;
        }

        private void buttonZoomOutClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            mainPictureBoxZoom(1 / 1.25f);

            resizeDrawings((float)mainPictureBox.Height / mainPictureBoxPreviousSize.Height);
        }

        private void buttonZoomSquareClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            mainPictureBoxZoom(3.25f);

            resizeDrawings((float)mainPictureBox.Height / mainPictureBoxPreviousSize.Height);
        }

        private void buttonZoomInClick(object sender, EventArgs e)
        {
            selectTool(buttonSelect);

            mainPictureBoxZoom(1.25f);

            resizeDrawings((float)mainPictureBox.Height / mainPictureBoxPreviousSize.Height);
        }

        private void mainPictureBoxZoom(float factor)
        {
            mainPictureBoxPreviousSize = mainPictureBox.Size;

            int newWidth = (int)(mainPictureBox.Width * factor);
            int newHeight = (int)(mainPictureBox.Height * factor);

            if (newWidth < 500 || newWidth > 4500)
            {
                return;
            }

            mainPictureBox.Size = new Size(newWidth, newHeight);
            panelImage.AutoScrollMinSize = mainPictureBox.Size;

            mainPictureBox.Location = new Point(0, 0);
        }

        private void buttonColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                buttonColorPicker.BackColor = colorDialog.Color;

                if (action == 2)
                {
                    rulerColor = colorDialog.Color;
                }
                else if (action == 4)
                {
                    textColor = colorDialog.Color;
                }
                else
                {
                    drawingColor = colorDialog.Color;
                }
            }
        }

        private void buttonResetCalibrationClick(object sender, EventArgs e)
        {
            sensorModifiedScalingFactor = 0;
            calibrated = false;
        }

        private void buttonSetCalibrationClick(object sender, EventArgs e)
        {
            recalibrate = true;
        }

        private void checkBoxMultiRulerCheckedChanged(object sender, EventArgs e)
        {
            multiRuler = (sender as CheckBox).Checked;

            if (draw && currentDrawing is Ruler)
            {
                completeMultiRuler();
            }
        }

        private void textBoxFrameNotesTextChanged(object sender, EventArgs e)
        {
            selectedFrame.notes = textBoxFrameNotes.Text;

            ExamImageModel selectedImage = examImages.Find(f => f.templateFrameId == selectedFrame.id);

            if (selectedImage != null)
            {
                selectedImage.notes = selectedFrame.notes;

                examHasChanges = true;
            }
        }

        private void getDifferenceBetweenPoints(List<Point> points)
        {
            differenceBetweenPoints = new List<Point>();

            foreach (Point p in points.Skip(1))
            {
                differenceBetweenPoints.Add(new Point(p.X - points.First().X, p.Y - points.First().Y));
            }
        }

        private void completeMultiRuler()
        {
            if (currentDrawing.points.Count > 1)
            {
                (currentDrawing as Ruler).lineLength.Remove((currentDrawing as Ruler).lineLength.Last());
            }
            else
            {
                selectedDrawingHistory.Remove(selectedDrawingHistory.Last());
                indexSelectedDrawingHistory--;
            }

            rulerDrawed = false;
            draw = false;
            selectedDrawingHistoryHandler();
            mainPictureBox.Refresh();
        }

        private void mainPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickPosition = e.Location;
                if (action != 0 && action != 8)
                {
                    draw = true;
                    examHasChanges = true;
                    counterDrawings++;

                    switch (action)
                    {
                        case 1:
                            currentDrawing = selectedDrawingHistory[indexSelectedDrawingHistory].FirstOrDefault(d => d.graphicsPath.IsOutlineVisible(clickPosition, new Pen(Color.Red, 5)));
                            if (currentDrawing != null)
                            {
                                switch (currentDrawing)
                                {
                                    case Ellipse _:
                                        selectedDrawingToMove = new Ellipse();
                                        break;

                                    case RectangleDraw _:
                                        selectedDrawingToMove = new RectangleDraw();
                                        break;

                                    case Arrow _:
                                        selectedDrawingToMove = new Arrow();
                                        break;

                                    case Ruler _:
                                        selectedDrawingToMove = new Ruler
                                        {
                                            lineLength = (currentDrawing as Ruler).lineLength,
                                            multiple = (currentDrawing as Ruler).multiple
                                        };

                                        if ((selectedDrawingToMove as Ruler).multiple)
                                        {
                                            getDifferenceBetweenPoints(currentDrawing.points);
                                        }
                                        break;

                                    case FreeDraw fd:
                                        selectedDrawingToMove = new FreeDraw();
                                        getDifferenceBetweenPoints(currentDrawing.points);

                                        break;

                                    case Text textDrawing:
                                        selectedDrawingToMove = new Text
                                        {
                                            text = textDrawing.text,
                                            font = textDrawing.font,
                                            brush = textDrawing.brush,
                                        };

                                        break;
                                }

                                selectedDrawingToMove.id = currentDrawing.id;
                                selectedDrawingToMove.examImageId = currentDrawing.examImageId;
                                selectedDrawingToMove.graphicsPath = currentDrawing.graphicsPath;
                                selectedDrawingToMove.drawingColor = currentDrawing.drawingColor;
                                selectedDrawingToMove.drawingSize = currentDrawing.drawingSize;
                                selectedDrawingToMove.points = new List<Point>(currentDrawing.points);

                                selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory])
                                {
                                    selectedDrawingToMove
                                });
                                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                                selectedDrawingHistory[indexSelectedDrawingHistory].Remove(currentDrawing);
                            }
                            break;

                        case 2:
                            if (multiRuler)
                            {
                                if (!rulerDrawed)
                                {
                                    currentDrawing = new Ruler
                                    {
                                        id = counterDrawings,
                                        examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id,
                                        graphicsPath = new GraphicsPath(),
                                        drawingColor = rulerColor,
                                        drawingSize = 2,
                                        points = new List<Point> { clickPosition },
                                        previewPoint = clickPosition,
                                        lineLength = new List<float> { 0 },
                                        multiple = true,
                                    };

                                    selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory])
                                    {
                                        currentDrawing
                                    });
                                    indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());

                                    rulerDrawed = true;
                                    mainPictureBox.Refresh();

                                }
                                else
                                {
                                    currentDrawing.points.Add((currentDrawing as Ruler).previewPoint);

                                    int index = (currentDrawing as Ruler).lineLength.LastIndexOf((currentDrawing as Ruler).lineLength.Last());
                                    (currentDrawing as Ruler).lineLength[index] = getRulerLength(currentDrawing.points.SkipLast(1).Last(), (currentDrawing as Ruler).points.Last());

                                    (currentDrawing as Ruler).lineLength.Add(0);
                                }
                            }
                            else
                            {
                                currentDrawing = new Ruler
                                {
                                    id = counterDrawings,
                                    examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id,
                                    graphicsPath = new GraphicsPath(),
                                    drawingColor = rulerColor,
                                    drawingSize = 2,
                                    points = new List<Point> { clickPosition, clickPosition },
                                    previewPoint = clickPosition,
                                    lineLength = new List<float> { 0 },
                                    multiple = false
                                };
                            }

                            break;

                        case 3:
                            currentDrawing = new FreeDraw
                            {
                                id = counterDrawings,
                                examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id,
                                graphicsPath = new GraphicsPath(),
                                points = new List<Point> { clickPosition },
                                drawingColor = drawingColor,
                                drawingSize = drawingSize
                            };

                            break;

                        case 4:
                            draw = false;

                            string textToDraw = getTextToDraw();

                            if (textToDraw.Length > 0)
                            {
                                currentDrawing = new Text
                                {
                                    id = counterDrawings,
                                    examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id,
                                    graphicsPath = new GraphicsPath(),
                                    text = textToDraw,
                                    font = new Font("Arial", textDrawingPreviousSize),
                                    brush = new SolidBrush(textColor),
                                    drawingColor = textColor,
                                    drawingSize = textDrawingPreviousSize,
                                    points = new List<Point> { clickPosition }
                                };

                                selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory])
                                {
                                    currentDrawing
                                });
                                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());

                                mainPictureBox.Invalidate();
                                selectedDrawingHistoryHandler();
                            }
                            break;

                        case 5:
                            currentDrawing = new Arrow
                            {
                                id = counterDrawings,
                                examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = drawingColor,
                                drawingSize = drawingSize,
                                points = new List<Point> { clickPosition, clickPosition }
                            };

                            break;

                        case 6:
                            currentDrawing = new Ellipse
                            {
                                id = counterDrawings,
                                examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = drawingColor,
                                drawingSize = drawingSize,
                                points = new List<Point> { clickPosition, clickPosition }
                            };

                            break;

                        case 7:
                            currentDrawing = new RectangleDraw
                            {
                                id = counterDrawings,
                                examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = drawingColor,
                                drawingSize = drawingSize,
                                points = new List<Point> { clickPosition, clickPosition }
                            };

                            break;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (draw && action == 2)
                {
                    completeMultiRuler();
                }
            }
        }

        private void mainPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                if (action < 4)
                {
                    if (action == 1)
                    {
                        if (selectedDrawingToMove != null)
                        {
                            List<Point> drawingPointsToMove = selectedDrawingToMove.points;

                            int indexFirstPoint = drawingPointsToMove.IndexOf(drawingPointsToMove.First());
                            int indexLastPoint = drawingPointsToMove.IndexOf(drawingPointsToMove.Last());

                            drawingPointsToMove[indexFirstPoint] = new Point(
                                e.X + currentDrawing.points.First().X - clickPosition.X,
                                e.Y + currentDrawing.points.First().Y - clickPosition.Y
                            );
                            drawingPointsToMove[indexLastPoint] = new Point(
                                e.X + currentDrawing.points.Last().X - clickPosition.X,
                                e.Y + currentDrawing.points.Last().Y - clickPosition.Y
                            );

                            if (currentDrawing is FreeDraw || (currentDrawing is Ruler ruler && ruler.multiple))
                            {
                                Point firstPoint = drawingPointsToMove.First();

                                for (int counterPoints = 1, counterDifference = 0; counterPoints < differenceBetweenPoints.Count; counterPoints++, counterDifference++)
                                {
                                    drawingPointsToMove[counterPoints] = new Point(
                                        firstPoint.X + differenceBetweenPoints[counterDifference].X,
                                        firstPoint.Y + differenceBetweenPoints[counterDifference].Y
                                    );
                                }
                            }
                        }
                    }
                    else if (action == 2)
                    {
                        (currentDrawing as Ruler).previewPoint = e.Location;
                    }
                    else if (action == 3)
                    {
                        currentDrawing.points.Add(e.Location);
                    }
                }
                else
                {
                    int indexLastPoint = currentDrawing.points.IndexOf(currentDrawing.points.Last());
                    currentDrawing.points[indexLastPoint] = e.Location;
                }
                mainPictureBox.Invalidate();
            }

            if (action == 8)
            {
                lastMagnifierPosition = e.Location;

                adjustMagnifierImage(lastMagnifierPosition, true);
            }
        }

        private void mainPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (action > 1 && action < 8)
                {
                    if (action == 2)
                    {
                        if (multiRuler)
                        {
                            return;
                        }

                        int indexLastPoint = currentDrawing.points.IndexOf(currentDrawing.points.Last());
                        currentDrawing.points[indexLastPoint] = e.Location;

                        if (recalibrate)
                        {
                            using (Form dialogRecalibrateRuler = new DialogRecalibrateRuler((currentDrawing as Ruler).lineLength.Last()))
                            {
                                var result = dialogRecalibrateRuler.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    recalibrateRuler((dialogRecalibrateRuler as DialogRecalibrateRuler).rulerValue);
                                    (currentDrawing as Ruler).lineLength = new List<float>
                                    {
                                        getRulerLength(currentDrawing.points.Last(),(currentDrawing as Ruler).previewPoint)
                                    };
                                }
                                recalibrate = false;
                            }
                        }
                    }
                    else if (action == 3)
                    {
                        if (currentDrawing.points.Any())
                        {
                            currentDrawing.points.Add(new Point(e.X + 1, e.Y + 1));
                        }
                    }

                    selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory])
                    {
                        currentDrawing
                    });
                    indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());

                    examHasChanges = true;
                }

                if (currentDrawing != null)
                {
                    selectedDrawingHistoryHandler();
                }

                mainPictureBox.Invalidate();
                draw = false;
                currentDrawing = null;
                selectedDrawingToMove = null;
            }
        }

        private void mainPictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (selectedDrawingHistory.Any())
            {
                if (selectedDrawingHistory[indexSelectedDrawingHistory].Count > 0)
                {
                    selectedDrawingHistory[indexSelectedDrawingHistory].ForEach(d => d.draw(e.Graphics));
                }
            }

            if (draw && currentDrawing != null)
            {
                if (action > 2)
                {
                    currentDrawing.draw(e.Graphics);
                }
                else if (action == 2)
                {
                    int index = (currentDrawing as Ruler).lineLength.LastIndexOf((currentDrawing as Ruler).lineLength.Last());
                    (currentDrawing as Ruler).lineLength[index] = getRulerLength(currentDrawing.points.Last(), (currentDrawing as Ruler).previewPoint);

                    currentDrawing.drawPreview(e.Graphics);
                }
            }
        }

        private void checkChangesAndSave()
        {
            if (examHasChanges)
            {
                eventUpdateExamLastChange?.Invoke(this, EventArgs.Empty);
                eventSaveExamImage?.Invoke(this, EventArgs.Empty);

                getDrawingsToSave();
                eventSaveExamImageDrawing?.Invoke(this, EventArgs.Empty);

                generateEditedImage();
                examHasChanges = false;
            }
        }

        public void getDrawingsToSave()
        {
            examImageDrawings = new List<ExamImageDrawingModel>();

            List<IDrawing> drawings = selectedDrawingHistory[indexSelectedDrawingHistory];

            if (drawings.Any())
            {
                if (drawings.Any(d => d.examImageId == 0))
                {
                    int examImageId = examImages.FirstOrDefault(ei => ei.templateFrameId == selectedFrame.id).id;

                    foreach (IDrawing d in drawings)
                    {
                        d.examImageId = examImageId;
                    }
                }

                foreach (IDrawing d in drawings)
                {
                    ExamImageDrawingModel drawingToSave = new ExamImageDrawingModel
                    {
                        examId = exam.id,
                        examImageId = d.examImageId,
                        drawingColor = d.drawingColor.ToArgb().ToString(),
                        drawingSize = (int)d.drawingSize,
                        drawingType = d.GetType().ToString().Split('.').Last(),
                        points = getCalibratedDrawingPoints(new List<Point>(d.points))
                    };

                    if (d is Text)
                    {
                        drawingToSave.drawingText = (d as Text).text;
                    }
                    else if (d is Ruler)
                    {
                        drawingToSave.lineLength = (d as Ruler).lineLength;
                    }

                    examImageDrawings.Add(drawingToSave);
                }
            }
        }

        private List<Point> getCalibratedDrawingPoints(List<Point> drawingPoints)
        {
            Size sizeToCompare = new Size();

            if (mainPictureBox.Height > mainPictureBox.Width)
            {
                sizeToCompare = new Size(447, 620);
            }
            else if (mainPictureBox.Width > mainPictureBox.Height)
            {
                sizeToCompare = new Size(858, 620);
            }

            if (sizeToCompare != mainPictureBox.Size)
            {
                float scale = (float)sizeToCompare.Height / mainPictureBox.Height;

                for (int counter = 0; counter < drawingPoints.Count; counter++)
                {
                    drawingPoints[counter] = Point.Round(new PointF(drawingPoints[counter].X * scale, drawingPoints[counter].Y * scale));
                }
            }

            return drawingPoints;
        }

        private void generateEditedImage()
        {
            if (selectedDrawingHistory[indexSelectedDrawingHistory].Count > 0)
            {
                Image frameImage = selectedFrame.filteredImage;

                Bitmap imageToDraw = new Bitmap(frameImage, new Size(
                    mainPictureBox.Height * frameImage.Width / frameImage.Height,
                    mainPictureBox.Height
                ));

                Graphics graphicsToDraw = Graphics.FromImage(imageToDraw);

                foreach (IDrawing drawing in selectedDrawingHistory[indexSelectedDrawingHistory])
                {
                    drawing.draw(graphicsToDraw);
                }

                Bitmap editedImage = new Bitmap(imageToDraw, new Size(frameImage.Width, frameImage.Height));

                editedImage.Save(Path.Combine(examPath, $"{selectedFrame.order}_edited.png"));
                selectedFrame.editedImage = editedImage;
            }
        }

        private void timerSensorStatusTick(object sender, EventArgs e)
        {
            Frame blinkingFrame = frames.FirstOrDefault(f => (Color)f.Tag == Color.LimeGreen) ?? selectedFrame;

            if (blinking)
            {
                blinkingFrame.BackColor = Color.Black;
            }
            else
            {
                Frame previousBlinking = frames.FirstOrDefault(f => f.BackColor == sensorStatusColor);

                if (previousBlinking != null)
                {
                    previousBlinking.BackColor = Color.Black;
                }

                blinkingFrame.BackColor = sensorStatusColor;
            }

            blinking = !blinking;
        }
    }
}