﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> bannedWords = Console.ReadLine()
                 .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string text = Console.ReadLine();

            foreach (string word in bannedWords)
            {
                text = text.Replace(word, new string('*', word.Length));
            }

            Console.WriteLine(text);

        }
    }
}
