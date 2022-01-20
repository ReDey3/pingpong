using System.Net.Sockets;
using Common.Converters.Abstractions;

namespace BLL.Actions
{
    public class SendBackToUser : Abstractions.IAction
    {
        private IStringConverter<byte[]> _converter;

        public SendBackToUser(IStringConverter<byte[]> converter)
        {
            _converter = converter;
        }

        public void RunAction(Socket handler, string input)
        {
            handler.Send(_converter.Convert(input));
        }
    }
}
