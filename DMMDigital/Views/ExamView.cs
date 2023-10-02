using DMMDigital.Interface;
using DMMDigital.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DMMDigital.Views;
using Emgu.CV.OCR;

namespace DMMDigital
{
    public partial class ExamView : Form, IExamView
    {
        public string patientName { get; set; }
        public string templateName { get; set; }
        public string examPath { get; set; }
        public Frame selectedFrame { get; set; }

        public event EventHandler eventGetExamPath;
        public event EventHandler eventDrawStringOnGp;

        int patientId, counterDrawings = 0, indexFrame = 0, action = 0, drawingHistoryIndex = 0, textDrawingPreviousSize = 26, drawingPreviousSize = 5;
        List<Frame> frames = new List<Frame>();
        NumericUpDown numericUpDownDrawingSize = null;
        Button buttonColorPicker = null;
        PictureBox pictureBoxMagnifier = null;
        TrackBar trackBarZoom = null;

        Color drawingColor = Color.Red;
        float drawingSize = 5;
        List<List<IDrawing>> drawingHistory = new List<List<IDrawing>>() { new List<IDrawing>() };
        List<Point> pointsDifferenceFreeDrawing = new List<Point>();
        Point clickPosition = new Point();
        Point drawingInitialPosition = new Point();
        Point drawingFinalPosition = new Point();
        IDrawing currentDrawing, selectedDrawingToMove;
        bool draw = false;

        public ExamView(PatientModel patient, List<TemplateFrameModel> templateFrames, string templateName, string sessionName)
        {
            InitializeComponent();
            ActiveControl = label1;

            patientId = patient.id;
            labelPatient.Text = patient.name;
            labelTemplate.Text = templateName;

            drawTemplate(templateFrames);
            Load += delegate
            {
                eventGetExamPath?.Invoke(this, EventArgs.Empty);
                DirectoryInfo di = Directory.CreateDirectory(examPath + "\\Paciente-" + patientId + "\\" + sessionName + "_" + DateTime.Now.ToString("dd-MM-yyyy"));
                examPath = di.FullName;
            };
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
                    Tag = Color.Black
                };

                if (newFrame.order == 1)
                {
                    newFrame.Tag = Color.LimeGreen;
                    selectedFrame = newFrame;
                }

                newFrame.Image = drawFrameImage(newFrame);
                newFrame.Location = new Point(frame.locationX / 2, frame.locationY / 2);
                newFrame.DoubleClick += frameDoubleClick;
                newFrame.Paint += framePaint;

                frames.Add(newFrame);
                panelTemplate.Controls.Add(newFrame);
            }
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

