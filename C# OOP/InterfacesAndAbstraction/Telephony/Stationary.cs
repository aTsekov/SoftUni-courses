using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Stationary : ICallable
    {
        public void Calling(string phoneNum)
        {
            Console.WriteLine($"Dialing... {phoneNum}");
        }
    }
}
