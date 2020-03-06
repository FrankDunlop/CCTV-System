using System;
using System.IO;
using System.Windows.Forms;
using DVR.LibVlc;
using DVR.Logging;
using DVR.PlaybackScreen;

namespace DVR.Search
{
    public partial class SearchFrm : Form
    {
        public ILogger Logger { get; set; }
        private readonly string _clipsPath = Properties.Settings.Default.ClipsPath;

        public SearchFrm(ILogger logger)
        {
            InitializeComponent();
            Logger = logger;
            UpdateCalendar();
        }

        #region Automatic Date Search
        private void UpdateCalendar()
        {
            FileListlst.Items.Clear();

            try
            {
                DirectoryInfo dir = new DirectoryInfo(_clipsPath);
                FileInfo[] aviFiles = dir.GetFiles("*.avi");

                int numFiles = aviFiles.Length;
                if (numFiles == 0)
                {
                    lblNumFiles.Text = ("No Recordings Available");
                }
                else
                {
                    numFiles = 0;
                    foreach (FileInfo f in aviFiles)
                    {
                        string fileName = f.Name;
                        string fileDate = fileName.Substring(5, 10);
                        DateTime file = Convert.ToDateTime(fileDate);
                        string dateNow = DateTime.Now.ToString();
                        dateNow = dateNow.Substring(0, 10);
                        dateNow = dateNow.Replace('/', '-');

                        //ensure the avi file is not currently being recorded
                        //if the end time is not part of the filename it is being recorded
                        //if (filename.Length > 30)
                        //{
                            monthCalendar1.AddBoldedDate(file);
                            if (dateNow == fileDate)
                            {
                                numFiles += 1;
                                FileListlst.Items.Add(fileName);
                            }
                        //}
                    }

                    if (numFiles == 1)
                    {
                        lblNumFiles.Text = ("1 Recording Available for Todays Date");
                    }
                    else
                    {
                        lblNumFiles.Text = (+numFiles + " Recordings Available for Todays Date");
                    }
                }
            }
            catch(Exception ex)
            {
                var error = ex.ToString();
                MessageBox.Show(error);
            } 
        }
        #endregion

        #region Manual Date Search
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(monthCalendar1.SelectionStart.ToLongDateString());
            ValidFileCheck(selectedDate);
        }

        private void SearchDateBtn_Click(object sender, EventArgs e)
        {
            if (QueryDate.Text != "")
            {
                ValidFileCheck(DateTime.Parse(QueryDate.Text));
            }
        }

        private void ValidFileCheck(DateTime selectedDate)
        {
            try
            {
                FileListlst.Items.Clear();
                DateTime[] validDates = new DateTime[monthCalendar1.BoldedDates.Length + 1];
                DirectoryInfo dir = new DirectoryInfo(_clipsPath);
                FileInfo[] aviFiles = dir.GetFiles("*.avi");

                int numFiles = 0;
                foreach (FileInfo f in aviFiles)
                {
                    string filename = f.Name;
                    string date = filename.Substring(5, 10);
                    DateTime validDate = Convert.ToDateTime(date);

                    if (selectedDate == validDate)
                    {
                        numFiles += 1;
                        FileListlst.Items.Add(filename);
                    }
                }

                if (numFiles == 0)
                {
                    lblNumFiles.Text = ("No Data on Selected Date");
                }
                if (numFiles == 1)
                {
                    lblNumFiles.Text = ("1 Recording Available for Date Selected");
                }
                else
                {
                    lblNumFiles.Text = (+numFiles + " Recordings Available for Date Selected");
                }
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                MessageBox.Show(error);
            }
        }
        #endregion

        private void FileListlst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string sfile = FileListlst.Text;
            DirectoryInfo dir = new DirectoryInfo(_clipsPath);
            FileInfo[] aviFiles = dir.GetFiles("*.avi");

            foreach (FileInfo f in aviFiles)
            {
                string filename = f.Name;
                string fdate = filename.Substring(5, 10);
                string ftime = filename.Substring(16, 8);
                string fcamnum = filename.Substring(3, 1);
                string scamnum = sfile.Substring(3, 1);
                string rdate = fdate.Replace("/", "-");
                string rtime = ftime.Replace(":", ".");
 
                if (fdate == rdate && ftime == rtime && fcamnum == scamnum)
                {
                    Logger.AppendToLog(DateTime.Now + "   Playback via Search Screen");
                    Vlc vlc = new Vlc();
                    Playback pb = new Playback(vlc);
                    pb.Show();
                    pb.CamFilePlayback(filename);
                    Close();
                    return;
                }
            }
        }
    }
}


