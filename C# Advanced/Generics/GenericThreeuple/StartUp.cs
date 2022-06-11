using System;

namespace GenericThreeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split(' ');

            string firstName = personInfo[0];
            string lastName = personInfo[1];
            string combinedName = firstName + " " + lastName;
            string street = personInfo[2];
            string city = string.Empty;
            if (personInfo.Length == 4)
            {
                city = personInfo[3];
            }
            else
            {
                string city1 = personInfo[3];
                string city2 = personInfo[4];
                city = city1 + " " + city2;
            }
            Threeuple<string,string,string> firstPerson = new Threeuple<string, string, string>(combinedName,street, city);

            string[] secondPersonInfo = Console.ReadLine().Split(' ');
            string name = secondPersonInfo[0];
            double beerLiters = double.Parse(secondPersonInfo[1]);
            string drunk = secondPersonInfo[2];
            bool Isdrunk = true;
            if (drunk == "drunk")
            {
                Isdrunk = true;
            }
            else
            {
                Isdrunk = false;
            }

            Threeuple<string, double, bool> secondPerson = new Threeuple<string, double, bool>(name, beerLiters, Isdrunk);

            string [] thirdPersonInfo = Console.ReadLine().Split(' ');
            string nameOfThird = thirdPersonInfo[0];
            double accountBalance = double.Parse(thirdPersonInfo[1]);
            string bankName = thirdPersonInfo[2];
            Threeuple <string,double,string> thirdPerson = new Threeuple<string, double, string>(nameOfThird,accountBalance, bankName);

            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdPerson);

        }
    }
}
