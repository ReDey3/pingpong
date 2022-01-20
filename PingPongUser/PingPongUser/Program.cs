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
            Console.WriteLine(serverData["ip"]);
            Console.WriteLine(serverData["port"]);
            IPHostEntry host = Dns.GetHostEntry(serverData["ip"]);
            IPAddress ipAddress = host.AddressList[0];
            
            int port;
            int.TryParse(serverData["port"], out port);

            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP  socket.
            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
                
            sender.Connect(remoteEP);
            
            int? bytesSent = null;
            int bytesRec = 0;
            byte[] msg = null;
            string userInput = "";

            while (true)
            {
                bootsrapper.Output.Output("Enter input");
                userInput = bootsrapper.StringInput.GetInput();
                
                msg = Encoding.ASCII.GetBytes(userInput);
                bytesSent = sender.Send(msg);
                bytesRec = sender.Receive(bytes);

                bootsrapper.Output.Output($"Server Response = {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");
            }
            
        }

    }
}