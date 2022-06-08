using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class BoxOfT <T>
    {
        public List<T> ListOfElements { get; set; }
        public int Count // Creates a property that gets the count of the list. 
        {
            get { return ListOfElements.Count; }
        }
        public BoxOfT()
        {
            this.ListOfElements = new List<T>();
        }
        public void Add(T element)
        {
            this.ListOfElements.Add(element);
        }
        public T Remove()
        {
            var lasElement = this.ListOfElements[ListOfElements.Count - 1]; // We seek for the last element and write it in the variable. 
             this.ListOfElements.RemoveAt(ListOfElements.Count - 1); // The last element gets deleted
            return lasElement; // Returns the last element. 
        }

    }
}
