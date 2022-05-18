using System;

namespace _01._Number_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {

            //Напишете програма, която чете цяло число n, въведено от потребителя, и отпечатва пирамида от числа като в примерите:
            int inputNum = int.Parse(Console.ReadLine());

            int current = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= inputNum; rows++)
            {
                for (int colums = 1; colums <= rows; colums++)
                {

                    if (current > inputNum)
                    {
                        isBigger = true;
                        break;
                        
                    }

                    Console.Write(current + " ");
                    current++;
                    
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();

            }



        }
    }
}
