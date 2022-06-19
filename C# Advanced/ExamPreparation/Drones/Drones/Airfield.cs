using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string nameAerfield, int capacity, double landingStrip)
        {
            this.Drones = new List<Drone>(); // Initialize the list of Drones
            this.NameAerfield = nameAerfield;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
        }
        public List<Drone> Drones { get; set; }
        public string NameAerfield { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count // count of the drones on the airfiled. 
        {
            get { return Drones.Count; }
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrWhiteSpace(NameAerfield) || string.IsNullOrWhiteSpace(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }
            if (Capacity <= Count)
            {
                return "Airfield is full.";
            }
            else
            {
                Drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }
        }
        public bool RemoveDrone(string name)
        {
            if (Drones.Any(d => d.Name == name))
            {
                Drones.RemoveAll(d => d.Name == name);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int RemoveDroneByBrand(string brand)
        {
            if (Drones.Any(d => d.Brand == brand))
            {
                var numDronesToRemove = Drones.Where(d => d.Brand == brand).Count();
                Drones.RemoveAll(d => d.Brand == brand);
                return numDronesToRemove;
            }
            else
            {
                return 0;
            }
        }
        public Drone FlyDrone(string name) // Drone: CW4
        {
            if (Drones.Any(d => d.Name == name))
            {
                Drone drone = Drones.FirstOrDefault(d => d.Name == name);
                drone.Available = false;
                return drone;
            }
            else
            {
                return null;
            }
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            var list = Drones.Where(d => d.Range >= range).ToList();
            foreach (var item in list)
            {
                item.Available = false;
            }
            return list;
        }
        public string Report()
        {
            var availableDrones = Drones.Where(d => d.Available == true);

            return $"Drones available at {NameAerfield}:{Environment.NewLine}{string.Join(Environment.NewLine, availableDrones)}";


            //    StringBuilder sb = new StringBuilder();
            //    sb.AppendLine($"Drones available at {NameAerfield}:");
            //    foreach (var item in Drones.Where(d => d.Available == true))
            //    {
            //        sb.AppendLine(item.ToString());
            //    }
            //    return sb.ToString().TrimEnd();
            //}


        }
    }
}
