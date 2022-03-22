using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> participants = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Dictionary<string, double> competitorsInfo = new Dictionary<string, double>();
            
            
            

            string info;
            while ((info = Console.ReadLine()) != "end of race")
            {
                double sum = 0;
                StringBuilder Name = new StringBuilder();
                foreach (char ch in info)
                {
                    if (char.IsLetter(ch))
                    {
                        Name.Append(ch);
                    }
                    else if (char.IsDigit(ch))
                    {
                        sum += ch - 48;
                    }

                }
                if (participants.Contains(Name.ToString()))
                {
                    if (competitorsInfo.ContainsKey(Name.ToString()))
                    {
                        competitorsInfo[Name.ToString()] += sum;
                    }
                    else
                    {
                        competitorsInfo.Add(Name.ToString(), sum);
                    }
                }
                else
                {
                    continue;
                }            
            }
             var sortedDict = competitorsInfo.OrderByDescending(x => x.Value);
            int counter = 0;

            foreach (var item in sortedDict)
            {
                
                counter ++;
                if (counter ==1 )
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                }
                
                
            }
        }
    }
}
