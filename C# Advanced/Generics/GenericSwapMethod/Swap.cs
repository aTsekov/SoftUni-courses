using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSwapMethod
{
    public class Swap<T>
    {
        public List<T> MyList { get; set; }

        public Swap(List<T> myList)
        {
            this.MyList = myList;
        }

        public void SwapMethod(List<T> myList, int index1, int index2)
        {
            T fistElement = MyList[index1];
            myList[index1] = MyList[index2];
            myList[index2] = fistElement;
        }
        public override string ToString() // overrive ToString in order to print the instance of Box directly in the format we want.
        {
            var sb = new StringBuilder();

            foreach (T element in MyList)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
