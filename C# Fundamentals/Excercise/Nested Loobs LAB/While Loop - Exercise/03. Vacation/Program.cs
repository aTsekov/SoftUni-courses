using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {

            double needVacationMoney = double.Parse(Console.ReadLine());
            double currMoney = double.Parse(Console.ReadLine());

                       
            int days = 0;
            int spendCounter= 0;
             

            while (spendCounter != 5)
            {
                 string  intput = Console.ReadLine();
                 double money = double.Parse(Console.ReadLine());
                 days++;

                 if (intput == "save")
                  {
                    
                    currMoney += money;
                    spendCounter = 0;

                 }
                else if (intput == "spend")                              
                {

                    spendCounter++;
                    

                    if ( money > currMoney)
                    {
                        currMoney = 0; 
                    }
                    else
                    {
                        currMoney -= money;
                    }
                                       

                }


                if (currMoney >= needVacationMoney)
                {
                    Console.WriteLine($"You saved the money for {days} days. ");
                    break;
                }                

            }

            if (spendCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);

            }







        }
    }
}
