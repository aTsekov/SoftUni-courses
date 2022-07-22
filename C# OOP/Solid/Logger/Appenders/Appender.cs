namespace Solid.Appenders
{
    using Solid.ReportLevel;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public ILayout Layout { get; }

        public abstract void Append(string dateTime, LogLevel reportLevel, string message);
        
    }
}
