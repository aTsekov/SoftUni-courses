using System;
using System.Collections.Generic;
using System.Linq;

namespace E01._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> passangersInEachWagon = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int maxCapacityPerWagon = int.Parse(Console.ReadLine());
            string comand = "" ;

            while (comand != "end")
            {
                comand = Console.ReadLine();

                string[] token = comand.Split(" ");
                if (token[0] == "end")
                {
                    break;
                }
                if (token[0] == "Add")
                {
                    int passengersToAdd = int.Parse(token[1]);
                    passangersInEachWagon.Add(passengersToAdd);
                }
                else
                {
                    int passengersToAdd = int.Parse( token[0]);

                    for (int i = 0; i < passangersInEachWagon.Count; i++)
                    {
                        int emptySpace = 0;
                        if (maxCapacityPerWagon >= passengersToAdd)
                        {
                            emptySpace = maxCapacityPerWagon - passangersInEachWagon[i];
                        }

                        if (passengersToAdd <= emptySpace)
                        {
                            passangersInEachWagon[i] = passengersToAdd + passangersInEachWagon[i];
                            break;
                        }
                    }
                }          
           
            }
            Console.WriteLine(String.Join(" ", passangersInEachWagon));
        }
    }
}
