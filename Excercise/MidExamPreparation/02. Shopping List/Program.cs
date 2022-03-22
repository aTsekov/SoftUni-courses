using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

            string comandArr = Console.ReadLine();
            string[] token = comandArr.Split(" ");
            bool flag = true;
            
            //string comand = token[0];
            

            while (comandArr != "Go Shopping!")
            {
                if (token[0] == "Urgent")
                {
                    string itemOne = token[1];
                    int index = 0;
                    if (!input.Contains(itemOne))
                    {
                        input.Insert(index, itemOne);
                    }
                    
                    

                }
                else if(token[0] == "Unnecessary")
                {
                    string itemOne = token[1];
                    if (input.Contains(itemOne))
                    {
                        input.Remove(itemOne);
                    }
                    

                }
                else if (token[0] == "Correct")
                {
                    string itemOne = token[1];
                    string itemTwo = token[2];
                    
                    if (input.Contains(itemOne))
                    {
                        int inxex = input.IndexOf(itemOne);
                        input.Insert(inxex, itemTwo);
                        input.Remove(itemOne);
                    }

                }
                else if (token[0] == "Rearrange")
                {
                    string itemOne = token[1];
                    if (input.Contains(itemOne))
                    {
                        
                        input.Add(itemOne);
                        input.Remove(itemOne);
                    }
                   
                }



                comandArr = Console.ReadLine();
                token = comandArr.Split(" ");

            }
            Console.WriteLine(string.Join(", ", input));

        }
    }
}
