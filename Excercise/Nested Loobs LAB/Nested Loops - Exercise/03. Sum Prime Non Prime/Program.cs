using System;

namespace _03._Sum_Prime_Non_Prime
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int primeNums = 0;
            int sumNonPrimeNums = 0;

            while (num != "stop")
            {
                             
                int digit = int.Parse(num);

                if (digit < 0)
                {
                    Console.WriteLine("Number is negative.");
                    
                }
                else
                {
                    int count = 0;
                    for (int i = 1; i <= digit; i++)
                    {
                        if (digit % i == 0 )
                        {
                            count++;
                        }
                    }
                    if (count== 2)
                    {
                        primeNums += digit;
                    }
                    else
                    {
                        sumNonPrimeNums += digit;
                    }
                }

                num = Console.ReadLine();

            }

            Console.WriteLine($"Sum of all prime numbers is: {primeNums}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNums}");


        }
    }
}
