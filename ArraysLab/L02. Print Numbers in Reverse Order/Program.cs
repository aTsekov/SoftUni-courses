using System;

namespace L02._Print_Numbers_in_Reverse_Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine()); // въвеждаме колко числа ще има в масива
            int[] numbers = new int[n]; // декларираме масива и му казваме, че ще бъде с големината на n въведеното число.

            for (int i = 0; i < n; i++)// правим фор цикъл за да пълним масива започвайки он нулева позиция.
            {

                numbers[i] = int.Parse(Console.ReadLine());

            }
            for (int i = numbers.Length - 1; i >= 0; i--)// правим втори цикъл за да обърнем стойнстите в масива
            {
                Console.Write(numbers[i]+ " "); // по този начин принтираме съдържанието на масива, минавайки през всеки индекс един по един с помощта на цикъла. 
            }

            //можем да заместин втория цикъл със следния синтаксис: 
            // Consol.WriteLine(string.Join(" ", numbers));


        }
    }
}
