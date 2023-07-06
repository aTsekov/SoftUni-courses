using System.Linq;
using System.Runtime.InteropServices;

namespace SimCorpTest
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] price = new[] { 1, 2, 3, 2 };

            int min = price.Min();
            int max = price.Max();

            Console.WriteLine(countInvestablePeriods(price, max, min));
        }

        public static long countInvestablePeriods(int[] price, int max_price, int min_price)
        {
            long counter = 0;
            int n = price.Length;

            for (int i = 0; i < n; i++)
            {
                int currentMax = int.MinValue;
                int currentMin = int.MaxValue;

                for (int j = i; j < n; j++)
                {
                    currentMax = Math.Max(currentMax, price[j]);
                    currentMin = Math.Min(currentMin, price[j]);

                    if (currentMax == max_price && currentMin == min_price)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }


    }

   
}