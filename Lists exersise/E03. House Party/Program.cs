using System;
using System.Collections.Generic;
using System.Linq;

namespace E03._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guestList = new List<string>();
            int comandsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < comandsNum; i++)
            {

                 string comand = Console.ReadLine();
                string[] token = comand.Split(" ");
                string name = token[0];

                if (token.Length == 3) // is  going to the party
                {

                    if (guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                        continue;
                    }
                    // това се изпълнява, само ако госта не е в листа с гости. 
                    guestList.Add(name);
                }
                else if (token.Length == 4) // is not going t o the party
                {
                    if (!guestList.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                        continue;
                    }
                    // if the guest is not present in the guest list.
                    guestList.Remove(name);
                }
                
                
            }
            PrintItems(guestList);
        }
        static void PrintItems (List<string> items)
        {
            for (int i = 0;i < items.Count; i++)
            {
                Console.WriteLine(items[i]);
            }
        }
    }
}
