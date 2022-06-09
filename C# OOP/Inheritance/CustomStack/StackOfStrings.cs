using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Count == 0) // if the count of the stack is 0 then return true
            {
                return true;
            } 
            return false;
        }
        public void AddRange(IEnumerable<string> elements) // It takes data sctructure of elements because we are using ForEach. IEnumerable is a base type. This way we can use it on every type of Data structure such as List, Stack, Queue, Array, etc. 
        {
            foreach (var item in elements) // for each item in elements push the item to the stack, list, array, etc. 
            {
                Push(item);
            }
        }

    }
}
