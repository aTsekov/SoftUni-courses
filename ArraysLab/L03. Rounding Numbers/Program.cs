using System;
using System.Linq;

namespace L03._Rounding_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string [] rawInput = Console.ReadLine().Split();// въвеждаме числата като стринг
            double[] items = new double[rawInput.Length]; //правим дължината на числовия масив равна на дължината на стринговия масив.

            for (int i = 0; i < rawInput.Length; i++) //въртим цикъл от 0 до дължината на стринговия масив
            {
                items[i] = double.Parse(rawInput[i]); // пълним числовия масив като парсваме датата ор стринговия масив
            }
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"{items[i]} => {Math.Round(items[i], MidpointRounding.AwayFromZero)}"); // принтираме едно по едно числата от числовия масив и ги закръгляме с метода aways from zero. 
            }
        }
    }
}
