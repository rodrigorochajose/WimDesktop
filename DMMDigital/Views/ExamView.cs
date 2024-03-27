using DMMDigital.Interface;
using DMMDigital.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Models.Drawings;
using DMMDigital.Components;
using DMMDigital._Repositories;
using DMMDigital.Presenters;
using MoreLinq;
using System.Threading;

namespace DMMDigital.Views
{
    public partial class ExamView : Form, IExamView
    {
        public int examId { get; set; }
        public string sessionName { get; set; }
        public PatientModel patient { get; set; }
        public int templateId { get; set; }
        public string examPath { get; set; }
        public Frame selectedFrame { get; set; }
        public List<ExamImageModel> examImages { get; set; }
        public List<TemplateFrameModel> templateFrames { get; set; }
        public List<ExamImageDrawingModel> examImageDrawings { get; set; }
        public List<ExamImageDrawingPointsModel> examImageDrawingPoints { get; set; }
        public bool detectorConnected { get; set; }

        public event EventHandler eventSaveExam;
        public event EventHandler eventSaveExamImage;
        public event EventHandler eventSaveExamImageDrawing;
        public event EventHandler eventGetPatient;
        public event EventHandler eventSaveAndClose;

        int action = 0;
        int indexFrame = 0;
        float drawingSize = 5;
        int counterDrawings = 0;
        int textDrawingPreviousSize = 26;
        int indexSelectedDrawingHistory = 0;

        double scalingFactorSensorImage = 0;

        bool draw = false;
        bool multiRuler = false;
        bool rulerDrawed = false;
        bool calibrated = false;
        bool recalibrate = false;

        Color drawingColor = Color.Red;
        Color textColor = Color.Red;
        Color rulerColor = Color.Red;
        TrackBar trackBarZoom;
        Button buttonColorPicker;
        PictureBox pictureBoxMagnifier;
        NumericUpDown numericUpDownDrawingSize;

        List<Frame> frames = new List<Frame>();
        List<Point> differenceBetweenPoints = new List<Point>();
        List<List<IDrawing>> selectedDrawingHistory = new List<List<IDrawing>>();
        List<FrameDrawingHistory> frameDrawingHistories = new List<FrameDrawingHistory>();

        IDrawing currentDrawing;
        IDrawing selectedDrawingToMove;
        Size mainPictureBoxOriginalSize = new Size();
        Point clickPosition = new Point();

        public ExamView(PatientModel patient, int templateId, List<TemplateFrameModel> templateFrames, string templateName, string sessionName, ConfigModel config)
        {
            InitializeComponent();
            associateConfigs(config);

            mainPictureBoxOriginalSize = mainPictureBox.Size;
            ActiveControl = label1;

            this.sessionName = sessionName;
            this.patient = patient;
            this.templateId = templateId;
            setLabelPatientTemplate(patient.name, templateName);
            this.templateFrames = templateFrames;

            examImages = new List<ExamImageModel>();

            Load += delegate {
                eventSaveExam?.Invoke(this, EventArgs.Empty);
                DirectoryInfo di = Directory.CreateDirectory(examPath + "\\Paciente-" + patient.id + "\\" + sessionName + "_" + DateTime.Now.ToString("dd-MM-yyyy"));
                examPath = di.FullName;
                drawTemplate();

                if (detectorConnected)
                {
                    detectorConnection.Image = Properties.Resources.icon_32x32_green;
                }
            };
        }

        public ExamView(int examId, PatientModel patient, ConfigModel config)
        {
            InitializeComponent();
            associateConfigs(config);

            this.examId = examId;
            this.patient = patient;

            Load += delegate
            {
                mainPictureBoxOriginalSize = mainPictureBox.Size;

                drawTemplate();
                loadExamDrawings();

                if (examImages.Any())
                {
                    enableTools();
                }

                if (examImageDrawings.Any())
                {
                    selectedDrawingHistoryHandler();
                }

                if (detectorConnected)
                {
                    detectorConnection.Image = Properties.Resources.icon_32x32_green;
                }
            };
        }
        
