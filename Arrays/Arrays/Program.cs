using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            var primes = new bool[n + 1]; // Когато имаме булев масив, всичките му стойности за false  по дефиниция. 

            for (int i = 2; i <= n ; i++)
            {
                primes[i] = true; // тъй като i = 2 всички стойности преди 2 (0 и 1)са false и си остават такива. На този ред правим вс стойности true от 2 нагоре.

            }
            for (int num = 2; num <= n; num++)
            {
                if (primes[num])
                {
                    Console.WriteLine(num); // до тук просто извъртаме числата от 2 до n. 

                    // TO DO: логиката, която ще намери всички прости числа. 
                    int p = num * 2;
                    while (p<=n)
                    {
                        primes[p] = false;
                        p = p + num;

                    }

                }
            }


        }
    }
}
