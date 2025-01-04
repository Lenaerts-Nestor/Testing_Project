using CarDecisionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Services
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public void LogWarning(string message)
        {
            Log("WARNING", message);
        }

        public void LogError(string message)
        {
            Log("ERROR", message);
        }

        private void Log(string logLevel, string message)
        {
            var logMessage = $"{DateTime.Now:G} [{logLevel}] {message}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }
    }
}