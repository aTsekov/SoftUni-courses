using System;
using System.IO;

namespace L01_Odd_Line
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputPath = Path.Combine("Data","input.txt");
            var outputPath = Path.Combine("Data", "output.txt");

            using (StreamReader input = new StreamReader(inputPath))
            {
                using (StreamWriter output = new StreamWriter(outputPath))
                {
                    string line  = input.ReadLine();
                    int count = 0;

                    while (line != null)
                    {
                        if (count % 2 != 0)
                        {
                            output.WriteLine(line);
                        }

                        count++;
                        line = input.ReadLine();
                    }

                }
                

            }
        }
    }
}
