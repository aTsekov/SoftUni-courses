using System;

namespace _06._Substitute
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNumFirstDigit = int.Parse(Console.ReadLine());
            int firstNumSecondDigit = int.Parse(Console.ReadLine());
            int secondNumFirstDigit = int.Parse(Console.ReadLine());
            int secondNumSecondDigit = int.Parse(Console.ReadLine());
            int counter = 0;
            bool hasEnded = false;

            for (int i = firstNumFirstDigit; i <= 8; i++)
            {
                for (int j = 9; j >= firstNumSecondDigit; j--)
                {
                    for (int k = secondNumFirstDigit; k <= 8; k++)
                    {
                        for (int l = 9; l >= secondNumSecondDigit; l--)
                        {
                            bool isValid = i % 2 == 0 &&
                                k % 2 == 0 &&
                                j % 2 != 0 &&
                                l % 2 != 0;

                            int firstNum = i * 10 + j;
                            int secondNum = k * 10 + l;

                            if (isValid && firstNum == secondNum)
                            {
                                Console.WriteLine($"Cannot change the same player.");
                            }
                            else if (isValid && firstNum != secondNum)
                            {
                                Console.WriteLine($"{i}{j} - {k}{l}");
                                counter++;
                            }
                            if (counter >= 6)
                            {
                                hasEnded = true;
                            }
                            if (hasEnded)
                            {
                                break;
                            }
                        }
                        if (hasEnded)
                        {
                            break;
                        }
                    }
                    if (hasEnded)
                    {
                        break;
                    }
                }
                if (hasEnded)
                {
                    break;
                }
            }

        }
    }
}
