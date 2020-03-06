using System;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace DVR.Devices
{
    public class USBDevice: Camera
    {
        Thread GetFramesThread = null;
        public string Name { get; set; }
        public string Version { get; set; }
        int index = 0;
        int deviceHandle;
        Bitmap bmp;
        int camwindowhandle = 0;
        int CaptureWidth = 0;
        int CaptureHeight = 0;
        bool fault = false;
        static ArrayList Webcams = new ArrayList();

        private const short WM_CAP = 1024;
        private const int WM_CAP_DRIVER_CONNECT = 1034;
        private const int WM_CAP_DRIVER_DISCONNECT = 1035;
        private const int WM_CAP_SET_PREVIEW = 1074;
        private const int WM_CAP_SET_PREVIEWRATE = 1076;
        private const int WM_CAP_SET_SCALE = 1077;
        const int WM_CAP_SET_VIDEOFORMAT = 1069;
        const int WM_CAP_GRAB_FRAME_NOSTOP = 1085;
        const int WM_CAP_SET_CALLBACK_FRAME = 1029;
        public const int WM_CAP_GET_FRAME = 1084;

        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;

        [DllImport("avicap32.dll")]
        protected static extern int capCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszWindowName,
            int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);

        //This function enables enumerate the web cam devices
        [DllImport("avicap32.dll")]
        protected static extern bool capGetDriverDescriptionA(short wDriverIndex,
            [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName,
           int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);

        [DllImport("user32", EntryPoint = "SendMessageA")]
        protected static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)] object lParam);
        
        [DllImport("user32", EntryPoint = "SendMessage")]
        static extern int SendBitmapMessage(int hWnd, uint wMsg, int wParam, ref BITMAPINFO lParam);

        [DllImport("user32", EntryPoint = "SendMessage")]
        static extern int SendHeaderMessage(int hWnd, uint wMsg, int wParam, CallBackDelegate lParam);

        delegate void CallBackDelegate(IntPtr hwnd, ref VIDEOHEADER hdr);
        CallBackDelegate delegateFrameCallBack;

        [DllImport("user32")]
        protected static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32")]
        protected static extern bool DestroyWindow(int hwnd);

        [StructLayout(LayoutKind.Sequential)]
        public struct VIDEOHEADER
        {
            public IntPtr lpData;
            public uint dwBufferLength;
            public uint dwBytesUsed;
            public uint dwTimeCaptured;
            public uint dwUser;
            public uint dwFlags;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.SafeArray)]
            byte[] dwReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFOHEADER
        {
            public uint biSize;
            public int biWidth;
            public int biHeight;
            public ushort biPlanes;
            public ushort biBitCount;
            public uint biCompression;
            public uint biSizeImage;
            public int biXPelsPerMeter;
            public int biYPelsPerMeter;
            public uint biClrUsed;
            public uint biClrImportant;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFO
        {
            public BITMAPINFOHEADER bmiHeader;
            public int bmiColors;
        }

        public USBDevice()
        {
            delegateFrameCallBack = FrameCallBack;
        }

        public override string ToString()
        {
            return Name;
        }

        public bool WebcamConnect(int handle, int width, int height)
        {
            CaptureWidth = width;
            CaptureHeight = height;

            BITMAPINFO bInfo = new BITMAPINFO();
            bInfo.bmiHeader = new BITMAPINFOHEADER();
            bInfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bInfo.bmiHeader);
            bInfo.bmiHeader.biWidth = CaptureWidth;
            bInfo.bmiHeader.biHeight = CaptureHeight;
            bInfo.bmiHeader.biPlanes = 1;
            bInfo.bmiHeader.biBitCount = 24; // bits per frame, 24 - RGB

            //the handle to the picturebox related to the camera on the main form
            camwindowhandle = handle;

            string deviceIndex = Convert.ToString(index);

            //creates a capture window but we dont display the actual preview
            deviceHandle = capCreateCaptureWindowA(ref deviceIndex, WS_CHILD, 0, 0, CaptureWidth, CaptureHeight, camwindowhandle, 0);

            //connect to the device
            if (SendMessage(deviceHandle, WM_CAP_DRIVER_CONNECT, index, 0)>0)
            {
                //set the video format
                SendBitmapMessage(deviceHandle, WM_CAP_SET_VIDEOFORMAT, Marshal.SizeOf(bInfo), ref bInfo);
                fault = false;
                return true;
            }

            MessageBox.Show("Cannot Connect to USB Device");
            fault = true;
            return false;
        }

        public override void InitCamera()
        {
            IPCameraButton.Enabled = false;

            //handle to the picturebox needed to connect to the webcam
            int handle = CameraScreen.Handle.ToInt32();

            if (LowRes)
            {
                //try connect to the webcam at low resolution
                if (!(WebcamConnect(handle, 320, 240)))
                {
                    IPCameraButton.Enabled = true;
                }
            }
            else
            {
                //try connect to the webcam at high resolution
                if (!(WebcamConnect(handle, 640, 480)))
                {
                    IPCameraButton.Enabled = true;
                }
            }
        }

        public override void StartDevice()
        {
            if (GetFramesThread == null)
            {
                if (!fault)
                {
                    GetFramesThread = new Thread(GetFrames);
                    GetFramesThread.Start();
                    Connected = true;
                }
            }
        }

        public override void StopDevice(string error)
        {
            Connected = false;
            RaiseStopCameraEvent(this, error);
            //GetFramesThread.Abort();
            GetFramesThread.Suspend();
            Stop();
        }

        public void GetFrames()
        {
            while (true)
            {
                SendMessage(deviceHandle, WM_CAP_GET_FRAME, 0, 0);
                SendHeaderMessage(deviceHandle, WM_CAP_SET_CALLBACK_FRAME, 0, delegateFrameCallBack);
                Thread.Sleep(35);
            }
        }

        public void FrameCallBack(IntPtr hwnd, ref VIDEOHEADER hdr)
        {
            try
            {
                bmp = new Bitmap(CaptureWidth, CaptureHeight, 3 * CaptureWidth, System.Drawing.Imaging.PixelFormat.Format24bppRgb, hdr.lpData);
                //image is captured upside down so flip 
                bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

                if (bmp.Width > 320 && bmp.Height > 240)
                {
                    Bitmap resizedBitmap = new Bitmap(bmp, new Size(320, 240));
                    RaiseFrameCapturedEvent(new CameraEventArgs(this, resizedBitmap));
                }
                else
                {
                    RaiseFrameCapturedEvent(new CameraEventArgs(this, bmp));
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                Console.Out.WriteLine("USBDevice: " + ex.Message);
#endif
            }
        }

        /// Stop the webcam and destroy the handle
        public void Stop()
        {
            try
            {
                //SendMessage(deviceHandle, WM_CAP_DRIVER_DISCONNECT, index, 0);
                //DestroyWindow(deviceHandle);
                //RaiseFrameCapturedEvent = null;
            }
            catch (Exception ex)
            {

            }
        }

        public override bool IsGetFramesThreadRunning()
        {
            throw new NotImplementedException();
        }
    }
}
