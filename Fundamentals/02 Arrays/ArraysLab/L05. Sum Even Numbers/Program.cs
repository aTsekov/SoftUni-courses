using System;
using System.Linq;

namespace L05._Sum_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // *** Това е единия начин за въвеждане от конзолата на числов масив ***

            string[] rawInput = Console.ReadLine().Split(); //правим стрингов масив

            int[] input = new int[rawInput.Length];//правим числов масив и казваме че дължината му е колкото на стринговия масив. 

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = int.Parse(rawInput[i]);//опитай се да парснеш входа и да го запишеш в числовия масив. 
            }

            //***Втория начин за въвеждане на числов масив е: ***

            // int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray(); // на using трябва да добавим System.Linq;

            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int currNum = input[i];
                if (currNum % 2 == 0)
                {
                    sum += currNum;
                }
            }

            Console.WriteLine(sum);

        }
    }
}
