using System;

namespace L04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string [] rawInput = Console.ReadLine().Split(' '); // четем от конзолата  и със split му казваме каква да е разделителната линия.Това май важи само за стрингове? 

            //for (int i = rawInput.Length - 1; i >= 0; i--) // обръщаме масива на обратно. 
            //{
            //    Console.Write(rawInput[i] + " ");
            //}

            Array.Reverse(rawInput); // тези два реда, също обръщата масива, вместо да ползваме цикъл. 
            Console.WriteLine(string.Join("^",rawInput)); // с този метод свързваме стойностите на масива и определаме какъв разделител да има между тях. В случая, разтояние. 

        }
    }
}
