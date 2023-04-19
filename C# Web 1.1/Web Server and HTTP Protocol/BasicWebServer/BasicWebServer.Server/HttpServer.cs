using BasicWebServer.Server.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server
{


    public class HttpServer
    {
        private readonly IPAddress ipAddress;

        private readonly int port;

        private readonly TcpListener serverListener;

        private readonly RoutingTable rountingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;
            this.serverListener = new TcpListener(this.ipAddress, port);

            routingTableConfiguration(this.rountingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable) : this("127.0.0.1", port, routingTable)
        {

        }

        public HttpServer(Action<IRoutingTable> routingTable) : this(8080,routingTable)
        {
            
        }


        public void Start()
        {
            this.serverListener.Start();


            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");

            while
                (true) //We make infinite loop so the server can be reached multiple times, but for some reason once the connection is closed
                //the server stops listening. 
            {
                var connection = serverListener.AcceptTcpClient(); //This accepts a pending connection request

                var networkStream = connection.GetStream(); //create the stream that is used to send and receive data.

                var requestText = this.ReadRequest(networkStream);
                Console.WriteLine(requestText);
                var request = Request.Parse(requestText);
                var response = this.rountingTable.MatchRequest(request);

                WriteResponse(networkStream, response);

                connection.Close();
            }
        }

        private void WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes =
                Encoding.UTF8
                    .GetBytes(response.ToString()); 

            networkStream.Write(responseBytes); 


        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;

            var buffer = new byte[bufferLength];
            var totalBytes = 0;
            var requestBuilder = new StringBuilder();

            do
            {
                var byteRead = networkStream.Read(buffer, 0, bufferLength);
                totalBytes += byteRead;
                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, byteRead));
            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}