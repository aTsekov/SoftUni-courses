namespace LineNumbers
{
    using System;
    using System.IO;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

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
