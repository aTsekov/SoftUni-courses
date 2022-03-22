using System;

namespace _02._Half_Sum_Element
{
    class Program
    {
        static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());
            int sum = 0;
            int largestNum = int.MinValue;
            int n = 0;

            for (int i = 0; i < input; i++)
            {
                n = int.Parse(Console.ReadLine());

                sum += n;
                if (n >= largestNum)
                {
                    largestNum = n;
                    continue;
                }
                

            }
            int sumWIthoutMax = sum - largestNum;
            if (sumWIthoutMax==largestNum )
            {
                Console.WriteLine($"Yes");
                Console.WriteLine($"Sum = {largestNum}");
            }
            else
            {
                Console.WriteLine($"No");
                Console.WriteLine($"Diff = {Math.Abs(sumWIthoutMax - largestNum)}");
            }

        }
    }
}
