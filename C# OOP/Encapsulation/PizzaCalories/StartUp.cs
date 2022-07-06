using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] doughtInput = command.Split(' ');
                    Dough dh = new Dough(doughtInput[1], doughtInput[2], double.Parse(doughtInput[3]));
                    Console.WriteLine($"{dh.Calories:F2}");
                }
            }
            catch (Exception ae)
            {

                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
