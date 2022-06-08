using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    {

        public static T[] Create<T> (int lenght, T item) //Method of <T>
        {
            var result = new T[lenght]; //The generic array (that can be of any type) gets the lenght from the the method. 
            for (int i = 0; i < lenght; i++) // for each index, add/place item (which is also generic)
            {
                result[i] = item;
            }
            return result;               // return the result                 
        }
    }
}
