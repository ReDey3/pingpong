using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Net;
using System.Net.Sockets;

namespace BLL.NetWorkers
{
    public class SocketWorker : INetWorkWrapper
    {
        private Socket _socket;

        public SocketWorker(IPAddress ipAddress)
        {
            _socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public Socket Accept()
        {
            return _socket.Accept();
        }

        public void Bind(EndPoint localEndpoint)
        {
            _socket.Bind(localEndpoint);
        }

        public void Listen(int backlog)
        {
            _socket.Listen(100);
        }

        public int Receive(byte[] dataToReceive)
        {
            return _socket.Receive(dataToReceive);
        }

        public void Send(byte[] dataToSend)
        {
            _socket.Send(dataToSend);
        }
    }
}
