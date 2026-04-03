using Catcophony.core.blackboard;
using Catcophony.core.goap.interfaces;
using Catcophony.core.naming;
using Catcophony.scenes.common.interfaces;

namespace Catcophony.core.goap.goals
{
    public partial class AdjToWaterGoal : GoalBase
    {
        private readonly IWorld _world;

        public AdjToWaterGoal(IAction parentAction, IWorld world)
        {
            _key = new("AdjToWater");
            _value = true;

            _parentAction = parentAction;
            _world = world;
        }

        public override bool Satisify(WorldState worldState, Blackboard<FastName> blackboard)
        {
            var worldStateBlackboard = worldState.GetBlackboard();

            if (worldStateBlackboard.TryGetVector2(Constants.Names.AgentPos, out var agentPos))
            {
                //Find Nearest water 
                //Are we adj to it.
            }

            return false;
        }
    }
}