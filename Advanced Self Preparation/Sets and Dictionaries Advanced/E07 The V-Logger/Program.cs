using System;
using System.Collections.Generic;
using System.Linq;

namespace E07_The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,HashSet<string>> vloggerWithHisFollowers = new Dictionary<string,HashSet<string>>();
            Dictionary<string,HashSet<string>> vloggerWithHisFollowings = new Dictionary<string,HashSet<string>>();
            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] commandArgs =command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                string cmdType = commandArgs[1];

                if (cmdType == "joined")
                {
                    Joined(vloggerWithHisFollowers, vloggerWithHisFollowings, commandArgs);

                }
                else if (cmdType == "followed")
                {
                    Followed(vloggerWithHisFollowers, vloggerWithHisFollowings, commandArgs);

                }
            }

            vloggerWithHisFollowers = vloggerWithHisFollowers.OrderByDescending(kvp =>kvp.Value.Count).ThenBy(kvp =>vloggerWithHisFollowings[kvp.Key].Count).ToDictionary(a => a.Key, b => b.Value);

            int cnt = 1;
               
            Console.WriteLine($"The V-Logger has a total of {vloggerWithHisFollowings.Count} vloggers in its logs.");

            KeyValuePair<string, HashSet<string>> mostFamousVlogger = vloggerWithHisFollowers.First();

            string famounsVloggerName = mostFamousVlogger.Key;
            HashSet<string> mostFamousVloggerFollowers = mostFamousVlogger.Value.OrderBy(m => m).ToHashSet();
            Console.WriteLine($"{cnt++}{famounsVloggerName} : {mostFamousVloggerFollowers.Count} followers, {vloggerWithHisFollowings[famounsVloggerName]} following");

            foreach (var follower in mostFamousVloggerFollowers)
            {
                Console.WriteLine($"*  {follower}");
            }
            
            foreach (var vloggerFollowersPair in vloggerWithHisFollowers.Skip(1))
            {
                HashSet<string> followers = vloggerFollowersPair.Value;
                Console.WriteLine($"{cnt++}. {vloggerFollowersPair.Key} : {followers.Count} followers, {vloggerWithHisFollowings[vloggerFollowersPair.Key].Count} following");
            }

        }

        private static void Followed(Dictionary<string, HashSet<string>> vloggerWithHisFollowers, Dictionary<string, HashSet<string>> vloggerWithHisFollowings, string[] commandArgs)
        {
            string follower = commandArgs[0];
            string toBeFollowed = commandArgs[2];
            if (follower != toBeFollowed)
            {
                if (vloggerWithHisFollowers.ContainsKey(toBeFollowed) && vloggerWithHisFollowings.ContainsKey(follower))
                {
                    vloggerWithHisFollowers[toBeFollowed].Add(follower);
                    vloggerWithHisFollowings[follower].Add(toBeFollowed);
                }

            }
        }

        private static void Joined(Dictionary<string, HashSet<string>> vloggerWithHisFollowers, Dictionary<string, HashSet<string>> vloggerWithHisFollowings, string[] commandArgs)
        {
            string vloggerToJoin = commandArgs[0];
            if (vloggerWithHisFollowers.ContainsKey(vloggerToJoin))
            {
                vloggerWithHisFollowings[vloggerToJoin] = new HashSet<string>();
                vloggerWithHisFollowers[vloggerToJoin] = new HashSet<string>();
            }
        }
    }
}
