using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity) :this ()
        {
            Name = name;
            Capacity = capacity;    
        }
        public Zoo()
        {
            Animals = new List<Animal>();
        }
        public List<Animal> Animals { get; set; }
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
            if (capacity < Animals.Count)
            {
                return "The zoo is full.";
            }
            else if (capacity >= Animals.Count)
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }

            return "Invalid input";
           
        }
        public int RemoveAnimals(string species)
        {
            
            int lenght = Animals.Count;
                
                    Animals.RemoveAll(animal => animal.Species.Equals(species));
            int counter = Animals.Count;
            int final = lenght - counter;

            return final; 
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List <Animal> animalsPerDiet = new List <Animal>();
            animalsPerDiet = Animals.Where(a => a.Diet == diet).ToList();
            return animalsPerDiet;
        }
        public Animal GetAnimalByWeight (double weight)
        {
            Animal animal = Animals.First(a => a.Weight == weight);
            return animal;
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal> animalLenght = Animals.Where(a => a.Lenght >= minimumLength && a.Lenght <= maximumLength).ToList();
            int count = animalLenght.Count;
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
    

}
