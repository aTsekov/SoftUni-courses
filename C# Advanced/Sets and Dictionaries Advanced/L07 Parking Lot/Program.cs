using System;
using System.Collections.Generic;

namespace L07_Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet <string> parking = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string [] token = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = token[0];
                string plateNum = token[1];

                if (direction == "IN")
                {
                    parking.Add(plateNum);
                }
                else if (direction == "OUT")
                {
                    parking.Remove(plateNum);
                }

            }

            if (parking.Count > 0)
            {
                foreach (var item in parking)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
           
        }
    }
}
