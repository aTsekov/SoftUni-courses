using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _001_Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string> usernames = Console.ReadLine().Split (new string[] {", "},StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List <string> valid = new List <string> ();

            

            foreach (var word in usernames)
            {
                bool flag = true;
                if (word.Length >= 3 && word.Length <= 16)
                {
                    foreach (char ch in word)
                    {
                        if (!(char.IsLetterOrDigit(ch) || ch.ToString() == "-" || ch.ToString() == "_"))
                        {
                            flag = false;
                            
                        }
                       
                    }
                    if (flag)
                    {
                        valid.Add(word);
                    }
                        
                }

                
            }
            Console.WriteLine(string.Join("\n", valid));

        }
    }
}
