namespace Solid
{
    using Solid.Appenders;
    using Solid.ReportLevel;
    using System.IO;

    internal class FileAppender : Appender
    {
        private const string FilePath = "../../../Output/result.txt";
        public FileAppender(ILayout layout)
            : base(layout)
        {
            
        }
       
        public override void Append(string dateTime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, dateTime, reportLevel, message);
            File.AppendAllText(FilePath, appendMessage);
        } 
    }
}