        private void associateConfigs(ConfigModel config)
        {
            examPath = config.examPath;
            drawingColor = Color.FromArgb(int.Parse(config.drawingColor));
            textColor = Color.FromArgb(int.Parse(config.textColor));
            rulerColor = Color.FromArgb(int.Parse(config.rulerColor));
            textDrawingPreviousSize = config.textSize;
            drawingSize = config.drawingSize;
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
                    Name = "filme" + frame.id,
                    orientation = frame.orientation,
                    Tag = Color.Black,
                    Location = new Point(frame.locationX / 2, frame.locationY / 2),

                };

                ExamImageModel selectedExamImage = examImages.FirstOrDefault(e => e.frameId == newFrame.order);

                if (selectedExamImage == null)
                {
                    newFrame.Image = drawFrameDefaultImage(newFrame);
                }
                else
                {
                    Image img = new Bitmap(Path.Combine(examPath, selectedExamImage.file));
                    newFrame.originalImage = new Bitmap(img);
                    newFrame.notes = selectedExamImage.notes;
                    newFrame.datePhotoTook = selectedExamImage.createdAt.ToString();

                    string filteredFile = $"{newFrame.order}-filtered.png";

                    if (File.Exists(Path.Combine(examPath, filteredFile)))
                    {
                        img = new Bitmap(Path.Combine(examPath, filteredFile));
                        newFrame.filteredImage = img;
                    }

                    newFrame.Image = img.GetThumbnailImage(newFrame.Width, newFrame.Height, () => false, IntPtr.Zero);

                    img.Dispose();
                }

                newFrame.DoubleClick += frameDoubleClick;
                newFrame.Paint += framePaint;

                frameDrawingHistories.Add(new FrameDrawingHistory(frame.id, new List<List<IDrawing>> { new List<IDrawing>() }));
                selectedDrawingHistory = frameDrawingHistories[indexFrame].drawingHistory;

                frames.Add(newFrame);
                panelTemplate.Controls.Add(newFrame);
            }

            selectedFrame = frames.First();
            selectedFrame.Tag = Color.LimeGreen;

            if (selectedFrame.filteredImage != null)
            {
                mainPictureBox.Image = selectedFrame.filteredImage.Clone() as Image;
            } 
            else if (selectedFrame.originalImage != null)
            {
                mainPictureBox.Image = selectedFrame.originalImage.Clone() as Image;
            }
            resizeMainPictureBox();

