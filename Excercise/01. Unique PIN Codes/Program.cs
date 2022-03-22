using System;

namespace _01._Unique_PIN_Codes
{
    class Program
    {
        static void Main(string[] args)
        {

            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 2; i <= firstNum; i++)
            {
                for (int j = 2; j <= secondNum; j++)
                {
                    for (int k = 2; k <= thirdNum; k++)
                    {
                        
                            

                            if (i % 2 == 0 && k % 2 == 0)
                            {
                            if (j == 2 || j == 3 || j == 5 || j == 7)
                            {
                                Console.WriteLine($"{i} {j} {k}");
                            }
                                                            
                            }

                        


                    }
                }
            }



        }
    }
}
