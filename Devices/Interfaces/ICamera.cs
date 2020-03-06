
using System.Drawing;
using System.Windows.Forms;
using DVR.Media;
using DVR.ImageProcessing;
using DVR.Models;

namespace DVR.Devices
{
    public interface ICamera
    {
        event CameraFrameDelegate FrameCaptured;
        event StopCameraDelegate StopCamera;

        CameraType CamType { get; set; }
        int CamNum { get; set; }
        bool Connected { get; set; }
        string Url { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        int CalculatedFPS { get; set; }
        int FrameCount { get; set; }
        bool LowRes { get; set; }

        PictureBox CameraScreen { get; set; }
        Button IPCameraButton { get; set; }
        Button WebCameraButton { get; set; }
        Button SnapshotButton { get; set; }
        Button AVICaptueButton { get; set; }
        Button FullscreenButton { get; set; }

        Timer WriteTimer { get; set; }
        Timer MotionTimer { get; set; }

        CameraSettingsModel CameraSettings { get; set; }

        IClipWriter ClipWriter { get; set; }
        IImageProcessor ImageProcessor { get; set; }
        IMotionCalculator MotionCalculator { get; set; }

        Point PrivacyStart { get; set; }
        Point PrivacyEnd { get; set; }
        Point WindowLocation { get; set; }
        Point WindowOffset { get; set; }

        string FileNameCam { get; set; }
        bool MotionDetected { get; set; }
        bool MotionMonitor { get; set; }
        bool CaptureFlag { get; set; }

        Bitmap LastFrame { get; set; }
        Bitmap PrevLastFrame { get; set; }

        void InitCamera();
        bool IsGetFramesThreadRunning();
        void StartDevice();
        void StopDevice(string error);
    }
}
