using System;
using System.Collections.Generic;
using System.Linq;

namespace L08_SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
           HashSet<string> VIP = new HashSet<string>();
            HashSet<string> normal = new HashSet<string>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                
                char ch = input[0];

                if (char.IsDigit(ch))
                {
                    VIP.Add(input);
                }
                else if (input == "PARTY")
                {
                    while (input != "END")
                    {
                        
                        input = Console.ReadLine();
                        char chRemovingGests = input[0];
                        if (char.IsDigit(chRemovingGests))
                        {
                            VIP.Remove(input);
                        }
                        else if (char.IsLetter(chRemovingGests))
                        {
                            normal.Remove(input);
                        }
                    }

                    break;
                }
                else if (char.IsLetter(ch))
                {
                    normal.Add(input);
                }

            }

            int NotCameGuests =  normal.Count + VIP.Count;
            Console.WriteLine(NotCameGuests);
            foreach (var item in VIP)
            {
                Console.WriteLine(String.Join("",item));
            }
            foreach (var item in normal)
            {
                Console.WriteLine(String.Join("", item));
            }
        }
    }
}
