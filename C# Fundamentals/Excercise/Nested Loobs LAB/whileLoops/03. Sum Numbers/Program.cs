using System;

namespace _03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Напишете програма, която чете цяло число от конзолата и на всеки следващ ред цели числа, докато тяхната сума стане по-голяма или равна на първоначалното число.След приключване да се отпечата сумата на въведените числа.
            int inputNum = int.Parse(Console.ReadLine());
            int sumNum = 1;

            while (sumNum <=inputNum)
            {
                int loopNum = int.Parse(Console.ReadLine());
                sumNum += loopNum;
            }
            Console.WriteLine(sumNum - 1);


        }
    }
}
