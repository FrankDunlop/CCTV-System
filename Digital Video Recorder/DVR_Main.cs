using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using DVR.Devices;
using DVR.Fullscreen;
using DVR.ImageProcessing;
using DVR.LibVlc;
using DVR.Log;
using DVR.Logging;
using DVR.Media;
using DVR.Models;
using DVR.PlaybackScreen;
using DVR.Properties;
using DVR.Search;
using DVR.SysSettings;
using Ninject;

namespace DVR
{
    public partial class DVRFrm : Form
    {
        #region Declarations
        private string snapshotsPath { get => Settings.Default.SnapshotsPath; }
        private string clipsPath { get => Settings.Default.ClipsPath; }
        IKernel kernel;// = new StandardKernel();
        public SysSettingsFrm SettingOpt;
        private ILogger Logger { get; }
        private ICamera _cam1;
        private ICamera _cam2;
        private ICamera _cam3;
        private ICamera _cam4;
        private CameraSettingsModel[] CamSettings = new CameraSettingsModel[4];

        #endregion

        #region MainForm Config
        public DVRFrm()
        {
            InitializeComponent();
            kernel = new StandardKernel();
            kernel.Bind<ILogger>().To<TextLogger>();
            Logger = kernel.Get<ILogger>();

            if (!Directory.Exists(snapshotsPath))
            {
                Directory.CreateDirectory(snapshotsPath);
            }

            if (!Directory.Exists(clipsPath))
            {
                Directory.CreateDirectory(clipsPath);
            }

            Logger.InitLog();
            Logger.AppendToLog($"{DateTime.Now}   Application Started");
            Height = 369;
            Width = 435;
            SettingOpt = new SysSettingsFrm(Logger);
            CamSettings = SettingOpt.CamSettings;
        }

