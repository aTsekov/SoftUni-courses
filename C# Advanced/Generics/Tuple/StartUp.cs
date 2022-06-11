using System;

namespace Tuple_
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string [] personInfo = Console.ReadLine().Split(' ');

            string firstName = personInfo[0];
            string lastName = personInfo[1];
            
            string combinedName = firstName + " " + lastName;
            string city = String.Empty;
            if (personInfo.Length == 3)
            {
                 city = personInfo[2];
            }
            else
            {
                string city1 = personInfo[2];
                string city2 = personInfo[3];
                city = city1 + " " + city2;
            }

            

            string[] personAndBeer =Console.ReadLine().Split(' ');
            string name = personAndBeer[0];
            double beerLiters = double.Parse(personAndBeer[1]);

            string [] digits = Console.ReadLine().Split(" ");
            int intNum = int.Parse(digits[0]);
            double doubleNum = double.Parse(digits[1]);

            Tuple<string, string> firstPerson = new Tuple<string, string>(combinedName, city);
            

            Tuple<string, double> beerPerson = new Tuple<string, double>(name, beerLiters);

            Tuple<int,double> nums = new Tuple<int,double>(intNum, doubleNum);

            Console.WriteLine(firstPerson);
            Console.WriteLine(beerPerson);
            Console.WriteLine(nums);
        }
    }
}
