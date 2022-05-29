using System;

namespace ImplementingCustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();

            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            customList.Add(7);

            customList.RemoveAt(3);
            customList.Shrink();
            customList.Contains(2);
            
            customList.Contains(100);
            customList.Swap(2, 4);
        }
    }
}
