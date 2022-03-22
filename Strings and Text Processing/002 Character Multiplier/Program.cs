using System;

namespace _002_Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] arr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string str1 = arr[0];
            string str2 = arr[1];
            int minItterations = Math.Min(str1.Length, str2.Length); // намираме кой от двата стринга е по-малък
            int maxIntterations = Math.Max(str1.Length, str2.Length);// намираме по-големия стринг. 
           
            Console.WriteLine(Multiply(str1,str2, minItterations, maxIntterations));

        }

        static string Multiply (string str1, string str2,int minItterations, int maxIntterations)
        {
            int sum = 0;
            char[] firstArr = str1.ToCharArray();
            char[] secondArr = str2.ToCharArray();
            for (int i = 0; i < minItterations; i++) // въртим цикъл до по-малкия стринг и умножаваме символ по символ
            {
                char ch1 = str1[i];
                char ch2 = str2[i];
                int sum1 = ch1 * ch2;
                sum += sum1;
            }

            if (maxIntterations == firstArr.Length ) // ако по-големия стринг е първия стринг, то тогава върти цикъл от края на малкия то края на големия стринг и добавяй към сумата.
            {
                for (int i = minItterations; i < maxIntterations; i++)
                {
                    sum += firstArr[i];
                }
            }

            else
            {
                for (int i = minItterations; i < maxIntterations; i++)
                {
                    sum += secondArr[i];
                }
            }

            return sum.ToString();
        }
    }
}
