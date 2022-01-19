using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Common.Converters;
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
        public IBytesConverter<string> _converter;
        public IRequestFormatter<string> _requestFormatter;
        public ActionRunner<string> _actionRunner;


        public Bootstrapper()
        {
            _converter = new BytesToStringConverter();
            _requestFormatter = new BasicFormatter();
            _actionRunner = new ActionRunner<string>(new Dictionary<string, IAction> { { "SendBackToUser", new SendBackToUser() } });

            UserInputCatcher = new UserInputCatcher<string>(_converter, _requestFormatter, _actionRunner);
            UserCatcher = new UserCatcher(new UserHandler(UserInputCatcher));
        }

    }
}
