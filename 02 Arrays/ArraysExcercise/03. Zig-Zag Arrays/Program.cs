using System;
using System.Linq;  

namespace E03._Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int n = int.Parse(Console.ReadLine());

            int [] array1 = new int[n]; // създаваме си два масива, вкоито ще държим преобразуваните данни. 
            int [] array2 = new int[n];// дължината им е = n  защото в зависимост от n толкова празни клетки ни трябват.

           

            for (int row = 1; row <= n ; row++) // циклим от първи (нечетен) ред до последния ред. 
            {
                int[] currentRawData = Console.ReadLine() // вкарваме суровата дата, която винаги е по две числа на ред и премахваме изличните празни пространства. 
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int firstNum = currentRawData[0];// запазваме първото число от масива в променлива (на всеки цикъл то се променя).
                int secondNum = currentRawData[1];// запазваме второто число от масива в променлива (на всеки цикъл то се променя).

                if (row % 2 != 0) // ако е нечетно число, взимаме първото число от суровата дата и го добавяме към първия масив. 
                {
                    array1 [row - 1] = firstNum;// на позиция row - 1 (първия път това е 0, след това 1, 2 и т.н.) слагаме стойността от текущата променлива (която ще се промени на следващия цикъл)
                    array2 [row - 1] = secondNum;

                }
                else // ако е нечетно взимаме второто число от суровата дата и го прибавяме към първия масив. 
                {
                    array1 [ row - 1] = secondNum;
                    array2[row - 1] = firstNum;
                }                         
                            
            }

            Console.WriteLine(String.Join(" ", array1));
            Console.WriteLine(String.Join(" ", array2));



        }
    }
}
