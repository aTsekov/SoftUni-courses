using System;

namespace _05._Print_Part_Of_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            //char test = '\0';  празен чар, които по подразбиране е 0
            //char test = default(char); празен чар, които по подразбиране е 0
            double sum = 0;
            for (int i = n; i <= m; i++)
            {
                char c = (char)i;


                Console.Write($"{c} ");

        }
            


        }
    }
}
