using System;

namespace _001_Advertisement_Message
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                string phrase = phrases[rand.Next(0, phrases.Length)];// така взимаме рандом фраза на рандом индекс он масива. 

                // int randomIndex = rand.Next(0, phrases.Length); така взимаме рандом индекс он масива
                string @event = events[rand.Next(0, events.Length)];
                string author = authors[rand.Next(0, authors.Length)];
                string city = cities[rand.Next(0, cities.Length)];
                Console.WriteLine($"{phrase} {@event} {author} {city}"); // вече сме записали рандом стринга в променливата и тук само принтираме. 

            } 





        }

    }
}
            
   

