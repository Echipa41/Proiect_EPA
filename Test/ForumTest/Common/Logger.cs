using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace ForumTest.Common
{
    public static class Logger
    {
        private static bool mConfigured = false;

        private static readonly ILog mInfoLogger = LogManager.GetLogger("DiagnosticsAppender");

        private static readonly ILog mExceptionLogger = LogManager.GetLogger("ErrorAppender");

        public static void Configure()
        {
            if (mConfigured)
                return;
            XmlConfigurator.Configure();
            mConfigured = true;
        }

        public static void LogInfo(String message)
        {
            mInfoLogger.Info(message);
        }

        public static void LogException(String message, Exception exception)
        {
            mExceptionLogger.Error(message, exception);
        }
    }
}
