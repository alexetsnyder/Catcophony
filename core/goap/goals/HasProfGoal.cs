using Catcophony.core.blackboard;
using Catcophony.core.goap.interfaces;
using Catcophony.core.naming;
using Catcophony.data.enums;

namespace Catcophony.core.goap.goals
{
    public partial class HasProfGoal : GoalBase
    {
        public HasProfGoal(IAction parent) 
        {
            _key = new("HasProf");
            _value = true;

            _parentAction = parent;
        }

        public override bool Satisify(WorldState worldState, Blackboard<FastName> blackboard)
        {
            var worldStateBlackboard = worldState.GetBlackboard();

            if (blackboard.TryGetInt(Constants.Names.WorkType, out var workTypeInt))
            {
                var workType = (WorkType)workTypeInt;

                if (worldStateBlackboard.TryGetInt(Constants.Names.AgentProf, out var agentProfInt))
                {
                    var agentProf = (WorkType)agentProfInt;

                    if (agentProf == workType)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}