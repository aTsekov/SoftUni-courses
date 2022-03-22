using System;
using System.Text;

namespace _05._Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            
            string password = string.Empty;

            for (int i = username.Length - 1; i >= 0; i--) // реверсивен/обратен цикъл. Въртим от дължината на въведения стринг - 1 до 0, защото 0 е първата позиция на стринга. - 1 е защото броим дължината от 0 , но стринг ни има 7 символа.
            {
                password += username[i]; // достъпваме всяка следваща позиция на стринга при всяко завъртане на цикъла и го добавяме към password стринга. 
            }      


            for (int counter = 1; counter <= 4 ; counter++)
            {

                
                string enteredPass = Console.ReadLine();
                if (enteredPass == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;

                }
                else
                {
                    if (counter == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                        continue;
                    }
                }


            }











        }
    }
}
