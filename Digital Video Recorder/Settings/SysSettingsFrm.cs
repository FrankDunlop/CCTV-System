using System;
using System.CodeDom;
using System.Windows.Forms;
using DAL.EF;
using DVR.Logging;
using DVR.Models;

namespace DVR.SysSettings
{
    public partial class SysSettingsFrm : Form
    {
        public ILogger Logger { get; set; }
        public CameraSettingsModel[] CamSettings { get; set; }

        public SysSettingsFrm(ILogger logger)
        {
            InitializeComponent();
            Logger = logger;
            CamSettings = new CameraSettingsModel[4];
            for (int i=0; i<4; i++)
            {
                CamSettings[i] = new CameraSettingsModel();
            }
            PopulateSettingsArray();
        }

        private void CamSettingsChangedLogEntry(int camNum, string logEntry)
        {
            Logger.AppendToLog($"{DateTime.Now}   Cam{camNum} {logEntry}");
        }

        #region Camera1 Options
        private void rdoCam1BlackText_Click(object sender, EventArgs e)
        {
            rdoCam1BlackText.Checked = true;
            rdoCam1WhiteText.Checked = false;
            CamSettings[0].BlackText = true;
            CamSettingsChangedLogEntry(1, "Text Colour Changed To Black");
        }

        private void rdoCam1WhiteText_Click(object sender, EventArgs e)
        {
            rdoCam1BlackText.Checked = false;
            rdoCam1WhiteText.Checked = true;
            CamSettings[0].BlackText = false;
            CamSettingsChangedLogEntry(1, "Text Colour Changed To White");
        }

        private void Cam1LowResRdo_Click(object sender, EventArgs e)
        {
            Cam1LowResRdo.Checked = true;
            Cam1HighResRdo.Checked = false;
            CamSettings[0].LowRes = true;
            CamSettingsChangedLogEntry(1, "Low Resolution Selected");
            SetCamHighRes(false);
            groupBox5.Enabled = true;
            groupBox9.Enabled = true;
            groupBox13.Enabled = true;
        }

        private void Cam1HighResRdo_Click(object sender, EventArgs e)
        {
            //if (!Main.Webcam1Connected && !Main.Webcam2Connected && !Main.Webcam3Connected && !Main.Webcam4Connected)
            //{
            //    Cam1LowResRdo.Checked = false;
            //    Cam1HighResRdo.Checked = true;
            //    Cam1LowRes = false;
            //    CamSettingsChangedLogEntry(1, "High Resolution Selected");
            //    //Main.CameraWindow1.Image = Image.FromFile("C:\\Digital Video Recorder\\VideoBackHR.jpg");
            //    SetCamHighRes(true);
            //    groupBox5.Enabled = false;
            //    groupBox9.Enabled = false;
            //    groupBox13.Enabled = false;
            //}
            //else
            //{
            //    Cam1LowResRdo.Checked = true;
            //    Cam1HighResRdo.Checked = false;
            //    MessageBox.Show("Disconnect Webcameras Before Selecting High Res Mode");
            //}
        }

