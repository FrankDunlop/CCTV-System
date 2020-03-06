using System;
using System.Windows.Forms;
using DVR.Devices;

namespace DVR.Fullscreen
{
    public partial class FullscreenFrm : Form
    {
        private readonly ICamera _cam;

        public FullscreenFrm(ICamera cam)
        {
            InitializeComponent();
            _cam = cam;
            timer1.Enabled = true;
        }

        //exit the fullscreen form and stop the image grab
        private void FullscreenPBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }

        //grab the image from the relevant camera window and use it fullscreen
        private void timer1_Tick(object sender, EventArgs e)
        {
            FullscreenPBox.Image = _cam.LastFrame;
        }
    }
}