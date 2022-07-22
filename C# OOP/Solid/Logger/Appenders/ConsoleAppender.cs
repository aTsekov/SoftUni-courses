namespace Solid
{
    using Solid.Appenders;
    using Solid.ReportLevel;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
            
        }
        

        public override void Append(string dateTime, LogLevel reportLevel, string message)
        {
            string appendMessage = string.Format(this.Layout.Format, dateTime, reportLevel, message);
            Console.WriteLine(appendMessage);
        }
    }
}
