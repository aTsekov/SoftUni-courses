using System;

namespace _03._Histogram
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double p4 = 0;
            double p5 = 0;
            

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                

                if (number <200)
                {
                    p1++;
                }
                else if (number >= 200 && number <=399)
                {
                    p2++;
                }
                else if (number >= 400 && number <= 599)
                {
                    p3++;
                }
                else if (number >= 600 && number <= 799)
                {
                    p4++;
                }
                else if (number >= 800 && number <= 1000)
                {
                    p5++;
                }

            }

            var p1Persentage = (p1 / n) * 100.0;
            var p2Persentage = (p2 / n) * 100.0;
            var p3Persentage = (p3 / n) * 100.0;
            var p4Persentage = (p4 / n) * 100.0;
            var p5Persentage = (p5 / n) * 100.0;

            Console.WriteLine($"{p1Persentage:f2}%");
            Console.WriteLine($"{p2Persentage:f2}%");
            Console.WriteLine($"{p3Persentage:f2}%");
            Console.WriteLine($"{p4Persentage:f2}%");
            Console.WriteLine($"{p5Persentage:f2}%");





        }
    }
}
