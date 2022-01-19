using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Actions.Abstractions;

namespace BLL
{
    public class ActionRunner<T>
    {
        private IDictionary<string, IAction> _actionsToRun;
        public ActionRunner(IDictionary<string, IAction> actionsToRun)
        {
            _actionsToRun = actionsToRun;
        }

        public void RunAction(IDictionary<string,string> actionToRun)
        {
            _actionsToRun[actionToRun.Keys.First()].RunAction();
        }
    }
}
