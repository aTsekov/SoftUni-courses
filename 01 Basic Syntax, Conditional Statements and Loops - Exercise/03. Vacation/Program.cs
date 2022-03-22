using System;

namespace _03._Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int numOfPeople = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();  
            string day  = Console.ReadLine();

            double singlePrice = 0;
            double totalPrice = 0; 

            if (groupType == "Students") 
            {
                if (day == "Friday")
                {
                    singlePrice = 8.45;
                }
                else if (day == "Saturday")
                {
                    singlePrice = 9.80;
                }
                else if (day == "Sunday")
                {
                    singlePrice = 10.46;
                }
                totalPrice = (singlePrice * numOfPeople);
                if (numOfPeople >= 30)
                {
                    totalPrice = (singlePrice * numOfPeople) * 0.85; 
                      
                }
            }
            else if (groupType == "Business")
            {
                if (day == "Friday")
                {
                    singlePrice = 10.90;
                }
                else if (day == "Saturday")
                {
                    singlePrice = 15.60;
                }
                else if (day == "Sunday")
                {
                    singlePrice = 16;
                }
                totalPrice = singlePrice * numOfPeople;
                if (numOfPeople >= 100)
                {
                    totalPrice = (numOfPeople - 10) * singlePrice;
                }
            }
            else if (groupType == "Regular")
            {
                if (day == "Friday")
                {
                    singlePrice = 15;
                }
                else if (day == "Saturday")
                {
                    singlePrice = 20;
                }
                else if (day == "Sunday")
                {
                    singlePrice = 22.50;
                }
                totalPrice = singlePrice * numOfPeople;
                if ( numOfPeople >= 10 && numOfPeople <= 20)
                {
                    totalPrice *= 0.95;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");




        }
    }
}
