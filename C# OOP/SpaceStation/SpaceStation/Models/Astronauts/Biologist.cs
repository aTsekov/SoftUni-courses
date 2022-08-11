namespace SpaceStation.Models.Astronauts
{
    using SpaceStation.Models.Astronauts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Biologist : Astronaut, IAstronaut
    {
        private const double biologistOxigen = 70;
        public Biologist(string name) 
            : base(name, biologistOxigen)
        {
        }
        public override void Breath()
        {
            Oxygen -= 5;
        }
    }
}
