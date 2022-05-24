using System;
using System.Collections.Generic;
using System.Linq;

namespace Е09_SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,int> submissions = new Dictionary<string,int>();
            var languageSubmissions = new Dictionary<string, List<int>>();

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] parts = input.Split('-');
                string username = parts[0];
                if (parts[1] == "banned")
                {
                    submissions.Remove(username);
                    continue;

                }

                string language = parts[1];
                int points = int.Parse(parts[2]);
                if (!submissions.ContainsKey(username))
                {
                    submissions.Add(username, points);
                }
                else if (submissions[username] < points)
                {
                    submissions[username] = points;
                }
               
                if (!languageSubmissions.ContainsKey(language))
                {
                    languageSubmissions.Add(language, new List<int>());
                    languageSubmissions[language].Add(points);
                }
                else
                {
                    languageSubmissions[language].Add(points);
                }
                

            }

            var sortedPoints = submissions.OrderByDescending( p => p.Value).ThenBy( p => p.Key);
            
            
            

            
            Console.WriteLine($"Results:");
            foreach (var item in sortedPoints)
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

           
            Console.WriteLine($"Submissions:");


            var newTest = languageSubmissions.OrderByDescending(l => l.Value.Count);

            foreach (var language in newTest)
            {
                Console.WriteLine($"{language.Key} - {language.Value.Count}");
            }
        }
        
    }
   
}
