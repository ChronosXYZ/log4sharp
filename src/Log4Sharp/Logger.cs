using System.Diagnostics;
using System;
using System.Drawing;
using Colorful;

namespace Log4Sharp
{
    public class Logger
    {
        public LogLevel LogLevel { get; set; }
        
        private readonly bool _isDefaultLogger;

        internal Logger(string name, LogLevel logLevel, bool systemLog, bool isDefaultLogger)
        {
            this.LogLevel = logLevel;
            this._isDefaultLogger = isDefaultLogger;
        }

        public void Error(string message)
        {
            if (LogLevel > LogLevel.Fatal)
            {
                writeLog(LogType.Error, message);
            }
        }

        public void Warning(string message)
        {
            if (LogLevel > LogLevel.Error)
            {
                writeLog(LogType.Warning, message);
            }
        }

        public void Info(string message)
        {
            if (LogLevel > LogLevel.Warn)
            {
                writeLog(LogType.Info, message);
            }
        }

        public void Debug(string message)
        {
            if (LogLevel > LogLevel.Info)
            {
                writeLog(LogType.Debug, message);
            }
        }

        public void Fatal(string message)
        {
            writeLog(LogType.Fatal, message);
            System.Environment.Exit(1);
        }

        private void writeLog(LogType logType, string message)
        {
            var st = new StackTrace();
            StackFrame stFrame;
            if (_isDefaultLogger)
            {
                stFrame = st.GetFrame(3);
            }
            else
            {
                stFrame = st.GetFrame(2);
            }

            var dateTimeFormatter = new Formatter($"{DateTime.Now}", Color.White);
            var frameFormatter = new Formatter($"{stFrame.GetMethod().ReflectedType.FullName}", Color.DeepPink);

            string outputMessage = "[{0}] [{1}] | [{2}]: " + message;

            Formatter tagFormatter = null;
            switch (logType)
            {
                case LogType.Error:
                {
                    tagFormatter = new Formatter("ERROR", Color.Red);
                    break;
                }
                case LogType.Fatal:
                {
                    tagFormatter = new Formatter("FATAL", Color.DarkRed);
                    break;
                }
                case LogType.Info:
                {
                    tagFormatter = new Formatter("INFO", Color.Aqua);
                    break;
                }
                case LogType.Warning:
                {
                    tagFormatter = new Formatter("WARNING", Color.Yellow);
                    break;
                }
                case LogType.Debug:
                {
                    tagFormatter = new Formatter("DEBUG", Color.LightGray);
                    break;
                }
                default:
                {
                    tagFormatter = new Formatter("UNKNOWN", Color.Green);
                    break;
                }
            }

            var formatters = new Formatter[]
            {
                dateTimeFormatter,
                frameFormatter,
                tagFormatter
            };
            Colorful.Console.WriteLineFormatted(outputMessage, Color.Gray, formatters);
        }

        private enum LogType
        {
            Error,
            Fatal,
            Info,
            Warning,
            Debug
        }
    }
}