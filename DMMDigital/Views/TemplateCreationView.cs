using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DMMDigital.Components;
using DMMDigital.Models;
using DMMDigital.Interface.IView;
using System.Linq;

namespace DMMDigital.Views
{
    public partial class TemplateCreationView : Form, ITemplateCreationView
    {
        public string templateName { get; set; }
        public List<FrameTemplate> framesList { get { return frames; } }

        public event EventHandler eventSaveTemplate;

        private int framesCounter = 0;
        private FrameTemplate selectedFrame;
        private List<FrameTemplate> frames = new List<FrameTemplate>();
        private bool dragging = false;
        private Point lastLocation;

        List<Point> horizontalTopPoints = new List<Point>();
        List<Point> horizontalBottomPoints = new List<Point>();
        List<Point> verticalTopPoints = new List<Point>();
        List<Point> verticalBottomPoints = new List<Point>();
        List<Point> midPoints = new List<Point>();

        public TemplateCreationView(string templateName, decimal rows, decimal columns, string orientation)
        {
            InitializeComponent();

            this.templateName = templateName;
            int height;
            int width;

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

            for (int rowsCounter = 0, locationY = 40; rowsCounter < rows; rowsCounter++, locationY += height + 10)
            {
                for (int columnsCounter = 0, locationX = 60; columnsCounter < columns; columnsCounter++, locationX += width + 10)
                {
                    createNewFrame(orientation, width, height, locationX, locationY);
                }
            }

            associateEvents();
        }

        public TemplateCreationView(string templateName, List<TemplateFrameModel> templateFrames)
        {
            InitializeComponent();
            this.templateName = templateName;

            foreach (TemplateFrameModel templateFrame in templateFrames)
            {
                int height;
                int width;

                if (templateFrame.orientation.Contains("Vertical"))
                {
                    height = 70;
                    width = 50;
                }
                else
                {
                    height = 50;
                    width = 70;
                }

                createNewFrame(
                    templateFrame.orientation,
                    width,
                    height,
                    templateFrame.locationX,
                    templateFrame.locationY
                );
            }

            associateEvents();
        }

        private void associateEvents()
        {
            buttonNewFrame.Click += delegate { createNewFrame("Vertical Cima", 50, 70, 0, 0); };
            buttonDeleteFrame.Click += delegate { deleteFrame(); };
            buttonSaveTemplate.Click += delegate { eventSaveTemplate?.Invoke(this, EventArgs.Empty); };
            buttonRotateLeft.Click += delegate { rotateFrameLeft(); };
            buttonRotateRight.Click += delegate { rotateFrameRight(); };
        }

        private void createNewFrame(string orientation, int width, int height, int locationX, int locationY)
        {
            framesCounter++;
            FrameTemplate newFrame = new FrameTemplate
            {
                order = framesCounter,
                orientation = orientation,
                Width = width,
                Height = height,
                BackColor = Color.Black,
                Name = "filme" + framesCounter,
                Location = new Point(locationX, locationY),
                Tag = Color.Black,
                topPoint = new Point(locationX, locationY),
                midPoint = new Point(locationX + (width / 2), locationY + (height / 2)),
                bottomRightPoint = new Point(locationX + width, locationY + height),
                bottomLeftPoint = new Point(locationX, locationY + height)
            };

            newFrame.MouseDown += frameMouseDown;
            newFrame.MouseMove += frameMouseMove;
            newFrame.MouseUp += frameMouseUp;
            panelTemplate.Controls.Add(newFrame);


            frames.Add(newFrame);
        }

        private void frameMouseDown(object sender, MouseEventArgs e)
        {
            FrameTemplate currentSelectedFrame = frames.Find(f => (Color)f.Tag == Color.LimeGreen);
            if (currentSelectedFrame != null)
            {
                currentSelectedFrame.Tag = Color.Black;
                currentSelectedFrame.Invalidate();
            }

            selectedFrame = (FrameTemplate)sender;
            textBoxSelectedFrame.Text = selectedFrame.Name;
            textBoxOrientation.Text = selectedFrame.orientation;
            selectedFrame.Tag = Color.LimeGreen;
            selectedFrame.Invalidate();

            dragging = true;
            lastLocation = e.Location;
        }

