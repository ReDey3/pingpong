using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.IO.Input;
using Common.IO.Output;
using Common.IO.Abstractions;

namespace PingPongUser
{
    public class ServerDataGetter
    {
        private IInput<string> _input;
        private IOutput<string> _output;

        public ServerDataGetter(IInput<string> input, IOutput<string> output)
        {
            _input = input;
            _output = output;
        }

        public IDictionary<string, string> AskForServerData()
        {
            _output.Output("Enter ip");
            var ip = _input.GetInput();
            _output.Output("Enter port");
            var port = _input.GetInput();
            return new Dictionary<string, string> { {"ip", ip}, {"port", port } };
        }
    }
}
