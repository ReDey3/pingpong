using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using PingPongUser;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];
            Bootstrapper bootsrapper = new Bootstrapper();
            IDictionary<string,string> serverData = bootsrapper.ServerData.AskForServerData();
            if ()
            {
                IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1337);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);


                sender.Connect(remoteEP);

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
                    Console.WriteLine("Server Response = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));
                }
            } 
        }

    }
}