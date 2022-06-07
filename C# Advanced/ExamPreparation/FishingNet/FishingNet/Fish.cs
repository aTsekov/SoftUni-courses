using System;
using System.Collections.Generic;

namespace FishingNet
{
    public class Fish
    {

       
        public Fish(string fishType, double lenght, double weight)
        {
            FishType = fishType;
            Length = lenght;
            Weight = weight;
        }
        public string FishType { get; set; }
        public double Length { get; set; }
        public double Weight { get; set; }
        public override string ToString()
        {
            return ($"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.");
        }

        internal static IEnumerable<object> OrderByDescending(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
