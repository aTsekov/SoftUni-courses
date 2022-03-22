using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            string comand = Console.ReadLine(); ;
            int totalStudents = 0;
            int totalStandards = 0;
            int totalKids = 0;
            int totalTickets = 0;

            while (comand != "Finish")
            {
                
                int student = 0;
                int standard = 0;
                int kid = 0;

                int freeSpots = int.Parse(Console.ReadLine());
                for (int i = 0; i < freeSpots; i++)
                {
                    string ticketType = Console.ReadLine();
                    if (ticketType == "End")

                    {
                        break;
                    }
                    switch (ticketType)
                    {
                        case "student":
                            student++;
                            break;
                        case "standard":
                            standard++;
                            break;
                        case "kid":
                            kid++;
                            break;
                    }

                }

                totalStudents += student;
                totalStandards += standard;
                totalKids += kid;
                double persentageFull = (student + standard + kid) / (double)freeSpots * 100;
                Console.WriteLine($"{comand} - {persentageFull:f2}% full.");
                comand = Console.ReadLine();
            }
            totalTickets = totalStandards + totalStudents + totalKids;
            Console.WriteLine($"Total tickets: {totalTickets}");
            double standartPercentage = totalStandards / (double)totalTickets * 100;
            double studentPercentage = totalStudents / (double)totalTickets * 100;
            double kidsPercentage = totalKids / (double)totalTickets * 100;


            
            Console.WriteLine($"{studentPercentage:f2}% student tickets.");
            Console.WriteLine($"{standartPercentage:f2}% standard tickets.");
            Console.WriteLine($"{kidsPercentage:f2}% kids tickets.");


        }
    }
}
