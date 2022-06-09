using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList mylist = new RandomList();

            mylist.Add("Gosho");
            mylist.Add("Pesho");
            mylist.Add("Maria");
            mylist.Add("Ganka");
            mylist.RandomString();
        }
    }
}
