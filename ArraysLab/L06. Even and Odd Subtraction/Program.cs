using System;
using System.Linq;

namespace L06._Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            //int sumOdd = 0;
            //int sumEven = 0;


            //for (int i = 0; i < input.Length; i++)
            //{
            //    int currentNum = input[i];

            //    if (currentNum % 2 == 0)
            //    {
            //        sumEven+=currentNum;
            //    }
            //    else
            //    {
            //        sumOdd+=currentNum;
            //    }
                
            //}
            //int difference = sumEven - sumOdd;
            //Console.WriteLine(difference);

            string [] rawData = Console.ReadLine().Split(' ');
            int [] input = new int[rawData.Length];

            for (int i = 0; i < input.Length ; i++)
            {
                input[i] = int.Parse(rawData[i]);

            }

            int sumOdd = 0;
            int sumEven = 0;


            for (int i = 0; i < input.Length; i++)
            {
                int currentNum = input[i];

                if (currentNum % 2 == 0)
                {
                    sumEven += currentNum;
                }
                else
                {
                    sumOdd += currentNum;
                }

            }
            int difference = sumEven - sumOdd;
            Console.WriteLine(difference);


        }
    }
}
