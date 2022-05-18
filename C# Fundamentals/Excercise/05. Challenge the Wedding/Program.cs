using System;

namespace _05._Challenge_the_Wedding
{
    class Program
    {
        static void Main(string[] args)
        {

            int men = int.Parse(Console.ReadLine());
            int women = int.Parse(Console.ReadLine());
            int tables = int.Parse(Console.ReadLine());
            
            bool isFull = false;
            int counter = 0;

            for (int i = 1; i <= men; i++)
            {
                for (int j = 1; j <= women ; j++)
                {
                    counter++;
                    Console.Write($"({i} <-> {j}) ");

                    if ( counter == tables)
                    {
                        isFull = true;
                        break;
                    }

                }
                if (isFull == true)
                {
                    break;
                }


            }


        }
    }
}
