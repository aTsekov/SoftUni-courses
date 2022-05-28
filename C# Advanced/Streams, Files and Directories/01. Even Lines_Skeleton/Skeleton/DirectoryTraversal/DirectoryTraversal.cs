namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            // разширение -> списък с файловете. 
            Dictionary<string, List<FileInfo>> extentionInfo = new Dictionary<string, List<FileInfo>>();
            // за всеки файл ни трябва разширението. 
            foreach (var file in files)
            {
                // взимаме информацията за файла за да вземем разширението. 
                FileInfo fileInfo = new FileInfo(file);
                string extention = fileInfo.Extension;

                if (!extentionInfo.ContainsKey(extention))
                {
                    extentionInfo.Add(extention, new List<FileInfo>());
                }
                extentionInfo[extention].Add(fileInfo);

            }
            StringBuilder sb = new StringBuilder();
            foreach (var entry in extentionInfo.OrderByDescending(entry => entry.Value.Count).ThenBy(entry => entry.Key))
            {
                //взимаме на вс разширение списъка с файлове
                //Списък с файлове трябва да се сортира спрямо размера на файла. 

                string extention = entry.Key;
                sb.Append(extention);
                List<FileInfo> filesInfo = new List<FileInfo>();
                filesInfo.OrderByDescending(file => file.Length);
                foreach (FileInfo fileInfo in filesInfo)
                {
                    sb.Append(($"--{fileInfo.Name} - {fileInfo.Length / 1024:F3}kb"));
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            // 
            string pathReport = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(pathReport, textContent);
        }

    }
}
