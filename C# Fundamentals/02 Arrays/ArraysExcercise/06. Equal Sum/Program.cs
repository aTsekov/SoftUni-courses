using System;
using System.Linq;

namespace _06._Equal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int [] input = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            int biggestNum = int.MinValue;
            int biggestNumIndex = 0;
            int leftSum = 0;
            int rightSum = 0;   


            // logic to find the largest num and it's index.
            for (int i = 0; i < input.Length; i++)
            {
                int currDigit = input[i];

                if (currDigit > biggestNum)
                {
                    biggestNum = currDigit;
                    biggestNumIndex = i;
                }

            }
            if (input.Length == 1)
            {
                Console.WriteLine("0");
                return;
            }
            // logic to find the sum on the left
            for (int i = 0; i < biggestNumIndex; i++)
            {
                int CurrDigitLeft = input[i];
                leftSum += CurrDigitLeft;

            }
            // logic to find the sum on the right
            for (int i = biggestNumIndex + 1 ; i < input.Length; i++)
            {
                int CurrDigitRight = input[i];
                rightSum += CurrDigitRight; 
            }
            if (input.Length == 1)
            {
                Console.WriteLine("0");
                
            }
            else if (leftSum == rightSum)
            {
                Console.WriteLine(biggestNumIndex);
            }
            else
            {
                Console.WriteLine("no");
            }


        }
    }
}
