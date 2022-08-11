namespace SpaceStation.Models
{
    using SpaceStation.Models.Planets.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;
        public Planet(string name)
        {
            this.Name = name;
            this.items = new List<string>();
        }
        public string Name 
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                name = value;
            }
        }
        public ICollection<string> Items => items;

      
    }
}
