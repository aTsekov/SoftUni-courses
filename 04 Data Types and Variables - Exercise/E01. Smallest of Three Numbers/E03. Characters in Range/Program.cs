using System;

namespace E03._Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char charOne = char.Parse(Console.ReadLine());
            char charTwo = char.Parse(Console.ReadLine());
           PrintChars(charOne, charTwo);
        }
        static void PrintChars (char charOne, char CharTwo)
        {

            char currChar = '0';
           
            if ((int)(charOne) < (int)(CharTwo))
            {
                for (int i = charOne + 1; i < CharTwo; i++)
                {             
                currChar = (char)i;


                Console.Write($"{currChar} ");
                }
            }
            else
            {            
                for (int k = CharTwo + 1; k < charOne; k++)
                {
                currChar = (char)k;
                Console.Write($"{currChar} ");
                }
            }




        }
    }
}
