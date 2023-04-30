using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Responses
{
    public class Response
    {
        //This class is the whole response that includes the status code the headers and the body of the message. 
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;

            this.Headers.Add(Header.Server, "My Web Server"); // add default headers to our response. 
            this.Headers.Add(Header.Date, $"{DateTime.UtcNow}");
        }
        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; } = new HeaderCollection();

        public string Body { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1  {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
                
            }

            result.AppendLine();

            if (Equals(!string.IsNullOrEmpty(this.Body)))
            {
                result.Append(this.Body);
            }
            return result.ToString();
        }
    }


}
