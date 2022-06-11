using System;
using System.Collections.Generic;
using System.Text;

namespace GenericThreeuple
{
    public class Threeuple <Tfirst, Tsecond,Tthird>
    {
        public Tfirst First { get; set; }
        public Tsecond Second { get; set; }
        public Tthird Third { get; set; }
        public Threeuple(Tfirst fistElement, Tsecond secondElement,Tthird thirdElement)
        {
            this.First = fistElement;
            this.Second = secondElement;
            this.Third = thirdElement;
        }
        public override string ToString() // overrive ToString in order to print the instance of Box directly in the format we want.
        {
            return $"{First} -> {Second} -> {Third}";
        }
    }
}
