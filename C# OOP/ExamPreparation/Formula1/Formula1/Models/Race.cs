namespace Formula1.Models
{
    using Formula1.Models.Contracts;
    using Formula1.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots; // This must be instantiated in the CTOR!!!

        
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.TookPlace = tookPlace;
            this.Pilots = new List<IPilot>(); // ???? THIS SHOULD NOT BE READONLY!!!
        }
        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRaceName,value);
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps;}
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidLapNumbers); //Is the message here correct? 
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get { return tookPlace;}
            set
            {
                tookPlace = false;
                tookPlace = value;
            }
        }

        public ICollection<IPilot> Pilots //I am not sure about the PROP !!!!
        {
            get { return pilots;}
            private set { pilots = value; }
        }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var place = TookPlace == true ? "Yes" : "No"; //I need to practice this. 
            string RaceInfo = $"The {RaceName} race has:{Environment.NewLine}Participants: {Pilots.Count}" +
                $"{Environment.NewLine}Number of laps: {NumberOfLaps}{Environment.NewLine}Took place: {place}";
            return RaceInfo;

            
        }
    }
}
