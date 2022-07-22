namespace Solid
{
    

    public interface ILoger 
    {
        public IAppender Appender { get; }
        void Info(string dateTime, string message);
        void Warning(string dateTime, string message);
        void Error(string dateTime, string message);
        void Critical(string dateTime, string message);
        void Fatal(string dateTime, string message);
    }
}