        private void DVRFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cam1 != null)
            {
                if (_cam1.Connected || _cam1.IsGetFramesThreadRunning())
                {
                    _cam1.StopDevice("Cam1 Stopped");
                }
            }
            if (_cam2 != null)
            {
                if (_cam2.Connected || _cam2.IsGetFramesThreadRunning())
                {
                    _cam2.StopDevice("Cam2 Stopped");
                }
            }
            if (_cam3 != null)
            {
                if (_cam3.Connected || _cam3.IsGetFramesThreadRunning())
                {
                    _cam3.StopDevice("Cam3 Stopped");
                }
            }
            if (_cam4 != null)
            {
                if (_cam4.Connected || _cam4.IsGetFramesThreadRunning())
                {
                    _cam4.StopDevice("Cam4 Stopped");
                }
            }
            Logger.AppendToLog($"{DateTime.Now}   Application Closed");
        }

        private void FPS_Tick(object sender, EventArgs e)
        {
            //timer gets frame count per camera every second = fps
            if (_cam1 != null)
            {
                _cam1.CalculatedFPS = _cam1.FrameCount;
                _cam1.FrameCount = 0;
            }
            if (_cam2 != null)
            {
                _cam2.CalculatedFPS = _cam2.FrameCount;
                _cam2.FrameCount = 0;
            }
            if (_cam3 != null)
            {
                _cam3.CalculatedFPS = _cam3.FrameCount;
                _cam3.FrameCount = 0;
            }
            if (_cam4 != null)
            {
                _cam4.CalculatedFPS = _cam4.FrameCount;
                _cam4.FrameCount = 0;
            }
        }
        #endregion

        #region Camera Add or Delete
        //resize the main form to show another camera window
        private void AddCambtn_Click(object sender, EventArgs e)
        {
            if ((Height == 697) && (Width == 770))
            {
                groupBox4.Visible = true;
                return;
            }

            if ((Height == 369) && (Width == 435))
            {
                Height = 369;
                Width = 770;
            }
            else
            {
                groupBox4.Visible = false;
                Height = 697;
                Width = 770;
            }
        }

        //resize the main form to show only relevant camera windows
        private void DelCambtn_Click(object sender, EventArgs e)
        {
            if ((Height == 697) && (Width == 770) && (groupBox4.Visible))
            {
                groupBox4.Visible = false;
                return;
            }

            if ((Height == 697) && (Width == 770))
            {
                Height = 369;
                Width = 770;
            }
            else
            {
                Height = 369;
                Width = 435;
            }
        }
        #endregion

        #region Settings & Log
        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            Logger.AppendToLog($"{DateTime.Now}   System Settings Screen Accessed");
            SettingOpt.ShowDialog();
        }

        private void SystemLogBtn_Click(object sender, EventArgs e)
        {
            SystemLog sysLog = new SystemLog(Logger);
            string log = Logger.GetLogEntries(sysLog.LogEntriestxt.Text);
            sysLog.AddLogEntries(log);
            sysLog.ShowDialog();
            Logger.AppendToLog($"{DateTime.Now}   System Log Accessed");
        }
        #endregion

        #region Icon Settings
        private void ResetCameraIcons(ICamera cam, string message)
        {
            cam.IPCameraButton.BackgroundImage = (cam.GetType() == typeof(IPDevice)) 
                ? GetImage("IP")
                : GetImage("USB");
            cam.CameraScreen.Image = cam.CameraScreen.Width == 320
                ? GetImage("VideoBack")
                : GetImage("VideoBackHR");
        }

        private Bitmap GetImage(string image)
        {
            System.Resources.ResourceManager RM = new System.Resources.ResourceManager("DVR.Properties.Resources", typeof(Resources).Assembly);
            return new Bitmap((Bitmap)RM.GetObject(image));
        }
    
        private void CameraToggleOnOff(ref ICamera cam)
        {
            if (!cam.Connected)
            {
                cam.InitCamera();
                cam.CameraScreen.Image = GetImage("Connecting");
                cam.StartDevice();
                cam.SnapshotButton.Enabled = true;
                cam.AVICaptueButton.Enabled = true;
                cam.IPCameraButton.BackgroundImage = (cam.GetType() == typeof(IPDevice))
                    ? GetImage("IPConnected")
                    : GetImage("USBConnected");
                cam.FullscreenButton.Enabled = true;
                Logger.AppendToLog($"{DateTime.Now}   Cam {cam.CamNum} Connected");
            }
            else
            {
                if (!cam.WriteTimer.Enabled)
                {
                    cam.Connected = false;
                    cam.StopDevice($"Camera {cam.CamNum} Stopped");
                    ResetCameraIcons(cam, "");
                    cam.WebCameraButton.Enabled = true;
                    cam.IPCameraButton.Enabled = true;
                    cam.FullscreenButton.Enabled = false;
                    cam.SnapshotButton.Enabled = false;
                    cam.AVICaptueButton.Enabled = false;
                    cam.CameraSettings.FPS = 0;
                    Logger.AppendToLog($"{DateTime.Now}   Cam {cam.CamNum} Disconnected");
                    cam = null;
                }
                else
                {
                    MessageBox.Show("Please Stop Recording Before Disconnecting");
                }
            }
        }
        #endregion

        #region Camera Selection
        private void WebCam1Btn_Click(object sender, EventArgs e)
        {
            if (_cam1 == null)
            {
                WebCam_Select webCamSel = new WebCam_Select();
                if (webCamSel.DevicesConnected() > 1)
                {
                    webCamSel.ShowDialog();
                }
                _cam1 = webCamSel.GetDevice();

                if (_cam1 != null)
                {
                    _cam1.CamType = CameraType.USB;
                    _cam1.CamNum = 1;
                    _cam1.Connected = false;
                    _cam1.Url = "";
                    _cam1.Username = "";
                    _cam1.Password = "";
                    _cam1.CameraScreen = CameraWindow1;
                    _cam1.IPCameraButton = IPCam1Btn;
                    _cam1.WebCameraButton = WebCam1Btn;
                    _cam1.SnapshotButton = Cam1SnapshotBtn;
                    _cam1.AVICaptueButton = Cam1CapAVIBtn;
                    _cam1.FullscreenButton = FullScreen1Btn;
                    _cam1.WriteTimer = WriteAVITimer1;
                    _cam1.MotionTimer = Motion1Timer;
                    _cam1.CameraSettings = CamSettings[0];
                    _cam1.PrivacyStart = new Point(0, 0);
                    _cam1.PrivacyEnd = new Point(0, 0);
                    _cam1.WindowLocation = new Point(92, 33);
                    _cam1.WindowOffset = new Point(4, 30);
                    _cam1.ImageProcessor = kernel.Get<IImageProcessor>();
                    _cam1.MotionCalculator = kernel.Get<IMotionCalculator>();
                }
                else
                {
                    MessageBox.Show("No USB devices found");
                    return;
                }

                _cam1.StopCamera += ResetCameraIcons;
                _cam1.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam1);
            }
            else
            {
                CameraToggleOnOff(ref _cam1);
            }
        }

        private void IPCam1Btn_Click(object sender, EventArgs e)
        {
            if(_cam1 == null)
            {
                _cam1 = new IPDevice
                {
                    CamType = CameraType.IP,
                    CamNum = 1,
                    Connected = false,
                    Url = "",
                    Username = "",
                    Password = "",
                    CameraScreen = CameraWindow1,
                    IPCameraButton = IPCam1Btn,
                    WebCameraButton = WebCam1Btn,
                    SnapshotButton = Cam1SnapshotBtn,
                    AVICaptueButton = Cam1CapAVIBtn,
                    FullscreenButton = FullScreen1Btn,               
                    WriteTimer = WriteAVITimer1,
                    MotionTimer = Motion1Timer,
                    CameraSettings = CamSettings[0],
                    PrivacyStart = new Point(0, 0),
                    PrivacyEnd = new Point(0, 0),
                    WindowLocation = new Point(92, 33),
                    WindowOffset = new Point(4, 30),
                    ImageProcessor = new BitmapProcessor(),
                    MotionCalculator = new DefaultMotionCalculator()
                };

                _cam1.StopCamera += ResetCameraIcons;
                _cam1.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam1);
            }
            else
            {
                CameraToggleOnOff(ref _cam1);
            }
        }

        private void WebCam2Btn_Click(object sender, EventArgs e)
        {
            if (_cam2 == null)
            {
                WebCam_Select webCamSel = new WebCam_Select();
                if (webCamSel.DevicesConnected() > 1)
                {
                    webCamSel.ShowDialog();
                }
                _cam2 = webCamSel.GetDevice();

                if (_cam2 != null)
                {   
                    _cam2.CamType = CameraType.USB;
                    _cam2.CamNum = 2;
                    _cam2.Connected = false;
                    _cam2.Url = "";
                    _cam2.Username = "";
                    _cam2.Password = "";                    
                    _cam2.CameraScreen = CameraWindow2;
                    _cam2.IPCameraButton = IPCam2Btn;
                    _cam2.WebCameraButton = WebCam2Btn;
                    _cam2.SnapshotButton = Cam2SnapshotBtn;
                    _cam2.AVICaptueButton = Cam2CapAVIBtn;
                    _cam2.FullscreenButton = FullScreen2Btn;                   
                    _cam2.WriteTimer = WriteAVITimer2;
                    _cam2.MotionTimer = Motion2Timer;
                    _cam2.CameraSettings = CamSettings[1];
                    _cam2.PrivacyStart = new Point(0, 0);
                    _cam2.PrivacyEnd = new Point(0, 0);
                    _cam2.WindowLocation = new Point(430, 33);
                    _cam2.WindowOffset = new Point(325, 30);
                }
                else
                {
                    MessageBox.Show("No USB devices found");
                    return;
                }
                _cam2.StopCamera += ResetCameraIcons;
                _cam2.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam2);
            }
            else
            {
                CameraToggleOnOff(ref _cam2);
            }
        }

        private void IPCam2Btn_Click(object sender, EventArgs e)
        {
            if (_cam2 == null)
            {
                _cam2 = new IPDevice
                {
                    CamType = CameraType.IP,
                    CamNum = 2,
                    Connected = false,
                    Url = "",
                    Username = "",
                    Password = "",
                    CameraScreen = CameraWindow2,
                    IPCameraButton = IPCam2Btn,
                    WebCameraButton = WebCam2Btn,
                    SnapshotButton = Cam2SnapshotBtn,
                    AVICaptueButton = Cam2CapAVIBtn,
                    FullscreenButton = FullScreen2Btn,
                    WriteTimer = WriteAVITimer2,
                    MotionTimer = Motion2Timer,
                    CameraSettings = CamSettings[1],
                    PrivacyStart = new Point(0, 0),
                    PrivacyEnd = new Point(0, 0),
                    WindowLocation = new Point(430, 33),
                    WindowOffset = new Point(325, 30),
                    ImageProcessor = new BitmapProcessor(),
                    MotionCalculator = new DefaultMotionCalculator()
                };

                _cam2.StopCamera += ResetCameraIcons;
                _cam2.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam2);
            }
            else
            {
                CameraToggleOnOff(ref _cam2);
            }
        }

        private void WebCam3btn_Click(object sender, EventArgs e)
        {
            if (_cam3 == null)
            {
                WebCam_Select webCamSel = new WebCam_Select();
                if (webCamSel.DevicesConnected() > 1)
                {
                    webCamSel.ShowDialog();
                }
                _cam3 = webCamSel.GetDevice();

                if (_cam3 != null)
                {
                    _cam3.CamType = CameraType.USB;
                    _cam3.CamNum = 3;
                    _cam3.Connected = false;
                    _cam3.Url = "";
                    _cam3.Username = "";
                    _cam3.Password = "";
                    _cam3.CameraScreen = CameraWindow3;
                    _cam3.IPCameraButton = IPCam3Btn;
                    _cam3.WebCameraButton = WebCam3btn;
                    _cam3.SnapshotButton = Cam3SnapshotBtn;
                    _cam3.AVICaptueButton = Cam3CapAVIBtn;
                    _cam3.FullscreenButton = FullScreen3Btn;
                    _cam3.WriteTimer = WriteAVITimer3;
                    _cam3.MotionTimer = Motion3Timer;
                    _cam3.CameraSettings = CamSettings[2];
                    _cam3.PrivacyStart = new Point(0, 0);
                    _cam3.PrivacyEnd = new Point(0, 0);
                    _cam3.WindowLocation = new Point(92, 365);
                    _cam3.WindowOffset = new Point(4, 270);
                }
                else
                {
                    MessageBox.Show("No USB devices found");
                    return;
                }
                _cam3.StopCamera += ResetCameraIcons;
                _cam3.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam3);
            }
            else
            {
                CameraToggleOnOff(ref _cam3);
            }
        }

        private void IPCam3btn_Click(object sender, EventArgs e)
        {
            if (_cam3 == null)
            {
                _cam3 = new IPDevice
                {
                    CamType = CameraType.IP,
                    CamNum = 3,
                    Connected = false,
                    Url = "",
                    Username = "",
                    Password = "",
                    CameraScreen = CameraWindow3,
                    IPCameraButton = IPCam3Btn,
                    WebCameraButton = WebCam3btn,
                    SnapshotButton = Cam3SnapshotBtn,
                    AVICaptueButton = Cam3CapAVIBtn,
                    FullscreenButton = FullScreen3Btn,
                    WriteTimer = WriteAVITimer3,
                    MotionTimer = Motion3Timer,
                    CameraSettings = CamSettings[2],
                    PrivacyStart = new Point(0, 0),
                    PrivacyEnd = new Point(0, 0),
                    WindowLocation = new Point(92, 365),
                    WindowOffset = new Point(4, 270),
                    ImageProcessor = new BitmapProcessor(),
                    MotionCalculator = new DefaultMotionCalculator()
                };
                _cam3.StopCamera += ResetCameraIcons;
                _cam3.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam3);
            }
            else
            {
                CameraToggleOnOff(ref _cam3);
            }
        }

        private void WebCam4btn_Click(object sender, EventArgs e)
        {
            if (_cam4 == null)
            {
                WebCam_Select webCamSel = new WebCam_Select();
                if (webCamSel.DevicesConnected() > 1)
                {
                    webCamSel.ShowDialog();
                }
                _cam4 = webCamSel.GetDevice();

                if (_cam4 != null)
                {
                    _cam4.CamType = CameraType.USB;
                    _cam4.CamNum = 4;
                    _cam4.Connected = false;
                    _cam4.Url = "";
                    _cam4.Username = "";
                    _cam4.Password = "";
                    _cam4.CameraScreen = CameraWindow4;
                    _cam4.IPCameraButton = IPCam4Btn;
                    _cam4.WebCameraButton = WebCam4btn;
                    _cam4.SnapshotButton = Cam4SnapshotBtn;
                    _cam4.AVICaptueButton = Cam4CapAVIBtn;
                    _cam4.FullscreenButton = FullScreen4Btn;
                    _cam4.WriteTimer = WriteAVITimer4;
                    _cam4.MotionTimer = Motion4Timer;
                    _cam4.CameraSettings = CamSettings[3];
                    _cam4.PrivacyStart = new Point(0, 0);
                    _cam4.PrivacyEnd = new Point(0, 0);
                    _cam4.WindowLocation = new Point(430, 365);
                    _cam4.WindowOffset = new Point(325, 270);
                }
                else
                {
                    MessageBox.Show("No USB devices found");
                    return;
                }
                _cam4.StopCamera += ResetCameraIcons;
                _cam4.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam4);
            }
            else
            {
                CameraToggleOnOff(ref _cam4);
            }
        }

        private void IPCam4btn_Click(object sender, EventArgs e)
        {
            if (_cam4 == null)
            {
                _cam4 = new IPDevice
                {
                    CamType = CameraType.IP,
                    CamNum = 4,
                    Connected = false,
                    Url = "",
                    Username = "",
                    Password = "",
                    CameraScreen = CameraWindow4,
                    IPCameraButton = IPCam4Btn,
                    WebCameraButton = WebCam4btn,
                    SnapshotButton = Cam4SnapshotBtn,
                    AVICaptueButton = Cam4CapAVIBtn,
                    FullscreenButton = FullScreen4Btn,
                    WriteTimer = WriteAVITimer4,
                    MotionTimer = Motion4Timer,
                    CameraSettings = CamSettings[3],
                    PrivacyStart = new Point(0, 0),
                    PrivacyEnd = new Point(0, 0),
                    WindowLocation = new Point(430, 365),
                    WindowOffset = new Point(325, 270),
                    ImageProcessor = new BitmapProcessor(),
                    MotionCalculator = new DefaultMotionCalculator()
                };
                _cam4.StopCamera += ResetCameraIcons;
                _cam4.FrameCaptured += (args) =>
                {
                    args.Cam.LastFrame = args.Cam.LastFrame ?? args.Frame;
                    Point formLocation = new Point(Location.X, Location.Y);
                    Point mouseLocation = new Point(MousePosition.X, MousePosition.Y);
                    Thread checkMotion = new Thread(() => new CameraFeedProcessor(args.Cam).ProcessImage(args, formLocation, mouseLocation));
                    checkMotion.Start();
                    checkMotion.Join(1000);
                };

                CameraToggleOnOff(ref _cam4);
            }
            else
            {
                CameraToggleOnOff(ref _cam4);
            }
        }
        #endregion

        #region User Activated Recording Start/Stop
        private void Cam1CapAVIBtn_Click(object sender, EventArgs e)
        {
            StartStopCapture(ref _cam1);
        }

        private void Cam2CapAVIBtn_Click(object sender, EventArgs e)
        {
            StartStopCapture(ref _cam2);
        }

        private void Cam3CapAVIBtn_Click(object sender, EventArgs e)
        {
            StartStopCapture(ref _cam3);
        }

        private void Cam4CapAVIBtn_Click(object sender, EventArgs e)
        {
            StartStopCapture(ref _cam4);
        }
        #endregion

        #region Motion Recording
        public void MotionActivator(ref ICamera Cam)
        {
            //after x seconds check to see if motion still detected, if it is keep recording otherwise disable recording
            if (Cam.MotionMonitor)
            {
                //if not already manually recording
                if (!Cam.CaptureFlag)
                {
                    Logger.AppendToLog($"{DateTime.Now}   Cam {Cam.CamNum} Motion Detected Recording Started");
                    Cam.CaptureFlag = false;
                    //start a motion activated recording
                    StartStopCapture(ref Cam);
                    Cam.MotionTimer.Interval = 1000;
                }
                else
                {
                    //set the timer so that it captures frames for a specified number of seconds every time motion is detected
                    //the timer is reset so that it records for an additional x number of seconds after the last movement detected
                    Cam.MotionTimer.Interval = (Convert.ToInt32(SettingOpt.Mot1RecSecs.Text)) * 1000;
                }
            }
            else
            {
                //close the file and stop recording
                Cam.CaptureFlag = true;
                StartStopCapture(ref Cam);
                Cam.MotionTimer.Enabled = false;
                Logger.AppendToLog($"{DateTime.Now}   Cam {Cam.CamNum} Motion Detected Recording Finished");
                //reset timer interval
                Cam.MotionTimer.Interval = 100;
            }

            //this ensures recording starts after motion detected
            Cam.MotionMonitor = false;
        }

        private void Motion1Timer_Tick(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Motion1 Timer Tick");
            MotionActivator(ref _cam1);
        }

        private void Motion2Timer_Tick(object sender, EventArgs e)
        {
            MotionActivator(ref _cam2);
        }

        private void Motion3Timer_Tick(object sender, EventArgs e)
        {
            MotionActivator(ref _cam3);
        }

        private void Motion4Timer_Tick(object sender, EventArgs e)
        {
            MotionActivator(ref _cam4);
        }
        #endregion

        #region Clip Capture
        public void StartStopCapture(ref ICamera Cam)
        {
            //change the recording status flag & start the write procedure if true, by default the capture flag is set to false
            Cam.CaptureFlag = !Cam.CaptureFlag;
            Cam.AVICaptueButton.BackgroundImage = GetImage("MovieRec");
            Cam.WriteTimer.Enabled = true;

            //if recording active and stop recording is selected
            if (!Cam.CaptureFlag)
            {
                Cam.AVICaptueButton.BackgroundImage = GetImage("Movie");

                if (Cam.ClipWriter != null)
                {
                    EndCaptureToFile(ref Cam);

                    if (!Cam.CameraSettings.RecordOnMotionEnabled)
                    {
                        Logger.AppendToLog($"{DateTime.Now}    Cam {Cam.CamNum} Manual Recording Stopped");
                    }
                }
            }
            else
            {
                if (!Cam.CameraSettings.RecordOnMotionEnabled)
                {
                    if (Cam.ClipWriter == null)
                    {
                        CreateClip(Cam);
                    }
                    Logger.AppendToLog($"{DateTime.Now}   Cam {Cam.CamNum} Manual Recording Started");
                }
            }
        }

        public void AddFrameToClip(ref ICamera Cam)
        {
            if (Cam.CaptureFlag)
            {
                try
                {
                    Cam.ClipWriter.AddFrameToFile(Cam.LastFrame);
                }
                catch (Exception ex)
                {
#if DEBUG
                    Console.Out.WriteLine("Error adding frame to clip, Cam" + Cam.CamNum);
#endif
                    if (!Cam.IsGetFramesThreadRunning())
                    {
                        Cam.AVICaptueButton.BackgroundImage = GetImage("Movie");
                        EndCaptureToFile(ref Cam);
                    }
                }
            }
        }

        private void WriteAVITimer1_Tick(object sender, EventArgs e)
        {
            AddFrameToClip(ref _cam1);
        }

        private void WriteAVITimer2_Tick(object sender, EventArgs e)
        {
            AddFrameToClip(ref _cam2);
        }

        private void WriteAVITimer3_Tick(object sender, EventArgs e)
        {
            AddFrameToClip(ref _cam3);
        }

        private void WriteAVITimer4_Tick(object sender, EventArgs e)
        {
            AddFrameToClip(ref _cam4);
        }
        #endregion

        #region Clip File Managment
        private void CreateClip(ICamera cam)
        {
            int fps = cam.CameraSettings.FPS;
            cam.WriteTimer.Interval = 1000 / fps;
            DateTime date = DateTime.Now;
            cam.FileNameCam = string.Format("Cam" + cam.CamNum + " " + string.Format("{0:dd}", date) + "-" + string.Format("{0:MM}", date) + "-" + string.Format("{0:yyyy}", date) 
                + " " + string.Format("{0:HH}", date) + "." + string.Format("{0:mm}", date) + "." + string.Format("{0:ss}", date) + ".avi");
            cam.ClipWriter = new AVIWriter();
            if (fps == 1) cam.ClipWriter.FrameRate = 1;
            if (fps == 12) cam.ClipWriter.FrameRate = 9;
            if (fps == 25) cam.ClipWriter.FrameRate = 18;
            cam.ClipWriter.CreateFile(cam.FileNameCam, cam.CameraScreen.Width, cam.CameraScreen.Height);
        }

        public void EndCaptureToFile(ref ICamera cam)
        {
            cam.WriteTimer.Enabled = false;
            cam.ClipWriter.CloseFile();
            //Cam.ClipWriter = null;
            FileRename(ref cam);
        }

        public void FileRename(ref ICamera cam)
        {
            //check if its a motion detect recording, user manual recording
            var recMode = cam.CameraSettings.RecordOnMotionEnabled ? " M" : " U";
            DateTime date = DateTime.Now;
            var fileName = string.Format("Cam" + cam.CamNum + " " + string.Format("{0:dd}", date) + "-" + string.Format("{0:MM}", date) + "-" + string.Format("{0:yyyy}", date)
                + " " + string.Format("{0:HH}", date) + "." + string.Format("{0:mm}", date) + "." + string.Format("{0:ss}", date) + recMode + ".avi");
            //rename the file
            File.Move(cam.FileNameCam, clipsPath + fileName);
        }
        #endregion

        #region Take Snapshot
        private void Cam1SnapshotBtn_Click(object sender, EventArgs e)
        {
            SaveSnapshot(_cam1);
            Logger.AppendToLog($"{DateTime.Now}   Cam{_cam1.CamNum} Snapshot Taken");
        }

        private void Cam2SnapshotBtn_Click(object sender, EventArgs e)
        {
            SaveSnapshot(_cam2);
            Logger.AppendToLog($"{DateTime.Now}   Cam{_cam2.CamNum} Snapshot Taken");
        }

        private void Cam3SnapshotBtn_Click(object sender, EventArgs e)
        {
            SaveSnapshot(_cam3);
            Logger.AppendToLog($"{DateTime.Now}   Cam{_cam3.CamNum} Snapshot Taken");
        }

        private void Cam4SnapshotBtn_Click(object sender, EventArgs e)
        {
            SaveSnapshot(_cam4);
            Logger.AppendToLog($"{DateTime.Now}   Cam{_cam4.CamNum} Snapshot Taken");
        }

        private void SaveSnapshot(ICamera cam)
        {
            try
            {
                var time = $"Cam{cam.CamNum} {DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} {DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}";
                cam.CameraScreen.Image.Save(snapshotsPath + time + ".bmp");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region Live View FullScreen
        private void FullScreen1Btn_Click(object sender, EventArgs e)
        {
            ShowCamFullScreen(_cam1);
        }

        private void FullScreen2Btn_Click(object sender, EventArgs e)
        {
            ShowCamFullScreen(_cam2);
        }

        private void FullScreen3Btn_Click(object sender, EventArgs e)
        {
            ShowCamFullScreen(_cam3);
        }

        private void FullScreen4Btn_Click(object sender, EventArgs e)
        {
            ShowCamFullScreen(_cam4);
        }

        private void ShowCamFullScreen(ICamera cam)
        {
            FullscreenFrm fullscreen = new FullscreenFrm(cam);
            fullscreen.Width = Screen.PrimaryScreen.WorkingArea.Width;
            fullscreen.Height = Screen.PrimaryScreen.WorkingArea.Height;
            fullscreen.ShowDialog();
        }
        #endregion

        #region Private Area Select
        private void SetPrivateAreaStartPosition(ICamera cam, Point offset)
        {
            if(cam.CameraSettings.PrivacyEnabled)
            {
                Cursor = Cursors.Cross;
                int valX = Location.X + cam.CameraScreen.Location.X + offset.X;
                int valY = Location.Y + cam.CameraScreen.Location.Y + offset.Y;
                cam.PrivacyStart = new Point(MousePosition.X - valX, MousePosition.Y - valY);
                cam.CameraSettings.PrivacySelected = false;
            }
        }

        private void SetPrivateAreaEndPosition(ICamera cam, Point offset)
        {
            if (cam.CameraSettings.PrivacyEnabled)
            {
                int valX = Location.X + cam.CameraScreen.Location.X + offset.X;
                int valY = Location.Y + cam.CameraScreen.Location.Y + offset.Y;
                cam.PrivacyEnd = new Point((MousePosition.X - valX) - cam.PrivacyStart.X, (MousePosition.Y - valY) - cam.PrivacyStart.Y);
                cam.CameraSettings.PrivacySelected = true;
                Cursor = Cursors.Default;
            }
        }

        private void CameraWindow1_MouseDown(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(90, 30);
            SetPrivateAreaStartPosition(_cam1, cameraScreenOffset);
        }

        private void CameraWindow1_MouseUp(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(90, 30);
            SetPrivateAreaEndPosition(_cam1, cameraScreenOffset);
        }

        private void CameraWindow2_MouseDown(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(432,33);
            SetPrivateAreaStartPosition(_cam2, cameraScreenOffset);
        }

        private void CameraWindow2_MouseUp(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(432, 33);
            SetPrivateAreaEndPosition(_cam2, cameraScreenOffset);
        }

        private void CameraWindow3_MouseDown(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(92, 365);
            SetPrivateAreaStartPosition(_cam3, cameraScreenOffset);
        }

        private void CameraWindow3_MouseUp(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(92, 365);
            SetPrivateAreaEndPosition(_cam3, cameraScreenOffset);
        }

        private void CameraWindow4_MouseDown(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(428, 365);
            SetPrivateAreaStartPosition(_cam4, cameraScreenOffset);
        }

        private void CameraWindow4_MouseUp(object sender, MouseEventArgs e)
        {
            Point cameraScreenOffset = new Point(428, 365);
            SetPrivateAreaEndPosition(_cam4, cameraScreenOffset);
        }
        #endregion

        #region Search and Playback
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Logger.AppendToLog($"{DateTime.Now}   Search Screen Accessed");
            SearchFrm searchOpt = new SearchFrm(Logger);
            searchOpt.ShowDialog();
        }

        private void PlayBackBtn_Click(object sender, EventArgs e)
        {
            Vlc vlc = new Vlc();
            Logger.AppendToLog($"{DateTime.Now}   Playback via Main Screen");
            Playback playback = new Playback(vlc);
            playback.Show();
            playback.PlayBackSelect();
        }
        #endregion
    }
}
