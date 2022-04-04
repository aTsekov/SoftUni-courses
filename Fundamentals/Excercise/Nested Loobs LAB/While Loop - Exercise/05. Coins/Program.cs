using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {

            double change = double.Parse(Console.ReadLine()); // въвеждаме какво трябва да е рестото

            double convertedChange = change * 100; // 1.23 >> 123.00   конвертираме рестото в стотинки
            int cents = (int)convertedChange; // 123.00 >> 123   конвентираме стотинките в цяло число

            int coinsCounter = 0;

            while (cents > 0) // докато 123 цента са по-голямо от 0 >върти цикъла
            {
                if (cents - 200 >= 0)
                {
                    coinsCounter++;
                        cents -= 200;
                }
                else if ( cents - 100 >= 0)
                {
                    coinsCounter++;
                    cents -= 100;
                }
                else if (cents - 50 >= 0)
                {
                    coinsCounter++;
                    cents -= 50;
                }
                else if (cents - 20 >= 0)
                {
                    coinsCounter++;
                    cents -= 20;
                }
                else if (cents - 10 >= 0)
                {
                    coinsCounter++;
                    cents -= 10;
                }
                else if (cents - 5 >= 0)
                {
                    coinsCounter++;
                    cents -= 5;
                }
                else if (cents - 2 >= 0)
                {
                    coinsCounter++;
                    cents -= 2;
                }
                else if (cents - 1 >= 0)
                {
                    coinsCounter++;
                    cents -= 1;
                }
                



            }

            Console.WriteLine(coinsCounter);

        }
    }
}
