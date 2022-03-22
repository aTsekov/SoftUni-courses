using System;

namespace _06._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNum = "";

            int largestNum = int.MinValue;

            while (inputNum != "Stop")
            {
                inputNum = Console.ReadLine();
                if (inputNum == "Stop")
                {
                    continue;
                }
                

                int currentNum = int.Parse(inputNum);

                if (currentNum >= largestNum)
                {
                    largestNum = currentNum ;
                }


            }
            Console.WriteLine(largestNum);


        }
    }
}
