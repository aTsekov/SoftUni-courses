using System;
using System.Collections.Generic;
using System.Linq;

namespace TASK1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //Stack
            int[] greyInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();//Queue

            const int sink = 40;
            const int oven = 50;
            const int countertop = 60;
            const int wall = 70;

            int sinkCounter = 0;
            int ovenCounter = 0;
            int countertopCounter = 0;
            int wallCounter = 0;
            int floorCounter = 0;

            Queue<int> grey = new Queue<int>(greyInput);
            Stack<int> white = new Stack<int>(whiteInput);

            while (true)
            {
                if (white.Count == 0 && grey.Count == 0) /// ?????????? DO I need this? Maybe not
                {
                    break;
                }
                if (white.Count == 0 || grey.Count == 0)
                {
                    break;
                }
                int currWhite = white.Peek();
                int currGrey = grey.Peek();
                int combined = 0;
                
                

                if (currWhite == currGrey) // if they match
                {
                    combined = currWhite + currGrey;
                    if (combined == sink)
                    {
                        sinkCounter++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else if (combined == oven)
                    {
                        ovenCounter++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else if (combined == countertop)
                    {
                        countertopCounter++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else if (combined == wall)
                    {
                        wallCounter++;
                        white.Pop();
                        grey.Dequeue();
                    }
                    else
                    {
                        floorCounter++;
                        white.Pop();
                        grey.Dequeue();
                    }

                }
                else
                {
                    currWhite = currWhite / 2;
                    white.Pop();
                    white.Push(currWhite);
                    grey.Dequeue();
                    grey.Enqueue(currGrey);
                }
            }

            if (white.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", white)}");
            }
            if (grey.Count == 0)
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grey)}");
            }
            Dictionary<string, int> tiles = new Dictionary<string, int>();
            if (sinkCounter != 0)
            {
                tiles.Add("Sink",sinkCounter);
            }
            if (wallCounter != 0)
            {
                tiles.Add("Wall",wallCounter);
            }

            if (ovenCounter != 0)
            {
                tiles.Add("Oven", ovenCounter);
            }
            if (countertopCounter !=0)
            {
                tiles.Add("Countertop", countertopCounter);
            }
            if (floorCounter !=0)
            {
                tiles.Add("Floor", floorCounter);
            }

            var ordered = tiles.OrderByDescending( n =>n.Value).ThenBy(n => n.Key);
            foreach (var tile in ordered)
            {
                Console.WriteLine($"{tile.Key}: {tile.Value}");
              
            }
        }
    }
}
