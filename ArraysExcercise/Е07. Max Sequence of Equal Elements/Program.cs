using System;
using System.Linq;

namespace Е07._Max_Sequence_of_Equal_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            
            int sequenceCounter = 1;
            int longestCount = 1;
            int longestNum = 0;


            for (int k = 0; k < input.Length - 1; k++)
            {
                if (input[k] == input[k + 1])
                {

                    sequenceCounter++;
                }
                else
                {
                    sequenceCounter = 1;
                    
                }
                if (sequenceCounter > longestCount)
                {
                    longestCount = sequenceCounter;
                    longestNum = input[k];
                }
            }




            int[] currSet = new int[longestCount];
            Array.Fill(currSet, longestNum);
            Console.WriteLine(String.Join(" ", currSet));


        }
    }
}
