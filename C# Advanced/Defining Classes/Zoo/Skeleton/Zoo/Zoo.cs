using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;    
        }
        public Zoo()
        {
            AnimalsWhichCouldNotBeModified = new List<Animal>();
        }
        public List<Animal> AnimalsWhichCouldNotBeModified { get; set; }
        public string  Name { get; set; }
        public int Capacity { get; set; }

        public string  AddAnimal(Animal animal)
        {
            double capacity = Capacity;
            
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (capacity < AnimalsWhichCouldNotBeModified.Count)
            {
                return "The zoo is full.";
            }
            else if (capacity >= AnimalsWhichCouldNotBeModified.Count)
            {
                return $"Successfully added {animal.Species} to the zoo.";
            }

            return "Invalid input";
           
        }
        public int RemoveAnimals(string species)
        {
            int counter = 0;
            foreach (var animal in AnimalsWhichCouldNotBeModified)
            {
                if (animal.Species == species)
                {
                    AnimalsWhichCouldNotBeModified.Remove(animal);
                    counter ++;
                }
            }
            return counter; 
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List <Animal> animalsPerDiet = new List <Animal>();
            animalsPerDiet = AnimalsWhichCouldNotBeModified.Where(a => a.Diet == diet).ToList();
            return animalsPerDiet;
        }
        public Animal GetAnimalByWeight (double weight)
        {
            Animal animal = AnimalsWhichCouldNotBeModified.First(a => a.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> animalLenght = AnimalsWhichCouldNotBeModified.Where(a => a.Lenght >= minimumLength && a.Lenght <= maximumLength).ToList();
            int count = animalLenght.Count;
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
    

}
