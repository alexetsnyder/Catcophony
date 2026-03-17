using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.data.enums;

namespace Quasar.core.goap.goals
{
    public partial class BuildWorkGoal : GoalBase
    {
        public BuildWorkGoal()
        {
            _key = new("BuildWork");
            _value = true;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetWorkList(new(WorkType.BUILDING.ToString()), out var workList))
            {
                if (workList.Count > 0)
                {
                    blackboard.Set(Constants.Names.CurrentWorkType, (int)WorkType.BUILDING);

                    return true;
                }
            }

            return false;
        }
    }
}