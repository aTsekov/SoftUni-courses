using System;

namespace _07._Min_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNum = "";

            int smallestNum = int.MaxValue;

            while (inputNum != "Stop")
            {
                inputNum = Console.ReadLine();
                if (inputNum == "Stop")
                {
                    continue;
                }


                int currentNum = int.Parse(inputNum);

                if (currentNum <= smallestNum)
                {
                    smallestNum = currentNum;
                }


            }
            Console.WriteLine(smallestNum);
        }
    }
}
