using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int Gladius = 70;
            const int Shamshir = 80;
            const int Katana = 90;
            const int Sabre = 110;
            const int Broadsword = 150;

            int[] steelInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] carbonInput = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> steel = new Queue<int>(steelInput);
            Stack<int> carbon = new Stack<int>(carbonInput);

            SortedDictionary<string, int> swards = new SortedDictionary<string, int>();

            SwardMaker(Gladius, Shamshir, Katana, Sabre, Broadsword, steel, carbon, swards);

            int forgedSwards = swards.Values.Sum();

            if (swards.Count == 0)
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            else
            {
                Console.WriteLine($"You have forged {forgedSwards} swords."); //
            }
            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            foreach (var item in swards)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }

        private static void SwardMaker(int Gladius, int Shamshir, int Katana, int Sabre, int Broadsword, Queue<int> steel, Stack<int> carbon, SortedDictionary<string, int> swards)
        {
            while (true)
            {
                if (steel.Count == 0 || carbon.Count == 0)
                {
                    break;
                }
                int firstSteel = steel.Peek();
                int firstCarbon = carbon.Peek();
                if (firstSteel + firstCarbon == Gladius)
                {
                    if (!swards.ContainsKey("Gladius"))
                    {
                        swards.Add("Gladius", 1);
                    }
                    else
                    {
                        swards["Gladius"]++;
                    }
                    steel.Dequeue();
                    carbon.Pop();

                }
                else if (firstSteel + firstCarbon == Shamshir)
                {
                    if (!swards.ContainsKey("Shamshir"))
                    {
                        swards.Add("Shamshir", 1);
                    }
                    else
                    {
                        swards["Shamshir"]++;
                    }
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (firstSteel + firstCarbon == Katana)
                {
                    if (!swards.ContainsKey("Katana"))
                    {
                        swards.Add("Katana", 1);
                    }
                    else
                    {
                        swards["Katana"]++;
                    }
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (firstSteel + firstCarbon == Sabre)
                {
                    if (!swards.ContainsKey("Sabre"))
                    {
                        swards.Add("Sabre", 1);
                    }
                    else
                    {
                        swards["Sabre"]++;
                    }
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (firstSteel + firstCarbon == Broadsword)
                {
                    if (!swards.ContainsKey("Broadsword"))
                    {
                        swards.Add("Broadsword", 1);
                    }
                    else
                    {
                        swards["Broadsword"]++;
                    }
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    int currentCarbon = carbon.Peek();
                    carbon.Pop();
                    currentCarbon += 5;
                    carbon.Push(currentCarbon);
                }
            }
        }
    }
}
