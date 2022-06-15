using System;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
    {
        public List<T> Listy { get; set; }
        public int currentIndex { get; set; } 
        public ListyIterator(List<T> myLisy)
        {
            Listy = new List<T>();
            this.Listy = myLisy;
            currentIndex = 0;
        }

        
        public bool HasNext() => currentIndex< this.Listy.Count -1 ;// check if there is a next index. 
        public bool Move()
        { 
            bool canMove = HasNext(); // write in CanMove if there is a next index. 
            int index = 0;
            if (canMove) // If there is a next index  move to it
            {
                currentIndex++;
            }
            return canMove; // return if there is a next index or not. 
        }

        //Print - should print the element at the current internal index. Calling Print on a collection without elements should throw an appropriate exception with the message "Invalid Operation!". 
        
        public void Print()
        {
            if (Listy.Count == 0)
            {
                throw new ArgumentException("Invalid Operation");
            }

            Console.WriteLine($"{Listy[currentIndex]}");
        }
        
    }
}
