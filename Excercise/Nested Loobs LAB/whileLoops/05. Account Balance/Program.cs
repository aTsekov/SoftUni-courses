using System;

namespace _05._Account_Balance
{
    class Program
    {
        static void Main(string[] args)
        {
            string deposit = Console.ReadLine();
            
            double sum = 0;

            while (deposit != "NoMoreMoney")
            {
                double depositMoney = double.Parse(deposit);
                if (depositMoney <= 0)
                {
                    Console.WriteLine($"Invalid operation!");
                    break;
                }
                sum += depositMoney;

                
                
                Console.WriteLine($"Increase: {depositMoney:f2}");
                deposit = Console.ReadLine();            
                          
            }

            
            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
