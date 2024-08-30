using System.Reflection;
using log4net;

namespace APITesting.Core.Utilities
{
    public static class Log
    {

        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogInfo(string message)
        {
            if (Logger.IsInfoEnabled)
            {
                Logger.Info(message);
            }
        }

        public static void LogError(string message, Exception ex)
        {
            if (Logger.IsErrorEnabled)
            {
                Logger.Error(message, ex);
            }
        }

        public static void LogDebug(string message)
        {
            if (Logger.IsDebugEnabled)
            {
                Logger.Debug(message);
            }
        }

        public static void LogWarn(string message)
        {
            if (Logger.IsWarnEnabled)
            {
                Logger.Warn(message);
            }
        }

        public static void LogFatal(string message, Exception ex)
        {
            if (Logger.IsFatalEnabled)
            {
                Logger.Fatal(message, ex);
            }
        }
    }
}

