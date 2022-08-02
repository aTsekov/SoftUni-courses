namespace CommandPattern.IO
{
    using CommandPattern.IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsolReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();
            return line;
        }
    }
}
