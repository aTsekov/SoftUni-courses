using System;
using System.Collections.Generic;
using System.Linq;

namespace _008_Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyInfo = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] courseArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string company = courseArgs[0];
                string emplID = courseArgs[1];

                
                if (!companyInfo.ContainsKey(company))
                {
                    companyInfo.Add(company, new List<string>() {emplID});
                }
                if (!companyInfo[company].Contains(emplID)) // така провяряваме дали срещу ключа има записана стойност повече от веднъж. 
                {
                    companyInfo[company].Add(emplID);
                }
                
            }
            Print(companyInfo);
        }
        static void Print(Dictionary<string, List<string>> companyInfo)
        {
            foreach (var kvp in companyInfo)
            {
                string companyName = kvp.Key;
                List<string> emplID = kvp.Value;

                Console.WriteLine($"{companyName}");
                foreach (string  ID in emplID)
                {
                    Console.WriteLine($"-- {ID}");
                }
            }
        }
    }
}
