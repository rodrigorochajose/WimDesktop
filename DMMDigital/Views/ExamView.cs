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
        public bool detectorConnected { get; set; }

        public event EventHandler eventSaveExam;
        public event EventHandler eventGetExamPath;
        public event EventHandler eventSaveExamImage;
        public event EventHandler eventSaveExamImageDrawing;
        public event EventHandler eventGetPatient;

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
        TrackBar trackBarZoom;
        Button buttonColorPicker;
        PictureBox pictureBoxMagnifier;
        NumericUpDown numericUpDownDrawingSize;

        List<Frame> frames = new List<Frame>();
        List<Point> pointsDifferenceFreeDrawing = new List<Point>();
        List<List<IDrawing>> selectedDrawingHistory = new List<List<IDrawing>>();
        List<FrameDrawingHistory> frameDrawingHistories = new List<FrameDrawingHistory>();

        IDrawing currentDrawing;
        IDrawing selectedDrawingToMove;
        Size mainPictureBoxOriginalSize = new Size();
        Point clickPosition = new Point();
        Point drawingFinalPosition = new Point();
        Point drawingInitialPosition = new Point();

        public ExamView(PatientModel patient, int templateId, List<TemplateFrameModel> templateFrames, string templateName, string sessionName)
        {
            InitializeComponent();

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
                eventGetExamPath?.Invoke(this, EventArgs.Empty);
                DirectoryInfo di = Directory.CreateDirectory(examPath + "\\Paciente-" + patient.id + "\\" + sessionName + "_" + DateTime.Now.ToString("dd-MM-yyyy"));
                examPath = di.FullName;
                drawTemplate();

                if (detectorConnected)
                {
                    detectorConnection.Image = Properties.Resources.icon_32x32_green;
                }
            };
        }

        public ExamView(int examId, int patientId)
        {
            InitializeComponent();
            this.examId = examId;
            patient = new PatientModel
            {
                id = patientId
            };

            Load += delegate
            {
                mainPictureBoxOriginalSize = mainPictureBox.Size;

                drawTemplate();

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
                    newFrame.Image = drawFrameImage(newFrame);
                }
                else
                {
                    using (FileStream fs = new FileStream(Path.Combine(examPath, selectedExamImage.file), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        Image image = Image.FromStream(fs);

                        newFrame.originalImage = new Bitmap(image);
                        newFrame.Image = image.GetThumbnailImage(newFrame.Width, newFrame.Height, () => false, IntPtr.Zero);
                        newFrame.notes = selectedExamImage.notes;
                        newFrame.datePhotoTook = selectedExamImage.createdAt.ToString();

                        image.Dispose();
                    }
                }

                newFrame.DoubleClick += frameDoubleClick;
                newFrame.Paint += framePaint;

                frames.Add(newFrame);

                List<IDrawing> frameDrawings = new List<IDrawing>();
                if (examImageDrawings != null)
                {
                    foreach (ExamImageDrawingModel drawing in examImageDrawings.Where(d => d.examImageId == newFrame.order))
                    {
                        using (Image img = Image.FromFile(Path.Combine(examPath, drawing.file)))
                        {
                            frameDrawings.Add(new ImageDrawed
                            {
                                id = int.Parse(drawing.file.Substring(4, 1)),
                                img = new Bitmap(img),
                            });
                        }
                    }
                }

                frameDrawingHistories.Add(new FrameDrawingHistory(frame.id, new List<List<IDrawing>> { frameDrawings }));
                selectedDrawingHistory = frameDrawingHistories[indexFrame].drawingHistory;

                panelTemplate.Controls.Add(newFrame);
            }

            selectedFrame = frames.First();
            selectedFrame.Tag = Color.LimeGreen;
            if (selectedFrame.originalImage != null)
            {
                mainPictureBox.Image = selectedFrame.originalImage.Clone() as Image;
                resizeMainPictureBox();
            }

            labelImageDate.Text = selectedFrame.datePhotoTook;
            textBoxFrameNotes.Text = selectedFrame.notes;
        }

        // passar pro presenter?
        private Image drawFrameImage(Frame currentFrame)
        {
            Bitmap image = new Bitmap(currentFrame.Width, currentFrame.Height);
            Graphics graphics = Graphics.FromImage(image);
            Font font = new Font("TimesNewRoman", 10, FontStyle.Bold, GraphicsUnit.Pixel);
            graphics.DrawString(currentFrame.order.ToString(), font, Brushes.White, new Point(0, 0));

            return image;
        }

        private void getDrawingsToSaveOnDatabase()
        {
            examImageDrawings = new List<ExamImageDrawingModel>();
            List<string> files = Directory.GetFiles(examPath).Where(f => !f.EndsWith("original.png")).ToList();

            foreach (string file in files)
            {
                examImageDrawings.Add(new ExamImageDrawingModel
                {
                    examId = examId,
                    examImageId = int.Parse(file.Substring(examPath.Length + 2, 1)),
                    file = file.Substring(examPath.Length + 1)
                });
            }

            eventSaveExamImageDrawing?.Invoke(this, EventArgs.Empty);
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

            indexFrame++;
            if (indexFrame == frames.Count())
            {
                indexFrame--;
                selectFrame();
            }

            frames[indexFrame].Tag = Color.LimeGreen;
            frames[indexFrame].Refresh();
        }

        private void selectFrame()
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

            mainPictureBox.Image = selectedFrame.originalImage;
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
                    Size rectangleSize;
                    if (selectedFrame.orientation.Contains("Horizontal"))
                    {
                        rectangleSize = new Size(
                            mainPictureBoxOriginalSize.Width,
                            mainPictureBoxOriginalSize.Height
                        );
                    }
                    else
                    {
                        rectangleSize = new Size(
                            mainPictureBoxOriginalSize.Height * mainPictureBox.Image.Width / mainPictureBox.Image.Height,
                            mainPictureBoxOriginalSize.Height
                        );
                    }

                    mainPictureBox.Size = rectangleSize;
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
                    tool.Enabled = true;
                }
            }
        }

        private void selectTool(object sender)
        {
            ToolStripButton selectedButton = toolStrip.Items.OfType<ToolStripButton>().SingleOrDefault(b => b.Tag != null && (string)b.Tag == "selected");
            if (selectedButton != null)
            {
                if (selectedButton.Name == "buttonZoom")
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
                        BackColor = drawingColor,
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
                    //panelToolOptions.Controls.SetChildIndex(trackBarZoom, 0);
                    //panelToolOptions.Refresh();
                    break;
            }
        }

        private void generateControlDrawingOption()
        {
            int value;
            value = action == 4 ? textDrawingPreviousSize : (int)drawingSize;

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
                BackColor = drawingColor,
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

        private float getRulerLength()
        {
            // 30 is sensor Width and 20 height -> i'm going to get from database these values
            double scalingFactorWidth = mainPictureBox.Image.Width / 20;
            double scalingFactorHeight = mainPictureBox.Image.Height / 30;

            float initialX = (currentDrawing.initialPosition.X * mainPictureBox.Image.Width / mainPictureBox.Width);
            float initialY = (currentDrawing.initialPosition.Y * mainPictureBox.Image.Height / mainPictureBox.Height);
            float finalX = (currentDrawing.finalPosition.X * mainPictureBox.Image.Width / mainPictureBox.Width);
            float finalY = (currentDrawing.finalPosition.Y * mainPictureBox.Image.Height / mainPictureBox.Height);

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

            File.Delete(Path.Combine(examPath, $"F{selectedFrame.order}-D{drawing.id}.png"));

            selectedDrawingHistoryHandler();
            mainPictureBox.Invalidate();
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

            if (drawing is Ellipse)
            {
                label.Text = $"Circulo-{drawing.id}";
            }
            else if (drawing is RectangleDraw)
            {
                label.Text = $"Retangulo-{drawing.id}";
            }
            else if (drawing is Arrow)
            {
                label.Text = $"Seta-{drawing.id}";
            }
            else if (drawing is Text)
            {
                label.Text = $"Texto{drawing.id}";
            }
            else if (drawing is Ruler)
            {
                label.Text = $"Régua-{drawing.id}";
            }
            else 
            {
                label.Text = $"DesenhoLivre-{drawing.id}";
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
            IExportExamView exportView = new ExportExamView
            {
                pathImages = examPath,
                framesToExport = frames,
                sessionName = sessionName
            };
            (exportView as Form).ShowDialog();
        }

        private void buttonDeleteClick(object sender, EventArgs e)
        {
            if (selectedFrame.originalImage != null)
            {
                DialogResult result = MessageBox.Show("Deseja excluir a imagem atual ?", "Excluir Imagem", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }

                File.Delete(Path.Combine(examPath, selectedFrame.order + "-original.png"));

                DirectoryInfo directory = new DirectoryInfo(examPath);
                List<FileInfo> frameDrawings = directory.GetFiles().Where(f => f.Name.Contains($"F{selectedFrame.order}-")).ToList();
                foreach (FileInfo file in frameDrawings)
                {
                    file.Delete();
                }

                selectedDrawingHistory = new List<List<IDrawing>>{ new List<IDrawing>() };
                indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                flowLayoutPanel1.Controls.Clear();

                examImages.RemoveAll(i => i.frameId == selectedFrame.order);

                selectedFrame.Image = drawFrameImage(selectedFrame);
                selectedFrame.originalImage = null;
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
            panelToolOptions.Controls.Clear();
            selectTool(sender);
            action = 0;
        }

        private void buttonMoveDrawingClick(object sender, EventArgs e)
        {
            panelToolOptions.Controls.Clear();
            selectTool(sender);
            action = 1;
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

            IFilterView filterView = new FilterView((Bitmap)selectedFrame.originalImage);
            (filterView as Form).ShowDialog();

            Image image = filterView.originalImage;

            image.Save(Path.Combine(examPath, selectedFrame.order + "-original.png"));

            selectedFrame.Invoke((MethodInvoker)(() =>
            {
                selectedFrame.originalImage = image;
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
            Image currentFrame = mainPictureBox.Image;
            currentFrame.RotateFlip(RotateFlipType.Rotate270FlipNone);
            mainPictureBox.Image = currentFrame;
            frames[indexFrame - 1].Image = currentFrame;
            selectedFrame.Refresh();
        }

        private void buttonRotateRightClick(object sender, EventArgs e)
        {
            Image currentFrame = mainPictureBox.Image;
            currentFrame.RotateFlip(RotateFlipType.Rotate90FlipNone);
            mainPictureBox.Image = currentFrame;
            frames[indexFrame - 1].Image = currentFrame;
            selectedFrame.Refresh();
        }

        private void buttonRestoreExamClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja restaurar a imagem original ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                action = 0;
                indexSelectedDrawingHistory = 0;

                clickPosition = new Point();
                drawingInitialPosition = new Point();
                drawingFinalPosition = new Point();
                mainPictureBoxOriginalSize = new Size();
                currentDrawing = new Ellipse();
                selectedDrawingToMove = new Ellipse();

                frames = new List<Frame>();
                pointsDifferenceFreeDrawing = new List<Point>();
                examImages = new List<ExamImageModel>();
                examImageDrawings = new List<ExamImageDrawingModel>();
                frameDrawingHistories = new List<FrameDrawingHistory>();
                selectedDrawingHistory = new List<List<IDrawing>>() { new List<IDrawing>() };

                DirectoryInfo directory = new DirectoryInfo(examPath);
                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }

                flowLayoutPanel1.Controls.Clear();
                mainPictureBox.Invalidate();
                saveExamChangesOnDatabase();
            }
        }

        private void buttonColorPickerClick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                drawingColor = colorDialog1.Color;
                buttonColorPicker.BackColor = drawingColor;
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
            if ((sender as CheckBox).Checked)
            {
                multiRuler = true;
            }
            else
            {
                multiRuler = false;
            }
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
                            drawingInitialPosition = currentDrawing.initialPosition;
                            drawingFinalPosition = currentDrawing.finalPosition;

                            switch (currentDrawing)
                            {
                                case Ruler _:
                                    selectedDrawingToMove = new FreeDraw
                                    {
                                        points = new List<Point>((currentDrawing as Ruler).points)
                                    };

                                    break;
                                case Ellipse _:
                                    selectedDrawingToMove = new Ellipse();

                                    break;
                                case RectangleDraw _:
                                    selectedDrawingToMove = new RectangleDraw();

                                    break;
                                case Arrow _:
                                    selectedDrawingToMove = new Arrow();

                                    break;
                                case FreeDraw fd:
                                    selectedDrawingToMove = new FreeDraw
                                    {
                                        points = new List<Point>(fd.points)
                                    };

                                    pointsDifferenceFreeDrawing = new List<Point>();

                                    drawingInitialPosition = (selectedDrawingToMove as FreeDraw).points.First();
                                    List<Point> pointsSelectedDrawing = (selectedDrawingToMove as FreeDraw).points;

                                    for (int counter = 1; counter <= (selectedDrawingToMove as FreeDraw).points.Count - 1; counter++)
                                    {
                                        pointsDifferenceFreeDrawing.Add(new Point(pointsSelectedDrawing[counter].X - drawingInitialPosition.X, pointsSelectedDrawing[counter].Y - drawingInitialPosition.Y));
                                    }

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
                            selectedDrawingToMove.graphicsPath = currentDrawing.graphicsPath;
                            selectedDrawingToMove.drawingColor = currentDrawing.drawingColor;
                            selectedDrawingToMove.drawingSize = currentDrawing.drawingSize;
                            selectedDrawingToMove.initialPosition = new Point(currentDrawing.initialPosition.X, currentDrawing.initialPosition.Y);
                            selectedDrawingToMove.finalPosition = new Point(currentDrawing.finalPosition.X, currentDrawing.finalPosition.Y);

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
                                if ((currentDrawing as Ruler).points.Count > 1)
                                {
                                    currentDrawing.finalPosition = (currentDrawing as Ruler).points.Last();
                                }
                                else
                                {
                                    selectedDrawingHistory.Remove(selectedDrawingHistory.Last());
                                    indexSelectedDrawingHistory--;
                                    currentDrawing.finalPosition = currentDrawing.initialPosition;
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
                                        graphicsPath = new GraphicsPath(),
                                        initialPosition = e.Location,
                                        finalPosition = e.Location,
                                        points = new List<Point>(),
                                        lineLength = new List<float>(),
                                        drawingColor = drawingColor,
                                        drawingSize = 2,
                                        multiple = true
                                    };

                                    (currentDrawing as Ruler).points.Add(currentDrawing.initialPosition);
                                    (currentDrawing as Ruler).lineLength.Add(0);

                                    selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory])
                                    {
                                        currentDrawing
                                    });
                                    indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());

                                    rulerDrawed = true;
                                }
                                else
                                {
                                    (currentDrawing as Ruler).points.Add(currentDrawing.finalPosition);
                                    (currentDrawing as Ruler).lineLength.Add(getRulerLength());
                                    currentDrawing.initialPosition = currentDrawing.finalPosition;
                                }
                            }
                        }
                        else
                        {
                            currentDrawing = new Ruler
                            {
                                id = counterDrawings,
                                graphicsPath = new GraphicsPath(),
                                initialPosition = e.Location,
                                finalPosition = e.Location,
                                points = new List<Point>(),
                                lineLength = new List<float>(),
                                drawingColor = drawingColor,
                                drawingSize = 2,
                                multiple = false
                            };
                            (currentDrawing as Ruler).points.Add(currentDrawing.initialPosition);
                            (currentDrawing as Ruler).lineLength.Add(0);
                        }

                    break;

                    case 3:
                        currentDrawing = new FreeDraw
                        {
                            id = counterDrawings,
                            graphicsPath = new GraphicsPath(),
                            points = new List<Point>(),
                            drawingColor = drawingColor,
                            drawingSize = drawingSize
                        };

                        (currentDrawing as FreeDraw).points.Add(e.Location);

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
                                graphicsPath = new GraphicsPath(),
                                initialPosition = clickPosition,
                                text = textToDraw,
                                font = new Font("Arial", textDrawingPreviousSize),
                                brush = new SolidBrush(drawingColor),
                                drawingColor = drawingColor,
                                drawingSize = textDrawingPreviousSize
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
                            graphicsPath = new GraphicsPath(),
                            initialPosition = clickPosition,
                            finalPosition = clickPosition,
                            drawingColor = drawingColor,
                            drawingSize = drawingSize
                        };

                        break;

                    case 6:
                        currentDrawing = new Ellipse
                        {
                            id = counterDrawings,
                            graphicsPath = new GraphicsPath(),
                            initialPosition = clickPosition,
                            finalPosition = clickPosition,
                            drawingColor = drawingColor,
                            drawingSize = drawingSize
                        };

                        break;

                    case 7:
                        currentDrawing = new RectangleDraw
                        {
                            id = counterDrawings,
                            graphicsPath = new GraphicsPath(),
                            initialPosition = clickPosition,
                            finalPosition = clickPosition,
                            drawingColor = drawingColor,
                            drawingSize = drawingSize
                        };

                        break;
                }
            }
        }

        private void mainPictureBoxMouseMove(object sender, MouseEventArgs e)
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
                        selectedDrawingToMove.initialPosition = new Point(e.X + drawingInitialPosition.X - clickPosition.X, e.Y + drawingInitialPosition.Y - clickPosition.Y);
                        selectedDrawingToMove.finalPosition = new Point(e.X + drawingFinalPosition.X - clickPosition.X, e.Y + drawingFinalPosition.Y - clickPosition.Y);

                        if (currentDrawing is FreeDraw)
                        {
                            int counter = 1;
                            (selectedDrawingToMove as FreeDraw).points[0] = selectedDrawingToMove.initialPosition;
                            Point firstPoint = (selectedDrawingToMove as FreeDraw).points[0];

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
            if (action != 0)
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

                        if (recalibrate)
                        {
                            using (Form dialogRecalibrateRuler = new DialogRecalibrateRuler())
                            {
                                var result = dialogRecalibrateRuler.ShowDialog();
                                if (result == DialogResult.OK)
                                {
                                    recalibrateRuler((dialogRecalibrateRuler as DialogRecalibrateRuler).rulerValue);
                                    (currentDrawing as Ruler).lineLength = new List<float>
                                    {
                                        getRulerLength()
                                    };
                                }
                                recalibrate = false;
                            }
                        }
                        (currentDrawing as Ruler).points.Add(currentDrawing.finalPosition);
                    }
                    else if (action == 3)
                    {
                        if ((currentDrawing as FreeDraw).points.Count == 1)
                        {
                            (currentDrawing as FreeDraw).points.Add(new Point(e.X + 1, e.Y + 1));
                        }
                    }

                    selectedDrawingHistory.Add(new List<IDrawing>(selectedDrawingHistory[indexSelectedDrawingHistory])
                    {
                        currentDrawing
                    });
                    indexSelectedDrawingHistory = selectedDrawingHistory.IndexOf(selectedDrawingHistory.Last());
                    draw = false;
                    mainPictureBox.Invalidate();
                }
                selectedDrawingToMove = null;
                selectedDrawingHistoryHandler();
            }
        }

        private void mainPictureBoxPaint(object sender, PaintEventArgs e)
        {
            if (selectedDrawingHistory.Count > 0)
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
                    (currentDrawing as Ruler).lineLength[index] = getRulerLength();

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

        private void timerTick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            foreach (ExamImageModel item in examImages)
            {
                Frame frame = frames.FirstOrDefault(i => i.order == item.frameId);

                if (frame != null)
                {
                    item.notes = frame.notes;
                }
            }
            eventSaveExamImage?.Invoke(this, EventArgs.Empty);
            getDrawingsToSaveOnDatabase();
        }

        public void examViewClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = true;
            timerTick(this, EventArgs.Empty);
        }
    }
}