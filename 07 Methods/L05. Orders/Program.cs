using System;

namespace L05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product =Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculateOrder(product, quantity);// извикваме си метода и пише в скобите двете променливи които с ме вкарали от конзолата и надолу метода ще замести тези променливи с онези в скобите. наприменр product с productMethod. 
            
           

        }
        static void CalculateOrder(string productMethod, int quantityMethod)// правим си метод, който не връща резултат. Това са само методи void.
        {// добавяме две променливи, които плануваме да ползваме в main метода. 
            if (productMethod == "coffee")
            {
                decimal price = quantityMethod * 1.50m;
                Console.WriteLine($"{price:F2}");
            }
            else if (productMethod == "water")
            {
                decimal price = quantityMethod * 1.00m;
                Console.WriteLine($"{price:F2}");
            }
            else if (productMethod == "coke")
            {
                decimal price = quantityMethod * 1.40m;
                Console.WriteLine($"{price:F2}");
            }
            else if (productMethod == "snacks")
            {
                decimal price = quantityMethod * 2.00m;
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
