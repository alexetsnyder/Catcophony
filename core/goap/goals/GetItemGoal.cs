using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.data.enums;

namespace Quasar.core.goap.goals
{
    public partial class GetItemGoal : GoalBase
    {
        public GetItemGoal()
        {
            _key = new("GetItemGoal");
            _value = true;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetWorkList(new(WorkType.GET_ITEM.ToString()), out var workList))
            {
                if (workList.Count > 0)
                {
                    blackboard.Set(Constants.Names.CurrentWorkType, (int)WorkType.GET_ITEM);

                    return true;
                }
            }

            return false;
        }
    }
}