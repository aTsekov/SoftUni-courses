using System;
using System.Collections.Generic;

namespace E06_Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] inputSongs = Console.ReadLine().Split(", ");
            Queue <string> queue = new Queue<string>(inputSongs); 
            while (queue.Count != 0)
            {

                string commandType = Console.ReadLine();
                
                if (commandType == "Play")
                {
                    queue.Dequeue();
                }
                else if (commandType.StartsWith("Add"))
                {
                    string song = commandType.Substring(4);
                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                    
                    
                }
                else if (commandType == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }

            }
            Console.WriteLine($"No more songs!");
        }
    }
}
