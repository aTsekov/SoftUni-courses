using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.HTTP
{
    public class Response
    {
        //This class is the whole response that includes the status code the headers and the body of the message. 
        public Response(StatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add("Server", "My Web Server"); // add default headers to our response. 
            this.Headers.Add("Date", $"{DateTime.UtcNow}");
        }
        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; set; }

        public string Body { get; set; }
    }

    
}
