using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _11_Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@[#]+)[A-Z][A-Za-z0-9]{4,}[A-Z]\@";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string barcodeToMatch = Console.ReadLine();
                string group = string.Empty;
                Match match = Regex.Match(barcodeToMatch, pattern);
                if (Regex.IsMatch(barcodeToMatch, pattern))
                {
                    char[] digits = barcodeToMatch.Where(x => char.IsDigit(x)).ToArray();

                    if (digits.Length == 0)
                    {
                        Console.WriteLine("Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {string.Join(string.Empty, digits)}");

                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }

            }
        }
    }
}
