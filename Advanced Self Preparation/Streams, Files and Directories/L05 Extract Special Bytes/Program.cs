using System;
using System.IO;

namespace L05_Extract_Special_Bytes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string exampleImage = Path.Combine("exampleimage.png");
            string bytes = Path.Combine("bytes.txt");
            string output = Path.Combine("output.bin");

            using (StreamReader image = new StreamReader(exampleImage))
            {
                string imageOutput = image.ReadToEnd();

                using (StreamReader textoutput = new StreamReader(bytes))
                {
                    string text = textoutput.ReadToEnd();


                    using (StreamWriter writeOutputInBytes = new StreamWriter(output))
                    {
                        writeOutputInBytes.WriteLine(imageOutput);
                        writeOutputInBytes.WriteLine(text);

                    }

                }

            }


        }
    }
}
