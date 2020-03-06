
namespace DVR.Models
{
    public class CameraSettingsModel
    {
        public int CamNum { get; set; }
        public string CamName { get; set; }
        public int FPS { get; set; }
        public bool BlackText { get; set; }
        public bool TextBottom { get; set; }
        public bool? LowRes { get; set; }
        public bool MotionDetectionEnabled { get; set; }
        public int Sensitivity { get; set; }
        public bool RecordOnMotionEnabled { get; set; }
        public int RecordSecs { get; set; }
        public bool PrivacyEnabled { get; set; }
        public bool PrivacySelected { get; set; }
        public bool ShowTimeDate { get; set; }
    }
}


