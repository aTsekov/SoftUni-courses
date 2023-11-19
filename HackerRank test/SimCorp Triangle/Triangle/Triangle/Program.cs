using TriangleTask.Figures;
using TriangleTask.Interfaces;
using TriangleTask.Utilities;

namespace TriangleTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal sideA = 0, sideB= 0, sideC = 0;

            Console.WriteLine("Input the 3 sides.");

            sideA = GetValidDecimalInput("Side A: ");
            sideB = GetValidDecimalInput("Side B: ");
            sideC = GetValidDecimalInput("Side C: ");

            //If the user tries to input a negative number  we capture the exception in the Triangle class
            //The system will trow the message "The sides must be a positive number!" but with unhandled exception. 
            //That's why it's needed to capture the exception in the main method as well. 

            try
            {
                ITriangle triangle = new Triangle(sideA, sideB, sideC);
                string triangleType = FigureChecker.TriangleType(triangle);
                Console.WriteLine($"The triangle is: {triangleType}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please try again!.");
            }
        }

        static decimal GetValidDecimalInput(string currentSide)
        {
            while (true)
            {
                Console.Write(currentSide);
               
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Please enter a valid decimal value.");
            }
        }

    }
    
}