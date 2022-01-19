using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace BLL.Actions.Abstractions
{
    public interface IAction<T>
    {
        public void RunAction(Socket handler, T input);
    }
}
