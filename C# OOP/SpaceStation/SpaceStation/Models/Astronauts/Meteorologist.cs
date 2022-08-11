namespace SpaceStation.Models
{
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Meteorologist : Astronaut, IAstronaut
    {
        private const double metheorologistOxigen = 90;
        public Meteorologist(string name) 
            : base(name, metheorologistOxigen)
        {
        }
    }
}
