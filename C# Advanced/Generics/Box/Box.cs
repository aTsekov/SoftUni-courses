using System;
using System.Collections.Generic;
using System.Text;

namespace Boxes
{
    public class Box<T> //Create generic class
    {
        public Box(T element)// ctor that accepts genery variable
        {
            this.Element = element;
        }
        public T Element { get; set; }
        public override string ToString() // overrive ToString in order to print the instance of Box directly in the format we want.
        {
            return $"{typeof(T)}: {Element}";
        }
    }
}
