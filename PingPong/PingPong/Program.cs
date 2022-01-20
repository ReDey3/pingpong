using System;
using System.Text;
using BLL.NetWorkers;
using BLL;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using Common;

namespace PingPong
{
    class Program 
    {
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
            IPAddress ipAddress = host.AddressList[0];
            int port;
            
            if (!int.TryParse(args[0], out port))
            {
                port = 1337;
            }
            Console.WriteLine(port);
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            INetWorkWrapper listener = new SocketWorker(ipAddress);
            //Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(100);
            bootstrapper.UserCatcher.WaitForNewUsers(listener);
        }
    }
}