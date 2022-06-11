using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple_
{
    public class Tuple <Tfirst,Tsecond>
    {
        public Tfirst First { get; set; }
        public Tsecond Second { get; set; }
        public Tuple(Tfirst fistElement, Tsecond secondElement)
        {
            this.First = fistElement;
            this.Second = secondElement;
        }
        public override string ToString() // overrive ToString in order to print the instance of Box directly in the format we want.
        {
            return $"{First} -> {Second}";
        }
    }
}