        private void frameHandler()
        {
            labelImageDate.Invoke((MethodInvoker)(() => labelImageDate.Text = selectedFrame.datePhotoTook));
            textBoxFrameNotes.Invoke((MethodInvoker)(() => textBoxFrameNotes.Text = selectedFrame.notes));

            selectedFrame.Tag = Color.Black;
            selectedFrame.Invoke((MethodInvoker)(() => selectedFrame.Refresh()));

            indexFrame++;
            selectedFrame = frames[indexFrame];
            selectedFrame.Tag = Color.LimeGreen;

            selectedFrame.Invoke((MethodInvoker)(() => selectedFrame.Refresh()));
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

            if (selectedFrame.photoTook == true)
            {
                using (FileStream fs = File.Open(Path.Combine(examPath, selectedFrame.order + "-radiografia.png"), FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
                {
                    mainPictureBox.Image = Image.FromStream(fs);
                }
            }
        }

        public void deleteCurrentImageToReplace()
        {
            DialogResult res = MessageBox.Show("Confirma sobreescrever a imagem atual ?", "Sobrescrever Imagem", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) { return; }
            selectedFrame.Image = null;
            mainPictureBox.Image = null;
            File.Delete(Path.Combine(examPath, selectedFrame.order + "-radiografia.png"));
        }

        public void loadImageOnMainPictureBox()
        {
            using (FileStream fs = File.Open(Path.Combine(examPath, selectedFrame.order + "-radiografia.png"), FileMode.Open, FileAccess.ReadWrite, FileShare.Delete))
            {
                Image image = Image.FromStream(fs);
                mainPictureBox.Image = image;
                generateImageThumbnail(image.Clone() as Image);
                resizeMainPictureBox();
                frameHandler();
                enableTools();
            }
        }

        public void resizeMainPictureBox()
        {
            Size rectangleSize;
            if (mainPictureBox.Width < mainPictureBox.Height)
            {
                rectangleSize = new Size(
                    mainPictureBox.Width,
                    mainPictureBox.Width * mainPictureBox.Image.Height / mainPictureBox.Image.Width
                );
            }
            else
            {
                rectangleSize = new Size(
                    mainPictureBox.Height * mainPictureBox.Image.Width / mainPictureBox.Image.Height,
                    mainPictureBox.Height
                );
            }

            mainPictureBox.Size = rectangleSize;
            mainPictureBox.Location = new Point((panel2.Width - mainPictureBox.Width) / 2, 0);
        }

        private void enableTools()
        {
            foreach (Button tool in panelTools.Controls.OfType<Button>())
            {
                tool.Invoke((MethodInvoker)(() => tool.Enabled = true));
            }
        }

        private void selectTool(object sender)
        {
            Button selectedButton = panelTools.Controls.OfType<Button>().Where(b => b.Tag != null && (string)b.Tag == "selected").FirstOrDefault();
            if (selectedButton != null)
            {
                if (selectedButton.Name == "buttonZoom")
                {
                    panel2.Controls.Remove(pictureBoxMagnifier);
                }
                selectedButton.BackColor = Color.WhiteSmoke;
                selectedButton.Tag = "selectable";
            }
            (sender as Control).BackColor = Color.LightGray;
            (sender as Control).Tag = "selected";
        }

        private void loadToolOptions()
        {
            panelToolOptions.Controls.Clear();
            switch (action)
            {
                case 2:
                    // regua

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

            //    if (action == 4)
            //    {
            //        drawingPreviousSize = (int)numericUpDownDrawingSize.Value;
            //        numericUpDownDrawingSize.Value = textDrawingPreviousSize;
            //    } 
            //    else if ((string)buttonText.Tag == "selected") // verify if the "last" selected tool was DrawText tool
            //    {
            //        textDrawingPreviousSize = (int)numericUpDownDrawingSize.Value;
            //        numericUpDownDrawingSize.Value = drawingPreviousSize;
            //    }

        }

        private void generateControlDrawingOption()
        {
            int value;
            if (action == 4)
            {
                value = textDrawingPreviousSize;
            }
            else
            {
                value = drawingPreviousSize;
            }

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
                BackColor = Color.Red,
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

        private void verifyHistoryToReset()
        {
            if (drawingHistoryIndex == 0)
            {
                drawingHistory = new List<List<IDrawing>>() { new List<IDrawing>() };
            }
        }

        private void numericUpDownDrawingSizeValueChanged(object sender, EventArgs e)
        {
            drawingSize = (int)numericUpDownDrawingSize.Value;
        }

        private void deleteDrawingOnHistory(int drawingId)
        {
            drawingHistory.Add(new List<IDrawing>(drawingHistory[drawingHistoryIndex]));
            drawingHistoryIndex = drawingHistory.LastIndexOf(drawingHistory.Last());

            IDrawing drawingToRemove = drawingHistory[drawingHistoryIndex].Where(drawing => drawing.id == drawingId).First();
            drawingHistory[drawingHistoryIndex].Remove(drawingToRemove);

            drawingHistoryHandler();
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
                Text = "testando"
            };

            pictureBox.Image = drawing.generateDrawingImageAndThumb(mainPictureBox.Width, mainPictureBox.Height);
            button.Click += delegate { deleteDrawingOnHistory(drawing.id); };

            panel.Controls.Add(button);
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(panel);
            flowLayoutPanel1.ScrollControlIntoView(panel);
        }

        private void drawingHistoryHandler()
        {
            flowLayoutPanel1.Controls.Clear();
            drawingHistory[drawingHistoryIndex].ForEach(d => showDrawingHistory(d));
        }

        private void generateImageThumbnail(Image currentImage)
        {
            selectedFrame.photoTook = true;
            selectedFrame.Image = currentImage.GetThumbnailImage(selectedFrame.Width, selectedFrame.Height, () => false, IntPtr.Zero);
        }

        private void buttonImportClick(object sender, EventArgs e)
        {
            DialogResult result;
            if (selectedFrame.photoTook == true)
            {
                result = MessageBox.Show("Deseja sobreescrever a imagem atual ?", "Sobrescrever Imagem", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) { return; }

            }

            result = dialogFileImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                Image selectedImage = Image.FromStream(dialogFileImage.OpenFile());
                mainPictureBox.Image = selectedImage;

                generateImageThumbnail(selectedImage.Clone() as Image);
                selectedImage.Save(Path.Combine(examPath, selectedFrame.order + "-radiografia.png"));

                frameHandler();

                enableTools();
            }

            resizeMainPictureBox();
        }

        private void buttonExportClick(object sender, EventArgs e)
        {

        }

        private void buttonDeleteClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja excluir a imagem atual ?", "Excluir Imagem", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                File.Delete(Path.Combine(examPath, selectedFrame.order + "-radiografia.png"));
                selectedFrame.Image = drawFrameImage(selectedFrame);
                mainPictureBox.Image = null;
            }
        }

        private void buttonCompareClick(object sender, EventArgs e)
        {
            selectTool(sender);
        }

        private void buttonSelectClick(object sender, EventArgs e)
        {
            panelToolOptions.Visible = false;
            selectTool(sender);
            action = 0;
        }

        private void buttonMoveClick(object sender, EventArgs e)
        {
            panelToolOptions.Controls.Clear();
            selectTool(sender);
            action = 1;
        }

