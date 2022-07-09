using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browsing(string [] URL)
        {
            bool isValid = false;
            foreach (var url in URL)
            {
                foreach (var item in url)
                {
                    if (char.IsDigit(item))
                    {

                        isValid = false;
                        break;
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                if (isValid)
                {
                    Console.WriteLine($"Browsing: {url}!");
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
                
                
            }
            
        }

        public void Calling(string phoneNum)
        {
            bool isValid = false;
            foreach (var ch in phoneNum)
            {
                if (!char.IsDigit(ch))
                {
                    isValid = false;
                    break;
                }
                else
                {
                    isValid = true;
                }
                
                
            }
            if (!isValid)
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {phoneNum}");
            }
        }

       
    }
}
