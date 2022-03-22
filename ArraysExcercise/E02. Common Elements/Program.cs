using System;

namespace E02._Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] arra1 = Console.ReadLine().Split(' ');
            string [] arra2 = Console.ReadLine().Split(' ');

            for (int i = 0; i < arra1.Length; i++)
            {
                for (int j = 0; j < arra2.Length; j++)
                {
                    if (arra1[i] == arra2 [j]) // сравняваме двата масива. Ако има съвпадаш елемент, само тогава влиза в if-a
                    {
                        Console.Write(arra1[i]+ " "); // това принтира само текушия j защото е влязло в проверката и по този начин принтираме само 
                        // съвпадащите елементи.
                    }

                }

            }
        }
    }
}
