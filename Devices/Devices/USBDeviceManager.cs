using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;

namespace USBDevx
{
   public class USBDeviceManager
   {
        [DllImport("avicap32.dll")]static extern bool capGetDriverDescription(int wDriverIndex,
        [MarshalAs(UnmanagedType.VBByRefStr)]ref String lpszName, int cbName, [MarshalAs(UnmanagedType.VBByRefStr)] ref String lpszVer, int cbVer);
      
        //create an array of webcam objects
       static ArrayList Webcams = new ArrayList();

        public USBDeviceManager()
        {
            String name = "".PadRight(40);
            String version = "".PadRight(25);

            //we can have up to 10 usb devices or webcams
            for (int i = 0; i < 10; i++)
            {
                if (capGetDriverDescription(i, ref name, 40, ref version, 25))
                {
                    Device webcam = new Device(i);
                    webcam.Name = name.Trim();
                    webcam.Version = version.Trim();

                    Webcams.Add(webcam); 
                }
            }
        }

        public Device GetWebcam(int index)
        {
            //return the webcam details at the specified index
            return (Device)Webcams[index];
        }
    }
}