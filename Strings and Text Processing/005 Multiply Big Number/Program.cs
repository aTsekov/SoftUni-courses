using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05.MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string longNum = Console.ReadLine();
            List<int> numberList = new List<int>();

            foreach (var item in longNum.Reverse())
            {
                numberList.Add((int)Char.GetNumericValue(item));
            }

            int shortNum = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            if (longNum == "0" || shortNum == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                int rest = 0;
                int baseNum = 0;

                foreach (int num in numberList)
                {
                    int current = num * shortNum + rest;
                    baseNum = current % 10;
                    rest = current / 10;
                    result.Append(baseNum);
                }
                if (rest != 0)
                {
                    result.Append(rest);
                }
                string resultStr = result.ToString();
                char[] reversedArr = resultStr.ToCharArray();
                Array.Reverse(reversedArr);
                resultStr = new String(reversedArr);
                Console.WriteLine(resultStr);
            }
        }
    }
}