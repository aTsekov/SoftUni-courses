using System;
using System.Linq;

namespace E11._Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine() // въвеждаме първоначалните числа в масива
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            string comand = string.Empty; // правим празен стринг, който по-късно променяме.


            while ((comand = Console.ReadLine()) != "end") // ако стринг стане end цикъла приключва. 
            {
                string[] cmdArgs = comand.Split(' '); // правим един масив който прима две стойности в първия случай. На позиция 0 стои exchange на позиция 1 стои индекса който искаме в първия случай 1. 

                string cmdType = cmdArgs[0]; // правим променлива, която взима командата от стринговия масив. 

                if (cmdType == "exchange")
                {
                    int exchangeIndex = int.Parse(cmdArgs[1]); // взимам, втория елемент на стринговия масив и това ни е индекса след който ще променяме оригиналния числов масив. 
                    if (exchangeIndex < 0 || exchangeIndex >= input.Length)
                    {
                        // Invalid index - outside of the array)
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    input = ExchangeIndexMethod(input, exchangeIndex);

                }
                else if (cmdType == "max")
                {
                    string OddOrEven = cmdArgs[1];
                    int maxInddex = MaxOddOrEven (input,OddOrEven);
                    

                    if (maxInddex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(maxInddex);
                    }                    

                }
                else if (cmdType == "min")
                {
                    string OddOrEven = cmdArgs[1];
                    int minInddex = MinOddOrEven(input, OddOrEven);

                    if (minInddex == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(minInddex);
                    }

                }



            }




        }
        static int[] ExchangeIndexMethod(int[] input, int exchangeIndex) // exchangeIndex е онти горен индекс, който искаме да променяме. 
        {
            int[] exchangedNumbers = new int[input.Length]; // правим си нов масив, в който ще държим разменените числа от първоначалния input, най-горе.
            int exchangedNumberIndex = 0; // правим си индекс, с който ще записваме от 0 в новия масив exhangedNumbers[].

            for (int i = exchangeIndex + 1; i < input.Length; i++)// въртим цикъла от exchange index +1 защото искаме да хванем и преместим и числото от дясно на индекса. Тоес ако индекса е 1 ние искаме да преместим нещата на индекс 0, 1 и 2. Въртим цикъла до дължината на първоначалния интов масив.
            {
                exchangedNumbers[exchangedNumberIndex] = input[i];// тук се случва следното:

                //excahngedNumber[] = {0, 0 ,0 ,0 ,0}
                // input [] =         {1, 2, 3, 4, 5}
                //excahngedNumber[] = {4, 5 ,0 ,0 ,0}

                exchangedNumberIndex++; // увеличваме индекса с 1 за да пълним всеки следващ елемент  от excahngedNumber[]

            }
            for (int i = 0; i <= exchangeIndex; i++) // въртим втори цикъл за да запълним задните числа в excahngedNumber[].
            {
                exchangedNumbers[exchangedNumberIndex] = input[i]; //тук се случва следното:
                //excahngedNumber[] = {0, 0 ,0 ,0 ,0}
                // input [] =         {1, 2, 3, 4, 5}
                //excahngedNumber[] = {4, 5 ,1 ,2 ,3}

                exchangedNumberIndex++;
            }
            return exchangedNumbers;
        }
        static int MaxOddOrEven(int[] input, string OddOrEven)
        {
            int index = -1;
            int maxValue = int.MinValue;
                      

            for (int i = 0; i < input.Length ; i++)
            {
                int currNum = input[i];
                if (OddOrEven == "even")
                {
                    if (currNum %2 == 0 && currNum >= maxValue)
                    {
                        maxValue = currNum;
                        index = i;
                    }
                }
                else if (OddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && currNum >= maxValue)
                    {
                        maxValue = currNum;
                        index = i;
                    }
                }
            }

            return index;
        }
        static int MinOddOrEven(int[] input, string OddOrEven)
        {
            int index = -1;
            int minValue = int.MaxValue;


            for (int i = 0; i < input.Length; i++)
            {
                int currNum = input[i];
                if (OddOrEven == "even")
                {
                    if (currNum % 2 == 0 && currNum <= minValue)
                    {
                        minValue = currNum;
                        index = i;
                    }
                }
                else if (OddOrEven == "odd")
                {
                    if (currNum % 2 != 0 && currNum <= minValue)
                    {
                        minValue = currNum;
                        index = i;
                    }
                }
            }

            return index;
        }

    }
}
