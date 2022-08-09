namespace Gym.Models.Gyms
{
    using global::Gym.Models.Athletes.Contracts;
    using global::Gym.Models.Equipment.Contracts;
    using global::Gym.Models.Gyms.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Gym : IGym // SHOULD THIS CLASS BE PROTECTED AS WELL? 
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> equipment;
        private ICollection<IAthlete> athletes;
        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Equipment = new List<IEquipment>(); // SHould this be as readOnly? 
            this.Athletes = new List<IAthlete>(); // SHould this be as readOnly? 
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");

                }
                name = value;
            } 
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value;
            }
        }
        public ICollection<IEquipment> Equipment
        {
            get { return equipment; }
            private set { equipment = value; }
        }
        public ICollection<IAthlete> Athletes
        {
            get { return athletes; }
            private set { athletes = value; }
        }
        public double EquipmentWeight { get; protected set; }

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity > this.Athletes.Count)
            {
                this.Athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
        }
        public bool RemoveAthlete(IAthlete athlete) //Is it correctly removed? 
        {
            return Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var ath in this.Athletes)
            {
                ath.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            if (Athletes.Count == 0)
            {
                sb.AppendLine(" No athletes");
            }
            else
            {
                sb.AppendLine($"Athletes: {string.Join(", ", Athletes)}");
            }
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight} grams");

            return sb.ToString().TrimEnd();
        }

        
    }
}
