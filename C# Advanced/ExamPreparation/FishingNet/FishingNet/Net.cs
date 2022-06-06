using System;
using System.Collections.Generic;
using System.Linq;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish { get; set; }
        public string Matrial { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return Fish.Count; }
        }


        public Net(string material, int capacity)
        {
            Fish = new List<Fish>();
            Capacity = capacity;
            Matrial = material;
        }

        public string AddFish(Fish fish)
        {
            if (fish.FishType == null || fish.FishType == " " || fish.Lenght <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Capacity <= Count)
            {
                return "Fishing net is full.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        //bool ReleaseFish(double weight) – removes a fish by given weight, if such exists return true, otherwise false.
        public bool ReleaseFish(double weight)
        {

            if (Fish.Any(f => f.Weight ==weight))
            {
                Fish.RemoveAll(f => f.Weight == weight);
                return true;
            }
            else
            {
                return false;
            }
        }
        //Fish GetFish(string fishType) – search and returns a fish by given fish type.
        public string GetFish (string fishType)
        {
            if (Fish.Any(f => f.FishType == fishType))
            {
                return fishType;
            }
            else
            {
                return null;
            }
             
        }
        public Fish GetBiggestFish()
        {
            double longestFish = 0;
            foreach (var fish in Fish)
            {
                if (fish.Lenght > longestFish)
                {
                    longestFish = fish.Lenght;
                }
            }
            return Fish.Where(f=> f.Lenght == longestFish).FirstOrDefault();
        }
        //Report() - returns information about the Net and all fish that were not released, order by fish's length descending  in the following format:
        public string Report()
        {
            var sortedFishes = Fish.OrderByDescending(f => f.Lenght).ToList();
            
            foreach (var fish in sortedFishes)
            {
                return $"Into the {Matrial}:{Environment.NewLine}There is a {fish.FishType}, {fish.Lenght} cm. long, and {fish.Weight} gr. in weight.";

            }
            return null;
        }
    }
}
