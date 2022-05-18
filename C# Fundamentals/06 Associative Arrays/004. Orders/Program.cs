using System;
using System.Collections.Generic;

namespace _004._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {   // четем от конзолата 1 ключ и две стойности
            string [] orderInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            // правим речник с един ключ и за value лист, защото имаме нужда от повече от една стойност.
            Dictionary <string, List<double>> dict = new Dictionary<string, List<double>>();

            
            
            

            while (orderInfo[0] != "buy")
            {
                string productKey = orderInfo[0];
                double price = double.Parse(orderInfo[1]);
                double quantity = double.Parse(orderInfo[2]);

                
                if (!dict.ContainsKey(productKey))// ако речника не съдържа ключ, който е като продукта го добавяме към речника и добавяме към листа двете стойности.
                {
                    dict.Add(productKey, new List<double>() { price, quantity });// така добавяме ключа и двете стойности към речника и листа едновремменно. 
                    
                }
                else// ако речника съдържа ключа, му обновяваме стойносстите.
                {
                    dict[productKey][0] = price; // на текущия ключ му слагаме стойност цена
                    dict[productKey][1] += quantity;// и на текущия ключ му слагаме втора стойност с помощта на листа.
                }


                orderInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            }
            foreach (var product in dict)
            {
                Console.WriteLine($"{product.Key} -> {(product.Value[0] * product.Value[1]):f2}");
            }



        }
    }
}
