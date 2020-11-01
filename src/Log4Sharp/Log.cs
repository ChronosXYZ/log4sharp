using System;

namespace Log4Sharp
{
    public class Log
    {
        private const LogLevel DefaultLogLevel = LogLevel.Error;
        
        private static readonly Logger DefaultLogger = new Logger("", DefaultLogLevel, false, true);

        public static void Error(string message) {
            DefaultLogger.Error(message);
        }

        public static void Warning(string message) {
            DefaultLogger.Warning(message);
        }

        public static void Fatal(string message) {
            DefaultLogger.Fatal(message);
        }

        public static void Info(string message) {
            DefaultLogger.Info(message);
        }

        public static void Debug(string message) {
            DefaultLogger.Debug(message);
        }

        public static void SetLogLevel(LogLevel lvl)
        {
            DefaultLogger.LogLevel = lvl;
        }
    }
}