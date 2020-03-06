using System;
using System.IO;
using System.Windows.Forms;
using DVR.Logging;

namespace DVR.Log
{
    public partial class SystemLog : Form
    {
        public ILogger logger { get; set; }

        public SystemLog(ILogger Logger)
        {
            InitializeComponent();
            logger = Logger;
        }

        public void AddLogEntries(string LogEntries)
        {
            LogEntriestxt.Text = LogEntries;
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            LogEntriestxt.Text = "";
            //logger.ClearLog();
        }
    }
}
