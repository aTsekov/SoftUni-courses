using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex =
                new Regex(@"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>\d+)\|[^|$%.\d]*(?<price>\d+\.?\d*)\$");

            double totalPrice = 0;

            while (true)
            {
                string customer = Console.ReadLine();

                if (customer == "end of shift")
                {
                    break;
                }

                var match = regex.Match(customer);

                if (match.Success)
                {
                    double currentPrice = double.Parse(match.Groups["price"].ToString()) *
                                          int.Parse(match.Groups["quantity"].ToString());
                    totalPrice += currentPrice;

                    Console.WriteLine($"{match.Groups["name"].Value}: {match.Groups["product"].Value} - {currentPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {totalPrice:f2}");

            // TEST CHANGE
        }
    }
}
