namespace CarRacing.Models.Racers
{
    using CarRacing.Models.Cars.Contracts;
    using CarRacing.Models.Racers.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Racer : IRacer
    {
        private string username;
        public string Username
        {
            get { return username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                username = value;
            }
        }

        public string RacingBehavior => throw new NotImplementedException();

        public int DrivingExperience => throw new NotImplementedException();

        public ICar Car => throw new NotImplementedException();

        public bool IsAvailable()
        {
            throw new NotImplementedException();
        }

        public void Race()
        {
            throw new NotImplementedException();
        }
    }
}
