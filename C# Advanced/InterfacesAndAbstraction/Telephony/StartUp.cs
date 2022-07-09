using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string [] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string [] URLs = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Smartphone smartphone = new Smartphone();
            Stationary st = new Stationary();
            foreach (var num in numbers)
            {
                if (num.Length == 7)
                {
                    st.Calling(num);
                }
                else if (num.Length == 10)
                {
                    smartphone.Calling(num);
                }
            }
            
                smartphone.Browsing(URLs);
            
        }
    }
}
