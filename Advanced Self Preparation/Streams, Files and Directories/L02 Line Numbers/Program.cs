using System;
using System.IO;

namespace L02_Line_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputPath = Path.Combine("Data", "input.txt");
            var outputPath = Path.Combine("Data", "output.txt");

            using (StreamReader input = new StreamReader(inputPath))
            {
                using (StreamWriter output = new StreamWriter(outputPath))
                {
                    string line = input.ReadLine();
                    int count = 0;
                    int num = 1;

                    while (line != null)
                    {
                        
                            output.WriteLine($"{num}.{line}");
                        
                        num++;
                        count++;
                        line = input.ReadLine();
                    }

                }


            }
        }
    }
}
