namespace Gym.Models.Gyms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGym : Gym
    {
        private const int boximGymCapacity = 15;
        public BoxingGym(string name) 
            : base(name, boximGymCapacity)
        {
        }
    }
}
