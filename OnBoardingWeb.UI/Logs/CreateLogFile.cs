using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnBoardingWeb.UI.Logs
{
    public class CreateLogFile
    {
        private string _logFormat;
        private string _errorTime;
        public CreateLogFile()
        {
            _logFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            _errorTime = year + month + day;
        }
        public void LogError(string path, string message)
        {
            StreamWriter streamWriter = new StreamWriter(path + _errorTime, true);
            streamWriter.WriteLine(_logFormat + message);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}