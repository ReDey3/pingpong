using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace PingPong
{
    class Program 
    {
        static void Main(string[] args)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1337);

            try
            {
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(localEndPoint);
                listener.Listen(100);
                Console.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();
                Console.WriteLine("User logged");
                string data = null;
                byte[] bytes = null;
                
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                   
                    Console.WriteLine("Text received : {0}", data);
                    data = ""; 
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}