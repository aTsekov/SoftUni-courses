namespace SumEvens_in_Background
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            //We open a task which creates a thread. On this new thread the calculation is done separately while the main thread 
            //is available and it's used by the console every time we type a command. Great example how the 2 threads are working simultaneously
            var task = Task.Run(() =>
            {
                for (long i = 0; i < 1000000000; i++)
                {
                    if (i % 2 == 0)
                    {
                        sum += i;
                    }
                }
            });

            while (true)
            {
                var line = Console.ReadLine();

                if (line == "exit")
                {
                    return;
                }
                else if (line == "show")
                {
                    Console.WriteLine(sum);
                }
            }
        }
    }
}