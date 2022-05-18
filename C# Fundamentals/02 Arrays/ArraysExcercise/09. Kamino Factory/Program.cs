using System;
using System.Linq;
using System.Text;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lenghtOfSequence = int.Parse(Console.ReadLine());
            string Clone = "";
            int onesCounter = 0;
            int currentOnesCounter = 0;
            int rows= 0;

            int[] firstDnaArr = new int [lenghtOfSequence];
            int[] secondDnaArr = new int [lenghtOfSequence];

            while ((Clone = Console.ReadLine()) != "Clone them!")
            {
                int[] arr = Clone.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                

                for (int i = 0; i < arr.Length -1; i++)
                {

                    arr[i] = firstDnaArr[i];
                    

                }
                

            }

            Console.WriteLine($"Best DNA sample {rows} with sum: {currentOnesCounter}.");
            Console.WriteLine(String.Join(" ", dnaArr));


        }
    }
}
