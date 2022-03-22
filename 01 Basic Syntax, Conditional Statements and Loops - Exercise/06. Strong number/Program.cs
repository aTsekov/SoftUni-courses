using System;

namespace _06._Strong_number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string number = Console.ReadLine();

            long FactorialSum = 0;

            for (int i = 0; i <= number.Length -1; i++)
            {
                char currCh = number[i];
                int currDigit = (int)currCh - 48;

                long currDigitFactorial = 1;
                for (int r = currDigit; r > 1; r--)
                {
                    currDigitFactorial *= r;
                }
                FactorialSum += currDigitFactorial;
            }

            if ( FactorialSum == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
            


        }
    }
}
