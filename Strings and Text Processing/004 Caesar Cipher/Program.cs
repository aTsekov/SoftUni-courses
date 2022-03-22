using System;
using System.Text;

namespace _004_Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder encrypted = new StringBuilder();

            foreach (char ch in input)
            {
                int numbChar = ch +3;
                char encryptedChar = (char)numbChar;
                encrypted.Append((char)numbChar);

                
               
            }
            Console.Write(encrypted);
        }
    }
}
