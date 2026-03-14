using Quasar.core.blackboard;
using Quasar.core.goap.actions;
using Quasar.core.goap.interfaces;
using Quasar.core.naming;
using Quasar.data.enums;
using Quasar.scenes.common.interfaces;

namespace Quasar.core.goap.goals
{
    public partial class MineWorkGoal(WorkType workType, IWorkSystem workSystem) : IGoal
    {
        public FastName Key => _key;

        public bool Value => _value;

        private readonly FastName _key = MineAction.Name;

        private readonly bool _value = true;

        private readonly WorkType _workType = workType;

        private readonly IWorkSystem _workSystem = workSystem;

        public bool Satisify(IGoal goal)
        {
            return (Key == goal.Key && Value == goal.Value);
        }

        public bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetWorkList(new(_workType.ToString()), out var workList))
            {
                return workList.Count > 0;
            }
            
            return false;
        }
    }
}