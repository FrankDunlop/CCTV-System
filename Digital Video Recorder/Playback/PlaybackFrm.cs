using System;
using System.Windows.Forms;
using DVR.LibVlc;

namespace DVR.PlaybackScreen
{
    public partial class Playback : Form
    {
        public Vlc Vlc { get; set; } 

        public Playback(Vlc vlc)
        {
            InitializeComponent();
            Vlc = vlc;
        }

        private void Cam1OpenBtn_Click(object sender, EventArgs e)
        {
            Vlc.Stop();
            PlayBackSelect();
        }

        private void Cam1PlayBtn_Click(object sender, EventArgs e)
        {
            TrackBar1Timer.Enabled = true;
            Vlc.Play();
        }

        private void Cam1PauseBtn_Click(object sender, EventArgs e)
        {
            Vlc.Pause();
            TrackBar1Timer.Enabled = true;
        }

        private void Cam1StopBtn_Click(object sender, EventArgs e)
        {
            Vlc.Stop();
            trackBar1.Value = 0;
        }

        private void Cam1SlowBtn_Click(object sender, EventArgs e)
        {
            Vlc.SpeedSlower();
        }

        private void Cam1FastBtn_Click(object sender, EventArgs e)
        {
            Vlc.SpeedFaster();
        }

        private void Cam1ExitBtn_Click(object sender, EventArgs e)
        {
            Vlc.Stop();
            Close();
        }

        public void CamFilePlayback(string fileName)
        {
            try
            {
                //dispose of any currently playing files
                Vlc.Dispose();
                Cam1Playback.Visible = true;
                var clip = Properties.Settings.Default.ClipsPath + fileName;
                Text = fileName;
                //initialize the vlc object and assign a picturebox for it
                Vlc.Initialize();
                Vlc.VideoOutput = PlaybackWindow;
                Vlc.AddTarget(clip);
                //play the file and update the trackbar
                trackBar1.Maximum = 100;
                Vlc.Play();
                TrackBar1Timer.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Playback Error: " + ex.Message);
            }
        }

        public void PlayBackSelect()
        {
            Vlc.Initialize();
            Vlc.VideoOutput = PlaybackWindow;
            Vlc.PlaylistClear();
            OpenFileDialog fileSelect = new OpenFileDialog();

            if (fileSelect.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine(fileSelect.FileName);
            }

            var file = (fileSelect.ToString()).Substring(55);
            if (file != " ")
            {
                Vlc.AddTarget(file);
                Text = file.Substring(14);
                trackBar1.Maximum = 100;
                Vlc.Play();
                TrackBar1Timer.Enabled = true;
            }
        }

        private void TrackBar1Timer_Tick(object sender, EventArgs e)
        {
            if (Vlc.IsPlaying)
            {
                float pos = Vlc.PositionGet;
                if (Convert.ToInt32(pos) < 0)
                {
                    pos = 1;
                }
                if (pos > 1)
                {
                    trackBar1.Value = 0;
                    Vlc.Stop();
                    TrackBar1Timer.Enabled = false;
                }
                else
                {
                    trackBar1.Value = (int)(pos * 100);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar1Timer.Enabled = true;
            int val = trackBar1.Value;
            float newVal = val;
            float test = (newVal / 100);
            Vlc.PositionSet(test);
            Vlc.Play();
        }
    }
}
