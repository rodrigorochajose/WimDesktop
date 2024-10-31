using NTwain;
using NTwain.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace DMMDigital.Views
{
    public partial class Form1 : Form
    {
        private TwainSession _twain;
        private bool _stopScan;
        private List<Image> _capturedImages;

        public Form1()
        {
            InitializeComponent();
            SetupTwain();
            _capturedImages = new List<Image>();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            CleanupTwain();
            base.OnFormClosing(e);
        }

        private void SetupTwain()
        {
            var appId = TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetEntryAssembly());
            _twain = new TwainSession(appId);
            _twain.StateChanged += (s, e) =>
            {
                Console.WriteLine("State changed to " + _twain.State);
            };
            _twain.DataTransferred += (s, e) =>
            {
                Image img = null;
                if (e.NativeData != IntPtr.Zero)
                {
                    var stream = e.GetNativeImageStream();
                    if (stream != null)
                    {
                        img = Image.FromStream(stream);
                    }
                }
                else if (!string.IsNullOrEmpty(e.FileDataPath))
                {
                    img = new Bitmap(e.FileDataPath);
                }
                if (img != null)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        _capturedImages.Add(img);
                        var pictureBox = new PictureBox
                        {
                            Image = img,
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Width = 200,
                            Height = 200,
                            Margin = new Padding(5)
                        };
                        flowLayoutPanel1.Controls.Add(pictureBox);
                    }));
                }
            };
            _twain.SourceDisabled += (s, e) =>
            {
                this.BeginInvoke(new Action(() =>
                {
                    btnStartCapture.Enabled = true;
                    btnStopScan.Enabled = false;
                }));
            };
            _twain.TransferReady += (s, e) =>
            {
                e.CancelAll = _stopScan;
            };

            _twain.SynchronizationContext = SynchronizationContext.Current;
            if (_twain.State < 3)
            {
                _twain.Open();
            }
        }

        private void CleanupTwain()
        {
            if (_twain.State == 4)
            {
                _twain.CurrentSource.Close();
            }
            if (_twain.State == 3)
            {
                _twain.Close();
            }
            if (_twain.State > 2)
            {
                _twain.ForceStepDown(2);
            }
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            if (_twain.State == 3)
            {
                DataSource myDS = _twain.Last();
                myDS.Open();
            }

            if (_twain.State == 4)
            {
                _stopScan = false;
                Console.WriteLine("Starting capture...");
                //if (_twain.CurrentSource.Capabilities.CapUIControllable.IsSupported)
                //{
                //    // Attempt to start capture without UI
                //    if (_twain.CurrentSource.Enable(SourceEnableMode.NoUI, false, this.Handle) == ReturnCode.Success)
                //    {
                //        Console.WriteLine("Capture started without UI.");
                //        btnStartCapture.Enabled = false;
                //        btnStopScan.Enabled = true;
                //    }
                //    else
                //    {
                //        Console.WriteLine("Failed to start capture without UI. Trying with UI.");
                //        // Fallback to starting capture with UI
                //        if (_twain.CurrentSource.Enable(SourceEnableMode.ShowUI, true, this.Handle) == ReturnCode.Success)
                //        {
                //            Console.WriteLine("Capture started with UI.");
                //            btnStartCapture.Enabled = false;
                //            btnStopScan.Enabled = true;
                //        }
                //    }
                //}
                //else
                //{
                // Start capture with UI
                if (_twain.CurrentSource.Enable(SourceEnableMode.ShowUI, true, this.Handle) == ReturnCode.Success)
                {
                    Console.WriteLine("Capture started with UI.");
                    btnStartCapture.Enabled = false;
                    btnStopScan.Enabled = true;
                }
                //}
            }
            else
            {
                Console.WriteLine("TWAIN state is not ready for capture.");
            }
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            _stopScan = true;
        }
    }
}