using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> nationals = new List<IId>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string [] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 3) // HUMAN
                {
                    string ID = tokens[2];
                    IId national = new Citizen(ID);
                    nationals.Add(national);
                }
                else if (tokens.Length == 2) // Robot
                {
                    string id = tokens[1];
                    IId national = new Robot(id);
                    nationals.Add(national);
                }

            }
            string fakeId = Console.ReadLine();
            List<IId> fakes = new List<IId>();

            foreach (var item in nationals)
            {
                int index = item.Id.Length - fakeId.Length;
                string lastDigits = item.Id.Substring(index);
                if (lastDigits == fakeId)
                {
                    fakes.Add(item);
                }
            }

            foreach (var item in fakes)
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
