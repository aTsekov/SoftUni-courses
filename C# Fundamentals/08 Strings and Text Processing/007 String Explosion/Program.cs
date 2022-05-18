using System;
using System.Text;

namespace P07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();

            //Here we should store a copy of inputStr
            StringBuilder outputText = new StringBuilder();
            int bombPower = 0;
            for (int i = 0; i < inputStr.Length; i++)
            {
                char currCh = inputStr[i];

                if (currCh == '>')
                {
                    
                    int currBombPower = GetIntValueOfCharacter(inputStr[i + 1]);// взимаме силата на бомбата(което е следващия чар.

                    outputText.Append(currCh); // добавяме текущия чар който е бомбата. 
                    bombPower += currBombPower; //добавяме към силата на бомбата, текущата сила на бомбата
                }
                else
                {
                    if (bombPower > 0)
                    {
                        //If there is detonated bomb
                        //Skips the character and decrease bomb power
                        bombPower--;
                    }
                    else
                    {
                        outputText.Append(currCh);
                    }
                }
            }

            Console.WriteLine(outputText.ToString());
        }

        static int GetIntValueOfCharacter(char ch)
        {
            return (int)ch - 48;
        }
    }
}