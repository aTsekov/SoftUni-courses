namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Weightlifter : Athlete, IAthlete
    {
        private const int weihgtlifterInitialStamina = 50;
        public Weightlifter(string fullName, string motivation, int numberOfMedals) 
            
            : base(fullName, motivation, numberOfMedals, weihgtlifterInitialStamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points");
            }
        }
    }
}
