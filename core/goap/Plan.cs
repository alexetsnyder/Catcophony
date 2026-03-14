using Quasar.core.blackboard;
using Quasar.core.goap.interfaces;
using System.Collections.Generic;

namespace Quasar.core.goap
{
    public partial class Plan(Blackboard blackboard, Queue<IAction> actions)
    {
        public Blackboard Blackboard { get; set; } = blackboard;

        public Queue<IAction> Actions { get; set; } = actions;
    }
}