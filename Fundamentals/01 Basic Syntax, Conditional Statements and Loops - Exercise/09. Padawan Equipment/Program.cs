using System;

namespace _09._Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double budget = double.Parse(Console.ReadLine());
            int studentsNum = int.Parse(Console.ReadLine());    
            double lightsabers = double.Parse(Console.ReadLine());           
            double robes = double.Parse(Console.ReadLine());
            double belts = double.Parse(Console.ReadLine());
            

            double robesTotalPrice = studentsNum * robes;

            double totalLightsabersPrice = Math.Ceiling (studentsNum * 1.1) * lightsabers;

            int studentsCount = 0;

            if (studentsNum >= 6)
            {
                studentsCount = studentsNum / 6;
            }

            double beltsTotalPrice = belts * (studentsNum - studentsCount);

            double grandTotal = robesTotalPrice + totalLightsabersPrice + beltsTotalPrice;




            if (budget >= grandTotal)
            {
                Console.WriteLine($"The money is enough - it would cost {grandTotal:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {grandTotal - budget:f2}lv more.");
            }




        }
    }
}
