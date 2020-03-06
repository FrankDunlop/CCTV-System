using System;
using System.IO;

namespace DVR.Logging
{
    public class TextLogger : ILogger
    {
        private string logPath = "C:\\DVR\\";
        public FileStream FileStream { get; set; }
        public string FileName { get; set; }

        public void InitLog()
        {
            try
            {
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }

                FileName = logPath + "SystemLog.txt";
                if (!File.Exists(FileName))
                {
                    FileStream = new FileStream(FileName, FileMode.Create);
                    FileStream.Close();
                }

                AppendToLog(DateTime.Now + "   Logging to Textfile");
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Logger Error: " + ex.Message);
            }
        }

        public void AppendToLog(string logEntry)
        {
            try
            {
                BinaryWriter bw = new BinaryWriter(new FileStream(FileName, FileMode.Append));
                bw.Write(logEntry + "\r\n");
                bw.Close();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Logger Error: " + ex.Message);
            }
        }

        public string GetLogEntries(string LogList)
        {
            FileStream fs = new FileStream(logPath + "SystemLog.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Remove(0, 1);
                line = line + "\r\n" + LogList;
                LogList = line;
            }

            fs.Close();
            return LogList;
        }

        public void ClearLog()
        {
            //FileStream file = new FileStream(logPath + "SystemLog.txt", FileMode.Create);
            //file.Close();
        }
    }
}
