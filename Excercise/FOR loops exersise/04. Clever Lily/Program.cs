using System;

namespace _04._Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {

            int age = int.Parse(Console.ReadLine());
            double laundyPrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse( Console.ReadLine());

            var toyCount = 0;
            var moneyCount = 0;
            var totalToyMoney = 0.0;
            var sumMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                moneyCount +=5;
                if (i % 2 ==0)
                {
                    sumMoney += moneyCount - 1;

                }
                else
                {
                    toyCount++;
                    
                }

                 

                
            }
            totalToyMoney = toyCount * toyPrice;

            double collectedMoney = totalToyMoney + sumMoney;

            if (collectedMoney >= laundyPrice)
            {
                Console.WriteLine($"Yes! {Math.Abs(collectedMoney - laundyPrice):f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(laundyPrice - collectedMoney):f2}");
            }


        }
    }
}
