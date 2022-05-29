using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementingCustomList
{
    public class CustomList
    {
        private int[] elements; // internal array that will be used only within the class. 
        private int internalCounter;//internal counter that will be used only in the class

        public CustomList()
        {
            elements = new int[2]; // we initialize the array with the constant value of 2. 
            internalCounter = 0;
        }

        public int Count
            => internalCounter;

        public int this[int i] // This property makes sure that the indexes will be within the range of the Array and if not it will throw an error. 
        {
            get
            {
                EnsureIsInRange(i);
                return elements[i];
            }
            set
            {
                EnsureIsInRange(i);
                elements[i] = value;
            }
        }

        public void Add(int element)
        {
            Resize();
            elements[internalCounter] = element; // the Array "elements" on position "internalCounter" = "element" that was added in the method .Add(5)/.Add(element)
            internalCounter++;
        }

        public void Shrink() // with this method we make sure that the unused elements of the array after it was expanded will be deleted. 
        {
            int[] newArray = new int[internalCounter]; // the new array is = to the internalCounter which is the actual count of the items in the elements array. 

            for (int i = 0; i < internalCounter; i++)
            {
                newArray[i] = elements[i]; // we copy the elements in the new array
            }

            elements = newArray; // with this row the two arrays will have the same size. 
        }

        public int RemoveAt(int index)
        {
            EnsureIsInRange(index); // we ensure once again that the index is within the range of the array. 

            int number = elements[index]; // We save the number that we want to delete so we can print it later. 

            internalCounter--; // lower the counter because we will delete one item. 

            for (int i = index; i < internalCounter; i++) // we move the elements to the left from the index to the array lenght. 
            {
                elements[i] = elements[i + 1];
            }

            return number;//print the delete element
        }

        public bool Contains(int element) // Check if the element exists in the list. 
        {
            for (int i = 0; i < internalCounter; i++)
            {
                if (elements[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex) //swap two elements. 
        {
            EnsureIsInRange(firstIndex); // ensure the two indexes are valid. 
            EnsureIsInRange(secondIndex);

            int firstElement = elements[firstIndex]; // we save the first element. 
            elements[firstIndex] = elements[secondIndex]; // we put the value of the second element on the first element. 
            elements[secondIndex] = firstElement; // the second element takes the value of the saved value from the first element. 
        }

        private void EnsureIsInRange(int i) // if the given index is outside of the bounds of the array >> throw an error. 
        {
            if (i < 0 || i >= internalCounter) 
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void Resize() // Resize the initial array so it can hold more values. 
        {
            if (elements.Length == internalCounter)
            {
                int[] copyArray = new int[elements.Length * 2];

                for (int i = 0; i < elements.Length; i++)
                {
                    copyArray[i] = elements[i];
                }

                elements = copyArray;
            }
        }
    }
}
