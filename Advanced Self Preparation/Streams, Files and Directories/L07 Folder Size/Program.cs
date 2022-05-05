using System;
using System.Text;
using System.IO;    

namespace L07_Folder_Size
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string directoryPath = @"C:\Users\Antoni\Desktop\SoftUni\SoftUni-courses\Advanced Self Preparation\Streams, Files and Directories";

            var totalLenght =  GetTotalLenghts(directoryPath);

            Console.WriteLine(totalLenght);
        }
        static long GetTotalLenghts (string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            long totalLenght = 0;

            foreach (string file in files)
            {
                totalLenght += new FileInfo(file).Length;

            }

            var subDirectories = Directory.GetDirectories(directoryPath);
            foreach (var directory in subDirectories)
            {
                totalLenght += GetTotalLenghts(directory);
            }

            return totalLenght;
        }
    }
}
