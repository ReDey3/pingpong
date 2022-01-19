using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common.Converters;
using Common.Converters.Abstractions;
using Common.RequestFormatters;
using Common.RequestFormatters.Abstractions;

namespace BLL
{
    public class UserInputCatcher<T>
    {
        private IBytesConverter<T> _converter;
        private IRequestFormatter<T> _requestFormatter;
        private ActionRunner<T> _actionRunner;

        public UserInputCatcher(IBytesConverter<T> converter, IRequestFormatter<T> requestFormatter, ActionRunner<T> actionRunner)
        {
            _converter = converter;
            _requestFormatter = requestFormatter;
            _actionRunner = actionRunner;
        }

        public void GetUserInput(Socket handler)
        {
            string data = null;
            byte[] bytes = new byte[1024];
            try
            {
                int bytesRec = handler.Receive(bytes);
                T convertedUserInput = _converter.Convert(bytes, bytesRec);

                IDictionary<string, string> parsedInput = _requestFormatter.FormatRequest(convertedUserInput);
                _actionRunner.RunAction(handler, parsedInput);
            }
            catch (Exception e)
            {
            } 
        }
    }
}
