using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server
{
    

    public class HttpServer
    {

        private readonly IPAddress ipAddress;// We would be providing an instrance of our IpAddress in the ctor
        private readonly int port; // We would be providing the port in the Ctor
        private readonly TcpListener serverListener; // we would use this TCP listener in the Ctor to give it the IpAddress and the Port


        public HttpServer(string ipAddress, int port)
        {
            this.ipAddress = IPAddress.Parse(ipAddress); //the field is = to the given value in the Ctor which will come from outside. 
            this.port = port;

            this.serverListener = new TcpListener(this.ipAddress, port);
        }

        public void Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine($"Listening for requests...");

            while (true)// Use the infinite loop so we can have multiple requests. 
            {
                var connection = serverListener.AcceptTcpClient();

                //Now when we have the connection we need to open a stream to the browser so we can visualize something.
                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);
                Console.WriteLine(requestText);

                // This method actually transfers/sends/writes our response to the browser.
                //WriteResponse(networkStream, "Hello from the Server!");

                connection.Close();
            }

            
        }

        private void WriteResponse(NetworkStream networkStream, string message)
        {
            while (true)// Use the infinite loop so we can have multiple requests. 
            {
                var connection = serverListener.AcceptTcpClient();

                //Get the length of the message in bytes so it can be transferred. 

                var contentLength = Encoding.UTF8.GetByteCount(message);

                //1. The first line of the response contains the HTTP version and the status code. 
                //2. On each new line is the headers - in this case the text type nad the text length, but there could be many variations. 
                //3. This is the body - which is the actual content. 
                var response = $@"HTTP/1.1 200 OK 
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{message}";


                //Transform the response in to bytes and this can be used with the networks stream. 
                var responseBytes = Encoding.UTF8.GetBytes(response);

                networkStream.Write(responseBytes); // This line actually transfers/sends/writes our response to the browser.

                connection.Close();
            }
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            } while (networkStream.DataAvailable);

           return requestBuilder.ToString();
        }
    }
}
