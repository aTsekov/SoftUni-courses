using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection
    {
        private readonly Dictionary<string, Header> headers; // We will keep headers as a dictionary with the header name as a key and the header itself as a value, so that we can our searching in the headers is easier.

        public HeaderCollection() => this.headers = new Dictionary<string, Header>();
        public int Count => this.headers.Count;

        public void Add(string name, string value)
        {
            var header = new Header(name, value); //Create a new Header and add it to the dictionary.
            this.headers.Add(name, header);
        }
    }
}
