using System;
using System.IO;

namespace CopyBinaryFile
{
    public class CopyBinaryFile
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\copyMe.png";
            string outputPath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputPath, outputPath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            // Създаваме рийдър с който прочитам инпут файла
            using(FileStream reader = new FileStream(inputFilePath,FileMode.Open))
            {
                //трябва ни writter - копира в outputfile

                using (FileStream writer = new FileStream(outputFilePath, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096]; // правим си буфер
                        int countBytes = reader.Read(buffer, 0, buffer.Length); // на всяко завъртане записваме нови 4096 байта в масива
                        if (countBytes == 0)
                        {
                            break;
                        }

                        writer.Write(buffer, 0, countBytes); // на всяко завъртане слагаме нови 4096 байта. 
                    }
                   
                }
            }
        }
    }
}
