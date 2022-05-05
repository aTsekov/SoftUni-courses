using System;
using System.IO;

namespace E05_Slice_a_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using FileStream fileStream = new FileStream("countries.txt", FileMode.OpenOrCreate);// we create a stream that reads the big file

            byte[] data = new byte [fileStream.Length];// we create an array with the lenght if the big file.
            

            int bytesPerFile =(int) Math.Ceiling( fileStream.Length/ 4.0); // We create int variable that is = to the bih file divided by 4 (we want to have 4 files) and we add the Math.Ceiling to round upper so we can have 3 files with a few byts more and the last file would containt a bit less byts but this way we will make sure we do not miss a byte if the divide to 4 will not leave a residue

            for (int i = 0; i < 4; i++)
            {
                byte [] buffer = new byte[bytesPerFile]; // we make a buffer  that is = to the bytes pe file
                fileStream.Read (buffer); // we read the file with the size of the buffer and put in the buffer so we can use it later. 

                using FileStream writer = new FileStream($"Part - {i}.txt", FileMode.OpenOrCreate); // we create a new file each new itteration with the size of the buffer. 
                writer.Write (buffer);
            }


        }
    }
}
