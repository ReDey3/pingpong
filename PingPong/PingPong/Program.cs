using System;
using System.Text;
using BLL;
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
            
            
            
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(100);
            userChatcher.WaitForNewUsers(listener);
        }
    }
}