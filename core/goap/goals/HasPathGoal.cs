using Quasar.core.blackboard;
using Quasar.core.common;
using Quasar.core.goap.interfaces;
using Quasar.core.naming;
using Quasar.data.enums;
using Quasar.scenes.common.interfaces;
using Quasar.scenes.systems.pathing;
using System.Linq;

namespace Quasar.core.goap.goals
{
    public partial class HasPathGoal(WorkType workType, IWorkSystem workSystem, IPathingSystem pathingSystem) : IGoal
    {
        public FastName Key => _key;

        public bool Value => _value;

        private readonly FastName _key = new("HasPath");

        private readonly bool _value = true;

        private readonly WorkType _workType = workType;

        private readonly IWorkSystem _workSystem = workSystem;

        private readonly IPathingSystem _pathingSystem = pathingSystem;

        private Path _path;

        public bool Satisify(IGoal goal)
        {
            return (Key == goal.Key && Value == goal.Value);
        }

        public bool Satisify(Blackboard blackboard)
        {
            if (blackboard.TryGetVector2(Constants.Names.Position, out var agentPos))
            {
                var workList = _workSystem.CheckForWork(_workType);
                if (workList.Count > 0)
                {
                    foreach (var adjPos in workList.SelectMany(w => w.AdjPos ?? []))
                    {
                        if (agentPos.IsEqualApprox(adjPos))
                        {
                            _path = _pathingSystem.CreateEmptyPath();
                            return true;
                        }

                        _path = _pathingSystem.FindPath(agentPos, adjPos);
                        if (_path != null)
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