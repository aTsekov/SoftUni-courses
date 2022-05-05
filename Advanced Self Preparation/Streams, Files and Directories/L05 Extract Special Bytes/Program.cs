using System;
using System.IO;

namespace L05_Extract_Special_Bytes
{
    internal class Program  
    { 
        static void Main(string[] args)
        {

            byte[] data = new byte[] {64, 83,111,102,116,33 };// we put the bytes we want to write in the file



            using  FileStream fileWriter =  new FileStream("Testoutput.txt",FileMode.OpenOrCreate);  
            using  FileStream fileReader =  new FileStream("output.txt",FileMode.OpenOrCreate);
            byte[] buffer = new byte[100];
            fileReader.Read(buffer, 0, 10); // Write in the buffer, start from the 0 (from the very begining) and put 10 bytes in the buffer

            //We aread as bytes the text that we have in the "output" file. and we are doing it with a buffer of 10 bytes. 


            fileWriter.Write(data, 0, data.Length); // in the file they appear as normal text. 

        }
    }
}
