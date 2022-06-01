using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            AddEngines(n, engines);

        }

        private static void AddEngines(int n, List<Engine> engines)
        {
            for (int i = 0; i < n; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ").ToArray();
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                Engine engine = new Engine();


                if (engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (engineInfo.Length == 3)
                {
                    if (char.IsDigit(engineInfo[2][0]))
                    {
                        int displacement = int.Parse(engineInfo[2]);
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        string efficiency = engineInfo[2];
                        engine = new Engine(model, power, efficiency);
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    engine = new Engine(model, power, displacement, efficiency);

                }
                engines.Add(engine);

            }
        }
    }
}
