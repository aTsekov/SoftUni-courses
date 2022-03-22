using System;

namespace _03_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string keyWord = Console.ReadLine();
            string text = Console.ReadLine();

            while (text.Contains(keyWord))
            {
                int startIndexOfWordToRemove = text.IndexOf(keyWord); // това намира първата поява на думата в скобите и запазваме индекса на който е намерена. 
                text = text.Remove(startIndexOfWordToRemove, keyWord.Length); // започни да триеш от индекса на който е намерена думата то индекса до който думата свършва. 
                
                //text = text.Replace(keyWord, ""); // друг вариян на това е всеки път когато думата е срещната да бъде заменята със празен стринг.
            }

            Console.WriteLine(text);
        }
    }
}