        private void SetCamHighRes(bool highres)
        {
            //if (highres)
            //{
            //    Main.Height = 610;
            //    Main.Width = 755;
            //    Main.groupBox1.Width = 652;
            //    Main.groupBox1.Height = 566;
            //    Main.CameraWindow1.Width = 640;
            //    Main.CameraWindow1.Height = 480;

            //    Main.groupBox2.Visible = false;
            //    Main.groupBox3.Visible = false;
            //    Main.groupBox4.Visible = false;

            //    Main.FullScreen1Btn.Location = new Point(631, 0);
            //    Main.WebCam1Btn.Location = new Point(201, 504);
            //    Main.IPCam1Btn.Location = new Point(262, 504);
            //    Main.Cam1SnapshotBtn.Location = new Point(329, 504);
            //    Main.Cam1CapAVIBtn.Location = new Point(388, 504);

            //    Main.AddCambtn.Enabled = false;
            //    Main.DelCambtn.Enabled = false;
            //}
            //else
            //{
            //    Main.Height = 369;
            //    Main.Width = 435;
            //    Main.groupBox1.Width = 332;
            //    Main.groupBox1.Height = 326;
            //    Main.CameraWindow1.Width = 320;
            //    Main.CameraWindow1.Height = 240;

            //    Main.groupBox2.Visible = true;
            //    Main.groupBox3.Visible = true;
            //    Main.groupBox4.Visible = true;

            //    Main.FullScreen1Btn.Location = new Point(311, 0);
            //    Main.WebCam1Btn.Location = new Point(41, 264);
            //    Main.IPCam1Btn.Location = new Point(102, 264);
            //    Main.Cam1SnapshotBtn.Location = new Point(169, 264);
            //    Main.Cam1CapAVIBtn.Location = new Point(228, 264);

            //    Main.AddCambtn.Enabled = true;
            //    Main.DelCambtn.Enabled = true;
            //}
        }

        private void rdoCam1Top_Click(object sender, EventArgs e)
        {
            rdoCam1Bot.Checked = false;
            rdoCam1Top.Checked = true;
            CamSettings[0].TextBottom = false;
            CamSettingsChangedLogEntry(1, "Text Display On Top Selected");
        }

        private void rdoCam1Bot_Click(object sender, EventArgs e)
        {
            rdoCam1Bot.Checked = true;
            rdoCam1Top.Checked = false;
            CamSettings[0].TextBottom = true;
            CamSettingsChangedLogEntry(1, "Text Display On Bottom Selected");
        }

        private void Cam1Nametxt_TextChanged(object sender, EventArgs e)
        {
            CamSettings[0].CamName = Cam1Nametxt.Text;
        }

        private void Cam1FPScbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CamSettings[0].FPS = int.Parse(Cam1FPScbo.Text);
            CamSettingsChangedLogEntry(1, $"FPS Changed to {Cam1FPScbo.Text} fps");
        }

