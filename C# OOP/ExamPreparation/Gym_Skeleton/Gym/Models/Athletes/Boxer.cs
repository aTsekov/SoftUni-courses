namespace Gym.Models.Athletes
{
    using Gym.Models.Athletes.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Boxer : Athlete, IAthlete
    {
        private const int boxerInitialStamina = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals) 
            : base(fullName, motivation, numberOfMedals, boxerInitialStamina)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 15;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points");
            }
        }
    }
}
