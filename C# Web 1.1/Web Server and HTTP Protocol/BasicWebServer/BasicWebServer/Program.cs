using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1"); //This is our local IP address
            var port = 8080; // on this port the server will be opened

            var serverListener = new TcpListener(ipAddress, port);// This listener is listening to an incoming connection on the specified IP and port.

            serverListener.Start(); // Start listening...

            

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");

            while (true) //We make infinite loop so the server can be reached multiple times, but for some reason once the connection is closed
            //the server stops listening. 
            {
                var connection = serverListener.AcceptTcpClient(); //This accepts a pending connection request

                var networkStream = connection.GetStream(); //create the stream that is used to send and receive data.

                var content = "Hello from the server!"; // this is our content and it will be visualized on the browser. 
                var contentLength = Encoding.UTF8.GetByteCount(content); //the length of the string but in bytes. 

                var response = $@"HTTP/1.1 200 OK 
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}"; // this is our HTTP response.A start-line describing the requests to be implemented, or its status of whether successful or a failure. This start-line is always a single line.An optional set of HTTP headers specifying the request, or describing the body included in the message.The request target, usually a URL. This would be Host: localgost: 8080.
                //A blank line indicating all meta-information for the request has been sent.
                //An optional body containing data associated with the request (like content of an HTML form), or the document associated with a response. The presence of the body and its size is specified by the start-line and HTTP headers.
                //The Content-Type specifies the type of the content that will be send. E.g. plain text as is our case now. But it can be also many different media types such as application/pdf, or text/html, or video/mp4 depending on what we are sending. 


                var responseBytes = Encoding.UTF8.GetBytes(response); // transform the whole response in to bytes so it can be sent via the stream. 

                networkStream.Write(responseBytes); //write the bytes into the stream. 

                //connection.Close();
            }


        }
    }
}