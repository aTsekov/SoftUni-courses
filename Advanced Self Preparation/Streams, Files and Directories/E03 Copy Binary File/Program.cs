using System;
using System.IO;

namespace E03_Copy_Binary_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File.Copy("CopyMe.png", "CopyMeCopy.png");
            FileStream fileReader = new FileStream("CopyMe.png", FileMode.Open);

            FileStream fileWriter = new FileStream("CopyMeCopy.png", FileMode.Create);
            byte[] arrayOfBytes = new byte[256];
            while (true)
            {
                int currentBytes = fileReader.Read(arrayOfBytes, 0, arrayOfBytes.Length);

                if (currentBytes == 0)
                {
                    break;
                }
                fileWriter.Write(arrayOfBytes, 0, arrayOfBytes.Length);

            }
            Console.WriteLine("Done");
            fileWriter.Close();

        }
    }
}
