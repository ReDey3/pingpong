using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Actions.Abstractions;
using System.Net.Sockets;
using Common;

namespace BLL
{
    public class ActionRunner<T>
    {
        private IDictionary<string, IAction> _actionsToRun;
        public ActionRunner(IDictionary<string, IAction> actionsToRun)
        {
            _actionsToRun = actionsToRun;
        }

        public void RunAction(Socket handler,IDictionary<string,string> actionToRun)
        {
            if (_actionsToRun.Keys.Contains(actionToRun.Keys.First())) 
            {
                _actionsToRun[actionToRun.Keys.First()].RunAction(handler, actionToRun.Values.First());
            }
        }
    }
}
