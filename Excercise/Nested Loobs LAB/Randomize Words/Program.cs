using System;

namespace Randomize_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] word = input.Split(' '); // разбивам на части стринга, за да мога да взема индекса на всяка дума. 
            Random random = new Random(); // декларирам класа първо

            for (int i = 0; i < word.Length; i++)
            {
                int randomIndex = random.Next(0, word.Length); // извеждам си в една променлива генерирания рандом индекс от масива
                string currentWord = word[i]; // запазвам си коя е текущата дума.
                word[i] = word [randomIndex]; // в текущата ни клетка записваме случаен индекс
                word [randomIndex] = currentWord; // казвам че текущия случаен индекс е текущата дума. 
            }
            foreach (var words in word)
            {
                Console.WriteLine(words); // принтирам разместения масив. 
            }
        }
    }
}
