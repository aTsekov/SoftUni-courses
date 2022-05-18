using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _14_Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiPattern = @"(\:\:|\*\*)([A-Z])([a-z]{2,})\1";
            string coolDigitPattern = @"(?<digits>\d)";

            BigInteger coolThreshhold = 1;

            MatchCollection coolDigitMatches = Regex.Matches(text, coolDigitPattern);

            foreach (Match digit in coolDigitMatches)
            {
                BigInteger currentDigit = long.Parse(digit.Groups["digits"].ToString());
                coolThreshhold *= currentDigit;
            }
            MatchCollection matchEmoji =Regex.Matches(text,emojiPattern);
            int matchedEmojies = 0;
            List<string> coolEmojiesList = new List<string>();
            BigInteger charSum = 0;
            foreach (Match matchedEmoji in matchEmoji)
            {
                matchedEmojies++;

                for (int i = 0; i < matchedEmoji.Length; i++)
                {
                    string matchEmojiString = matchedEmoji.ToString();
                    char ch = matchEmojiString[i];
                    charSum += ch;
                }
                if (charSum > coolThreshhold)
                {
                    coolEmojiesList.Add(matchedEmoji.ToString());

                }

                charSum = 0;
            }
            Console.WriteLine($"Cool threshold: {coolThreshhold}");
            Console.WriteLine($"{matchedEmojies} emojis found in the text. The cool ones are:");
            foreach (var item in coolEmojiesList)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}
