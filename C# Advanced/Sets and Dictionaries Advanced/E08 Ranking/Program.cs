using System;
using System.Collections.Generic;
using System.Linq;

namespace E08_Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string contestInput = Console.ReadLine();
            Dictionary<string,string> contests = new Dictionary<string,string>();

            while (contestInput != "end of contests")
            {
                string[] tokens = contestInput.Split(":", StringSplitOptions.RemoveEmptyEntries);
                contests.Add(tokens[0], tokens[1]); // добавяме името на контеста и паролата за него.

                contestInput = Console.ReadLine();  
            }


            string submissionInput = Console.ReadLine();
            SortedDictionary<string, Dictionary<string,int>> submissionResults = new SortedDictionary<string, Dictionary<string, int>>();

            while (submissionInput != "end of submissions")
            {
                string[] tokens = submissionInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string pass = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (!contests.ContainsKey(contest) || contests[contest] != pass)
                {
                    submissionInput = Console.ReadLine();
                    continue;

                }

                if (!submissionResults.ContainsKey(username))
                {
                    submissionResults.Add(username,new Dictionary<string, int>());
                    submissionResults[username].Add(contest,points);

                }
                else
                {
                    
                    if (!submissionResults[username].ContainsKey(contest))
                    {
                        submissionResults[username].Add(contest, points);

                    }
                    else
                    {
                        int tempPoints = submissionResults[username][contest];
                        if (submissionResults[username][contest]<points)
                        {
                            submissionResults[username][contest] = points;
                        }
                    }
                }


                submissionInput = Console.ReadLine();
            }

            KeyValuePair<string, Dictionary<string,int>> bestCandidate =submissionResults.OrderByDescending(kvp => kvp.Value.Values.Sum()).First();

            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
            Console.WriteLine("Ranking:");

            foreach ((string username,Dictionary<string,int> contestResults) in submissionResults)
            {
                Console.WriteLine(username);
                foreach ((string contest,int points) in contestResults.OrderByDescending(c=>c.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
            
        }
    }
}
