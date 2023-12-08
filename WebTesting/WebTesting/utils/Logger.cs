using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTesting.utils
{
    internal class Logger
    {
        private StreamWriter logFile;

        public Logger(string filePath) 
        {
            logFile = new FileInfo(filePath).CreateText();
        }

        public void logToFile(string nameOfAction)
        {
            logFile.WriteLine(DateTime.Now + " - Выполнено без ошибок: " + nameOfAction);
        }
        
        public void CloseStream()
        {
            logFile.Close();
        }

    }
}
