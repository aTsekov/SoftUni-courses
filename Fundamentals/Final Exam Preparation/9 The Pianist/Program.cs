using System;
using System.Collections.Generic;

namespace _03_The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> piecesDict = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                string [] piecesInfo = Console.ReadLine().Split('|',StringSplitOptions.RemoveEmptyEntries);
                string piece = piecesInfo[0];
                string composer = piecesInfo[1];
                string key = piecesInfo[2];
                piecesDict.Add(piece, new List<string> { composer, key });
                    
            }
            string[] commandArg = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            while (commandArg [0] != "Stop")
            {
                
                string command = commandArg [0];
                if (command == "Add")
                {
                    string piece = commandArg[1];
                    string composer = commandArg[2];
                    string key = commandArg[3];
                    if (!piecesDict.ContainsKey(piece))
                    {
                        piecesDict.Add(piece, new List<string> { composer, key });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        
                    }
                    else
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }

                }
                else if (command == "Remove")
                {
                    string piece = commandArg[1];
                    if (!piecesDict.ContainsKey(piece))
                    {
                       Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                    else
                    {
                        piecesDict.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string piece = commandArg[1];
                    string newKey = commandArg[2];
                    string key = piecesDict[piece][1];
                    if (piecesDict.ContainsKey(piece))
                    {
                        //foreach (var list in piecesDict[piece][1])
                        //{
                        //    piecesDict[piece][1]
                        //    key = list[1];
                        //    list.Remove(key);
                        //    list.Add(newKey);
                        //    break;
                        //}
                        piecesDict[piece].Remove(key);
                        piecesDict[piece].Add(newKey);
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        
                    }
                    else
                    {
                        
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                commandArg = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in piecesDict)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
