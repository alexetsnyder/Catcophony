using Quasar.core.blackboard;
using Quasar.core.naming;
using Quasar.data.enums;

namespace Quasar.core.goap.goals
{
    public partial class HasWorkGoal : GoalBase
    {
        private WorkType _workType;

        public HasWorkGoal(WorkType workType)
        {
            _key = new("HasWork");
            _value = true;

            _workType = workType;
        }

        public override bool Satisify(WorldState worldState, Blackboard<int> blackboard)
        {
            var worldStateBlackboard = worldState.GetBlackboard();
            FastName workTypeFastName = new(_workType.ToString());

            if (worldStateBlackboard.TryGetWorkList(workTypeFastName, out var workList))
            {
                if (workList.Count > 0)
                {
                    blackboard.Set(ActionId, (int)_workType  );

                    return true;
                }
            }

            return false;
        }
    }
}