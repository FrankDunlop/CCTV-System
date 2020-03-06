using System;
using DAL.EF;

namespace DVR.Logging
{
    public class DBLogger: ILogger
    {
        public DVREntities db { get; set; }

        public void InitLog()
        {
            AppendToLog(DateTime.Now + "   Logging to Database");
        }

        public void AppendToLog(string LogEntry)
        {
            try
            {
                using (db = new DVREntities())
                {
                    db.AddToLogs(new Log { Message = LogEntry });
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine("Logger Error: " + ex.Message);
            }
        }

        public string GetLogEntries(string LogList)
        {
            /*string logList = "";
            try
            {
                using (db = new DVREntities())
                {
                    var query = from log in db.Logs
                                orderby log.ID descending
                                select log;

                    foreach (var logEntry in query)
                    {
                        logList += logEntry.Message + "\r\n";
                    }
                }
                return logList;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }*/

            return null;
        }

        public void ClearLog()
        {
            //throw new NotImplementedException();
        }
    }
}
