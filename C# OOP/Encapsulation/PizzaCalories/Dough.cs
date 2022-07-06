using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double white = 1.5;
        private const double wholegrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;
        private const double grams = 2;

        private string flourType;
        private string bakingTechnique;
        private double weightGrams;
        private double doughtType;
        private double techniqueType;
        public Dough(string flourType, string bakingTechnique, double weightGrams)
        {
            this.FlourType = flourType;
            this.BakinTechnique = bakingTechnique;
            this.WeightGrams = weightGrams;
        }
        public string FlourType

        {
            get { return flourType; }
            private set
            {
                if (value.ToLower() == "White".ToLower())
                {
                    doughtType = white;
                }
                else if (value.ToLower() == "Wholegrain".ToLower())
                {
                    doughtType = wholegrain;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value;
            }
        }
        
            
        public string BakinTechnique
        {
            get { return bakingTechnique; }
            private set
            {
                if (value.ToLower() == "Crispy".ToLower())
                {
                    techniqueType = crispy;
                }
                else if (value.ToLower() == "Chewy".ToLower())
                {
                    techniqueType = chewy;
                }
                else if (value.ToLower() == "Homemade".ToLower())
                {
                    techniqueType = homemade;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
            }
        }
        public double WeightGrams
        {
            get { return weightGrams; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                weightGrams = value;
            }
        }

        public double Calories => (grams * this.WeightGrams * this.doughtType * this.techniqueType);

    }
}
