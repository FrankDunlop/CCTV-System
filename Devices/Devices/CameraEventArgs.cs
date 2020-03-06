using System;
using System.Drawing;

namespace DVR.Devices
{
    public class CameraEventArgs : EventArgs, ICameraEventArgs
    {
        public ICamera Cam { get; set; }
        public Bitmap Frame { get; set; }

        public CameraEventArgs(ICamera cam, Bitmap frame)
        {
            Cam = cam;
            Frame = frame;
        }
    }
}
