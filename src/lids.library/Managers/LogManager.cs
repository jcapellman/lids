using System;
using System.IO;
using System.Text;

namespace lids.library.Managers
{
    public class LogManager
    {
        private readonly StringBuilder _sbLog;
        private readonly string _logName;

        public LogManager()
        {
            _sbLog = new StringBuilder();
            _logName = $"{DateTime.Now.Ticks}.log";
        }

        public void WriteMessage(string msg)
        {
            _sbLog.Append($"{DateTime.Now} - {msg}");
        }

        public void FlushLog()
        {
            File.WriteAllText(_logName, _sbLog.ToString());
        }
    }
}