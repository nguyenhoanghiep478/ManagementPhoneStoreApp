using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ManagementPhoneStore
{
    public partial class ImeiScannerDialog : Form
    {
        private VideoCaptureDevice videoSource;
        private DateTime lastFrameTime = DateTime.MinValue;
        public string IMEI { get; private set; } 
        public ImeiScannerDialog()
        {
            InitializeComponent();
        }

        private void ImeiScannerDialog_Load(object sender, EventArgs e)
        {
            try
            {
              
                FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy camera trên máy tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Mở camera mặc định
                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động camera: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private Bitmap ConvertToGrayscale(Bitmap original)
{
    Bitmap grayscaleImage = new Bitmap(original.Width, original.Height);
    using (Graphics g = Graphics.FromImage(grayscaleImage))
    {
        var colorMatrix = new System.Drawing.Imaging.ColorMatrix(new float[][]
        {
            new float[] {0.3f, 0.3f, 0.3f, 0, 0},
            new float[] {0.59f, 0.59f, 0.59f, 0, 0},
            new float[] {0.11f, 0.11f, 0.11f, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
        });
        var attributes = new System.Drawing.Imaging.ImageAttributes();
        attributes.SetColorMatrix(colorMatrix);
        g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
            0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
    }
    return grayscaleImage;
}
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
               
                if ((DateTime.Now - lastFrameTime).TotalMilliseconds < 1000)
                    return;
                lastFrameTime = DateTime.Now;

                Bitmap originalBitmap = (Bitmap)eventArgs.Frame.Clone();
                Bitmap bitmapForDecoding = new Bitmap(originalBitmap);

                pictureBoxVideo.Invoke(new MethodInvoker(() =>
                {
                    pictureBoxVideo.Image?.Dispose();
                    pictureBoxVideo.Image = originalBitmap;
                }));

                Task.Run(() =>
                {
                    try
                    {
                        ZXing.BarcodeReader reader = new ZXing.BarcodeReader
                        {
                            AutoRotate = true,
                            Options = new ZXing.Common.DecodingOptions
                            {
                                TryHarder = true,
                                TryInverted = true
                            }
                        };

                        var result = reader.Decode(bitmapForDecoding);

                        if (result != null)
                        {
                            Invoke(new MethodInvoker(() =>
                            {
                                IMEI = result.Text;
                                this.DialogResult = DialogResult.OK;
                                this.StopCamera();
                                this.Close();
                            }));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi trong xử lý mã QR: {ex.Message}");
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong VideoSource_NewFrame: {ex.Message}");
            }
        }
        private void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource = null;
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            StopCamera();
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
        private void IMEIScannerDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera(); 
        }

        private void pictureBoxVideo_Click(object sender, EventArgs e)
        {

        }
    }
}
