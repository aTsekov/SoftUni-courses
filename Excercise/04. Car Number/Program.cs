using System;

namespace _04._Car_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    for (int k = a; k <= b; k++)
                    {
                        for (int m = a; m <= b; m++)
                        {

                            if (i % 2 == 0 && m % 2 != 0 && i > m && (j+k) % 2 == 0)
                            {
                                
                                
                                Console.Write($"{i}{j}{k}{m} ");

                                

                            }
                            else if (i % 2 != 0 && m % 2 == 0 && i > m && (j + k) % 2 == 0)
                            {
                                Console.Write($"{i}{j}{k}{m} ");
                            }

                        }
                    }
                }


            }
        }
    }
}
