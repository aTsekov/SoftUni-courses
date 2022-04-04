using System;

namespace _03._Courier_Express
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string serviceType = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());
            double cents = 0;
            double totalPrice = 0;
            double totalPriceWithAdd = 0;

            if (serviceType == "standard")
            {
                if (weight < 1)
                {
                    cents = 3;
                    totalPrice = distance * cents / 100;
                }
                else if ( weight > 1 && weight < 10)
                {
                    cents = 5;
                    totalPrice = distance * cents / 100;
                }
                else if (weight >= 10 && weight < 40)
                {
                    cents = 10;
                    totalPrice = distance * cents / 100;
                }
                else if (weight >= 40 && weight < 90)
                {
                    cents = 15;
                    totalPrice = distance * cents / 100;
                }
                else if (weight >=90 && weight < 150)
                {
                    cents = 20;
                    totalPrice = distance * cents / 100;
                }

            }

            else if (serviceType == "express")
            {
                if (weight < 1)
                {
                    cents = 3;
                    totalPrice = distance * cents / 100;
                    totalPriceWithAdd = ((cents * 0.8) * weight / 100) * distance;
                }
                else if (weight > 1 && weight < 10)
                {
                    cents = 5;
                    totalPrice = distance * cents / 100;
                    totalPriceWithAdd = ((cents * 0.4) * weight / 100) * distance;
                }
                else if (weight >= 10 && weight < 40)
                {
                    cents = 10;
                    totalPrice = distance * cents / 100;
                    totalPriceWithAdd = ((cents * 0.05) * weight / 100) * distance;
                }
                else if (weight >= 40 && weight < 90)
                {
                    cents = 15;
                    totalPrice = distance * cents / 100;
                    totalPriceWithAdd = ((cents * 0.02) * weight/100) * distance;
                }
                else if (weight >= 90 && weight < 150)
                {
                    cents = 20;
                    totalPrice = distance * cents / 100;
                    totalPriceWithAdd = ((cents * 0.01) * weight / 100) * distance;
                }


            }

            if (serviceType == "standard")
            {
                Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {totalPrice:f2} lv.");
            }
            else
            {
                Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {totalPrice + totalPriceWithAdd:f2} lv.");
            }
            

        }
    }
}
