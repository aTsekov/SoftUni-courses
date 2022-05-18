using System;

namespace _04._Sum_of_Two_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int counter = 0;
            bool isFound = false;

            for (int i = startNum; i <= endNum; i++)
            {
                for (int j = startNum; j <= endNum; j++)
                {
                    counter++;

                    if (i + j == magicNum)
                    {
                        Console.WriteLine($"Combination N:{counter} ({i} + {j} = {magicNum})");
                        isFound = true;
                        break;
                        
                    }
                                                           

                }

                if (isFound == true)
                {
                    break;
                }
            }

            if (isFound == false)
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNum}");
            }
            


        }
    }
}
