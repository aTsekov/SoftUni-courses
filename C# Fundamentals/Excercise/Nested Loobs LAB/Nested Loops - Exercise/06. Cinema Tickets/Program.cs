using System;

namespace _06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {

            string movie = Console.ReadLine();
            int freeSits = int.Parse(Console.ReadLine());
            string ticketType = "";
            int studentNum = 0;
            int standardNum = 0;
            int kidNum = 0;


            while (movie != "Finish")
            {
                int totalTickets = 0;

                for (int i = 0; i <= freeSits; i++)
                {
                    ticketType = Console.ReadLine();

                    if (ticketType == "student")
                    {
                        studentNum++;
                    }
                    else if (ticketType == "standard")
                    {
                        standardNum++;
                    }
                    else if (ticketType == "kid")
                    {
                        kidNum++;
                    }
                    else if (ticketType == "End")
                    {

                        Console.WriteLine($"{movie}{(totalTickets / freeSits) * 100}");

                        break;

                    }
                    int currentMovieTickets = studentNum + standardNum + kidNum);
                    }
                
                movie = Console.ReadLine();
            }
             
            
            





        }
    }
}