        private void frameMouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point newLocation = selectedFrame.Location;
                newLocation.X += (e.X - lastLocation.X) / 10 * 10;
                newLocation.Y += (e.Y - lastLocation.Y) / 10 * 10;

                selectedFrame.Location = newLocation;
                selectedFrame.topPoint = selectedFrame.Location;
                selectedFrame.midPoint = new Point(selectedFrame.Location.X + (selectedFrame.Width / 2), selectedFrame.Location.Y + (selectedFrame.Height / 2));
                selectedFrame.bottomRightPoint = new Point(selectedFrame.Location.X + selectedFrame.Width, selectedFrame.Location.Y + selectedFrame.Height);
                selectedFrame.bottomLeftPoint = new Point(selectedFrame.Location.X, selectedFrame.Location.Y + selectedFrame.Height);

                checkFramesAlignment();
            }
        }

        private void checkFramesAlignment()
        {
            horizontalTopPoints = new List<Point>();
            horizontalBottomPoints = new List<Point>();
            verticalTopPoints = new List<Point>();
            verticalBottomPoints = new List<Point>();
            midPoints = new List<Point>();

            List<FrameTemplate> notSelectedFrames = frames.Where(f => f != selectedFrame).ToList();

            foreach (FrameTemplate frame in notSelectedFrames)
            {
                if (frame.midPoint.Y == selectedFrame.midPoint.Y || frame.midPoint.X == selectedFrame.midPoint.X)
                {
                    midPoints.Add(frame.midPoint);
                }

                if (frame.topPoint.Y == selectedFrame.topPoint.Y)
                {
                    horizontalTopPoints.Add(frame.topPoint);
                }

                if (frame.bottomRightPoint.Y == selectedFrame.bottomRightPoint.Y)
                {
                    horizontalBottomPoints.Add(frame.bottomRightPoint);
                }

                if (frame.topPoint.X == selectedFrame.topPoint.X)
                {
                    verticalTopPoints.Add(frame.topPoint);
                }

                if (frame.bottomRightPoint.X == selectedFrame.bottomRightPoint.X)
                {
                    verticalBottomPoints.Add(frame.bottomRightPoint);
                }
            }
            panelTemplate.Refresh();
        }

        private void frameMouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
            panelTemplate.Refresh();
        }

        private void deleteFrame()
        {
            framesCounter--;
            framesList.Remove(selectedFrame);
            panelTemplate.Controls.Remove(selectedFrame);
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
                selectedFrame.Refresh();
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
                selectedFrame.Refresh();
            }
        }

        private void panelTemplatePaint(object sender, PaintEventArgs e)
        {
            if (dragging)
            {
                Pen pen = new Pen(Color.Orange, 1.75f);

                if (horizontalTopPoints.Any())
                {
                    horizontalTopPoints.ForEach(point => e.Graphics.DrawLine(pen, point, selectedFrame.Location));
                }

                if (horizontalBottomPoints.Any())
                {
                    horizontalBottomPoints.ForEach(point => e.Graphics.DrawLine(pen, point, selectedFrame.bottomLeftPoint));
                }

                if (verticalTopPoints.Any())
                {
                    verticalTopPoints.ForEach(point => e.Graphics.DrawLine(pen, point, selectedFrame.Location));
                }

                if (verticalBottomPoints.Any())
                {
                    verticalBottomPoints.ForEach(point => e.Graphics.DrawLine(pen, point, selectedFrame.bottomRightPoint));
                }

                if (midPoints.Any())
                {
                    midPoints.ForEach(point => e.Graphics.DrawLine(pen, point, selectedFrame.midPoint));
                }
            }
        }
    }
}

