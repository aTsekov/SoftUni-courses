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

            using FileStream readFileStream = new FileStream(exampleImage, FileMode.Open);
            using FileStream readFileStream2 = new FileStream(bytes, FileMode.Open);

            using FileStream writeFileStream = new FileStream(output, FileMode.Create);
            byte[] buffer = new byte[4096];


            while (readFileStream.CanRead)
            {
                int counter = readFileStream.Read(buffer, 0, buffer.Length);
                readFileStream2.Read(buffer, 0, buffer.Length);
                if (counter == 0)
                {
                    break;

                }

                writeFileStream.Write(buffer, 0, buffer.Length);
                
            }
            


        }
    }
}
