using System.Drawing;

namespace DVR.ImageProcessing
{
    public class ImageSettingsModel
    {
        public bool TextBottom;
        public bool PrivacyEnabled;
        public int WindowLocationX;
        public int PrivacyStartX;
        public int WindowOffsetX;
        public int WindowLocationY;
        public int PrivacyStartY;
        public int WindowOffsetY;
        public int PrivacyEndX;
        public int PrivacyEndY;
        public bool PrivacySelected;
        public bool ShowTimeDate;
        public int CamNum;
        public int CalculatedFPS;
        public bool MotionDetected;
        public bool BlackText;
        public Bitmap ImageCapture;
        public Point FormLocation;
        public Point MouseLocation;
    }
}
