using Catcophony.core.blackboard;
using Catcophony.core.goap.interfaces;
using Catcophony.core.naming;

namespace Catcophony.core.goap.goals
{
    public partial class FalseAdjToGoal : GoalBase
    {
        public FalseAdjToGoal(IAction parent)
        {
            _key = new("AdjTo");
            _value = true;

            _parentAction = parent;
        }

        public override bool Satisify(WorldState worldState, Blackboard<FastName> blackboard)
        {
            return false;
        }
    }
}