        private void buttonZoomClick(object sender, EventArgs e)
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
            selectTool(sender);
            action = 2;
        }

        private void buttonUndoClick(object sender, EventArgs e)
        {
            if (drawingHistoryIndex - 1 > -1)
            {
                drawingHistoryIndex--;
                mainPictureBox.Invalidate();
                drawingHistoryHandler();
            }
        }

        private void buttonRedoClick(object sender, EventArgs e)
        {
            if (drawingHistoryIndex + 1 < drawingHistory.Count)
            {
                drawingHistoryIndex++;
                mainPictureBox.Invalidate();
                drawingHistoryHandler();
            }
        }

        private void buttonFilterClick(object sender, EventArgs e)
        {
            selectTool(sender);
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

        private void buttonRestoreClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja restaurar a imagem original ?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                drawingHistory = new List<List<IDrawing>>() { new List<IDrawing>() };
                pointsDifferenceFreeDrawing = new List<Point>();
                clickPosition = new Point();
                drawingInitialPosition = new Point();
                drawingFinalPosition = new Point();
                currentDrawing = new Ellipse();
                selectedDrawingToMove = new Ellipse();
                drawingHistoryIndex = 0;
                action = 0;
                flowLayoutPanel1.Controls.Clear();
                mainPictureBox.Invalidate();
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
                                font = new Font("Arial", drawingSize),
                                brush = new SolidBrush(drawingColor),
                                drawingColor = drawingColor,
                                drawingSize = drawingSize
                            };

                            drawingHistory.Add(new List<IDrawing>(drawingHistory[drawingHistoryIndex]) { currentDrawing });
                            drawingHistoryIndex = drawingHistory.LastIndexOf(drawingHistory.Last());

                            mainPictureBox.Invalidate();
                            drawingHistoryHandler();
                        }


                        break;
                    case 1:
                        currentDrawing = drawingHistory[drawingHistoryIndex].FirstOrDefault(d => d.graphicsPath.IsOutlineVisible(clickPosition, new Pen(Color.Red, 5)));
                        if (currentDrawing != null)
                        {
                            drawingInitialPosition = currentDrawing.initialPosition;
                            drawingFinalPosition = currentDrawing.finalPosition;

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
                                case FreeDraw fd:
                                    selectedDrawingToMove = new FreeDraw
                                    {
                                        points = new List<Point>((currentDrawing as FreeDraw).points)
                                    };

                                    pointsDifferenceFreeDrawing = new List<Point>();

                                    drawingInitialPosition = (selectedDrawingToMove as FreeDraw).points.First();
                                    List<Point> pointsSelectedDrawing = (selectedDrawingToMove as FreeDraw).points;

                                    for (int counter = 1; counter <= (selectedDrawingToMove as FreeDraw).points.Count - 1; counter++)
                                    {
                                        pointsDifferenceFreeDrawing.Add(new Point(pointsSelectedDrawing[counter].X - drawingInitialPosition.X, pointsSelectedDrawing[counter].Y - drawingInitialPosition.Y));
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
                            selectedDrawingToMove.id = currentDrawing.id;
                            selectedDrawingToMove.graphicsPath = currentDrawing.graphicsPath;
                            selectedDrawingToMove.drawingColor = currentDrawing.drawingColor;
                            selectedDrawingToMove.drawingSize = currentDrawing.drawingSize;
                            selectedDrawingToMove.initialPosition = new Point(currentDrawing.initialPosition.X, currentDrawing.initialPosition.Y);
                            selectedDrawingToMove.finalPosition = new Point(currentDrawing.finalPosition.X, currentDrawing.finalPosition.Y);

                            drawingHistory.Add(new List<IDrawing>(drawingHistory[drawingHistoryIndex])
                            {
                                selectedDrawingToMove
                            });
                            drawingHistoryIndex = drawingHistory.LastIndexOf(drawingHistory.Last());
                            drawingHistory[drawingHistoryIndex].Remove(currentDrawing);
                        }
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
                (e.Y * mainPictureBox.Image.Height / mainPictureBox.Height) - rectangleHeight / 2
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
                if (action != 1)
                {
                    verifyHistoryToReset();

                    if (action == 3)
                    {
                        if ((currentDrawing as FreeDraw).points.Count == 1)
                        {
                            (currentDrawing as FreeDraw).points.Add(new Point(e.X + 1, e.Y + 1));
                        }
                    }

                    drawingHistory.Add(new List<IDrawing>(drawingHistory[drawingHistoryIndex]){
                            currentDrawing
                    });
                    drawingHistoryIndex = drawingHistory.LastIndexOf(drawingHistory.Last());
                }
                selectedDrawingToMove = null;
                drawingHistoryHandler();

                draw = false;
                mainPictureBox.Invalidate();
            }
        }

        private void mainPictureBoxPaint(object sender, PaintEventArgs e)
        {
            drawingHistory[drawingHistoryIndex].ForEach(d => d.draw(e.Graphics));

            if (draw && currentDrawing != null && action != 1)
            {
                currentDrawing.draw(e.Graphics);
            }
        }
    }
}
