using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;

namespace BasicWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Response>> routes;
        public IRoutingTable Map(string url, Method method, Response response)
        {
            throw new NotImplementedException();
        }

        public IRoutingTable MapGet(string url, Response response)
        {
            throw new NotImplementedException();
        }

        public IRoutingTable MapPost(string url, Response response)
        {
            throw new NotImplementedException();
        }
    }
}
