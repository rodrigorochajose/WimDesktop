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

namespace DMMDigital
{
    public partial class ExamView : Form, IExamView
    {
        public string patientName { get; set; }
        public string templateName { get; set; }
        public string examPath { get; set; }
        public Frame selectedFrame { get; set; }

        public event EventHandler eventGetExamPath;
        public event EventHandler eventGetTextToDraw;

        int indexFrame = 0, patientId = 0, action = 0, drawingHistoryIndex = 0;
        List<Frame> frames = new List<Frame>();

        Pen pen = new Pen(Color.Red, 5);
        List<List<iDrawing>> drawingHistory = new List<List<iDrawing>>() { new List<iDrawing>() };
        List<Point> pointsDifferenceFreeDrawing = new List<Point>();
        Point clickPosition = new Point();
        Point drawingInitialPosition = new Point();
        Point drawingFinalPosition = new Point();
        iDrawing currentDrawing, selectedDrawingToMove;
        bool draw = false;

        public ExamView(PatientModel patient, List<TemplateFrameModel> templateFrames, string templateName, string sessionName)
        {
            InitializeComponent();

            patientId = patient.id;
            labelPatient.Text = patient.name;
            labelTemplate.Text = templateName;

            drawTemplate(templateFrames);
            selectedFrame = frames.First();

            eventGetExamPath?.Invoke(this, EventArgs.Empty);

            DirectoryInfo di = Directory.CreateDirectory(examPath + "\\Paciente-" + patientId + "\\" + sessionName + "_" + DateTime.Now.ToString("dd-MM-yyyy"));
            examPath = di.FullName;
        }
        public void loadImageOnMainFrame()
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

                enableTools();
            }
        }
        
        public void selectFrameToLoadImage()
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
            //m_nId = Detector.CreateDetector(this);
            //Detector d = Detector.DetectorList[m_nId];
            //d?.Connect();
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
            if (drawingHistoryIndex - 1 > -1)
            {
                drawingHistoryIndex--;
            }
            mainFrame.Invalidate();
        }

        private void buttonRedoClick(object sender, EventArgs e)
        {
            if (drawingHistoryIndex + 1 < drawingHistory.Count)
            {
                drawingHistoryIndex++;
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
                drawingHistory = new List<List<iDrawing>>() { new List<iDrawing>() };
                pointsDifferenceFreeDrawing = new List<Point>();
                clickPosition = new Point();
                drawingInitialPosition = new Point();
                drawingFinalPosition = new Point();
                currentDrawing = new Arrow();
                selectedDrawingToMove = new Arrow();
                drawingHistoryIndex = 0;
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

                        drawingHistory.Add(new List<iDrawing>(drawingHistory[drawingHistoryIndex]){ currentDrawing });
                        drawingHistoryIndex = drawingHistory.LastIndexOf(drawingHistory.Last());

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
                        draw = false;

                        currentDrawing = new Text
                        {
                            initialPosition = clickPosition,
                            text = getTextToDraw(),
                            font = new Font("Arial", 16),
                            brush = new SolidBrush(Color.Red),
                        };

                        drawingHistory.Add(new List<iDrawing>(drawingHistory[drawingHistoryIndex]){ currentDrawing });
                        drawingHistoryIndex = drawingHistory.LastIndexOf(drawingHistory.Last());

                        mainFrame.Invalidate();

                        break;
                    case 1:
                        currentDrawing = drawingHistory[drawingHistoryIndex].FirstOrDefault(d => d.graphicsPath.IsOutlineVisible(clickPosition, pen));

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
                                        points = (currentDrawing as FreeDraw).points,
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
                            selectedDrawingToMove.initialPosition = new Point(currentDrawing.initialPosition.X, currentDrawing.initialPosition.Y);
                            selectedDrawingToMove.finalPosition = new Point(currentDrawing.finalPosition.X, currentDrawing.finalPosition.Y);

                            drawingHistory.Add(new List<iDrawing>(drawingHistory[drawingHistoryIndex])
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
                        selectedDrawingToMove.initialPosition = new Point(e.X + drawingInitialPosition.X - clickPosition.X, e.Y + drawingInitialPosition.Y - clickPosition.Y);
                        selectedDrawingToMove.finalPosition = new Point(e.X + drawingFinalPosition.X - clickPosition.X, e.Y + drawingFinalPosition.Y - clickPosition.Y);

                        if (currentDrawing is FreeDraw)
                        {
                            Point firstPoint = (selectedDrawingToMove as FreeDraw).points.First();
                            int counter = 1;

                            (selectedDrawingToMove as FreeDraw).points[0] = new Point(e.X + drawingInitialPosition.X - clickPosition.X, e.Y + drawingInitialPosition.Y - clickPosition.Y);

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
                if (drawingHistoryIndex == 0)
                {
                    drawingHistory = new List<List<iDrawing>>() { new List<iDrawing>() };
                }

                if (action != 1 && action != 3)
                {
                    drawingHistory.Add(new List<iDrawing>(drawingHistory[drawingHistoryIndex]){
                            currentDrawing
                    });
                    drawingHistoryIndex = drawingHistory.LastIndexOf(drawingHistory.Last());

                }

                draw = false;
                mainFrame.Invalidate();
            }
        }

        private void mainFramePaint(object sender, PaintEventArgs e)
        {
            drawingHistory[drawingHistoryIndex].ForEach(d => d.draw(e.Graphics, pen));

            if (draw)
            {
                if (action == 3)
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;
                    selectedDrawingToMove?.drawPreview(e.Graphics, pen);
                }
                else
                {
                    currentDrawing.drawPreview(e.Graphics, pen);
                }
            }
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
    }
}