            labelImageDate.Text = selectedFrame.datePhotoTook;
            textBoxFrameNotes.Text = selectedFrame.notes;
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
                                frameId = drawing.examImageId,
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
                                frameId = drawing.examImageId,
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
                                frameId = drawing.examImageId,
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
                                frameId = drawing.examImageId,
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
                                frameId = drawing.examImageId,
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
                                frameId = drawing.examImageId,
                                graphicsPath = new GraphicsPath(),
                                drawingColor = Color.FromArgb(int.Parse(drawing.drawingColor)),
                                drawingSize = drawing.drawingSize,
                                points = drawing.points,
                                lineLength = new List<float>(),
                                multiple = false,
                            };

                            if (ruler.points.Count > 2)
                            {
                                ruler.multiple = true;
                            }


                            for (int counter = 0; counter < ruler.points.Count - 1; counter++)
                            {
                                Point initialPoint = ruler.points[counter];
                                Point finalPoint = ruler.points[counter + 1];

                                float length = getRulerLength(initialPoint, finalPoint);
                                ruler.lineLength.Add(length);
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
                    List<List<IDrawing>> currentDrawingHistory = frameDrawingHistories.FirstOrDefault(f => f.frameId == drawing.frameId).drawingHistory;

                    currentDrawingHistory.Add(new List<IDrawing>(currentDrawingHistory.Last())
                    {
                        drawing
                    });
                }

                selectedDrawingHistory = frameDrawingHistories.FirstOrDefault().drawingHistory;
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
            }
        }

        private void frameHandler(Image image)
        {
            DateTime createdAt = DateTime.Now;

            if (selectedFrame.originalImage != null)
            {
                examImages.RemoveAll(i => i.frameId == selectedFrame.order);
            }

            examImages.Add(new ExamImageModel
            {
                examId = examId,
                frameId = selectedFrame.order,
                file = selectedFrame.order + "-original.png",
                notes = selectedFrame.notes,
                createdAt = createdAt
            });

            selectedFrame.datePhotoTook = createdAt.ToString();

            labelImageDate.Invoke((MethodInvoker)(() => labelImageDate.Text = selectedFrame.datePhotoTook));
            textBoxFrameNotes.Invoke((MethodInvoker)(() => textBoxFrameNotes.Text = selectedFrame.notes));

            selectedFrame.originalImage = image.Clone() as Image;

            selectedFrame.Tag = Color.Black;
            selectedFrame.Invoke((MethodInvoker)(() =>
            {
                selectedFrame.Image = image.GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
                selectedFrame.Refresh();
            }));

            indexFrame = ++indexFrame == frames.Count() ? --indexFrame : indexFrame++;

            Frame nextFrameToGetImage = frames[indexFrame];

            nextFrameToGetImage.Invoke((MethodInvoker)(() =>
            {
                frames[indexFrame].Tag = Color.LimeGreen;
                frames[indexFrame].Refresh();
            }));
        }

        public void selectFrame()
        {
            selectedFrame = frames[indexFrame];

            selectedDrawingHistory = frameDrawingHistories[indexFrame].drawingHistory;
            indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
            selectedDrawingHistoryHandler();
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

            labelImageDate.Invoke((MethodInvoker)(() => labelImageDate.Text = selectedFrame.datePhotoTook));
            textBoxFrameNotes.Invoke((MethodInvoker)(() => textBoxFrameNotes.Text = selectedFrame.notes));
            selectedFrame.Tag = Color.LimeGreen;

            selectedFrame.Refresh();
            indexFrame = selectedFrame.order - 1;

            if (frameDrawingHistories.Count > 0)
            {
                selectedDrawingHistory = frameDrawingHistories[indexFrame].drawingHistory;
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
            }

            selectedDrawingHistoryHandler();

            if (selectedFrame.filteredImage != null)
            {
                mainPictureBox.Image = selectedFrame.filteredImage;
            }
            else if (selectedFrame.originalImage != null)
            {
                mainPictureBox.Image = selectedFrame.originalImage;
            }
            else
            {
                mainPictureBox.Image = null;
            }

            resizeMainPictureBox();
        }

        public bool dialogOverrideCurrentImage()
        {
            DialogResult res = MessageBox.Show("Confirma sobreescrever a imagem atual ?", "Sobrescrever Imagem", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                return false;
            }
            return true;
        }

        public void loadImageOnMainPictureBox()
        {
            selectFrame();
            using (FileStream fs = File.Open(Path.Combine(examPath, selectedFrame.order + "-original.png"), FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
            {
                Image image = Image.FromStream(fs);
                mainPictureBox.Image = image;
                frameHandler(image);
                resizeMainPictureBox();
                enableTools();
                saveExamChangesOnDatabase();
            }
        }

        public void resizeMainPictureBox()
        {
            if (mainPictureBox.Image != null)
            {
                mainPictureBox.Invoke((MethodInvoker)(() =>
                {
                    mainPictureBox.Size = new Size(
                        mainPictureBoxOriginalSize.Height * mainPictureBox.Image.Width / mainPictureBox.Image.Height,
                        mainPictureBoxOriginalSize.Height
                    );
                    mainPictureBox.Location = new Point((panel2.Width - mainPictureBox.Width) / 2, 0);
                }));
            }
        }

        private void enableTools()
        {
            if (examImages.Any())
            {
                foreach (ToolStripButton tool in toolStrip.Items.OfType<ToolStripButton>())
                {
                    Invoke((MethodInvoker)(() => tool.Enabled = true));
                }
            }
        }

        private void selectTool(object sender)
        {
            ToolStripButton selectedButton = toolStrip.Items.OfType<ToolStripButton>().SingleOrDefault(b => b.Tag != null && (string)b.Tag == "selected");
            if (selectedButton != null)
            {
                if (selectedButton.Name == "buttonMagnifier")
                {
                    panel2.Controls.Remove(pictureBoxMagnifier);
                }
                selectedButton.BackColor = Color.WhiteSmoke;
                selectedButton.Tag = "selectable";
            } 
            (sender as ToolStripButton).BackColor = Color.LightGray;
            (sender as ToolStripButton).Tag = "selected";
        }

        private void loadToolOptions()
        {
            panelToolOptions.Controls.Clear();
            switch (action)
            {
                case 2:
                    Label labelColor = new Label
                    {
                        Name = "labelRulerColor",
                        Text = "Cor",
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
                        Size = new Size(102, 23),
                        Text = "Padrão do Sensor",
                        UseVisualStyleBackColor = false,
                    };
                    buttonResetCalibration.Click += buttonResetCalibrationClick;

                    Button buttonSetCalibration = new Button
                    {
                        Location = new Point(121, 31),
                        Name = "button3",
                        Size = new Size(102, 23),
                        Text = "Recalibrar",
                        UseVisualStyleBackColor = false,
                    };
                    buttonSetCalibration.Click += buttonSetCalibrationClick;

                    CheckBox checkBoxMultiRuler = new CheckBox
                    {
                        Font = new Font("Segoe UI", 9F),
                        Location = new Point(238, 22),
                        Name = "checkBoxMultiRuler",
                        Size = new Size(119, 19),
                        Text = "Medição Multipla",
                    };
                    checkBoxMultiRuler.CheckedChanged += checkBoxMultiRulerCheckedChange;

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
                        Minimum = 1,
                        Value = 1,
                        Name = "trackBarZoom",
                        Size = new Size(338, 45)
                    };

                    panelToolOptions.Controls.Add(trackBarZoom);
                    break;
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
                Text = "Cor",
                AutoSize = true,
                Size = new Size(31, 19),
                Location = new Point(38, 21),
                Font = new Font("Segoe UI", 10F),
            };

            Label labelSize = new Label
            {
                Name = "labelSize",
                Text = "Tamanho",
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

            TextBox textBox = new TextBox
            {
                Size = new Size(size.Width - 10, 23),
                Location = new Point(5, label.Location.Y + 25),
                Font = new Font("Arial", 10, FontStyle.Regular)
            };

            Button okButton = new Button
            {
                DialogResult = DialogResult.OK,
                Name = "okButton",
                Size = new Size(75, 23),
                Text = "&OK",
                Location = new Point(size.Width - 80 - 80, size.Height - 25)
            };

            Button cancelButton = new Button
            {
                DialogResult = DialogResult.Cancel,
                Name = "cancelButton",
                Size = new Size(75, 23),
                Text = "&Cancel",
                Location = new Point(size.Width - 80, size.Height - 25)
            };

            inputBox.Controls.AddRange(new Control[] { label, textBox, okButton, cancelButton });
            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            inputBox.ShowDialog();
            return textBox.Text;
        }

        private float getRulerLength(Point initialPoint, Point finalPoint)
        {
            // 30 is sensor Width and 20 height -> i'm going to get from database these values
            double scalingFactorWidth = mainPictureBox.Image.Width / 20;
            double scalingFactorHeight = mainPictureBox.Image.Height / 30;

            float initialX = initialPoint.X * mainPictureBox.Image.Width / mainPictureBox.Width;
            float initialY = initialPoint.Y * mainPictureBox.Image.Height / mainPictureBox.Height;
            float finalX = finalPoint.X * mainPictureBox.Image.Width / mainPictureBox.Width;
            float finalY = finalPoint.Y * mainPictureBox.Image.Height / mainPictureBox.Height;

            float lenghtInMilimeters = (float)Math.Sqrt(Math.Pow((initialX - finalX) / scalingFactorWidth, 2) + Math.Pow((initialY - finalY) / scalingFactorHeight, 2));

            if (calibrated)
            {
                lenghtInMilimeters *= (float)scalingFactorSensorImage;
            }

            return lenghtInMilimeters;
        }

        private void recalibrateRuler(double rulerValue)
        {
            scalingFactorSensorImage = rulerValue / (currentDrawing as Ruler).lineLength.First();
            calibrated = true;
        }

        private void verifyHistoryToReset()
        {
            if (indexSelectedDrawingHistory == 0)
            {
                selectedDrawingHistory = new List<List<IDrawing>>() { new List<IDrawing>() };
            }
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
            saveExamChangesOnDatabase();
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
                Image = Properties.Resources.icon_16x16_trash
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
                    label.Text = "Circulo";
                    break;

                case RectangleDraw _:
                    label.Text = "Retangulo";
                    break;

                case Arrow _:
                    label.Text = "Seta";
                    break;

                case Ruler _:
                    label.Text = "Régua";
                    break;

                case FreeDraw _:
                    label.Text = "DesenhoLivre";
                    break;

                case Text _:
                    label.Text = "Texto";
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
            if (selectedDrawingHistory.Count > 0)
            {
                selectedDrawingHistory[indexSelectedDrawingHistory].ForEach(showDrawingHistory);
                saveExamChangesOnDatabase();
            }
        }

        private void buttonNewExamClick(object sender, EventArgs e)
        {
            IChooseTemplateExamView chooseTemplateView = new ChooseTemplateExamView();
            eventGetPatient?.Invoke(this, e);

            chooseTemplateView.patientId = patient.id;
            chooseTemplateView.patientName = patient.name;
            chooseTemplateView.patientBirthDate = patient.birthDate;
            chooseTemplateView.patientPhone = patient.phone;
            chooseTemplateView.patientRecommendation = patient.recommendation;
            chooseTemplateView.patientObservation = patient.observation;

            new ChooseTemplateExamPresenter(chooseTemplateView, new TemplateRepository(), "examView");
        }

        private void buttonOpenExamClick(object sender, EventArgs e)
        {
            new PatientPresenter(new PatientView(), new PatientRepository(), "newPage");
        }

        private void buttonImportClick(object sender, EventArgs e)
        {
            if (frames[indexFrame].originalImage != null)
            {
                if (dialogOverrideCurrentImage() == false)
                {
                    return;
                }
            }

            DialogResult result = dialogFileImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectFrame();
                Image selectedImage = Image.FromStream(dialogFileImage.OpenFile());
                mainPictureBox.Image = selectedImage;
                resizeMainPictureBox();

                selectedImage.Save(Path.Combine(examPath, selectedFrame.order + "-original.png"));
                frameHandler(selectedImage);

                enableTools();
            }
            saveExamChangesOnDatabase();
        }

        private void buttonExportClick(object sender, EventArgs e)
        {
            for (int counter = 0; counter < frames.Count; counter++)
            {
                if (frames[counter].originalImage != null)
                {
                    if (frameDrawingHistories[counter].drawingHistory.Count > 1)
                    {
                        Image frameImage = frames[counter].originalImage;
                        Bitmap imageToDraw = new Bitmap(frameImage, new Size(
                            mainPictureBoxOriginalSize.Height * frameImage.Width / frameImage.Height,
                            mainPictureBoxOriginalSize.Height
                        ));

                        Graphics graphicsToDraw = Graphics.FromImage(imageToDraw);

                        foreach (IDrawing drawing in frameDrawingHistories[counter].drawingHistory.Last())
                        {
                            drawing.draw(graphicsToDraw);
                        }

                        Bitmap editedImage = new Bitmap(imageToDraw, new Size(frameImage.Width, frameImage.Height));

                        editedImage.Save(Path.Combine(examPath, $"{frames[counter].order}-edited.png"));
                    }
                }
            }

            IExportExamView exportView = new ExportExamView
            {
                pathImages = examPath,
                framesToExport = frames.Where(f => f.originalImage != null).ToList(),
                patientName = patient.name
            };
            (exportView as Form).ShowDialog();
        }

        private void buttonDeleteClick(object sender, EventArgs e)
        {
            if (selectedFrame.originalImage != null)
            {
                DialogResult result = MessageBox.Show("Deseja excluir a imagem atual ?", "Excluir Imagem", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }

                File.Delete(Path.Combine(examPath, $"{selectedFrame.order}-original.png"));

                string filteredImagePath = Path.Combine(examPath, $"{selectedFrame.order}-filtered.png");

                if (File.Exists(filteredImagePath)) {
                    File.Delete(filteredImagePath);
                }

                frameDrawingHistories[indexFrame].drawingHistory = new List<List<IDrawing>> { new List<IDrawing>() };

                selectedDrawingHistory = frameDrawingHistories[indexFrame].drawingHistory;
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                flowLayoutPanel1.Controls.Clear();

                examImages.RemoveAll(ei => ei.frameId == selectedFrame.order);

                selectedFrame.Image = drawFrameDefaultImage(selectedFrame);
                selectedFrame.originalImage = null;
                selectedFrame.filteredImage = null;
                selectedFrame.datePhotoTook = "";
                selectedFrame.notes = "";

                labelImageDate.Text = selectedFrame.datePhotoTook;
                textBoxFrameNotes.Text = selectedFrame.notes;

                mainPictureBox.Image = null;
                saveExamChangesOnDatabase();
            }
        }

        private void buttonCompareFrameClick(object sender, EventArgs e)
        {
            selectTool(sender);

            IChooseFramesToCompare compareFrames = new ChooseFramesToCompare
            {
                framesToSelect = frames
            };
            (compareFrames as Form).ShowDialog();
        }

        private void buttonSelectClick(object sender, EventArgs e)
        {
            action = 0;
            selectTool(sender);
            panelToolOptions.Controls.Clear();
        }

        private void buttonMoveDrawingClick(object sender, EventArgs e)
        {
            action = 1;
            selectTool(sender);
            panelToolOptions.Controls.Clear();
        }

        private void buttonMagnifierClick(object sender, EventArgs e)
        {
            action = 8;
            loadToolOptions();
            selectTool(sender);

            pictureBoxMagnifier = new PictureBox
            {
                Location = new Point(762, 205),
                Name = "pictureBoxMagnifier",
                Size = new Size(250, 250),
                Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height)
            };

            panel2.Controls.Add(pictureBoxMagnifier);
            panel2.Controls.SetChildIndex(pictureBoxMagnifier, 0);
        }

        private void buttonRulerClick(object sender, EventArgs e)
        {
            action = 2;
            loadToolOptions();
            selectTool(sender);
        }

        private void buttonUndoClick(object sender, EventArgs e)
        {
            if (indexSelectedDrawingHistory - 1 > -1)
            {
                indexSelectedDrawingHistory--;
                mainPictureBox.Invalidate();
                selectedDrawingHistoryHandler();
            }
        }

        private void buttonRedoClick(object sender, EventArgs e)
        {
            if (indexSelectedDrawingHistory + 1 < selectedDrawingHistory.Count)
            {
                indexSelectedDrawingHistory++;
                mainPictureBox.Invalidate();
                selectedDrawingHistoryHandler();
            }
        }

        private void buttonFilterClick(object sender, EventArgs e)
        {
            selectTool(sender);

            Image img = selectedFrame.filteredImage ?? selectedFrame.originalImage;

            IFilterView filterView = new FilterView(new Bitmap(img));
            (filterView as Form).ShowDialog();

            Image image = filterView.originalImage;

            image.Save(Path.Combine(examPath, selectedFrame.order + "-filtered.png"));

            selectedFrame.Invoke((MethodInvoker)(() =>
            {
                selectedFrame.filteredImage = image;
                selectedFrame.Image = image.GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
                selectedFrame.Refresh();
            }));
            mainPictureBox.Image = image;
        }

        private void buttonFreeDrawClick(object sender, EventArgs e)
        {
            action = 3;
            loadToolOptions();
            selectTool(sender);
        }

        private void buttonTextClick(object sender, EventArgs e)
        {
            action = 4;
            loadToolOptions();
            selectTool(sender);
        }

        private void buttonArrowClick(object sender, EventArgs e)
        {
            action = 5;
            loadToolOptions();
            selectTool(sender);
        }

        private void buttonEllipseClick(object sender, EventArgs e)
        {
            action = 6;
            loadToolOptions();
            selectTool(sender);
        }

        private void buttonRectangleDrawClick(object sender, EventArgs e)
        {
            action = 7;
            loadToolOptions();
            selectTool(sender);
        }

        private void buttonRotateLeftClick(object sender, EventArgs e)
        {
            Image currentImage = mainPictureBox.Image;
            currentImage.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (selectedFrame.filteredImage != null)
            {
                currentImage.Save(Path.Combine(examPath, $"{selectedFrame.order}-filtered.png"));
            } 
            else
            {
                currentImage.Save(Path.Combine(examPath, $"{selectedFrame.order}-original.png"));
            }

            mainPictureBox.Image = currentImage;
            selectedFrame.Image = currentImage.GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
            selectedFrame.Refresh();
        }

        private void buttonRotateRightClick(object sender, EventArgs e)
        {
            Image currentImage = mainPictureBox.Image;
            currentImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            if (selectedFrame.filteredImage != null)
            {
                currentImage.Save(Path.Combine(examPath, $"{selectedFrame.order}-filtered.png"));
            }
            else
            {
                currentImage.Save(Path.Combine(examPath, $"{selectedFrame.order}-original.png"));
            }

            mainPictureBox.Image = currentImage;
            selectedFrame.Image = currentImage.GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
            selectedFrame.Refresh();
        }

        private void buttonRestoreExamClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja restaurar a imagem original ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (selectedFrame.originalImage != null)
                {
                    examImages.RemoveAll(ei => ei.frameId == selectedFrame.order);

                    selectedDrawingHistory = new List<List<IDrawing>> { new List<IDrawing>() };
                    indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                    flowLayoutPanel1.Controls.Clear();

                    if (selectedFrame.filteredImage != null) {

                        selectedFrame.filteredImage = null;

                        Image img = selectedFrame.originalImage;
                        mainPictureBox.Image = img;

                        selectedFrame.Invoke((MethodInvoker)(() =>
                        {
                            selectedFrame.Image = new Bitmap(img).GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
                            selectedFrame.Refresh();
                        }));

                        File.Delete(Path.Combine(examPath, $"{selectedFrame.order}-filtered.png"));
                    }

                    mainPictureBox.Refresh();
                    saveExamChangesOnDatabase();
                }
            }
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
            scalingFactorSensorImage = 0;
            calibrated = false;
        }

        private void buttonSetCalibrationClick(object sender, EventArgs e)
        {
            recalibrate = true;
        }

        private void checkBoxMultiRulerCheckedChange(object sender, EventArgs e)
        {
            multiRuler = (sender as CheckBox).Checked;
        }

        private void textBoxFrameNotesTextChanged(object sender, EventArgs e)
        {
            selectedFrame.notes = textBoxFrameNotes.Text;
        }

        private void mainPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            clickPosition = e.Location;
            if (action != 0)
            {
                draw = true;
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

                                    if ((selectedDrawingToMove as Ruler).multiple) {
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
                            selectedDrawingToMove.frameId = currentDrawing.frameId;
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
                            if (e.Button == MouseButtons.Right)
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
                            else
                            {
                                if (!rulerDrawed)
                                {
                                    currentDrawing = new Ruler
                                    {
                                        id = counterDrawings,
                                        frameId = selectedFrame.order,
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
                                }
                                else
                                {
                                    currentDrawing.points.Add((currentDrawing as Ruler).previewPoint);

                                    int index = (currentDrawing as Ruler).lineLength.LastIndexOf((currentDrawing as Ruler).lineLength.Last());
                                    (currentDrawing as Ruler).lineLength[index] = getRulerLength(currentDrawing.points.SkipLast(1).Last(), (currentDrawing as Ruler).points.Last());

                                    (currentDrawing as Ruler).lineLength.Add(0);
                                }
                            }
                        }
                        else
                        {
                            currentDrawing = new Ruler
                            {
                                id = counterDrawings,
                                frameId = selectedFrame.order,
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
                            frameId = selectedFrame.order,
                            graphicsPath = new GraphicsPath(),
                            points = new List<Point> { clickPosition },
                            drawingColor = drawingColor,
                            drawingSize = drawingSize
                        };

                        break;

                    case 4:
                        draw = false;
                        verifyHistoryToReset();

                        string textToDraw = getTextToDraw();

                        if (textToDraw.Length > 0)
                        {
                            currentDrawing = new Text
                            {
                                id = counterDrawings,
                                frameId = selectedFrame.order,
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
                            frameId = selectedFrame.order,
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
                            frameId = selectedFrame.order,
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
                            frameId = selectedFrame.order,
                            graphicsPath = new GraphicsPath(),
                            drawingColor = drawingColor,
                            drawingSize = drawingSize,
                            points = new List<Point> { clickPosition, clickPosition }
                        };

                        break;
                }
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
                int rectangleWidth = pictureBoxMagnifier.Width / trackBarZoom.Value;
                int rectangleHeight = pictureBoxMagnifier.Height / trackBarZoom.Value;

                PointF rectangleInitialPosition = new PointF(
                (e.X * mainPictureBox.Image.Width / mainPictureBox.Width) - rectangleWidth / 2,
                (e.Y * (mainPictureBox.Image.Height + 10) / mainPictureBox.Height) - rectangleHeight / 2
                );

                RectangleF rectangle = new RectangleF(rectangleInitialPosition, new Size(rectangleWidth, rectangleHeight));

                Graphics graphics = Graphics.FromImage(pictureBoxMagnifier.Image);
                graphics.Clear(Color.White);
                graphics.DrawImage(mainPictureBox.Image, new Rectangle(0, 0, pictureBoxMagnifier.Width, pictureBoxMagnifier.Height), rectangle, GraphicsUnit.Pixel);

                pictureBoxMagnifier.Refresh();
            }
        }

        private void mainPictureBoxMouseUp(object sender, MouseEventArgs e)
        {
            if (action > 1)
            {
                //verifyHistoryToReset();
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
                    if (currentDrawing.points.Count == 1)
                    {
                        currentDrawing.points.Add(new Point(e.X + 1, e.Y + 1));
                    }
                }

                selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory])
                {
                    currentDrawing
                });
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                    
            }
            selectedDrawingHistoryHandler();
            mainPictureBox.Invalidate();

            draw = false;
            currentDrawing = null;
            selectedDrawingToMove = null;
        }

        private void mainPictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (selectedDrawingHistory.Any())
            {
                selectedDrawingHistory[indexSelectedDrawingHistory].ForEach(d => d.draw(e.Graphics));
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

        private void saveExamChangesOnDatabase()
        {
            if (!timer1.Enabled)
            {
                timer1.Enabled = true;
            }
        } 

        public void timerTick(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                foreach (ExamImageModel item in examImages)
                {
                    Frame frame = frames.FirstOrDefault(i => i.order == item.frameId);

                    if (frame != null)
                    {
                        item.notes = frame.notes;
                    }
                }

                getDrawingsToSave();
                eventSaveExamImage?.Invoke(this, EventArgs.Empty);
                eventSaveExamImageDrawing?.Invoke(this, EventArgs.Empty);

                timer1.Enabled = false;
            }
        }

        public void getDrawingsToSave()
        {
            examImageDrawings = new List<ExamImageDrawingModel>();
            examImageDrawingPoints = new List<ExamImageDrawingPointsModel>();
            List<IDrawing> drawings = new List<IDrawing>();

            foreach (FrameDrawingHistory fdh in frameDrawingHistories)
            {
                if (fdh.drawingHistory.Count > 1)
                {
                    drawings.AddRange(fdh.drawingHistory.Last());
                }
            }

            if (drawings.Any())
            {
                foreach (IDrawing d in drawings)
                {
                    ExamImageDrawingModel drawingToSave = new ExamImageDrawingModel
                    {
                        id = d.id,
                        examId = examId,
                        examImageId = d.frameId,
                        drawingColor = d.drawingColor.ToArgb().ToString(),
                        drawingSize = (int)d.drawingSize,
                        drawingType = d.GetType().ToString().Split('.').Last(),
                        points = d.points
                    };

                    if (d is Text)
                    {
                        drawingToSave.drawingText = (d as Text).text;
                    }

                    examImageDrawings.Add(drawingToSave);
                }
            }
        }

        private void examViewFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = timer1.Enabled;

            if (e.Cancel)
            {
                eventSaveAndClose?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}