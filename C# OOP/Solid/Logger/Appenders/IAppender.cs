namespace Solid
{
    using Solid.ReportLevel;

    public interface IAppender
    {
        public ILayout Layout { get; }
        void Append(string dateTime, LogLevel reportmessage, string message);
    }
}
