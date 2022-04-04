using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {

            string favouriteBook = Console.ReadLine();
            int bookCounter = 0;
            string nextBook = "";


            while (favouriteBook != "No More Books")
            {
                nextBook = Console.ReadLine();
                
                if (nextBook == favouriteBook)
                {
                    Console.WriteLine($"You checked {bookCounter} books and found it.");
                    break; 
                }
                
                if (nextBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookCounter} books.");
                    break;
                }
                bookCounter++;
            }








        }
    }
}
