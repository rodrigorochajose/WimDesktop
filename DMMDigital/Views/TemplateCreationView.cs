using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DMMDigital.Components;
using DMMDigital.Models;
using DMMDigital.Interface.IView;
using System.Linq;
using DMMDigital.Properties;

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

        private enum EnumOrientation
        {
            verticalTop,
            verticalBottom,
            horizontalLeft,
            horizontalRight
        };

        private readonly Dictionary<EnumOrientation, string> dictOrientation = new Dictionary<EnumOrientation, string>
        {
            { EnumOrientation.verticalTop, Resources.textVerticalTop },
            { EnumOrientation.verticalBottom, Resources.textVerticalBottom },
            { EnumOrientation.horizontalLeft, Resources.textHorizontalLeft },
            { EnumOrientation.horizontalRight, Resources.textHorizontalRight }
        };

        public TemplateCreationView(string templateName, decimal rows, decimal columns, int orientation)
        {
            InitializeComponent();

            this.templateName = templateName;
            int height;
            int width;

            if (orientation < 2)
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

                if (templateFrame.orientation < 2)
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
            KeyPress += (s, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape)
                {
                    saveTemplate();
                }
            };

            buttonNewFrame.Click += delegate 
            { 
                createNewFrame(0, 50, 70, 0, 0); 
            };

            buttonDeleteFrame.Click += delegate 
            { 
                deleteFrame(); 
            };

            buttonSaveTemplate.Click += delegate 
            { 
                saveTemplate();
            };

            buttonRotateLeft.Click += delegate 
            { 
                rotateFrameLeft(); 
            };

            buttonRotateRight.Click += delegate 
            { 
                rotateFrameRight(); 
            };
        }

        private void saveTemplate()
        {
            DialogResult res = MessageBox.Show("Salvar Template", "Confirma salvar template?", MessageBoxButtons.YesNo);

            if (DialogResult.Yes.Equals(res))
            {
                eventSaveTemplate?.Invoke(this, EventArgs.Empty);
            }
        }

        private void createNewFrame(int orientation, int width, int height, int locationX, int locationY)
        {
            framesCounter++;
            FrameTemplate newFrame = new FrameTemplate
            {
                order = framesCounter,
                orientation = orientation,
                Width = width,
                Height = height,
                BackColor = Color.Black,
                Name = "frame" + framesCounter,
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
            textBoxOrientation.Text = dictOrientation[(EnumOrientation)selectedFrame.orientation];
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
                    case 0:
                        selectedFrame.orientation = 2;
                        break;

                    case 1:
                        selectedFrame.orientation = 3;
                        break;

                    case 2:
                        selectedFrame.orientation = 1;
                        break;

                    case 3:
                        selectedFrame.orientation = 0;
                        break;
                }

                (selectedFrame.Width, selectedFrame.Height) = (selectedFrame.Height, selectedFrame.Width);
                textBoxOrientation.Text = dictOrientation[(EnumOrientation)selectedFrame.orientation];
                selectedFrame.Refresh();
            }
        }

        private void rotateFrameRight()
        {
            if (selectedFrame != null)
            {
                switch (selectedFrame.orientation)
                {
                    case 0:
                        selectedFrame.orientation = 3;
                        break;

                    case 1:
                        selectedFrame.orientation = 2;
                        break;

                    case 2:
                        selectedFrame.orientation = 0;
                        break;

                    case 3:
                        selectedFrame.orientation = 1;
                        break;
                }

                (selectedFrame.Width, selectedFrame.Height) = (selectedFrame.Height, selectedFrame.Width);
                textBoxOrientation.Text = dictOrientation[(EnumOrientation)selectedFrame.orientation];
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

