namespace CommandPattern.IO.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IWriter
    {
        void Write(string value);
        void WriteLine(string value);
    }
}
