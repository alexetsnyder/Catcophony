using Catcophony.core.blackboard;
using Catcophony.core.goap.interfaces;
using Catcophony.core.naming;

namespace Catcophony.core.goap.goals
{
    public partial class HasItemGoal : GoalBase
    {
        public HasItemGoal(IAction parent) 
        {
            _key = new("HasItem");
            _value = true;

            _parentAction = parent;
        }

        public override bool Satisify(WorldState worldState, Blackboard<FastName> blackboard)
        {
            var worldStateBlackboard = worldState.GetBlackboard();

            if (worldStateBlackboard.TryGetItem(Constants.Names.AgentItem, out var item))
            {
                if (item != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}