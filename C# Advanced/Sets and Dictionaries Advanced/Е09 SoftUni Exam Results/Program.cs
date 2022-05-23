using System;
using System.Collections.Generic;
using System.Linq;

namespace Е09_SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var submissions = new Dictionary<string, Dictionary<string, List<int>>>();
            var languageSubmissions = new Dictionary<string, List<int>>();

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] parts = input.Split('-');
                string username = parts[0];
                string language = parts[1];
                int points = int.Parse(parts[2]);

                if (!submissions.ContainsKey(username))
                {
                    submissions.Add(username, new Dictionary<string, List<int>>());
                    submissions[username].Add(language, new List<int>());
                    submissions[username][language].Add(points);
                    
                }
                else
                {
                    submissions[username][language].Add(points);

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
                if (parts[2] == "banned")
                {
                    submissions.Remove(username);

                }

            }
            submissions.OrderByDescending(x => x.Value.Values).ThenBy(u => u.Key);
            Console.WriteLine($"Results:");

            foreach ((var username, var language) in submissions)
            {
                Console.Write($"{username} | {language}");

                
            }
            Console.WriteLine($"Submissions:");


            languageSubmissions.OrderByDescending(lang => lang.Value);
            foreach (var language in languageSubmissions)
            {
                Console.WriteLine($"{language.Key} - {language.Value.Count}");
            }
        }
        
    }
}
