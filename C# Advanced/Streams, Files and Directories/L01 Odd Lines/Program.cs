using System;
using System.IO; // using for Streams

namespace L01_Odd_Lines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "input.txt");
            var dest = Path.Combine("data", "output.txt");

            using (FileStream file = new FileStream(path, FileMode.Open))// We define the stream and the path from where we will read it. We reach the file input in the folder "data". "FileMode.Open" means that we open the file.
            {

                using (TextReader text = new StreamReader(file))
                {
                    using (FileStream destFile = new FileStream(dest, FileMode.Create))
                    {
                        using (TextWriter writer = new StreamWriter(destFile))
                        {
                            string line = text.ReadLine();
                            int lineNum = 0;
                            while (line != null)
                            {
                                if (lineNum % 2 != 0)
                                {
                                    writer.WriteLine(line);
                                }

                                lineNum++;
                                line = text.ReadLine();
                            }
                        }
                    }

                }

            }
        }
    }
}