using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {

            string name = Console.ReadLine();

            int grade = 1;
            double sumMark = 0;
            int failedclass = 0;
            


            while (grade <=12) // цикъла се върти докато стигне 12 клас или ученика повтаря два класа. 
            {
                double mark = double.Parse(Console.ReadLine()); // въвеждаме оценката
                                                                // сумираме всяка въведена оценка


                if (mark < 4)
                {
                    failedclass++;

                    if (failedclass == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break; 
                    }

                    continue;
                }

                sumMark += mark;
                grade++;
                
            }

            double markAverage = sumMark / 12;

            if (failedclass<2)
            
            {

                Console.WriteLine($"{name} graduated. Average grade: {markAverage:f2} ");
            }
            
                
            

            
            
            
                
            
            





        }
    }
}
