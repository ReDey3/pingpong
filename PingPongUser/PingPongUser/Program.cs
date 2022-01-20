using System.Text;
using System.Net;
using System.Net.Sockets;
using PingPongUser;
using Common;
using Common.RequestDTO;

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
            PersonRequestDTO personRequestDTO;

            int port;
            int.TryParse(serverData["port"], out port);

            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
            

            // Create a TCP/IP  socket.
            TcpClient sender = new TcpClient(ipAddress.AddressFamily);
            Person person = bootsrapper.PersonFactory.Create();
            
            sender.Connect(remoteEP);
            
            int? bytesSent = null;
            int bytesRec = 0;
            byte[] msg = null;
            string userInput = "";

            while (true)
            {
                bootsrapper.Output.Output("Enter input");
                userInput = bootsrapper.StringInput.GetInput();

                personRequestDTO = new PersonRequestDTO(person, userInput);
                
                bytesSent = sender.Client.Send(bootsrapper.Converter.Convert(personRequestDTO));
                bytesRec = sender.Client.Receive(bytes);

                bootsrapper.Output.Output($"Server Response = {Encoding.ASCII.GetString(bytes, 0, bytesRec)}");
            }
            
        }

    }
}