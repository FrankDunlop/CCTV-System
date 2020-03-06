using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace DVR.Devices
{
    public class IPDevice : Camera
    {
        Thread _getFramesThread = null;
        bool _captureFrames = false;
        Bitmap _bitmapFromStream;
        
        public override void InitCamera()
        {
            WebCameraButton.Enabled = false;
            IPCam_Select camSelect = new IPCam_Select();
            camSelect.ShowDialog();
            Url = camSelect.GetUrl;
            Username = camSelect.GetUser;
            Password = camSelect.GetPass;
        }

        public override bool IsGetFramesThreadRunning()
        {
            return _getFramesThread.IsAlive;
        }

        public override void StartDevice()
        {
            if (_getFramesThread == null)
            {
                Connected = true;
                _getFramesThread = new Thread(GetFrames)
                {
                    Name = CamNum.ToString()
                };
                _captureFrames = true;
                _getFramesThread.Start();
            }
        }

        public override void StopDevice(string message)
        {
            RaiseStopCameraEvent(this, message);
            _captureFrames = false;
            //_getFramesThread.Abort();
            //_getFramesThread.Suspend();
            Console.Out.WriteLine(message);
            Connected = false;
        }

        private void GetFrames()
        {   
            bool alt = false;
            bool errorConnecting = false;
   
            while (_captureFrames)
            {
                try
                {
                    if (errorConnecting)
                    {
                        Bitmap staticScreen = new Bitmap(320, 240);
                        Graphics flagGraphics = Graphics.FromImage(staticScreen);
                        int black = 0;
                        int blue = 5;

                        while (blue <= 240)
                        {
                            flagGraphics.FillRectangle(Brushes.Black, 0, (alt ? blue : black), 320, 5);
                            flagGraphics.FillRectangle(Brushes.Navy, 0, (alt ? black : blue), 320, 5);
                            black += 10;
                            blue += 10;
                        }
                        alt = !alt;
                        RaiseFrameCapturedEvent(new CameraEventArgs(this, staticScreen));
                    }
                    else
                    {
                        byte[] buffer = new byte[100000];
                        int read = 0;
                        int total = 0;
                        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
                        WebResponse resp = null;

                        if ((Username != string.Empty) && (Password != string.Empty))
                        {
                            req.Credentials = new NetworkCredential(Username, Password);
                        }

                        try
                        {
                            resp = req.GetResponse();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show($"Error Connecting to Camera {CamNum} {ex.Message}");
                            Console.Out.WriteLine("Exception: IPDevice.GetFrames Cam{0} :{1}", CamNum, ex.Message);
                            errorConnecting = true;
                        }

                        Stream stream = resp.GetResponseStream();

                        while ((read = stream.Read(buffer, total, 1000)) != 0)
                        {
                            total += read;
                        }

                        _bitmapFromStream = (Bitmap)Bitmap.FromStream(new MemoryStream(buffer, 0, total));

                        if (_bitmapFromStream.Width > 320 && _bitmapFromStream.Height > 240)
                        {
                            Bitmap resizedBitmap = new Bitmap(_bitmapFromStream, new Size(320, 240));
                            RaiseFrameCapturedEvent(new CameraEventArgs(this, resizedBitmap));
                            //CameraScreen.Image = resizedBitmap;
                        }
                        else
                        {
                            RaiseFrameCapturedEvent(new CameraEventArgs(this, _bitmapFromStream));
                        }
                    }
#if DEBUG
                    Console.Out.WriteLine("Cam {0} Captured Image, Thread {1}", CamNum, Thread.CurrentThread.Name);
#endif

                    Thread.Sleep(40); // 1000/40 (25 fps)
                }
                catch (Exception ex)
                {
                    Bitmap flag = new Bitmap(320, 240);
                    Graphics flagGraphics = Graphics.FromImage(flag);                
                    flagGraphics.FillRectangle(Brushes.Navy, 0, 0, 320, 240);
                    Console.Out.WriteLine("Exception: IPDevice.GetFrames Cam{0} :{1}", CamNum, ex.Message);
                    RaiseFrameCapturedEvent(new CameraEventArgs(this, flag));
                }
            }
        }
    }
}
