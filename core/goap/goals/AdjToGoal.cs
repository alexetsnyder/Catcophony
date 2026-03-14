using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.core.goap.interfaces;
using Quasar.core.naming;
using Quasar.data.enums;
using Quasar.scenes.common.interfaces;
using System.Linq;

namespace Quasar.core.goap.goals
{
    public partial class AdjToGoal(WorkType workType = WorkType.NONE, IWorkSystem workSystem = null) : IGoal
    {
        public FastName Key => _key;

        public bool Value => _value;

        private readonly FastName _key = new("AdjTo");

        private readonly bool _value = true;

        private readonly WorkType _workType = workType;

        private readonly IWorkSystem _workSystem = workSystem;

        public bool Satisify(IGoal goal)
        {
            return (Key == goal.Key && Value == goal.Value);
        }

        public bool Satisify(Blackboard blackboard)
        {
            if (_workType == WorkType.NONE || _workSystem == null)
            {
                return false;
            }

            if (blackboard.TryGetVector2(Constants.Names.Position, out var agentPos))
            {
                var workList = _workSystem.CheckForWork(_workType);
                if (workList.Count > 0)
                {
                    foreach (var adjPos in workList.SelectMany(w => w.AdjPos ?? []))
                    {
                        if (adjPos.IsEqualApprox(agentPos))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}