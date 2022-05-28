namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

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



            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 0;
            List<string> outputLines = new List<string>();

            foreach (string line in lines)
            {
                count++;

                int counntLetters = line.Count(char.IsLetter);
                int countSymbol = line.Count(char.IsPunctuation);
                string modifiedLine = $"Line {count}: {line} ({counntLetters})({countSymbol})";
                outputLines.Add(modifiedLine);
            }

            File.WriteAllLines(outputFilePath, outputLines);




        }
    }
}
