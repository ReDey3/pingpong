using BLL.Actions.Abstractions;
using System.Net.Sockets;

namespace BLL
{
    public class ActionRunner<T>
    {
        private IDictionary<string, IAction> _actionsToRun;
        public ActionRunner(IDictionary<string, IAction> actionsToRun)
        {
            _actionsToRun = actionsToRun;
        }

        public void RunAction(Socket handler,IDictionary<string,T> actionToRun)
        {
            if (_actionsToRun.Keys.Contains(actionToRun.Keys.First())) 
            {
                _actionsToRun[actionToRun.Keys.First()].RunAction(handler, actionToRun.Values.First().ToString());
            }
        }
    }
}
