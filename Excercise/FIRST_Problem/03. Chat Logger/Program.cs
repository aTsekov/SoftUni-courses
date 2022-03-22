using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Chat_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chat = new List<string>();
            
             
            string command = Console.ReadLine();
            string[] token = command.Split(" ");
            string message4 = string.Empty;






            while (command != "end")
            {
                if (token[0] == "Chat")
                {
                   
                    string message = token[1];
                    
                    chat.Add(message);
                    

                }
                else if (token[0] == "Delete")
                {
                    string message = token[1];
                    if (chat.Contains(message))
                    {
                        chat.Remove(message);
                        

                    }

                }
                else if (token[0] == "Edit")
                {
                    string message = token[1];
                    string edditedMessage = token[2];

                    if (chat.Contains(message))
                    {
                        int index = chat.IndexOf(message);
                        chat.Remove(message);
                        chat.Insert(index, edditedMessage);
                    }
                    else
                    {
                        
                        chat.Add(edditedMessage);
                    }
                        
                    
                                               

                    


                }
                else if (token[0] == "Pin")
                {
                    string message = token[1];
                    if (chat.Contains(message))
                    {

                        int index = chat.IndexOf(message);
                        chat.RemoveAt(index);
                        chat.Add(message);
                        
                    }



                }
                else if (token[0] == "Spam")
                {
                    string message1 = token[1];
                    string message2 = token[2];
                    string message3 = token[3];
                    if (token.Length >=5)
                    {
                        message4 = token[4];
                    }
                    
                    chat.Add(message1);
                    chat.Add(message2);
                    chat.Add(message3);
                    if (token.Length >= 5)
                    {
                        chat.Add(message4);
                    }
                    
                    

                }
                command = Console.ReadLine();

                token = command.Split(" ");
            }
            Console.WriteLine(string.Join("\n", chat));
        }

    }
}