        private void Private1Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Private1Chk.Checked)
            {
                CamSettingsChangedLogEntry(1, "Privacy Option Enabled");
                CamSettings[0].PrivacyEnabled = true;
            }
            else
            {
                CamSettingsChangedLogEntry(1, "Privacy Option Disabled");
                CamSettings[0].PrivacyEnabled = false;
            }
        }

        private void ShowTime1Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowTime1Chk.Checked)
            {
                CamSettingsChangedLogEntry(1, "On Screen Display Option Enabled");
                CamSettings[0].ShowTimeDate = true;
            }
            else
            {
                CamSettingsChangedLogEntry(1, "On Screen Display Option Disabled");
                CamSettings[0].ShowTimeDate = false;
            }
        }

        private void Motion1Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Motion1Chk.Checked)
            {
                RecMot1Chk.Enabled = true;
                CamSettings[0].MotionDetectionEnabled = true;
                CamSettingsChangedLogEntry(1, "Motion Detect Enabled");
            }
            else
            {
                CamSettings[0].MotionDetectionEnabled = false;
                RecMot1Chk.Checked = false;
                CamSettings[0].RecordOnMotionEnabled = false;
                RecMot1Chk.Enabled = false;
                CamSettingsChangedLogEntry(1, "Motion Detect Disabled");
            }
        }

        private void RecMot1Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (RecMot1Chk.Checked)
            {
                CamSettingsChangedLogEntry(1, "Record On Motion Enabled");
                CamSettings[0].RecordOnMotionEnabled = true;
            }
            else
            {
                CamSettingsChangedLogEntry(1, "Record On Motion Disabled");
                CamSettings[0].RecordOnMotionEnabled = false;
            }
        }

        private void Mot1RecSecs_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(1, "Recording Seconds Changed To " + Mot1RecSecs.Text);
            CamSettings[0].RecordSecs = Convert.ToInt32(Mot1RecSecs.Value);
        }

        private void Mot1Sensitivity_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(1, "Sensitivity Changed To " + Mot1Sensitivity.Text);
            CamSettings[0].Sensitivity = Convert.ToInt32(Mot1Sensitivity.Value);
        }
        #endregion

        #region Camera2 Options
        public bool Cam2TimeDateShow()
        {
            return ShowTime2Chk.Checked;
        }

        private void rdoCam2BlackText_Click(object sender, EventArgs e)
        {
            rdoCam2BlackText.Checked = true;
            rdoCam2WhiteText.Checked = false;
            CamSettings[1].BlackText = true;
            CamSettingsChangedLogEntry(2, "Text Colour Changed To Black");
        }

        private void rdoCam2WhiteText_Click(object sender, EventArgs e)
        {
            rdoCam2BlackText.Checked = false;
            rdoCam2WhiteText.Checked = true;
            CamSettings[1].BlackText = false;
            CamSettingsChangedLogEntry(2, "Text Colour Changed To White");
        }

        private void rdoCam2Top_Click(object sender, EventArgs e)
        {
            rdoCam2Bot.Checked = false;
            rdoCam2Top.Checked = true;
            CamSettings[1].TextBottom = false;
            CamSettingsChangedLogEntry(2, "Text Display On Top Selected");
        }

        private void rdoCam2Bot_Click(object sender, EventArgs e)
        {
            rdoCam2Bot.Checked = true;
            rdoCam2Top.Checked = false;
            CamSettings[1].TextBottom = true;
            CamSettingsChangedLogEntry(2, "Text Display On Bottom Selected");
        }

        private void Cam2Nametxt_TextChanged(object sender, EventArgs e)
        {
            CamSettings[1].CamName = Cam2Nametxt.Text;
        }

        private void Cam2FPScbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CamSettings[1].FPS = int.Parse(Cam2FPScbo.Text);
            CamSettingsChangedLogEntry(2, $"FPS Changed to {Cam2FPScbo.Text} fps");
        }

        private void Private2Chk_CheckedChanged(object sender, EventArgs e)
        {
            var privacy = string.Empty;

            if (Private2Chk.Checked)
            {
                privacy = "Privacy Option Enabled";
                CamSettings[1].PrivacyEnabled = true;
            }
            else
            {
                privacy = "Privacy Option Disabled";
                CamSettings[1].PrivacyEnabled = false;
            }

            CamSettingsChangedLogEntry(2, privacy);
        }

        private void ShowTime2Chk_CheckedChanged(object sender, EventArgs e)
        {
            var display = String.Empty;

            if (ShowTime2Chk.Checked)
            {
                display = "On Screen Display Option Enabled";
                CamSettings[1].ShowTimeDate = true;
            }
            else
            {
                display = "On Screen Display Option Disabled";
                CamSettings[1].ShowTimeDate = false;
            }

            CamSettingsChangedLogEntry(2, display);
        }

        private void Motion2Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Motion2Chk.Checked)
            {
                RecMot2Chk.Enabled = true;
                CamSettings[1].MotionDetectionEnabled = true;
                CamSettingsChangedLogEntry(2, "Motion Detect Enabled");
            }
            else
            {
                CamSettings[1].MotionDetectionEnabled = false;
                RecMot2Chk.Checked = false;
                CamSettings[1].RecordOnMotionEnabled = false;
                RecMot2Chk.Enabled = false;
                CamSettingsChangedLogEntry(2, "Motion Detect Disabled");
            }
        }

        private void RecMot2Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (RecMot2Chk.Checked)
            {
                CamSettings[1].RecordOnMotionEnabled = true;
                CamSettingsChangedLogEntry(2, "Record On Motion Enabled");
            }
            else
            {
                CamSettings[1].RecordOnMotionEnabled = false;
                CamSettingsChangedLogEntry(2, "Record On Motion Disabled");
            }
        }

        private void Mot2RecSecs_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(2, "Recording Seconds Changed To " + Mot2RecSecs.Text);
            CamSettings[1].RecordSecs = Convert.ToInt32(Mot2RecSecs.Value);
        }

        private void Mot2Sensitivity_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(2, "Sensitivity Changed To " + Mot2Sensitivity.Text);
            CamSettings[1].Sensitivity = Convert.ToInt32(Mot2Sensitivity.Value);
        }
        #endregion

        #region Camera3 Options
        public bool Cam3TimeDateShow()
        {
            return ShowTime3Chk.Checked;
        }

        private void rdoCam3BlackText_Click(object sender, EventArgs e)
        {
            rdoCam3BlackText.Checked = true;
            rdoCam3WhiteText.Checked = false;
            CamSettings[2].BlackText = true;
            CamSettingsChangedLogEntry(3, "Text Colour Changed To Black");
        }

        private void rdoCam3WhiteText_Click(object sender, EventArgs e)
        {
            rdoCam3BlackText.Checked = false;
            rdoCam3WhiteText.Checked = true;
            CamSettings[2].BlackText = false;
            CamSettingsChangedLogEntry(3, "Text Colour Changed To White");
        }

        private void rdoCam3Top_Click(object sender, EventArgs e)
        {
            rdoCam3Bot.Checked = false;
            rdoCam3Top.Checked = true;
            CamSettings[2].TextBottom = false;
            CamSettingsChangedLogEntry(3, "Text Display On Top Selected");
        }

        private void rdoCam3Bot_Click(object sender, EventArgs e)
        {
            rdoCam3Bot.Checked = true;
            rdoCam3Top.Checked = false;
            CamSettings[2].TextBottom = true;
            CamSettingsChangedLogEntry(3, "Text Display On Bottom Selected");
        }

        private void Cam3Nametxt_TextChanged(object sender, EventArgs e)
        {
            CamSettings[2].CamName = Cam3Nametxt.Text;
        }

        private void Cam3FPScbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CamSettings[2].FPS = int.Parse(Cam3FPScbo.Text);
            CamSettingsChangedLogEntry(3, string.Format("FPS Changed to {0} fps", Cam3FPScbo.Text));
        }

        private void Private3Chk_CheckedChanged(object sender, EventArgs e)
        {
            String privacy;

            if (Private3Chk.Checked)
            {
                privacy = "Privacy Option Enabled";
                CamSettings[2].PrivacyEnabled = true;
            }
            else
            {
                privacy = "Privacy Option Disabled";
                CamSettings[2].PrivacyEnabled = false;
            }

            CamSettingsChangedLogEntry(3, privacy);
        }

        private void ShowTime3Chk_CheckedChanged(object sender, EventArgs e)
        {
            String display;

            if (ShowTime3Chk.Checked)
            {
                display = "On Screen Display Option Enabled";
                CamSettings[2].ShowTimeDate = true;
            }
            else
            {
                display = "On Screen Display Option Disabled";
                CamSettings[2].ShowTimeDate = false;
            }

            CamSettingsChangedLogEntry(3, display);
        }

        private void Motion3Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Motion3Chk.Checked)
            {
                RecMot3Chk.Enabled = true;
                CamSettings[2].MotionDetectionEnabled = true;
                CamSettingsChangedLogEntry(3, "Motion Detect Enabled");
            }
            else
            {
                CamSettings[2].MotionDetectionEnabled = false;
                RecMot3Chk.Checked = false;
                CamSettings[2].RecordOnMotionEnabled = false;
                RecMot3Chk.Enabled = false;
                CamSettingsChangedLogEntry(3, "Motion Detect Disabled");
            }
        }

        private void RecMot3Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (RecMot3Chk.Checked)
            {
                CamSettings[2].RecordOnMotionEnabled = true;
                CamSettingsChangedLogEntry(3, "Record On Motion Enabled");
            }
            else
            {
                CamSettings[2].RecordOnMotionEnabled = false;
                CamSettingsChangedLogEntry(3, "Record On Motion Disabled");
            }
        }

        private void Mot3RecSecs_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(3, "Recording Seconds Changed To " + Mot3RecSecs.Text);
            CamSettings[2].RecordSecs = Convert.ToInt32(Mot3RecSecs.Value);
        }

        private void Mot3Sensitivity_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(3, "Sensitivity Changed To " + Mot3Sensitivity.Text);
            CamSettings[2].Sensitivity = Convert.ToInt32(Mot3Sensitivity.Value);
        }
        #endregion

        #region Camera4 Options
        public bool Cam4TimeDateShow()
        {
            return ShowTime4Chk.Checked;
        }

        private void rdoCam4BlackText_Click(object sender, EventArgs e)
        {
            rdoCam4BlackText.Checked = true;
            rdoCam4WhiteText.Checked = false;
            CamSettings[3].BlackText = true;
            CamSettingsChangedLogEntry(4, "Text Colour Changed To Black");
        }

        private void rdoCam4WhiteText_Click(object sender, EventArgs e)
        {
            rdoCam4BlackText.Checked = false;
            rdoCam4WhiteText.Checked = true;
            CamSettings[3].BlackText = false;
            CamSettingsChangedLogEntry(4, "Text Colour Changed To White");
        }

        private void rdoCam4Top_Click(object sender, EventArgs e)
        {
            rdoCam4Bot.Checked = false;
            rdoCam4Top.Checked = true;
            CamSettings[3].TextBottom = false;
            CamSettingsChangedLogEntry(4, "Text Display On Top Selected");
        }

        private void rdoCam4Bot_Click(object sender, EventArgs e)
        {
            rdoCam4Bot.Checked = true;
            rdoCam4Top.Checked = false;
            CamSettings[3].TextBottom = true;
            CamSettingsChangedLogEntry(4, "Text Display On Bottom Selected");
        }

        private void Cam4Nametxt_TextChanged(object sender, EventArgs e)
        {
            CamSettings[3].CamName = Cam4Nametxt.Text;
        }

        private void Cam4FPScbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CamSettings[3].FPS = int.Parse(Cam4FPScbo.Text);
            CamSettingsChangedLogEntry(4, string.Format("FPS Changed to {0} fps", Cam4FPScbo.Text));
        }

        private void Private4Chk_CheckedChanged(object sender, EventArgs e)
        {
            String privacy;

            if (Private4Chk.Checked)
            {
                privacy = "Privacy Option Enabled";
                CamSettings[3].PrivacyEnabled = true;
            }
            else
            {
                privacy = "Privacy Option Disabled";
                CamSettings[3].PrivacyEnabled = false;
            }

            CamSettingsChangedLogEntry(4, privacy);
        }

        private void ShowTime4Chk_CheckedChanged(object sender, EventArgs e)
        {
            String display;

            if (ShowTime4Chk.Checked)
            {
                display = "On Screen Display Option Enabled";
                CamSettings[3].ShowTimeDate = true;
            }
            else
            {
                display = "On Screen Display Option Disabled";
                CamSettings[3].ShowTimeDate = false;
            }

            CamSettingsChangedLogEntry(4, display);
        }

        private void Motion4Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (Motion4Chk.Checked)
            {
                RecMot4Chk.Enabled = true;
                CamSettings[3].MotionDetectionEnabled = true;
                CamSettingsChangedLogEntry(4, "Motion Detect Enabled");
            }
            else
            {
                CamSettings[3].MotionDetectionEnabled = false;
                RecMot4Chk.Checked = false;
                CamSettings[3].RecordOnMotionEnabled = false;
                RecMot4Chk.Enabled = false;
                CamSettingsChangedLogEntry(4, "Motion Detect Disabled");
            }
        }

        private void RecMot4Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (RecMot4Chk.Checked)
            {
                CamSettings[3].RecordOnMotionEnabled = true;
                CamSettingsChangedLogEntry(4, "Record On Motion Enabled");
            }
            else
            {
                CamSettings[3].RecordOnMotionEnabled = true;
                CamSettingsChangedLogEntry(4, "Record On Motion Disabled");
            }
        }

        private void Mot4RecSecs_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(4, "Recording Seconds Changed To " + Mot4RecSecs.Text);
            CamSettings[3].RecordSecs = Convert.ToInt32(Mot4RecSecs.Value);
        }

        private void Mot4Sensitivity_ValueChanged(object sender, EventArgs e)
        {
            CamSettingsChangedLogEntry(4, "Sensitivity Changed To " + (Mot4Sensitivity.Text));
            CamSettings[3].Sensitivity = Convert.ToInt32(Mot4Sensitivity.Value);
        }
        #endregion

        #region Default Settings
        private void PopulateSettingsArray()
        {
            if (GetCameraSettings())
            {
                Cam1Nametxt.Text = CamSettings[0].CamName;
                Cam2Nametxt.Text = CamSettings[1].CamName;
                Cam3Nametxt.Text = CamSettings[2].CamName;
                Cam4Nametxt.Text = CamSettings[3].CamName;

                ShowTime1Chk.Checked = CamSettings[0].ShowTimeDate;
                ShowTime2Chk.Checked = CamSettings[1].ShowTimeDate;
                ShowTime3Chk.Checked = CamSettings[2].ShowTimeDate;
                ShowTime4Chk.Checked = CamSettings[3].ShowTimeDate;

                rdoCam1BlackText.Checked = CamSettings[0].BlackText;
                rdoCam2BlackText.Checked = CamSettings[1].BlackText;
                rdoCam3BlackText.Checked = CamSettings[2].BlackText;
                rdoCam4BlackText.Checked = CamSettings[3].BlackText;
                rdoCam1WhiteText.Checked = !CamSettings[0].BlackText;
                rdoCam2WhiteText.Checked = !CamSettings[1].BlackText;
                rdoCam3WhiteText.Checked = !CamSettings[2].BlackText;
                rdoCam4WhiteText.Checked = !CamSettings[3].BlackText;

                rdoCam1Bot.Checked = CamSettings[0].TextBottom;
                rdoCam2Bot.Checked = CamSettings[1].TextBottom;
                rdoCam3Bot.Checked = CamSettings[2].TextBottom;
                rdoCam4Bot.Checked = CamSettings[3].TextBottom;
                rdoCam1Top.Checked = !CamSettings[0].TextBottom;
                rdoCam2Top.Checked = !CamSettings[1].TextBottom;
                rdoCam3Top.Checked = !CamSettings[2].TextBottom;
                rdoCam4Top.Checked = !CamSettings[3].TextBottom;

                Cam1LowResRdo.Checked = true; // CamSettings[0].LowRes;
                Cam2LowResRdo.Checked = true; // CamSettings[1].LowRes;
                Cam3LowResRdo.Checked = true; // CamSettings[2].LowRes;
                Cam4LowResRdo.Checked = true; // CamSettings[3].LowRes;

                //Cam1FPScbo.SelectedIndex = CamSettings[0].FPS;
                //Cam2FPScbo.SelectedIndex = CamSettings[1].FPS;
                //Cam3FPScbo.SelectedIndex = CamSettings[2].FPS;
                //Cam4FPScbo.SelectedIndex = CamSettings[3].FPS;

                Private1Chk.Checked = CamSettings[0].PrivacyEnabled;
                Private2Chk.Checked = CamSettings[1].PrivacyEnabled;
                Private3Chk.Checked = CamSettings[2].PrivacyEnabled;
                Private4Chk.Checked = CamSettings[3].PrivacyEnabled;

                Motion1Chk.Checked = CamSettings[0].MotionDetectionEnabled;
                Motion2Chk.Checked = CamSettings[1].MotionDetectionEnabled;
                Motion3Chk.Checked = CamSettings[2].MotionDetectionEnabled;
                Motion4Chk.Checked = CamSettings[3].MotionDetectionEnabled;

                RecMot1Chk.Enabled = CamSettings[0].MotionDetectionEnabled;
                RecMot2Chk.Enabled = CamSettings[1].MotionDetectionEnabled;
                RecMot3Chk.Enabled = CamSettings[2].MotionDetectionEnabled;
                RecMot4Chk.Enabled = CamSettings[3].MotionDetectionEnabled;

                RecMot1Chk.Checked = CamSettings[0].RecordOnMotionEnabled;
                RecMot2Chk.Checked = CamSettings[1].RecordOnMotionEnabled;
                RecMot3Chk.Checked = CamSettings[2].RecordOnMotionEnabled;
                RecMot4Chk.Checked = CamSettings[3].RecordOnMotionEnabled;

                Mot1RecSecs.Value = CamSettings[0].RecordSecs < 10 ? 10 : CamSettings[0].RecordSecs;
                Mot2RecSecs.Value = CamSettings[1].RecordSecs < 10 ? 10 : CamSettings[1].RecordSecs;
                Mot3RecSecs.Value = CamSettings[2].RecordSecs < 10 ? 10 : CamSettings[2].RecordSecs;
                Mot4RecSecs.Value = CamSettings[3].RecordSecs < 10 ? 10 : CamSettings[3].RecordSecs;
            }
        }
        #endregion

        private void SettingsFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCameraSettings();
        }

        public bool GetCameraSettings()
        {
            try
            {
                throw new Exception();

                /*var db = new DVREntities();

                var settings = (from s in db.CamSettings
                                    orderby s.CamNum
                                    select s).ToList();

                if (settings.Count == 0)
                {
                    for (int i = 1; i < 5; i++)
                    {
                        CamSetting camSettings = new CamSetting();
                        camSettings.CamName = i.ToString();
                        camSettings.FPS = 12;
                        camSettings.BlackTest = false;
                        camSettings.TextBottom = false;
                        camSettings.LowRes = true;
                        camSettings.MotionDetectEnabled = true;
                        camSettings.Sensitivity = 30;
                        camSettings.RecOnMotion = false;
                        camSettings.RecSeconds = 10;
                        camSettings.PrivacyEnabled = false;
                        camSettings.PrivacySelected = false;
                        camSettings.ShowTimeDate = true;
                        db.AddToCamSettings(camSettings);
                    }
                    
                    db.SaveChanges();

                    settings = (from s in db.CamSettings
                                    orderby s.CamNum
                                    select s).ToList();
                }

                //TO DO: Use AutoMapper here
                foreach (var item in settings)
                {
                    CamSettings[item.CamNum - 1].CamNum = item.CamNum;
                    CamSettings[item.CamNum - 1].CamName = item.CamName;
                    CamSettings[item.CamNum - 1].FPS = item.FPS;
                    CamSettings[item.CamNum - 1].BlackText = item.BlackTest;
                    CamSettings[item.CamNum - 1].TextBottom = item.TextBottom;
                    CamSettings[item.CamNum - 1].LowRes = item.LowRes;
                    CamSettings[item.CamNum - 1].MotionDetectionEnabled = item.MotionDetectEnabled;
                    CamSettings[item.CamNum - 1].Sensitivity = item.Sensitivity;
                    CamSettings[item.CamNum - 1].RecordOnMotionEnabled = item.RecOnMotion;
                    CamSettings[item.CamNum - 1].RecordSecs = item.RecSeconds;
                    CamSettings[item.CamNum - 1].PrivacyEnabled = item.PrivacyEnabled;
                    CamSettings[item.CamNum - 1].PrivacySelected = item.PrivacySelected;
                    CamSettings[item.CamNum - 1].ShowTimeDate = item.ShowTimeDate;
                }

                return true;*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                CameraSettingsModel camSettings1 = new CameraSettingsModel();
                camSettings1.CamName = "1";
                camSettings1.FPS = 12;
                camSettings1.BlackText = false;
                camSettings1.TextBottom = false;
                camSettings1.LowRes = true;
                camSettings1.MotionDetectionEnabled = true;
                camSettings1.Sensitivity = 30;
                camSettings1.RecordOnMotionEnabled = false;
                camSettings1.RecordSecs = 10;
                camSettings1.PrivacyEnabled = false;
                camSettings1.PrivacySelected = false;
                camSettings1.ShowTimeDate = true;
                CamSettings[0] = camSettings1;

                CameraSettingsModel camSettings2 = new CameraSettingsModel();
                camSettings2.CamName = "2";
                camSettings2.FPS = 12;
                camSettings2.BlackText = false;
                camSettings2.TextBottom = false;
                camSettings2.LowRes = true;
                camSettings2.MotionDetectionEnabled = true;
                camSettings2.Sensitivity = 30;
                camSettings2.RecordOnMotionEnabled = false;
                camSettings2.RecordSecs = 10;
                camSettings2.PrivacyEnabled = false;
                camSettings2.PrivacySelected = false;
                camSettings2.ShowTimeDate = true;
                CamSettings[1] = camSettings2;

                CameraSettingsModel camSettings3 = new CameraSettingsModel();
                camSettings3.CamName = "3";
                camSettings3.FPS = 12;
                camSettings3.BlackText = false;
                camSettings3.TextBottom = false;
                camSettings3.LowRes = true;
                camSettings3.MotionDetectionEnabled = true;
                camSettings3.Sensitivity = 30;
                camSettings3.RecordOnMotionEnabled = false;
                camSettings3.RecordSecs = 10;
                camSettings3.PrivacyEnabled = false;
                camSettings3.PrivacySelected = false;
                camSettings3.ShowTimeDate = true;
                CamSettings[2] = camSettings3;

                CameraSettingsModel camSettings4 = new CameraSettingsModel();
                camSettings4.CamName = "4";
                camSettings4.FPS = 12;
                camSettings4.BlackText = false;
                camSettings4.TextBottom = false;
                camSettings4.LowRes = true;
                camSettings4.MotionDetectionEnabled = true;
                camSettings4.Sensitivity = 30;
                camSettings4.RecordOnMotionEnabled = false;
                camSettings4.RecordSecs = 10;
                camSettings4.PrivacyEnabled = false;
                camSettings4.PrivacySelected = false;
                camSettings4.ShowTimeDate = true;
                CamSettings[3] = camSettings4;

                return false;
            }
        }

        public void SaveCameraSettings()
        {
            /*try
            {
                using (var db = new DVREntities())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        CameraSettingsModel camSettings = new CameraSettingsModel();
                        camSettings = CamSettings[i];

                        var setting = db.CamSettings.First(b => b.CamNum == camSettings.CamNum);
                        if (setting != null)
                        {
                            setting.CamName = camSettings.CamName;
                            setting.FPS = camSettings.FPS;
                            setting.BlackTest = camSettings.BlackText;
                            setting.TextBottom = camSettings.TextBottom;
                            setting.LowRes = camSettings.LowRes;
                            setting.MotionDetectEnabled = camSettings.MotionDetectionEnabled;
                            setting.Sensitivity = camSettings.Sensitivity;
                            setting.RecOnMotion = camSettings.RecordOnMotionEnabled;
                            setting.RecSeconds = camSettings.RecordSecs;
                            setting.PrivacyEnabled = camSettings.PrivacyEnabled;
                            setting.PrivacySelected = camSettings.PrivacySelected;
                            setting.ShowTimeDate = camSettings.ShowTimeDate;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }
    }
}
