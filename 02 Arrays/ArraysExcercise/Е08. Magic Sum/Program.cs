using System;
using System.Linq;

namespace Е08._Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();           
            int num = int.Parse(Console.ReadLine());
            



            for (int i = 0; i < arr.Length -1; i++)
            {
                              
                for (int k = i + 1; k < arr.Length; k++)
                {
                    

                    if (arr [i] + arr [k] == num)
                    {
                        Console.WriteLine(arr[i] + " " + arr[k]);
                        
                    }

                }

            }
            


        }
    }
}
