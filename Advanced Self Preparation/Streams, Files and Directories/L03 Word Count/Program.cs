using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace L03_Word_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = Path.Combine("Data", "words.txt");
            var input = Path.Combine("Data", "Input.txt");
            string output = Path.Combine("Data", "Output.txt");
            Dictionary <string, int> wordAndFrequency = new Dictionary<string, int>();


            using (StreamReader wordsStream =  new StreamReader(words))
            {
                string wordsToSearch = File.ReadAllText(words);
                string [] splitWords = wordsToSearch.Split(" ");

                using (StreamReader inputToSearchIn = new StreamReader(input))
                {
                    string textToSeach = inputToSearchIn.ReadToEnd();

                    using (StreamWriter OutputText = new StreamWriter(output))
                    {
                        int counter = 0;

                        
                        string[] wholeText = textToSeach.ToLower()
                        .Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i < splitWords.Length; i++)
                        {
                            
                            wordAndFrequency.Add(splitWords[i],0);
                        }
                        foreach (var word in splitWords)
                        {
                            foreach (var item in wholeText)
                            {
                                if (word == item)
                                {
                                    if (wordAndFrequency.ContainsKey(word))
                                    {
                                        wordAndFrequency[word]++;

                                    }

                                }
                            }

                        }

                        foreach (var item in wordAndFrequency.OrderByDescending(x => x.Value))
                        {
                            OutputText.WriteLine($"{item.Key} - {item.Value}");
                        }




                    }

                }


            }
        }
    }
}
