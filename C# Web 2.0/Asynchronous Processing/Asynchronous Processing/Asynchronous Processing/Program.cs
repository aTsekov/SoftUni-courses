using System.Threading;

namespace Asynchronous_Processing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numA = int.Parse(Console.ReadLine());
            var numB = int.Parse(Console.ReadLine());

            Thread evens = new Thread(() => PrintEvenNumber(numA, numB));
            evens.Start();// schedules the thread for execution
            evens.Join();// waits for the thread to finish its work (blocks the calling thread)

            Console.WriteLine("Thread finished work ");

        }

        static void PrintEvenNumber(int numA, int numB)
        {
            for (int i = numA; i <= numB; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}