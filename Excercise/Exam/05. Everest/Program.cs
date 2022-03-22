using System;

namespace _05._Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string YesNo = "";
            int startingMeters = 5364;
            const int EVEREST = 8848;
            int days = 1;            
            int climbedMeters = 0;

            while (YesNo != "END")
            {
                YesNo = Console.ReadLine();
                
                
                if (YesNo == "Yes")
                {
                    YesNo = Console.ReadLine();
                    climbedMeters = int.Parse(YesNo);
                    startingMeters += climbedMeters;
                    days++;
                }
                else if (YesNo == "No")
                {
                    YesNo = Console.ReadLine();
                    climbedMeters = int.Parse(YesNo);
                    startingMeters += climbedMeters;
                }

                if (startingMeters >= EVEREST) // CHECK IF SHOULD BE >=
                {
                    Console.WriteLine($"Goal reached for {days} days!");
                    break;
                }
                if (days == 5 || YesNo == "END")
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine(startingMeters);
                    break;

                }



            }

            //if (YesNo == "END")
            //{
            //    Console.WriteLine("Failed!");
            //    Console.WriteLine(startingMeters);
            //}


        }
    }
}
