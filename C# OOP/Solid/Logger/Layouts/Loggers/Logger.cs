namespace Solid
{
    using Solid.ReportLevel;
    using System.Collections.Generic;

    public class Logger : ILoger
    {
        public Logger()
        {
        }

        public Logger(params IAppender [] appenders)
        {
            this.Appenders = new List<IAppender>();
            this.Appenders.AddRange(appenders);
        }
        public List<IAppender> Appenders { get; }

        

        public void Critical(string dateTime, string message)
        {
            Log(dateTime, LogLevel.Critical, message);
        }

       

        public void Error(string dateTime, string message)
        {
            Log(dateTime, LogLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Log(dateTime, LogLevel.Fatal, message);
        }

        public void Info(string dateTime, string message)
        {
            Log(dateTime, LogLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            Log(dateTime, LogLevel.Warning, message);
        }
        private void Log(string dateTime, LogLevel logLevel, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, logLevel, message);
            }
        }
    }
}
