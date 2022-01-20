using System.Net.Sockets;

namespace BLL.Actions.Abstractions
{
    public interface IAction
    {
        public void RunAction(Socket handler, string input);
    }
}
