namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Kettlebell : Equipment
    {
        private const double ketblebellWeight = 1000;
        private const decimal ketblebellPrice = 80;
        public Kettlebell() 
            : base(ketblebellWeight, ketblebellPrice)
        {
        }
    }
}
