using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = string.Empty;

        }
        public Car(string model,Engine engine) : this ( model, engine, 0, string.Empty) 
        {

        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; } = null;
        public string? Color { get; set; } = null;


    }
}
