using System;

namespace E04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MinCharNum = 6;
            const int MaxCharNum = 10;
            const int MinDigits = 2;

            string password = Console.ReadLine();

            bool isInRange = numberOfChars(password, MinCharNum, MaxCharNum); ;
            bool isOnlyLettersAndDigits = OnlyLetersAndDigits(password);
            bool isMinLenght = MinLenght(password,MinDigits);

            if (isInRange == false)
            {
                Console.WriteLine($"Password must be between {MinCharNum} and {MaxCharNum} characters");
            }
            if (isOnlyLettersAndDigits == false)
            {
                Console.WriteLine($"Password must consist only of letters and digits");
            }
            if (isMinLenght == false)
            {
                Console.WriteLine($"Password must have at least {MinDigits} digits");
            }
            if (isInRange == true && isOnlyLettersAndDigits == true && isMinLenght == true )
            {
                Console.WriteLine("Password is valid");
            }
          
        }

        static bool numberOfChars (string password, int MinCharNum, int MaxCharNum)
        {
            bool isInRange = true;
            if (password.Length < MinCharNum ||password.Length > MaxCharNum)
            {
                isInRange = false;
                return isInRange;
            }
            else
            {
                return isInRange = true;
            }


            
        }
        static bool OnlyLetersAndDigits(string password)
        {
            bool isOnlyLettersAndDigits = true;

            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return isOnlyLettersAndDigits = false;
                    
                }
                
                
                
            }
            return isOnlyLettersAndDigits = true;


        }
        static bool MinLenght(string password, int MinDigits)
        {
            bool isInMinDigits = true;
            int minLenght = 0;

            foreach (char ch in password)
            {

                if (Char.IsDigit(ch))
                {
                    minLenght++;
                    if (minLenght >= MinDigits)
                    {
                        return isInMinDigits = true;
                    }
                    
                }

            }
            return isInMinDigits = false;

        }
    }
}
