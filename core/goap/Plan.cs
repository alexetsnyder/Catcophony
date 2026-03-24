using Catcophony.core.blackboard;
using Catcophony.core.goap.interfaces;
using System.Collections.Generic;

namespace Catcophony.core.goap
{
    public partial class Plan(Queue<IAction> actions)
    {
        public Queue<IAction> Actions { get; set; } = actions;
    }
}