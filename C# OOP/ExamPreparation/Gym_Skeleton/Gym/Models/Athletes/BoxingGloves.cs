namespace Gym.Models.Athletes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BoxingGloves : Equipment
    {
        private const double glovesWeight = 227;
        private const decimal glovesPrice = 227;
        public BoxingGloves() 
            : base(glovesWeight, glovesPrice)
        {
        }
        
    }
}
