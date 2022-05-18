using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace L02_Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int numOfRecords = int.Parse(Console.ReadLine());
            Dictionary<string,List<decimal>> gradesBook = new Dictionary<string,List<decimal>>();

            for (int i = 0; i < numOfRecords; i++)
            {
                string [ ] tokens = Console.ReadLine().Split(' ');

                if (gradesBook.ContainsKey(tokens[0]))
                {
                    gradesBook[tokens[0]].Add(decimal.Parse(tokens[1]));
                }
                else
                {
                    gradesBook.Add(tokens[0], new List<decimal>() { decimal.Parse(tokens[1]) }); // We add value in the list which is the a the value of the KVP in the Dictionary. 
                }

            }

            foreach (var item in gradesBook)
            {
                Console.WriteLine($"{item.Key} -> {string.Join(' ', item.Value.Select(x => x.ToString("F2")))} (avg: {item.Value.Average():f2})"); 
                //We use the select in this case becase we need to format each element in the list (each value) 

            }
        }
    }
}
