﻿using System;

namespace Not_deviding_on_3_and_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9 ; i++)
            {
                for (int j = 1; j <= 9 ; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int m = 1; m <= 9 ; m++)
                        {

                            if ((i + j) == (k + m))
                            {
                                if (n % (i + j) == 0)
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
}
