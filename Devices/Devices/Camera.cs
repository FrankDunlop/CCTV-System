using System.Drawing;
using DVR.Media;
using DVR.ImageProcessing;
using System.Windows.Forms;
using DVR.Models;

namespace DVR.Devices
{
    public delegate void CameraFrameDelegate(CameraEventArgs e);
    public delegate void StopCameraDelegate(ICamera cam, string error);

    public abstract class Camera: ICamera
    {
        public event CameraFrameDelegate FrameCaptured;
        public event StopCameraDelegate StopCamera;

        public CameraType CamType { get; set; }
        public int CamNum { get; set; }
        public bool Connected { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int CalculatedFPS { get; set; }
        public int FrameCount { get; set; }
        public bool LowRes { get; set; }

        public PictureBox CameraScreen { get; set; }
        public Button IPCameraButton { get; set; }
        public Button WebCameraButton { get; set; }
        public Button SnapshotButton { get; set; }
        public Button AVICaptueButton { get; set; }
        public Button FullscreenButton { get; set; }
        public Timer WriteTimer { get; set; }
        public Timer MotionTimer { get; set; }
        public CameraSettingsModel CameraSettings { get; set; }
        public IClipWriter ClipWriter { get; set; }
        public IImageProcessor ImageProcessor { get; set; }
        public IMotionCalculator MotionCalculator { get; set; }
        public Point PrivacyStart { get; set; }
        public Point PrivacyEnd { get; set; }
        public Point WindowLocation { get; set; }
        public Point WindowOffset { get; set; }
        public string FileNameCam { get; set; }
        public bool MotionDetected { get; set; }
        public bool MotionMonitor { get; set; }
        public bool CaptureFlag { get; set; }
        public Bitmap LastFrame { get; set; }
        public Bitmap PrevLastFrame { get; set; }
        public CameraEventArgs CamArgs { get; set; }

        public void RaiseStopCameraEvent(ICamera camera, string message)
        {
            StopCamera?.Invoke(camera, message);
        }

        public void RaiseFrameCapturedEvent(CameraEventArgs args)
        {
            FrameCaptured?.Invoke(args);
        }

        public abstract void InitCamera();
        public abstract bool IsGetFramesThreadRunning();
        public abstract void StartDevice();
        public abstract void StopDevice(string error);
    }
}
