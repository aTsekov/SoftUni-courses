using System;

namespace Drones
{
    public class Drone
    {
        private string _name;
        private string _brand;
        private int _range;
        private bool _available = true;
        public Drone(string name, string brand, int range)
        {
            this.Name = name;
            this.Brand = brand;
            this.Range = range;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public int Range
        {
            get { return _range; }
            set { _range = value; }
        }
        public bool Available
        {
            get { return _available; }
            set { _available = value; }
        }

        public override string ToString()
        {
            return $"Drone: {Name}{Environment.NewLine}" +
                $"Manufactured by: {Brand}{Environment.NewLine}" +
                $"Range: {Range} kilometers";
        }

    }
}
