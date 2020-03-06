using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DVR.Devices
{
    public partial class WebCam_Select : Form
    {
        [DllImport("avicap32.dll")]
        static extern bool capGetDriverDescription(int wDriverIndex,
        [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);

        USBDevice _selectedDevice;
        int _numDevices = 0;

        static ArrayList Webcams = new ArrayList();

        public WebCam_Select()
        {
            InitializeComponent();
            //get the devices on the system by driver
            GetAttachedUSBDevices();
        }

        public void GetAttachedUSBDevices()
        {
            string name = "".PadRight(40);
            string version = "".PadRight(25);
            cboUSBDevices.Items.Clear();

            //we can have up to 10 usb devices or webcams
            for (int i = 0; i < 10; i++)
            {
                //get the driver details
                if (capGetDriverDescription(i, ref name, 40, ref version, 25))
                {
                    USBDevice webcam = new USBDevice();
                    webcam.Name = name.Trim();
                    webcam.Version = version.Trim();
                    Webcams.Add(webcam);
                    cboUSBDevices.Items.Add(webcam);
                    _numDevices += 1;
                }
            }
            //cboUSBDevices.SelectedIndex = 0;
        }

        public int DevicesConnected()
        {
            //if only one device driver
            if (_numDevices == 1)
            {
                //return it
                _selectedDevice = (USBDevice)Webcams[0];
            }
            return _numDevices;
        }

        public void BtnConnect_Click(object sender, EventArgs e)
        {
            if (cboUSBDevices.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select A Device");
            }
            else
            {
                //if more than one driver listed on the system return the selected one
                _selectedDevice = (USBDevice)Webcams[cboUSBDevices.SelectedIndex];
                Close();
            }
        }

        public USBDevice GetDevice()
        {
            return _selectedDevice;
        }
    }
}
