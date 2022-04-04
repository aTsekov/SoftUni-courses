using System;
using System.Linq;

namespace E02._The_Lift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int waitingPeopleToGetLift =  int.Parse(Console.ReadLine());
            int [] liftArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();
            int peopleAlreadyInLift = 0;
            int capacity = 0;

            for (int i = 0; i < liftArr.Length; i++) // в случай че в асансьора вече има хора, трябва да ги махнем от общия капацитет.
            {
                peopleAlreadyInLift += liftArr[i];
                capacity = (liftArr.Length * 4) - peopleAlreadyInLift;
            }
            if (capacity >= waitingPeopleToGetLift) // ако имаме свободно място в асансьора.
            {
                EmptySpots( capacity,  waitingPeopleToGetLift, liftArr);
            }
            else if (capacity < waitingPeopleToGetLift)
            {
                NoSpots(capacity, waitingPeopleToGetLift, liftArr);
            }           

        }
        static void EmptySpots (int capacity, int waitingPeopleToGetLift, int[] liftArr)
        {
            int index = 0;

            for (int i = 1;i <= 4 ; i++)
            {
                
                if (index <= 4)
                {
                    liftArr[index] = i;
                    if (i == 4)
                    {
                        index++;
                        i = 0;
                    }
                }

                waitingPeopleToGetLift--;
                capacity --;
                if (waitingPeopleToGetLift <=0)
                {
                    if (capacity > waitingPeopleToGetLift)
                    {
                        Console.WriteLine("The lift has empty spots!");
                        Console.WriteLine(String.Join(' ', liftArr));
                        break;
                    }
                    else if (capacity == waitingPeopleToGetLift)
                    {
                        Console.WriteLine(String.Join(' ', liftArr));
                        break ;
                    }
                    

                }
                
                


            }

        }
        static void NoSpots(int capacity, int waitingPeopleToGetLift, int[] liftArr)
        {
            int index = 0;

            for (int i = 0; i < liftArr.Length; i++)
            {


                for (int j = liftArr[i]; j < 4; j++)
                {
                    liftArr[i] += 1;
                    waitingPeopleToGetLift--;

                }                              

            }
            if (waitingPeopleToGetLift >= capacity)
            {
                Console.WriteLine($"There isn't enough space! {waitingPeopleToGetLift} people in a queue!");
                Console.WriteLine($"{(String.Join(' ', liftArr))}");
            }
        }
    }
}
