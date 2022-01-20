using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.IO.Abstractions;
using Common.IO.Input;
using Common.IO.Output;

namespace PingPongUser
{
    public class Bootstrapper
    {
        public ServerDataGetter ServerData;
        public IInput<string> Input;
        public IOutput<string> Output;


        public Bootstrapper()
        {
            Output = new ConsoleOutput();
            Input = new StringInput();
            ServerData = new ServerDataGetter(Input, Output);
        }


    }
}
