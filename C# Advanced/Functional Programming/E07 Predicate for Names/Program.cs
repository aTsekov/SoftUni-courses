using System;
using System.Linq;

namespace E07_Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxLenghtName = int.Parse(Console.ReadLine());

            

            Func<string, int, bool> nameLenght =
                (name, lenght) => name.Length <= lenght;

            string[] names = Console.ReadLine().Split(' ').Where(name => nameLenght(name,maxLenghtName)).ToArray();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
