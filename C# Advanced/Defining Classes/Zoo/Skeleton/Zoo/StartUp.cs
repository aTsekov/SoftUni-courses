using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var zoo = new Zoo("Zoo Time",20);
            var animaleOne = new Animal("elephant", "herbivore", 4000, 4);
            Console.WriteLine(zoo.AddAnimal(animaleOne));
        }
    }
}
