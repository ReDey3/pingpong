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
            byte[] bytes = new byte[1024];
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1337);

            // Create a TCP/IP  socket.
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

                
            sender.Connect(remoteEP);

            Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

            int? bytesSent = null;
            int bytesRec = 0;
            byte[] msg = null;
            string userInput = "";

            while (true)
            {
                Console.Write("Enter input");
                userInput = Console.ReadLine();
                msg = Encoding.ASCII.GetBytes(userInput);
                bytesSent = sender.Send(msg);
                bytesRec = sender.Receive(bytes);
                Console.WriteLine("Server Response = {0}",Encoding.ASCII.GetString(bytes, 0, bytesRec));
            }
            
        }

    }
}