namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            //създаваме output директория
            Directory.CreateDirectory(outputPath);
            // взимаме вс файлове от инпут директорията 
            string [] files = Directory.GetFiles(inputPath);
            //3 всеки файл го копираме в output директорията:

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file); // взимаме името на файла
                var copyDestionation = Path.Combine(outputPath, fileName); // в директорията на оутпут файла искаме да копираме файла, който взехме в предишната стъпка. 
                File.Copy(file, copyDestionation); // копираме. 
            }
        }
    }
}
