using System;
using System.Windows.Forms;
using DVR.LibVlc;

namespace SinglePlaybackScreen
{
    public partial class SinglePlayback : Form
    {
        Vlc vlc1 = new Vlc();
        String cameranumber;

        public SinglePlayback(String camnum)
        {
            InitializeComponent();
            cameranumber = camnum;
            this.Text = cameranumber + " Playback";
            Display();
        }

        public void Display()
        {
            String file;
            vlc1.Initialize();

            //vlc1.VideoOutput = Cam1PlaybackWindow;
            vlc1.PlaylistClear();
            OpenFileDialog FileSelect = new OpenFileDialog();

            if (FileSelect.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(FileSelect.FileName);
            }

            file = (FileSelect.ToString()).Substring(55);

            vlc1.AddTarget(file);

            file = file.Substring(file.Length - 23, 18);

            //Cam1PlaybackLbl.Enabled = true;
            //Cam1PlaybackLbl.Text = "File Date: " + (file.Remove(10)) + "   Time:" + file.Substring(file.Length - 8, 6);

            //trackBar1.Maximum = 100;
            timer1.Enabled = true;
            vlc1.Play();
        }

        private void CamPlayBtn_Click(object sender, EventArgs e)
        {
            //Cam1PlaybackLbl.Enabled = true;
            timer1.Enabled = true;
            vlc1.Play();
        }

        private void CamOpenBtn_Click(object sender, EventArgs e)
        {
            vlc1.Stop();
            Display();
        }

        private void CamExitBtn_Click(object sender, EventArgs e)
        {
            vlc1.Stop();
            this.Close();
        }

        private void CamPauseBtn_Click(object sender, EventArgs e)
        {
            vlc1.Pause();
        }

        private void CamFastBtn_Click(object sender, EventArgs e)
        {
            vlc1.SpeedFaster();
        }

        private void CamSlowBtn_Click(object sender, EventArgs e)
        {
            vlc1.SpeedSlower();
        }

        private void CamStopBtn_Click(object sender, EventArgs e)
        {
            vlc1.Stop();
            //trackBar1.Value = 0;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //int val = trackBar1.Value;
            //float newval = (float)(val);
            //float test = (newval / 100);
            //vlc1.PositionSet(test);
            //vlc1.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (vlc1.IsPlaying)
            {
                float myfloat = vlc1.PositionGet;
                if (myfloat < 0)
                {
                    myfloat = 1;
                }
                if (myfloat > 1)
                {
                    //trackBar1.Value = 0;
                    vlc1.Stop();
                    timer1.Enabled = false;
                    //Cam1PlaybackLbl.Enabled = false;
                }
                else
                {
                    //trackBar1.Value = (int)(myfloat * 100);
                }
            }
            else
            {
                //trackBar1.Value = 0;
                //vlc1.Stop();
                //Cam1PlaybackLbl.Enabled = false;
                timer1.Enabled = false;
            }
        }
    }
}
