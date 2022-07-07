using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = new Pizza();
                string command;
                while ((command = Console.ReadLine()) != "END")
                {

                    if (command.StartsWith('D'))
                    {
                        string[] doughtInput = command.Split(' ');
                        Dough dh = new Dough(doughtInput[1], doughtInput[2], double.Parse(doughtInput[3]));
                        //Console.WriteLine($"{dh.calories:F2}");
                        pizza.Dough = dh;
                    }
                    else if (command.StartsWith('T'))
                    {
                        string[] toppingInput = command.Split(' ');
                        Topping tp = new Topping(toppingInput[1],double.Parse(toppingInput[2]));
                        //Console.WriteLine($"{tp.toppingCalories:F2}");
                        pizza.AddTopping(tp);
                    }
                    else if (command.StartsWith('P'))
                    {
                        string[] pizzaInfo = command.Split(' ');
                       pizza = new Pizza(pizzaInfo[1]);
                    }
                    
                    
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
                
            }
            catch (Exception ae)
            {

                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
