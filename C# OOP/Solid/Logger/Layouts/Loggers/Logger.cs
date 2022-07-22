namespace Solid
{
    using Solid.ReportLevel;

    public class Logger : ILoger
    {
        public Logger()
        {
        }

        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }
        public IAppender Appender { get; }

        

        public void Critical(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Critical, message);
        }

        public void Error(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Error, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Fatal, message); ;
        }

        public void Info(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Info, message); ;
        }

        public void Warning(string dateTime, string message)
        {
            this.Appender.Append(dateTime, LogLevel.Warning, message);
        }
    }
}
