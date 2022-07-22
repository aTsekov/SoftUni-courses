namespace Solid
{
    using Solid.Appenders;
    using Solid.LogFiles;
    using Solid.ReportLevel;
    using System.IO;

    internal class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";
        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            
        }
       public ILogFile LogFile { get; }
        public override void Append(string dateTime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, dateTime, reportLevel, message);

            LogFile.Write(appendMessage);

            File.AppendAllText(FilePath, appendMessage);
        } 
    }
}
