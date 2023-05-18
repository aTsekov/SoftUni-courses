namespace Chronometer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();
            string line;
            while ((line = Console.ReadLine()) != "exit")
            {
                

                if (line == "start")
                {
                    Task.Run(() => { chronometer.Start(); }); //The chronometer runs on a separate thread so it can measure the time. 
                    //However whenever we type the command on the console, both threads are giving result. The second thread gives us the result and the main thread is responsive sow e can type on the console.
                }
                else if (line == "stop")
                {
                    chronometer.Stop();
                }
                else if (line == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (line == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine($"Laps: no laps");
                        continue;
                    }

                    Console.WriteLine("Laps: ");
                    for (int i = 0; i < chronometer.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i}. {chronometer.Laps[i]}");
                    }
                }
                else if (line == "reset")
                {
                    chronometer.Reset();
                }
                else if (line == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
            }
            chronometer.Stop();
        }
    }
}