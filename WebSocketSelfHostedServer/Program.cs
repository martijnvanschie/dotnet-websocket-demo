using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8181);

            server.Start();
            Console.WriteLine("Server has started on 127.0.0.1:80.{0}Waiting for a connection...", Environment.NewLine);

            TcpClient client = server.AcceptTcpClient();

            Console.WriteLine("A client connected.");

            NetworkStream stream = client.GetStream();

            while (true)
            {
                while (!stream.DataAvailable);
                while (client.Available < 3) ;

                byte[] bytes = new byte[client.Available];
                stream.Read(bytes, 0, client.Available);
                string s = Encoding.UTF8.GetString(bytes);
                Console.WriteLine(s);
            }
        }
    }
}
