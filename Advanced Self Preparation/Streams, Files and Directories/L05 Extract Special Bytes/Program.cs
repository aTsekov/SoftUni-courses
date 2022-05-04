using System;
using System.IO;

namespace L05_Extract_Special_Bytes
{
    internal class Program  
    { 
        static void Main(string[] args)
        {

            using  FileStream fileReader =  new FileStream("output.txt",FileMode.OpenOrCreate);
            byte[] buffer = new byte[100];
            fileReader.Read(buffer, 0, 10); // Write in the buffer, start from the 0 (from the very begining) and put 10 bytes in the buffer

            //We aread as bytes the text that we have in the "output" file. and we are doing it with a buffer of 10 bytes. 

            


        }
    }
}
