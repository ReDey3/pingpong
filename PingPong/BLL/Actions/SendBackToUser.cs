using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common.Converters.Abstractions;
using Common.Converters;

namespace BLL.Actions
{
    public class SendBackToUser : Abstractions.IAction<string>
    {
        private 
        public void RunAction(Socket handler, string input)
        {
            handler.Send(Encoding.ASCII.GetBytes(input));
        }
    }
}
