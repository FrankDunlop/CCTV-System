
using System.Drawing;

namespace DVR.Devices
{
    public interface ICameraEventArgs
    {
        ICamera Cam { get; set; }
        Bitmap Frame { get; set; }
    }
}
