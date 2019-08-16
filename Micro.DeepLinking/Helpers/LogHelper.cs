using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Micro.DeepLinking.Helpers
{
    public class LogHelper
    {
        private string LOG_PATH = ConfigurationManager.AppSettings["ErrorLogsPhysicalPath"];

        public void InsertLog(Exception ex, string functionName)
        {
            try
            {
                string Message = String.Concat(Regex.Replace(functionName, "([a-z])([A-Z])", "$1 $2") + " - " + "Exception Message: ", ex.Message, " Inner Exception: ", (ex.InnerException != null ? ex.InnerException.InnerException.ToString() : " empty"));
                string path = LOG_PATH + DateTime.Now.Year;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = path + @"\" + DateTime.Now.Month;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = path + @"\" + DateTime.Now.Day;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path = path + @"\" + functionName + DateTime.Now.Hour + ".txt";

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(string.Format("{0} : {1}", DateTime.Now, Message));
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(string.Format("{0} : {1}", DateTime.Now, Message));
                    }
                }
            }
            catch
            {

            }
        }
    }
}
