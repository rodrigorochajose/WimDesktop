using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class CompareFrames : Form
    {
        public List<Image> selectedImages { get; set; }
        public string compareMode { get; set; }

        public CompareFrames()
        {
            InitializeComponent();
        }

        private void buttonCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBackClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
            Close();
        }

        private void compareFramesLoad(object sender, EventArgs e)
        {
            tableLayoutPanel1.SuspendLayout();

            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            List<Image> horizontalImages = new List<Image>();
            List<Image> verticalImages = new List<Image>();

            if (compareMode.Contains("Multipla"))
            {
                foreach (Image img in selectedImages)
                {
                    if (img.Width > img.Height)
                    {
                        horizontalImages.Add(img);
                    }
                    else
                    {
                        verticalImages.Add(img);
                    }
                }

                int horizontalColumns = (int)Math.Ceiling((float)horizontalImages.Count / 3);
                int verticalColumns = (int)Math.Ceiling((float)verticalImages.Count / 2);

                tableLayoutPanel1.ColumnStyles.Clear();
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (100 / horizontalColumns + verticalColumns) * horizontalColumns));
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (100 / horizontalColumns + verticalColumns) * verticalColumns));
                tableLayoutPanel1.ColumnCount = 2;


                if (horizontalColumns > 0)
                {
                    TableLayoutPanel tableHorizontalFrames = new TableLayoutPanel
                    {
                        ColumnCount = horizontalColumns,
                        Dock = DockStyle.Fill,
                        Name = "horizontalTableLayoutPanel1",
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                        Margin = new Padding(0)
                    };

                    tableLayoutPanel1.Controls.Add(tableHorizontalFrames, 0, 0);

                    for (int columnCounter = 0; columnCounter < horizontalColumns; columnCounter++)
                    {
                        int pbInserted = 0;

                        tableHorizontalFrames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableHorizontalFrames.Width / horizontalColumns));

                        TableLayoutPanel tableColumn = new TableLayoutPanel
                        {
                            ColumnCount = 1,
                            Dock = DockStyle.Fill,
                            Name = "horizontalTableLayoutPanel1",
                            CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                            Margin = new Padding(0)
                        };

                        tableHorizontalFrames.Controls.Add(tableColumn, columnCounter, 0);

                        for (int rowCounter = 0; rowCounter < horizontalImages.Count; rowCounter++)
                        {
                            if (pbInserted == 3)
                            {
                                horizontalImages.RemoveRange(0, 3);
                                break;
                            }
                            else
                            {
                                PictureBox pb = new PictureBox
                                {
                                    Image = horizontalImages[rowCounter],
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Dock = DockStyle.Fill,
                                };
                                pbInserted++;

                                tableColumn.RowStyles.Add(new RowStyle(SizeType.Percent));
                                tableColumn.RowCount++;
                                tableColumn.Controls.Add(pb, 0, rowCounter);
                            }
                        }

                        for (int counter = 0; counter < pbInserted; counter++)
                        {
                            tableColumn.RowStyles[counter] = new RowStyle(SizeType.Percent, tableColumn.Height / pbInserted);
                        }
                    }
                }


                if (verticalColumns > 0)
                {
                    TableLayoutPanel tableVerticalFrames = new TableLayoutPanel
                    {
                        ColumnCount = verticalColumns,
                        Dock = DockStyle.Fill,
                        Name = "tableVerticalFramesLayoutPanel1",
                        CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                        Margin = new Padding(0)
                    };

                    tableLayoutPanel1.Controls.Add(tableVerticalFrames, 1, 0);


                    for (int columnCounter = 0; columnCounter < verticalColumns; columnCounter++)
                    {
                        int pbInserted = 0;
                        tableVerticalFrames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableVerticalFrames.Width / verticalColumns));

                        TableLayoutPanel tableColumn = new TableLayoutPanel
                        {
                            ColumnCount = 1,
                            Dock = DockStyle.Fill,
                            Name = "tableColumn" + columnCounter,
                            CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                            Margin = new Padding(0)
                        };

                        tableVerticalFrames.Controls.Add(tableColumn, columnCounter, 0);

                        for (int rowCounter = 0; rowCounter < verticalImages.Count; rowCounter++)
                        {
                            if (pbInserted == 2)
                            {
                                verticalImages.RemoveRange(0, 2);
                                break;
                            }
                            else
                            {
                                PictureBox pb = new PictureBox
                                {
                                    Image = verticalImages[rowCounter],
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Dock = DockStyle.Fill,
                                };
                                pbInserted++;

                                tableColumn.RowStyles.Add(new RowStyle(SizeType.Percent));
                                tableColumn.RowCount++;
                                tableColumn.Controls.Add(pb, 0, rowCounter);
                            }
                        }

                        for (int counter = 0; counter < pbInserted; counter++)
                        {
                            tableColumn.RowStyles[counter] = new RowStyle(SizeType.Percent, tableColumn.Height / pbInserted);
                        }
                    }
                }
            }
            else
            {
                for (int counter = 0; counter < selectedImages.Count; counter++)
                {
                    PictureBox pb = new PictureBox
                    {
                        Image = selectedImages[counter],
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Dock = DockStyle.Fill
                    };

                    if (compareMode.Contains("Vertical"))
                    {
                        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, tableLayoutPanel1.Width / selectedImages.Count));
                        tableLayoutPanel1.ColumnCount++;
                        tableLayoutPanel1.Controls.Add(pb, counter, 0);
                    }
                    else
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, tableLayoutPanel1.Height / selectedImages.Count));
                        tableLayoutPanel1.RowCount++;
                        tableLayoutPanel1.Controls.Add(pb, 0, counter);
                    }

                }
            }
            tableLayoutPanel1.ResumeLayout();
        }
    }
}

