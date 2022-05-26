using System;
using System.Collections.Generic;
using System.Linq;
namespace E10_ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
           
        {
            Dictionary<string, SortedSet<string>> forceSideDict = new Dictionary<string, SortedSet<string>>();
            
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] separatingString = { " | ", " -> " };
                string[] parts = input.Split(separatingString, StringSplitOptions.RemoveEmptyEntries);
                

                if (input.Contains("|")) // The user is on the right
                {
                    string forceUser = parts[1]; // User
                    string forceSide = parts[0]; // Side
                    if (!forceSideDict.ContainsKey(forceSide))
                    {
                        forceSideDict.Add(forceSide,new SortedSet<string>());
                        forceSideDict[forceSide].Add(forceUser); 
                    }
                }
                else if (input.Contains("->")) //The user is on the left
                {
                    string forceUser = parts[0];//User
                    string forceSide = parts[1];//Side
                    if (!forceSideDict.ContainsKey(forceSide))
                    {
                        forceSideDict.Add(forceSide, new SortedSet<string>());
                        forceSideDict[forceSide].Add(forceUser);
                        
                    }
                    else 
                    {
                        foreach (var side in forceSideDict)
                        {
                            foreach (var user in side.Value)
                            {
                                if (user == forceUser)
                                {
                                    forceSideDict[side.Key].Remove(user);
                                    break;
                                }
                            }
                        }
                        forceSideDict[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }
            


            var sortedDict= forceSideDict.OrderByDescending(x => x.Value.Count).ThenBy(name => name.Key);



            foreach (var side in sortedDict)
            {
                if (side.Value.Count == 0)
                {
                    continue;
                }
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value)
                {
                    
                    Console.WriteLine($"! {user}");
                }
            }
            




        }
    }
}
