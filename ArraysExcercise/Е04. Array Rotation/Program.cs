using System;
using System.Linq;

namespace Е04._Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int roations = int.Parse(Console.ReadLine());
            

            for (int rot = 1; rot <= roations; rot++) // с този цикъл повтаряме ротацията. 
            {
                int firstEl = input[0]; // запазваме си пъроначалното ПЪРВО число.

                for (int i = 0; i <= input.Length - 2; i++) // този цикъл е за една ротация. 
                {
                    // i = 0
                    //input [0] =input [1]
                    //i = 1
                    //input [1] =input [2]
                    //i = 2
                    //input [2] =input [3]
                    //i = 3 (input.Lenght - 2)
                    

                    input[i] = input[i + 1]; // тук казваме че текущата стройност на масива i взима стойнстта на масива от i + 1. 
                    // това го правим, за да преместим числата на ляво. 
                    // (input.Lenght - 2) го ползваме, защото масива има 5 елемента подредени от 0 до 4 позиция.
                    // на първата итерация обработваме индекси 0 и 1, на втората, 1 и 2, на третата 2 и 3, на четвъртата 3 и 4. и тук трябва да спрем, защото ако беше Lenght - 1 тогава щяхме да излезем извън масива и да получим грешка.  позиция четири се пази празна
                    // докато не я запълним с първото число, което сме запазили в firstEl. 

                }
                input[input.Length - 1] = firstEl; //на последния индекс слагаме пъривя елемент който сме запазили предварително. 
            }

            Console.WriteLine(String.Join(" ", input));
        }
    }
}
