using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.IO.Abstractions;
using Common.Converters.Abstractions;
using Common.Converters;
using Common.IO.Input;
using Common.IO.Output;

namespace PingPongUser
{
    public class Bootstrapper
    {
        public ServerDataGetter ServerData;
        public IInput<string> IpInput;
        public IInput<string> NumberInput;
        public IInput<string> StringInput;
        public IOutput<string> Output;
        public IObjectConverter<byte[]> Converter;
        public Factories.PersonFactory PersonFactory;


        public Bootstrapper()
        {
            Converter = new ObjectToBytes();
            Output = new ConsoleOutput();
            IpInput = new IpConsoleInput();
            NumberInput = new NumberConsoleInput();
            StringInput = new StringInput();
            ServerData = new ServerDataGetter(IpInput, NumberInput, Output);
            PersonFactory = new Factories.PersonFactory(StringInput, NumberInput, Output);
        }


    }
}
