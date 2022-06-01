using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine()
        {

        }
        public Engine(string model, int power, int displacement, string efficinecy)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficinecy = efficinecy;


        }
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }
       
        public Engine(string model, int power, int displacement)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
        }
        public Engine(string model, int power, string efficinecy)
        {
            Model = model;
            Power = power;           
            Efficinecy = efficinecy;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; } = null;
        public string? Efficinecy { get; set; } = null ;

    }
}
