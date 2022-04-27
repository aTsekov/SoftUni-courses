using System;
using System.Collections.Generic;
using System.Linq;

namespace L04_Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            SortedDictionary<string, Dictionary<string,decimal>> shops = new SortedDictionary<string,Dictionary<string,decimal>>();

            
            string input = Console.ReadLine();
            while (input != "Revision")
            {

                string[] tokes = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string shop = tokes[0];
                string product = tokes[1];
                decimal price = decimal.Parse(tokes[2]);

                if (!shops.ContainsKey(tokes[0]))
                {
                    shops[shop] = new Dictionary<string, decimal>();
                }
                shops[shop].Add(product, price);


                input = Console.ReadLine();
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product  in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {(double)product.Value}");
                }
            }
        }
    }
}
