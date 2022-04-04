using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Friend_List_Maintenance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();
            string[] token = command.Split(" ");
            string nameToBan = string.Empty;
            int counter = 0;
            int blackListedCouter = 0;
            

            List<string> bannedNames = new List<string>();

            while (command != "Report")
            {
                if (token[0] == "Blacklist")
                {
                    nameToBan = token[1];

                    if (names.Contains(nameToBan))
                    {
                        string blackList = "Blacklisted";
                        int indexOfNameToBan = names.IndexOf(nameToBan);
                        names.RemoveAt(indexOfNameToBan);
                        names.Insert(indexOfNameToBan, blackList);
                        Console.WriteLine($"{nameToBan} was blacklisted.");
                        bannedNames.Add(nameToBan);
                        blackListedCouter ++;
                    }
                    else
                    {
                        Console.WriteLine($"{nameToBan} was not found.");
                    }


                }

                else if (token[0] == "Error")
                {
                    int index = int.Parse(token[1]);
                    string lostName = names[index];
                    string lost = "Lost";
                    //string previousLostName = string.Empty;

                    if (index > 0 && index < names.Count)
                    {
                        if (names[index] != nameToBan)
                        {
                            if (counter == 0)
                            {

                                Console.WriteLine($"{lostName} was lost due to an error.");
                                //previousLostName = lostName;
                                names.RemoveAt(index);
                                names.Insert(index, lost);
                                counter++;
                            }

                        }

                    }


                }
                else if (token[0] == "Change")
                {
                    int index = int.Parse(token[1]);
                    string newName = token[2];
                    
                    
                    if (index >= 0 && index < names.Count)
                    {
                        string oldName = names[index];
                        names.RemoveAt((int)index);
                        names.Insert(index, newName);
                        Console.WriteLine($"{oldName} changed his username to {newName}.");

                    }


                    
                }
                command = Console.ReadLine();
                token = command.Split(" ");
            }
            if (blackListedCouter > 0)
            {
                Console.WriteLine($"Blacklisted names: {blackListedCouter} ");
            }
            else if (blackListedCouter == 0)
            {
                Console.WriteLine($"Blacklisted names: {blackListedCouter}");
            }
            
            Console.WriteLine($"Lost names: {counter}");           
            Console.WriteLine(string.Join(" ",names));
            
            
            
            
        }
    }
}
