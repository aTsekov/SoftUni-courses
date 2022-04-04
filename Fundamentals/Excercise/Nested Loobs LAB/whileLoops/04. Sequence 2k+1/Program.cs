using System;

namespace _04._Sequence_2k_1
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            int k = 1;

            while (input >= k)
            {

                Console.WriteLine(k);
                k = k * 2 + 1;
                    

            }


        }
    }
}
