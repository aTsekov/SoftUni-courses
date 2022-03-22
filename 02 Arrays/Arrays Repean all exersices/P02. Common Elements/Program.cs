using System;

namespace P02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int k = 0; k < arr1.Length; k++)
                {
                    if (arr2[i] == arr1 [k])
                    {
                        Console.Write(arr1[k] + " ");
                    }
                }

            }

        }
    }
}
