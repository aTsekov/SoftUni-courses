using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        
        public List<Fish> FishesList { get; set; }
        public string Matrial { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return FishesList.Count; }
        }


        public Net(string material, int capacity)
        {
            FishesList = new List<Fish>();
            Capacity = capacity;
            Matrial = material;
        }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (Capacity <= Count)
            {
                return "Fishing net is full.";
            }
            else
            {
                FishesList.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        //bool ReleaseFish(double weight) – removes a fish by given weight, if such exists return true, otherwise false.
        public bool ReleaseFish(double weight)
        {

            if (FishesList.Any(f => f.Weight ==weight))
            {
                FishesList.RemoveAll(f => f.Weight == weight);
                return true;
            }
            else
            {
                return false;
            }
        }
        //Fish GetFish(string fishType) – search and returns a fish by given fish type.
        public Fish GetFish (string fishType)
        {
            //Fish fishToSelect = Fish.Where(f =>f.FishType == fishType).FirstOrDefault();
            //if (Fish.Any(f => f.FishType == fishType))
            //{
            //    return $"There is a {fishToSelect.FishType}, {fishToSelect.Length} cm. long, and {fishToSelect.Weight} gr. in weight.";
            //}
            //else
            //{
            //    return null;
            //}
            var fish = this.FishesList.FirstOrDefault(e => e.FishType == fishType);
            return fish;

        }
        public Fish GetBiggestFish()
        {
            double longestFish = 0;
            foreach (var fish in FishesList)
            {
                if (fish.Length > longestFish)
                {
                    longestFish = fish.Length;
                }
            }
            return FishesList.Where(f=> f.Length == longestFish).FirstOrDefault();


        }
        //Report() - returns information about the Net and all fish that were not released, order by fish's length descending  in the following format:
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Matrial}:");

            foreach (var item in FishesList.OrderByDescending(x => x.Length))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
