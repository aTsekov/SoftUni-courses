using System;

namespace Boxes
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numberOFLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOFLines; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box);

            }


        }
    }
}
