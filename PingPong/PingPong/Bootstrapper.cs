using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Common.Converters;
using Common.IO.Abstractions;
using Common.IO.Output;
using Common;
using Common.RequestFormatters;
using Common.Converters.Abstractions;
using Common.RequestFormatters.Abstractions;
using BLL.Actions.Abstractions;
using BLL.Actions;

namespace PingPong
{
    public class Bootstrapper
    {

        public UserCatcher UserCatcher;
        public UserInputCatcher<object> UserInputCatcher;
        public IBytesConverter<object> ToPersonConverter;
        public IStringConverter<byte[]> ToBytesConverter;
        public IRequestFormatter<object> RequestFormatter;
        public ActionRunner<object> ActionRunner;
        public IOutput<string> ConsoleOutput;

        public Bootstrapper()
        {
            ToPersonConverter = new BytesToObject();
            ToBytesConverter = new StringToBytes();
            RequestFormatter = new BasicFormatter();
            ConsoleOutput = new ConsoleOutput();
            ActionRunner = new ActionRunner<object>(new Dictionary<string, IAction> { { "SendBackToUser", new SendBackToUser(ToBytesConverter) } });
            
            UserInputCatcher = new UserInputCatcher<object>(ToPersonConverter, RequestFormatter, ActionRunner);
            UserCatcher = new UserCatcher(new UserHandler(UserInputCatcher, ConsoleOutput), ConsoleOutput);
        }

    }
}
