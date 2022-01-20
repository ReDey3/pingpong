using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Common.Converters;
using Common.IO.Abstractions;
using Common.IO.Output;
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
        public UserInputCatcher<string> UserInputCatcher;
        public IBytesConverter<string> ToStringConverter;
        public IStringConverter<byte[]> ToBytesConverter;
        public IRequestFormatter<string> RequestFormatter;
        public ActionRunner<string> ActionRunner;
        public IOutput<string> ConsoleOutput;

        public Bootstrapper()
        {
            ToStringConverter = new BytesToStringConverter();
            ToBytesConverter = new StringToBytes();
            RequestFormatter = new BasicFormatter();
            ConsoleOutput = new ConsoleOutput();
            ActionRunner = new ActionRunner<string>(new Dictionary<string, IAction> { { "SendBackToUser", new SendBackToUser(ToBytesConverter) } });

            UserInputCatcher = new UserInputCatcher<string>(ToStringConverter, RequestFormatter, ActionRunner);
            UserCatcher = new UserCatcher(new UserHandler(UserInputCatcher, ConsoleOutput), ConsoleOutput);
        }

    }
}
