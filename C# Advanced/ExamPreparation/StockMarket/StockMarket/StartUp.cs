using System;

namespace StockMarket
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Sample Code Usage:

            // Initialize Investor
            Investor investor = new Investor("Peter Lynch", "p.lynch@gmail.com", 2000m, "Fidelity");

            // Initialize Stock
            Stock ibmStock = new Stock("IBM", "Arvind Krishna", 138.50m, 5000);

            // Print a stock
            Console.WriteLine(ibmStock.ToString());

            // Company: IBM
            // Director: Arvind Krishna
            // Price per share: $138.50
            // Market capitalization: $692500.00

            // Buy a stock
            investor.BuyStock(ibmStock);
        }
    }
}
