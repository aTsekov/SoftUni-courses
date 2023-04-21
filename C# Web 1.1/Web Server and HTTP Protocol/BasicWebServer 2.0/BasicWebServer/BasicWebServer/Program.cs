using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BasicWebServer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ipAddress = IPAddress.Parse("127.0.0.1"); //Instance of our local IP address
            var port = 8080; //port, on which our console app will work.

            //next we need to make the browser "listens to our console app. This happens with the help of the TcpListener class

            var serverListener = new TcpListener(ipAddress, port);
            serverListener.Start();

            //we need to make our server wait for the browser to connect to it.
            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine($"Listening for requests...");

            while (true)// Use the infinite loop so we can have multiple requests. 
            {
                var connection = serverListener.AcceptTcpClient();

                //Now when we have the connection we need to open a stream to the browser so we can visualize something.

                var networkStream = connection.GetStream();

                var content = "Hello from the server!";
                var contentLength = Encoding.UTF8.GetByteCount(content);

                //1. The first line of the response contains the HTTP version and the status code. 
                //2. On each new line is the headers - in this case the text type nad the text length, but there could be many variations. 
                //3. This is the body - which is the actual content. 
                var response = $@"HTTP/1.1 200 OK 
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";


                //Transform the response in to bytes and this can be used with the networks stream. 
                var responseBytes = Encoding.UTF8.GetBytes(response);

                networkStream.Write(responseBytes); // This line actually transfers/sends/writes our response to the browser.

                connection.Close();
            }

        }
    }
}