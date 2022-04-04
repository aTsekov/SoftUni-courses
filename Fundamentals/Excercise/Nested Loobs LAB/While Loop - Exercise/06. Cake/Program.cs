using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int wide = int.Parse(Console.ReadLine());
            int lenght = int.Parse(Console.ReadLine());
            int pieces = wide * lenght;
            string takenPieces = "";
            int piecesNum = 0;
            int piecesCounter = 0;

            while (pieces > 0)
            {
               takenPieces = Console.ReadLine();
                if (takenPieces == "STOP")
                {
                    break;
                }
               piecesNum = int.Parse(takenPieces);
               piecesCounter += piecesNum;

                if (pieces <piecesCounter)
                {
                    Console.WriteLine($"No more cake left! You need {piecesCounter - pieces} pieces more.");
                    break;
                }
               
                
            }

            if (takenPieces == "STOP")
            {
                Console.WriteLine($"{pieces - piecesCounter} pieces are left.");
            }


        }
    }
}
