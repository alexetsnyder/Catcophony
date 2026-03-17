using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.data.enums;

namespace Quasar.core.goap.goals
{
    public partial class HaulWorkGoal : GoalBase
    {
        public HaulWorkGoal()
        {
            _key = new("HaulWork");
            _value = true;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetWorkList(new(WorkType.HAULING.ToString()), out var workList))
            {
                if (workList.Count > 0)
                {
                    blackboard.Set(Constants.Names.CurrentWorkType, (int)WorkType.HAULING);

                    return true;
                }
            }

            return false;
        }
    }
}