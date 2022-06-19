using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowelsQ = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());

            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            HashSet<char> pearContent = new HashSet<char>();
            HashSet<char> flourContent = new HashSet<char>();
            HashSet<char> porkContent = new HashSet<char>();
            HashSet<char> oliveContent = new HashSet<char>();


            List<string> foundWords = new List<string>();

            while (consonants.Count != 0) // Loop until the we have consonants. 
            {
                char currVowel = vowelsQ.Peek();
                char currConsonant = consonants.Peek();
                //***************PEAR*****************
                if (IsVowelPresent(pear, currVowel))
                {
                   pearContent.Add(currVowel);    
                }
                if (IsConsonentPresent(pear,currConsonant))
                {
                    pearContent.Add(currConsonant);
                  
                }
                
                //******************FLOUR********************

                if (IsVowelPresent(flour, currVowel))
                {
                    flourContent.Add(currVowel);
                }
                if (IsConsonentPresent(flour, currConsonant))
                {
                    flourContent.Add(currConsonant);
                }
                

                //**************PORK*****************
                if (IsVowelPresent(pork, currVowel))
                {
                    porkContent.Add(currVowel);

                }
                if (IsConsonentPresent(pork, currConsonant))
                {
                    porkContent.Add(currConsonant);
                }
                
                //*******************OLIVE***************
                if (IsVowelPresent(olive, currVowel))
                {
                    oliveContent.Add(currVowel);

                }
                if (IsConsonentPresent(olive, currConsonant))
                {
                    oliveContent.Add(currConsonant);
                }
                
                vowelsQ.Dequeue(); // remove the vowel and move it to the last position in the queue
                vowelsQ.Enqueue(currVowel);
                consonants.Pop(); // remove the consonant
            }
            if (pearContent.Count == pear.Length)
            {
                foundWords.Add(pear);
            }
            if (flourContent.Count == flour.Length)
            {
                foundWords.Add(flour);
            }
            if (porkContent.Count == pork.Length)
            {
                foundWords.Add(pork);
            }
            if (oliveContent.Count == olive.Length)
            {
                foundWords.Add(olive);
            }

            Console.WriteLine($"Words found: {foundWords.Count}");
            Console.WriteLine(String.Join(Environment.NewLine,foundWords));

        }
        static bool IsVowelPresent( string wordToCheck, char currVowel)
        {
            if (wordToCheck.Contains(currVowel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool IsConsonentPresent(string wordToCheck, char currConsonent)
        {
            if (wordToCheck.Contains(currConsonent))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
