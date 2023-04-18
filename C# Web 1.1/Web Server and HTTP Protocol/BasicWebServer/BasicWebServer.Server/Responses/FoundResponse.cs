using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class FoundResponse : Response
    {
        public FoundResponse(): base (StatusCode.NotFound)
        {
            
        }
    }
}
