namespace Formula1.IO
{
    using System;
    using System.IO;
    using Formula1.IO.Contracts;
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        


    }
}
