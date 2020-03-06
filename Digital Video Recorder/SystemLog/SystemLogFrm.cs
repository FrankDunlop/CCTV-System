using System;
using System.IO;
using System.Windows.Forms;
using DVR.Logging;

namespace DVR.Log
{
    public partial class SystemLog : Form
    {
        public ILogger Logger { get; set; }

        public SystemLog(ILogger logger)
        {
            InitializeComponent();
            Logger = logger;
        }

        public void AddLogEntries(string logEntries)
        {
            LogEntriestxt.Text = logEntries;
        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            LogEntriestxt.Text = "";
        }
    }
}
