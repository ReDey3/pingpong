using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Common
{
    public interface INetWorkWrapper
    {
        // Will wrap the most common function of socket and tcp client so we can use it generically
        public Socket Accept();
        public void Send(byte[] dataToSend);
        public int Receive(byte[] dataToReceive);
        public void Bind(IPEndPoint localEndpoint);
        public void Listen(int backlog);
    }
}
