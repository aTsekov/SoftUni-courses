using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace _04_StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            static void Main(string[] args)
            {
                int numOfMessages = int.Parse(Console.ReadLine());

                string messageToDectypt = String.Empty;
                int decryptionKey = 0;
                string decryptedMessage = string.Empty;
                string pattern = @"\@(?<planet>[A-Z][a-z]+)([^@,\-!:>]*)\:(?<population>\d+)(([^@,\-!:>]*))\!(?<atackType>[A|D]{1})\!([^@,\-!:>]*)->(?<soldierCount>\d+)";

                List<string> attackedPlanets = new List<string>();
                List<string> destroyedPlanets = new List<string>();


                for (int i = 0; i < numOfMessages; i++)
                {
                    messageToDectypt = Console.ReadLine();
                    decryptionKey = GetDecryptionKey(messageToDectypt);
                    decryptedMessage = DecryptedMessage(messageToDectypt, decryptionKey);

                    Match match = Regex.Match(decryptedMessage, pattern);
                    if (match.Success)
                    {
                        if (match.Groups["atackType"].Value == "A")
                        {
                            attackedPlanets.Add(match.Groups["planet"].Value);
                        }
                        else if (match.Groups["atackType"].Value == "D")
                        {
                            destroyedPlanets.Add(match.Groups["planet"].Value);
                        }
                    }

                }
                Print(attackedPlanets, destroyedPlanets);
            }
            static void Print(List<string> attackedPlanets, List<string> destroyedPlanets)
            {
                Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
                foreach (string planetName in attackedPlanets.OrderBy(n => n))
                {

                    Console.WriteLine($"-> {planetName}");

                }
                Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
                foreach (string planetName in destroyedPlanets.OrderBy(n => n))
                {

                    Console.WriteLine($"-> {planetName}");

                }
            }
            static string DecryptedMessage(string messageToDectypt, int decryptionKey)
            {
                StringBuilder dectyptedMessage = new StringBuilder();
                foreach (char ch in messageToDectypt)
                {
                    char newCh = (char)(ch - decryptionKey);
                    dectyptedMessage.Append(newCh);
                }
                return dectyptedMessage.ToString();
            }
            static int GetDecryptionKey(string messageToDectypt)
            {
                string dectyptPattern = @"([star]{1})";
                MatchCollection matches = Regex.Matches(messageToDectypt, dectyptPattern, RegexOptions.IgnoreCase);
                return matches.Count;
            }
        }
    }

}
    

