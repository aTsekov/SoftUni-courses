using System;

namespace _07._Vending_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string input = Console.ReadLine();
            string START = "";
            double coinsSum = 0;
            double price = 0;
            

            while (input != "Start")
            {
                double coins = double.Parse(input);                             
                

                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                {
                    coinsSum += coins;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }

                input = Console.ReadLine();

            }

            while (true)
            {



                input = Console.ReadLine();
                if (input == "End")
                {
                    Console.WriteLine($"Change: {coinsSum:f2}");
                    break;
                }

                if (input == "Nuts")
                {
                    price = 2.0;
                    if (coinsSum >= price)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        coinsSum -= price;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }

                }
                else if (input == "Water")
                {
                    price = 0.7;
                    if (coinsSum >= price)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        coinsSum -= price;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Crisps")
                {
                    price = 1.5;
                    if (coinsSum >= price)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        coinsSum -= price;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Soda")
                {
                    price = 0.8;
                    if (coinsSum >= price)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        coinsSum -= price;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                }
                else if (input == "Coke")
                {
                    price = 1.0;
                    if (coinsSum >= price)
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        coinsSum -= price;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, not enough money");
                 else
                {
                    Console.WriteLine("Invalid product");
                } 


            }


        }
    }
}
