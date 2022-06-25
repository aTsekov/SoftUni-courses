using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    { 

        public Renovator(string name, string type, double rate, int days)
        {
            this.Name = name;
            this.Type = type;
            this.Rate = rate;
            this.Days = days;

        }
        private string _name;
        private string _type;
        private double _rate;
        private int _days;
        private bool _hired = false;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public double Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        public int Days
        {
            get { return _days; }
            set { _days = value; }
        }
        public bool Hired
        {
            get { return _hired; }
            set { _hired = value; }

        }


        public override string ToString()
        {
            return $"-Renovator: {Name}{Environment.NewLine}--Specialty: {Type}{Environment.NewLine}--Rate per day: {Rate} BGN";
        }
    }
}
