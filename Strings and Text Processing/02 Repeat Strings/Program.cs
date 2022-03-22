using System;
using System.Text;

namespace _02_Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] words = Console.ReadLine().Split(' '); // правим масив от думи и фи сплитваме по спейс

            StringBuilder result = new StringBuilder(); // декларираме стринг билдър, в който ще пазим целия резултат(в случая всички долепени думи)

            foreach (string word in words)// правим foreach цикъл, за да можем да вземем всяка дума по отделно и да запазим в променлива, дължината на думата. 
            {
                int wordLenght = word.Length;

                for (int i = 0; i < wordLenght; i++) // колкото е дълга думата толкова пъти въртим цикъла
                {
                    //result.Append(word); // слепяме думите без разтояние и без никакъв разделител
                    result.Insert(0, word);
                }
            }
            Console.WriteLine(result);// принтираме.  
        }
    }
}
