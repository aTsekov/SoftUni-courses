using System;
using System.Collections.Generic;

namespace _002_A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resource = "";
            Dictionary<string, int> resources = new Dictionary<string, int>();


            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource)) // ако ресурса вече съществува, добавяме към ключа(ресурса) количеството
                {
                    resources[resource] += quantity;
                }
                else // ако го няма ресурса - добавяме ресурса и добавяме количеството. Или иначе казано, добавяме Key/Value pair. 
                {
                    resources.Add(resource, quantity);
                }
            }

            foreach (var resource1 in resources)// принтираме ключа и стойността му
            {
                Console.WriteLine($"{resource1.Key} -> {resource1.Value}");
            }

        }
    }
}
