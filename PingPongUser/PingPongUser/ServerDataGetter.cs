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
        private IInput<string> _ipInput;
        private IInput<string> _numberInput;
        private IOutput<string> _output;

        public ServerDataGetter(IInput<string> ipInput, IInput<string> numberInput, IOutput<string> output)
        {
            _numberInput = numberInput;
            _ipInput = ipInput;
            _output = output;
        }

        public IDictionary<string, string> AskForServerData()
        {
            _output.Output("Enter ip");
            var ip = _ipInput.GetInput();
            _output.Output("Enter port");
            var port = _numberInput.GetInput();
            return new Dictionary<string, string> { {"ip", ip}, {"port", port } };
        }
    }
}
