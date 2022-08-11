namespace SpaceStation.Models
{
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Geodesist : Astronaut, IAstronaut
    {
        private const double geodesisttOxigen = 50;
        public Geodesist(string name) 
            : base(name, geodesisttOxigen)
        {
        }
    }
}
