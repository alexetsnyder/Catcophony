using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.data.enums;

namespace Quasar.core.goap.goals
{
    public partial class MineWorkGoal : GoalBase
    {
        public MineWorkGoal()
        {
            _key = new("MineWork");
            _value = true;
        }

        public override bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetWorkList(new(WorkType.MINING.ToString()), out var workList))
            {
                if (workList.Count > 0)
                {
                    blackboard.Set(Constants.Names.SelectedWorkType, (int)WorkType.MINING);

                    return true;
                }
                return workList.Count > 0;
            }
            
            return false;
        }
    }
}