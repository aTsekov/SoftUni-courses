namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            
            int counter = 0;

            using (StreamReader sr = new StreamReader(inputFilePath)) //We create a new stream reader that reads the file content
            {
                string[] specialSymbols = new[] { "-", ",", ".", "!", "?" }; // we make an array with the special symbols that we will replace later on
                string line = sr.ReadLine(); //we read a line from the text file
                while (line != null) // we itterate, until there are no lines left to read.
                {



                    foreach (var symbol in specialSymbols) // each symbol we replace with @. line is = line because string is imputable and we have to rewrite its value. 
                    {
                        line = line.Replace(symbol, "@");

                    }

                    if (counter % 2 == 0)
                    {
                        Console.WriteLine(string.Join(" ", line.Split().Reverse())); // we threat line an array now >> we reverce it and join it by " " so it can be printed. 
                    }
                    counter++;


                    line = sr.ReadLine(); // we read the next line and repeat until we have lines. 
                }

                return String.Empty;
            }
        }
        private static string ReverseWords(string replacedSymbols)
        {
            throw new NotImplementedException();
        }

        private static string ReplaceSymbols(string line)
        {
            throw new NotImplementedException();
        }
    }

}
