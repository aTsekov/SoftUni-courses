using System;

namespace _05._Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            const int FACEBOOK = 150;
            const int INSTAGRAM = 100;
            const int REDDIT = 50;

            int tabsNum = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double salarySum = 0;
            

            for (int i = 0; i < tabsNum; i++)
            {
                string tabName = Console.ReadLine();
                if (tabName == "Facebook")
                {
                    salarySum += FACEBOOK;
                }
                else if (tabName == "Instagram")
                {
                    salarySum += INSTAGRAM;
                }
                else if (tabName == "Reddit")
                {
                    salarySum += REDDIT;
                }
                if (salary <= salarySum)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
                
            }

            if(salary > salarySum)
            {
                Console.WriteLine(salary - salarySum);
            }
        }
    }
}
