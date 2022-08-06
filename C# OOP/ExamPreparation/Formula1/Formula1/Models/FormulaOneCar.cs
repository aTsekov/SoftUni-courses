namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;

        

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
        }
        public string Model
        {
            get { return model; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidF1CarModel, value);
                }
                model = value;
            }
        }

        public int Horsepower
        {
            get { return horsePower; }
            protected set
            {
                if (value < 900 || value > 1050) // Is this inclusive or exclusive ?? "="
                {
                    throw new ArgumentException($"Invalid car horsepower: {value}." );// Why I cannot put the value here? 
                }
                horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            protected set
            {
                if (value < 1.6 || value > 2)
                {
                    throw new ArgumentException($"Invalid car engine displacement: {value}.");// Why I cannot put the value here? 

                }
                engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            double racePoints = engineDisplacement / horsePower * laps;
            return racePoints;
        }
    }
}
