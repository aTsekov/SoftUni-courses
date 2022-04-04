using System;

namespace _003_Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string filePath = Console.ReadLine(); // четем стринг от конзолата

            string fileInfo = filePath.Substring(filePath.LastIndexOf('\\') + 1); // правим съб стринг, зада взземем последната част след \ (The last occurance of \ backslash)

            //gotinVirus.pdf.exe // ако обаче имаме кофти файл като този трябва да вземем последния индекс на който се среща точката
            // това е нужно защото името на файла е gotinVirus.pdf a екстеншъна е .ехе

            int dotIndex = fileInfo.LastIndexOf('.'); // взимаме последния индекс на който се среща точката
            string fileName = fileInfo.Substring(0, dotIndex); // името е равно на събстринг от нулевия индекс до последния индекс на който сме срещнали точка
            string fileExtension = fileInfo.Substring(dotIndex + 1); // есктеншъна е равен на  събстринг от последния индекс на който сме срещнали точката + 1 (на тази позиция е буквата "е" в случая) и като не добавим запетая в събстринга, го взима до края на стринг. 

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
