using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
            
        }
        public List<Car> Participants { get; set; } //Is this the correct data structure??
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }//the maximum allowed number of participants in the race
        public int MaxHorsePower  { get; set; }//the maximum allowed Horse Power of a Car in the Race
        public int Count
        {
            get { return Participants.Count; }
        }

        public void Add(Car car)
        {
            string currPlate = car.LicensePlate;

            if (!Participants.Any(x => x.LicensePlate == car.LicensePlate))
            {
                if (car.HorsePower <= MaxHorsePower && Participants.Count <= Capacity)
                {
                    Participants.Add(car);
                }
            }
            
        }
        public bool Remove(string licensePlate)
        {
            if (Participants.Any(x => x.LicensePlate == licensePlate)) // if there is such a plate
            {
                Participants.RemoveAll(c => c.LicensePlate == licensePlate);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Car FindParticipant(string licensePlate)
        {

            if (Participants.Any(x => x.LicensePlate == licensePlate)) // if there is such a plate
            {
                var car = Participants.FirstOrDefault(c =>c.LicensePlate == licensePlate);
                return car;
            }
            else
            {
                return null;
            }
        }
        public Car GetMostPowerfulCar()
        {

            if (Participants.Count > 0) // if there is such a plate
            {
                double mostPowerful = 0;
                foreach (var car in Participants)
                {
                    if (car.HorsePower > mostPowerful)
                    {
                        mostPowerful = car.HorsePower;
                    }
                }
                return Participants.Where( c => c.HorsePower == mostPowerful ).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public string Report()
        {
            return $"Race: {Name} - Type: {Type} (Laps: {Laps}){Environment.NewLine}{string.Join(Environment.NewLine, Participants)}";
        }

    }
}
