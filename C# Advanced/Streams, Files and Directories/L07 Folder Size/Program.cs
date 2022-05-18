using System;
using System.Text;
using System.IO;    

namespace L07_Folder_Size
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We get the directory path of the folder that we want to see the size in bytes.
            string directoryPath = @"C:\Users\Antoni\Desktop\SoftUni\SoftUni-courses\Advanced Self Preparation\Streams, Files and Directories";

            var totalLenght =  GetTotalLenghts(directoryPath); // we made a recursive method (method that cals itselc) s owe can not only calculate the files in the main folder, but also its sub-directories. 

            Console.WriteLine(totalLenght);
        }
        static long GetTotalLenghts (string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath);// We make an array that contains each file name
            long totalLenght = 0;

            foreach (string file in files)
            {
                totalLenght += new FileInfo(file).Length; //we itterate trhough each file in the array and add it to totalLenght to calc all files size and add it to the variable (and the problem is solved to here)

            }

            // However if we want to include the sub directories we have to call the method (recursive) in itself 
            string [] subDirectories = Directory.GetDirectories(directoryPath);// we get each of the sub direactories in an array and we itterate them and add them to the totalLenght with the method itself. 
            foreach (var directory in subDirectories)
            {
                totalLenght += GetTotalLenghts(directory);
            }

            return totalLenght;
        }
    }
}
