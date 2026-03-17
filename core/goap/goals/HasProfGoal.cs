using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.data.enums;

namespace Quasar.core.goap.goals
{
    public partial class HasProfGoal : GoalBase
    {
        public HasProfGoal()
        {
            _key = new("HasProf");
            _value = true;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetInt(Constants.Names.CurrentWorkType, out var selectedWorkTypeInt))
            {
                var selectedWorkType = (WorkType)selectedWorkTypeInt;

                if (blackboard.TryGetInt(Constants.Names.AgentWorkType, out var agentWorkTypeInt))
                {
                    var agentWorkType = (WorkType)agentWorkTypeInt;

                    if (agentWorkType == selectedWorkType)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}