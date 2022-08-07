namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car; // THis Should be initiated in the CTOR!
        private bool canRace = false;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            //this.Car = car; // Should this be like this? 
            this.CanRace = canRace;
        }
        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPilot, value);
                }
                fullName = value;
            }
        }
        public bool CanRace
        {
            get {return canRace; }
            private set
            {
                
                canRace = value;
            }
        }
        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                car = value;
            }
        }

        public int NumberOfWins { get; private set; } // Should this be left like that?



        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            canRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {fullName} has {NumberOfWins} wins.";
        }
    }
}
