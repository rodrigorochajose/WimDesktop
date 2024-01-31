using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DMMDigital.Components;
using DMMDigital.Models;

namespace DMMDigital.Views
{
    public partial class TemplateHandlerView : Form, ITemplateHandlerView
    {
        public string templateName { get; set; }
        public IList<Frame> framesList { get { return frames; } }

        public event EventHandler eventSaveTemplate;

        int framesCounter = 0;
        Frame selectedFrame;
        List<Frame> frames = new List<Frame>();

        public TemplateHandlerView(string templateName, decimal rows, decimal columns, string orientation, List<TemplateFrameModel> templateFrames)
        {
            InitializeComponent();


            Console.WriteLine(templateFrames);

            this.templateName = templateName;
            int height, width;

            if (orientation.Contains("Vertical"))
            {
                height = 70;
                width = 50;
            }
            else
            {
                height = 50;
                width = 70;
            }

            for (int rowsCounter = 0, locationY = 50; rowsCounter < rows; rowsCounter++, locationY += height + 10)
            {
                for (int columnsCounter = 0, locationX = 70; columnsCounter < columns; columnsCounter++, locationX += width + 10)
                {
                    createNewFrame(orientation, width, height, locationX, locationY);
                }
            }

            buttonNewFrame.Click += delegate { createNewFrame(orientation, width, height, 0, 0); };
            buttonDeleteFrame.Click += delegate { deleteFrame(); };
            buttonSaveTemplate.Click += delegate { eventSaveTemplate?.Invoke(this, EventArgs.Empty); };
            buttonRotateLeft.Click += delegate { rotateFrameLeft(); };
            buttonRotateRight.Click += delegate { rotateFrameRight(); };
        }

        private void createNewFrame(string orientation, int width, int height, int locationX, int locationY)
        {
            framesCounter++;
            Frame newFrame = new Frame
            {
                order = framesCounter,
                orientation = orientation,
                Width = width,
                Height = height,
                BackColor = Color.Black,
                Name = "filme" + framesCounter,
                Location = new Point(locationX, locationY),
                Tag = Color.Black,
            };

            newFrame.MouseDown += selectFrame;
            newFrame.Paint += paintFrameBorder;
            newFrame = drawImage(newFrame);
            panel2.Controls.Add(newFrame);
            frames.Add(newFrame);
            ControlExtension.Draggable(newFrame, true);
        }

        private Frame drawImage(Frame frame)
        {
            Bitmap image = new Bitmap(frame.Width, frame.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawString(frame.order.ToString(), new Font("TimesNewRoman", 20, FontStyle.Bold, GraphicsUnit.Pixel), Brushes.White, new Point(0, 0));
            frame.Image = image;
            return frame;
        }

        private void selectFrame(object sender, EventArgs e)
        {
            Frame currentSelectedFrame = frames.Find(f => (Color)f.Tag == Color.LimeGreen);
            if (currentSelectedFrame != null)
            {
                currentSelectedFrame.Tag = Color.Black;
                currentSelectedFrame.Invalidate();
            }

            selectedFrame = (Frame)sender;
            textBoxSelectedFrame.Text = selectedFrame.Name;
            textBoxOrientation.Text = selectedFrame.orientation;
            selectedFrame.Tag = Color.LimeGreen;
            selectedFrame.Invalidate();
        }

        private void paintFrameBorder(object sender, PaintEventArgs e)
        {
            Frame frame = sender as Frame;
            if ((Color)frame.Tag == Color.Black) 
            { 
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, ButtonBorderStyle.None);
            } 
            else
            {
                ControlPaint.DrawBorder(e.Graphics, frame.ClientRectangle, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid, (Color)frame.Tag, 3, ButtonBorderStyle.Solid);
            }
        }

        private void deleteFrame()
        {
            framesCounter--;
            framesList.Remove(selectedFrame);
            panel2.Controls.Remove(selectedFrame);
            textBoxSelectedFrame.Text = "";
            textBoxOrientation.Text = "";
        }

        private void rotateFrameLeft()
        {
            if (selectedFrame != null)
            {
                switch (selectedFrame.orientation)
                {
                    case "Vertical Cima":
                        selectedFrame.orientation = "Horizontal Esquerda";
                        break;

                    case "Horizontal Esquerda":
                        selectedFrame.orientation = "Vertical Baixo";
                        break;

                    case "Vertical Baixo":
                        selectedFrame.orientation = "Horizontal Direita";
                        break;

                    case "Horizontal Direita":
                        selectedFrame.orientation = "Vertical Cima";
                        break;
                }

                (selectedFrame.Width, selectedFrame.Height) = (selectedFrame.Height, selectedFrame.Width);
                textBoxOrientation.Text = selectedFrame.orientation;
                drawImage(selectedFrame);
            }
        }

        private void rotateFrameRight()
        {
            if (selectedFrame != null)
            {
                switch (selectedFrame.orientation)
                {
                    case "Vertical Cima":
                        selectedFrame.orientation = "Horizontal Direita";
                        break;

                    case "Horizontal Esquerda":
                        selectedFrame.orientation = "Vertical Cima";
                        break;

                    case "Vertical Baixo":
                        selectedFrame.orientation = "Horizontal Esquerda";
                        break;

                    case "Horizontal Direita":
                        selectedFrame.orientation = "Vertical Baixo";
                        break;
                }

                (selectedFrame.Width, selectedFrame.Height) = (selectedFrame.Height, selectedFrame.Width);
                textBoxOrientation.Text = selectedFrame.orientation;
                drawImage(selectedFrame);
            }
        }
    }
}

