using System;
using System.Linq;

namespace E05._Top_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rawData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int[] topIntegers = new int[rawData.Length];
            int topIntegersIndex = 0; // last index that we added to TopIntegers.
            



            for (int i = 0; i <= rawData.Length - 1; i++)
            {
                int currentNum = rawData[i];
                bool isTopInteger = true;
                

                for (int j = i + 1; j <= rawData.Length - 1; j++) // когато j = i + 1  това гарантира, че винаги ще започваме от следващия елемент а не от текущия.
                {
                    int nextNum = rawData[j];
                    if (currentNum <= nextNum)
                    {
                        
                        isTopInteger = false;
                        break;
                    }


                }
                if (isTopInteger)
                {
                    topIntegers[topIntegersIndex] = currentNum;
                    topIntegersIndex++;
                }

                


            }
            for (int i = 0; i < topIntegersIndex; i++)
            {
                Console.Write($"{topIntegers[i]} ");


            }

        }
    }
}
